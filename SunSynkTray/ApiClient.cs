﻿using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SunSynkTray
{
    internal class ApiClient
    {

        internal class ApiResponse
        {
            public int code { get; set; }
            public string msg { get; set; }
            public bool success { get; set; }
        }

        /// <summary>
        ///     An authentication request
        /// </summary>
        internal class AuthRequest
        {
            public string username { get; set; }
            public string password { get; set; }
            public string grant_type { get; set; } = "password";
            public string client_id { get; set; } = "csp-web";
            public string source { get; set; } = "sunsynk";
        }

        internal class AuthResponse : ApiResponse
        {
            public AuthResponseData data { get; set; }
        }

        internal class AuthResponseData
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public string refresh_token { get; set; }
            public int expires_in { get; set; }
            public string scope { get; set; }
        }

        internal class PlantsResponse : ApiResponse
        {
            public PlantsResponseData data { get; set; }
        }

        internal class PlantsResponseData
        {
            public int pageSize { get; set; }
            public int pageNumber { get; set; }
            public int total { get; set; }
            public PlantsReponseDataInfos[] infos { get; set; }
        }

        internal class PlantsReponseDataInfos
        {
            public int id { get; set; }
            public string name { get; set; }
            public DateTime updateAt { get; set; }

            // there are more fields, don't care about them

            public override string ToString()
            {
                return $"{id}: {name} (updated {Tools.TimeAgoFormat(updateAt)})";
            }
        }

        internal class EnergyFlowResponse : ApiResponse
        {
            public EnergyFlowResponseData data { get; set; }
        }

        internal class EnergyFlowResponseData
        {
            public int pvPower { get; set; }
            public int battPower { get; set; }
            public int gridOrMeterPower { get; set; }
            public int loadOrEpsPower { get; set; }
            public float soc { get; set; }

            // there are more fields, don't care about them
        }

        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = $"https://api.sunsynk.net";
        private string _lastError;
        private DateTime _expiresIn;
        private UserSettings settings;

        public ApiClient(UserSettings settings, bool debug = false)
        {

            if (debug)
            {
                WebProxy proxy = new WebProxy("http://localhost:8080");

                _httpClient = new HttpClient(new HttpClientHandler
                {
                    Proxy = proxy,
                    UseProxy = true,
                    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
                });
            }
            else
            {
                _httpClient = new HttpClient();
            }

            _httpClient.BaseAddress = new Uri(_baseUrl);

            this.settings = settings;
        }

        public string LastError()
        {
            return _lastError;
        }

        public async Task<bool> Login()
        {
            AuthRequest req = new AuthRequest
            {
                username = settings.UserName,
                password = settings.Password
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("/oauth/token", req);
            response.EnsureSuccessStatusCode();

            AuthResponse auth = await response.Content.ReadFromJsonAsync<AuthResponse>();

            if (!auth.success)
            {
                _lastError = auth.msg;
                return false;
            }

            // set the expires_in time
            _expiresIn = DateTime.Now.AddSeconds(auth.data.expires_in);

            // set the auth header
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", auth.data.access_token);

            return true;
        }

        public bool IsAuthenticated()
        {
            return _expiresIn == null ? false : DateTime.Now < _expiresIn;
        }

        public void RefreshAuthToken()
        {
            if (!IsAuthenticated())
            {
                // implement token refreshing
            }

        }

        public async Task<T> Get<T>(string endpoint)
        {
            RefreshAuthToken();

            return await _httpClient.GetFromJsonAsync<T>(endpoint);
        }

        /// <summary>
        ///  Return the plants available to the account.
        /// </summary>
        /// <returns></returns>
        public async Task<PlantsResponse> Plants()
        {
            return await Get<PlantsResponse>("/api/v1/plants?page=1&limit=10&name=&status=");
        }

        public async Task<EnergyFlowResponse> EnergyFlow(int plantId)
        {
            return await Get<EnergyFlowResponse>($"/api/v1/plant/energy/{plantId}/flow?date={DateTime.Now.ToString("yyyy-MM-dd")}");
        }
    }
}
