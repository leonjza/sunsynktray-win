using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SunSynkTray
{
    public partial class MainWindow : Form
    {

        private UserSettings _settings;
        private ApiClient _apiClient;
        private int _timerSeconds = 60;


        public MainWindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {

            _settings = SettingsManager.Load();

            // potentially the first boot which wont have any settings
            if (string.IsNullOrWhiteSpace(_settings.UserName))
            {
                return;
            }

            textBoxUsername.Text = _settings.UserName;
            maskedTextBoxPassword.Text = _settings.Password;

            // try and connect to the API using the credentials we have
            labelWebStatus.Text = "Checking credentials...";
            labelWebStatus.Visible = true;

            bool success;
            string message;

            try
            {
                _apiClient = new ApiClient(_settings);
                (success, message) = await _apiClient.Login();
            }
            catch (Exception)
            {
                labelWebStatus.Text = "Failed to connect to SunSynk API";
                labelWebStatus.Visible = true;

                return;
            }

            if (!success)
            {
                labelWebStatus.Text = $"Failed to authenticate: {message}";
                return;
            }

            if (_settings.PlantId == null)
            {
                labelWebStatus.Text = $"Authenticated but no plant selected";
                return;
            }

            labelWebStatus.Text = $"Using plant ID {_settings.PlantId} ({_settings.PlantName}) for user {_settings.UserName}";
            labelWebStatus.Visible = true;

            timerCallApi.Start();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void toolStripMenuExit_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void toolStripMenuIOpen_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide(); // just hide the window
            }
        }

        private async void buttonSetCredentials_Click(object sender, EventArgs e)
        {

            listBoxPlants.Items.Clear();
            listBoxPlants.Visible = false;

            _settings = new UserSettings
            {
                UserName = textBoxUsername.Text.Trim(),
                Password = maskedTextBoxPassword.Text,
            };

            labelWebStatus.Text = "Checking credentials...";
            labelWebStatus.Visible = true;

            _apiClient = new ApiClient(_settings);
            var (success, message) = await _apiClient.Login();

            if (!success)
            {
                labelWebStatus.Text = $"Failed to authenticate: {message}";
                return;
            }

            SettingsManager.Save(_settings); // store the credentials, they obviously work!

            labelWebStatus.Text = "Login successful! Loading plants...";
            ApiClient.PlantsResponse plants = await _apiClient.Get<ApiClient.PlantsResponse>("/api/v1/plants?page=1&limit=10&name=&status=");
            
            // populate the plants list
            foreach (var plant in plants.data.infos)
            {
                listBoxPlants.Items.Add(plant); // will use the overridden ToString() to format
            }
            labelWebStatus.Text = "Choose a plant to poll";
            listBoxPlants.Visible = true;
        }

        private async void listBoxPlants_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPlantStatus.Visible = false;

            if (listBoxPlants.SelectedItem is ApiClient.PlantsReponseDataInfos info)
            {
                labelWebStatus.Text = $"Using plant ID {info.id} ({info.name}) for user {_settings.UserName}";
                
                _settings.PlantId = info.id;
                _settings.PlantName = info.name;
                SettingsManager.Save(_settings);

                ApiClient.EnergyFlowResponse energy = await _apiClient.Get<ApiClient.EnergyFlowResponse>($"/api/v1/plant/energy/{_settings.PlantId}/flow?date={DateTime.Now.ToString("yyyy-MM-dd")}");

                string statusText = $"PV = {energy.data.pvPower}W, Batt = {energy.data.battPower}W, Grid = {energy.data.gridOrMeterPower}, Load = {energy.data.loadOrEpsPower}, SOC = {energy.data.soc}";

                labelPlantStatus.Text = $"Status: {statusText}";
                labelPlantStatus.Visible = true;

                trayIcon.Text = statusText;
                trayIcon.Icon = Tools.CreateIcon(energy.data.soc, energy.data.loadOrEpsPower);

                if (!timerCallApi.Enabled) timerCallApi.Start();
            }
        }

        private async void timerCallApi_Tick(object sender, EventArgs e)
        {
            if (_apiClient == null || _settings.PlantId == null || !_apiClient.IsAuthenticated()) return;

            if (_timerSeconds > 0)
            {
                _timerSeconds--;
                labelInterval.Text = $"{_timerSeconds}s";
                labelInterval.Visible = true;

                return;
            }

            _timerSeconds = 60;

            try
            {
                ApiClient.EnergyFlowResponse energy = await _apiClient.Get<ApiClient.EnergyFlowResponse>($"/api/v1/plant/energy/{_settings.PlantId}/flow?date={DateTime.Now.ToString("yyyy-MM-dd")}");
                string statusText = $"PV = {energy.data.pvPower}W, Batt = {energy.data.battPower}W, Grid = {energy.data.gridOrMeterPower}, Load = {energy.data.loadOrEpsPower}, SOC = {energy.data.soc}";

                labelPlantStatus.Text = $"Status: {statusText}";
                labelPlantStatus.Visible = true;

                trayIcon.Text = statusText;
                trayIcon.Icon = Tools.CreateIcon(energy.data.soc, energy.data.loadOrEpsPower);

            } catch (Exception ex)
            {
                string statusText = $"Failed to make API call: {ex}";
                labelPlantStatus.Text = statusText;
                labelPlantStatus.Visible = true;

                trayIcon.Text = statusText;
                trayIcon.Icon = Tools.CreateIcon(0.0f, 0);
            }
        }
    }
}
