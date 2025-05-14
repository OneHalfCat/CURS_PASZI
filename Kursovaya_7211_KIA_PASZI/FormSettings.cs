using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kursovaya_7211_KIA_PASZI.ConfigManager;
using System.ServiceProcess;
using System.Configuration.Install;  
namespace Kursovaya_7211_KIA_PASZI

{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            var config = ConfigManager.Config;

            // Добавление IP-адресов в список
            listBoxAllowedIPs.Items.Clear();
            foreach (var ip in config.AllowedIPAddresses)
            {
                listBoxAllowedIPs.Items.Add(ip);
            }
            checkBoxProtection.Checked = ConfigManager.Config.IsProtectionEnabled;
            checkBoxOffline.Checked = ConfigManager.Config.EnableOfflineProtection;
            checkBoxLogToFile.Checked = ConfigManager.Config.LogToFileEnabled;
            // Загрузка SMTP и Email-настроек
            textBoxEmailFrom.Text = config.EmailFrom;
            textBoxEmailTo.Text = config.EmailTo;
            numericRetryMinutes.Value = ConfigManager.Config.CheckIntervalMinutes;
            textBoxSmtpServer.Text = config.SmtpServer;
            textBoxSmtpPort.Text = config.SmtpPort;
            string decryptedPassword = ConfigManager.Decrypt(ConfigManager.Config.SmtpPassword);
            TextBoxStmpPassword.Text = decryptedPassword;
            checkBoxUseSSL.Checked = ConfigManager.Config.EnableSsl;
        }
        private void buttonAddIP_Click(object sender, EventArgs e)
        {
            string newIP = textBoxNewIP.Text.Trim();
            if (!string.IsNullOrEmpty(newIP) && !ConfigManager.Config.AllowedIPAddresses.Contains(newIP))
            {
                ConfigManager.AddAllowedIp(newIP);
                listBoxAllowedIPs.Items.Add(newIP);
                textBoxNewIP.Clear();
            }
        }

        private void buttonRemoveIP_Click(object sender, EventArgs e)
        {
            if (listBoxAllowedIPs.SelectedItem != null)
            {
                string selectedIP = listBoxAllowedIPs.SelectedItem.ToString();
                ConfigManager.RemoveAllowedIp(selectedIP);
                listBoxAllowedIPs.Items.Remove(selectedIP);
            }
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            ConfigManager.Config.EmailFrom = textBoxEmailFrom.Text.Trim();
            ConfigManager.Config.EmailTo = textBoxEmailTo.Text.Trim();
            ConfigManager.Config.SmtpServer = textBoxSmtpServer.Text.Trim();
            ConfigManager.Config.SmtpPort = textBoxSmtpPort.Text.Trim();
            ConfigManager.Config.SmtpPassword = ConfigManager.Encrypt(TextBoxStmpPassword.Text);
            ConfigManager.Config.IsProtectionEnabled = checkBoxProtection.Checked;
            ConfigManager.Config.EnableOfflineProtection = checkBoxOffline.Checked;
            ConfigManager.Config.LogToFileEnabled = checkBoxLogToFile.Checked;
            ConfigManager.Config.CheckIntervalMinutes = (int)numericRetryMinutes.Value;
            ConfigManager.Config.EnableSsl = checkBoxUseSSL.Checked;
            ConfigManager.SaveConfig();

            MessageBox.Show("Настройки сохранены."+ ConfigManager.Encrypt(ConfigManager.Config.SmtpPassword), "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static string CalculateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();  // Преобразуем хеш в строку
            }
        }
        private void buttonTestEmail_Click(object sender, EventArgs e)
        {
            try
            {

                // Отправляем тестовое письмо на тот же адрес (emailFrom == emailTo)
                EmailSender.SendTestEmail(
                    textBoxSmtpServer.Text.Trim(),  // smtp.gmail.com   
                    int.Parse(textBoxSmtpPort.Text.Trim()),  // 587 (TLS)
                    textBoxEmailFrom.Text.Trim(),  // Твой Gmail
                    TextBoxStmpPassword.Text.Trim(),  // Пароль приложения
                    textBoxEmailTo.Text.Trim(),  // Кому отправлять (тот же адрес)
                    checkBoxUseSSL.Checked
                );
                // Сообщение об успешной отправке
                MessageBox.Show("Письмо успешно отправлено!");
            }
            catch (Exception ex)
            {
                // Сообщение об ошибке
                MessageBox.Show("Ошибка при отправке письма: " + ex.Message);
            }
        }
        public static void InstallService(string exePath, string serviceName)
        {

            try
            {
                string servicePath = exePath; // Укажи путь к exe службы

                // Создаем ServiceInstaller и ServiceProcessInstaller
                var serviceProcessInstaller = new ServiceProcessInstaller
                {
                    Account = ServiceAccount.LocalSystem // Локальный системный аккаунт
                };

                var serviceInstaller = new ServiceInstaller
                {
                    ServiceName = "Protection_service",  // Имя службы
                    DisplayName = "Protection Service",  // Отображаемое имя
                    StartType = ServiceStartMode.Automatic // Старт при запуске системы
                };

                // Устанавливаем и запускаем службу
                var installer = new AssemblyInstaller(servicePath, null);
                installer.UseNewContext = true; // Использовать новый контекст

                // Добавляем ServiceInstaller в установку
                installer.Installers.Add(serviceProcessInstaller);
                installer.Installers.Add(serviceInstaller);

                // Устанавливаем службу
                installer.Install(new System.Collections.Hashtable());

                MessageBox.Show("Служба успешно установлена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при установке службы: " + ex.Message);
            }
        }
        public static void StartService(string serviceName)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c net start \"{serviceName}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Verb = "runas" // Запуск от имени администратора
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show($"Служба {serviceName} успешно запущена.\n\n{output}", "Успех");
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при запуске службы:\n{error}", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение при запуске службы: " + ex.Message);
            }
        }
        public static void StopService(string serviceName)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c net stop \"{serviceName}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    Verb = "runas" // Запуск от имени администратора
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show($"Служба {serviceName} успешно остановлена.\n\n{output}", "Успех");
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при остановке службы:\n{error}", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Исключение при остановке службы: " + ex.Message);
            }
        }
        public static void DeleteService(string serviceName)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("sc.exe",
                    $"delete \"{serviceName}\"")
                {
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления службы: {ex.Message}");
            }
        }
        private void buttonInstall_Click(object sender, EventArgs e)
        {
            string exePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Service_Kursovaya_KIA_7211.exe");
            InstallService(exePath, "Protection_service");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartService("Protection_service");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopService("Protection_service");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            StopService("Protection_service"); // желательно остановить перед удалением
            DeleteService("Protection_service");
        }
        private void buttonReboot_Click_1(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("shutdown", "/r /t 0")
                {
                    UseShellExecute = true,
                    Verb = "runas" // Требуется запуск от администратора
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось перезагрузить систему. Возможно, не хватает прав администратора.\n\n" + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
