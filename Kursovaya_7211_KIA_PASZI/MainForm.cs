using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Kursovaya_7211_KIA_PASZI
{
    public partial class MainForm : Form
    {
        private void MainForm_Load(object sender, EventArgs e)
        {
            var lines = Logger.GetLogLines();
            foreach (var line in lines.Reverse())
            {
                listBoxLogs.Items.Add(line);
            }
        }
        public MainForm()
        {
            InitializeComponent();
        }

        public static string GetPublicIPAddress()
        {
            try
            {
                using (var client = new WebClient())
                {
                    string ip = client.DownloadString("https://api.ipify.org");
                    return ip;
                }
            }
            catch
            {
                return "Нет подключения";
            }
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            string currentIP = GetPublicIPAddress();
            textBoxCurrentIP.Text = currentIP;

            bool isTrusted = ConfigManager.Config.AllowedIPAddresses.Contains(currentIP);
            string status = isTrusted ? "ОК" : "НЕИЗВЕСТЕН";

            labelSecurity.Text = isTrusted ? "Защищено" : "Подозрительное подключение";
            labelSecurity.ForeColor = isTrusted ? Color.Green : Color.Red;

            string logEntry = $"IP: {currentIP} — {status}";
            listBoxLogs.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {logEntry}");
            Logger.Log(logEntry); // << Запись в файл
            btnGetGeoLocation_Click();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonOpenLog_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Logger.GetLogFilePath();

                if (!File.Exists(path))
                {
                    MessageBox.Show("Файл логов ещё не создан.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                System.Diagnostics.Process.Start("notepad.exe", path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть лог-файл.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGetGeoLocation_Click()
        {
            // Очищаем ListBox перед выводом новых данных
            listBoxGeoLocation.Items.Clear();

            try
            {
                // Получаем внешний IP-адрес
                string externalIp = new WebClient().DownloadString("https://api.ipify.org").Trim();

                // Получаем данные геолокации для IP
                string geoData = new WebClient().DownloadString($"http://ip-api.com/json/{externalIp}");

                // Преобразуем ответ в удобный формат и выводим в ListBox
                listBoxGeoLocation.Items.Add("Информация о геолокации:");
                listBoxGeoLocation.Items.Add($"IP: {externalIp}");

                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(geoData);
                listBoxGeoLocation.Items.Add($"Страна: {json.country}");
                listBoxGeoLocation.Items.Add($"Регион: {json.regionName}");
                listBoxGeoLocation.Items.Add($"Город: {json.city}");
                listBoxGeoLocation.Items.Add($"Широта: {json.lat}");
                listBoxGeoLocation.Items.Add($"Долгота: {json.lon}");
                listBoxGeoLocation.Items.Add($"Организация: {json.org}");
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение в ListBox
                listBoxGeoLocation.Items.Add($"Ошибка: {ex.Message}");
            }
        }
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings ();
            settings.ShowDialog(); // Модально
            buttonRefresh.PerformClick(); // Обновить данные после настроек

        }
    }
}
