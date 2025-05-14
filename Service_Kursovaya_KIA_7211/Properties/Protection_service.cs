using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Kursovaya_7211_KIA_PASZI;
using static Kursovaya_7211_KIA_PASZI.ConfigManager;

namespace Service_Kursovaya_KIA_7211.Properties
{
    partial class Protection_service : ServiceBase
    {
        private Timer checkTimer;

        public Protection_service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // Загрузка конфигурации
            ConfigManager.LoadConfig();

            // Настройка таймера проверки
            checkTimer = new Timer
            {
                Interval = ConfigManager.Config.CheckIntervalMinutes * 60 * 1000, // Минуты → миллисекунды
                AutoReset = true
            };
            checkTimer.Elapsed += OnTimedEvent;
            checkTimer.Start();

            // Лог
            Log("Служба Protection_service запущена.");
        }

        protected override void OnStop()
        {
            checkTimer?.Stop();
            checkTimer?.Dispose();

            Log("Служба Protection_service остановлена.");
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                ConfigManager.LoadConfig();
                // Проверка включения защиты
                if (ConfigManager.Config.IsProtectionEnabled)
                {
                    Log("Выполняется проверка защиты...");

                    // Основная логика проверки
                    Check();
                }
                else
                {
                    Log("Защита отключена в конфигурации.");
                }
            }
            catch (Exception ex)
            {
                Log($"Ошибка в таймере службы: {ex.Message}");
            }
        }
        public static void Check()
        {
            try
            {
                // Получаем внешний IP-адрес
                string externalIp = new WebClient().DownloadString("https://api.ipify.org").Trim();

                // Проверяем, содержится ли IP в списке разрешённых
                if (!ConfigManager.Config.AllowedIPAddresses.Contains(externalIp))
                {
                    Log($"Обнаружен подозрительный IP: {externalIp}");
                    Log($"Настройки SMTP для отправки письма: ");
                    Log($"SMTP сервер: {ConfigManager.Config.SmtpServer}");
                    Log($"SMTP порт: {ConfigManager.Config.SmtpPort}");
                    Log($"Отправитель: {ConfigManager.Config.EmailFrom}");
                    Log($"Получатель: {ConfigManager.Config.EmailTo}");
                    Log($"SSL включен: {ConfigManager.Config.EnableSsl}");
                    Log($"Пароль: {ConfigManager.Decrypt(ConfigManager.Config.SmtpPassword)}");
                    // Отправка уведомления на email
                    string subject = "Предупреждение о нарушении безопасности";
                    string body = $"Обнаружен подозрительный IP-адрес: {externalIp}. Проверьте настройки безопасности.";
                    EmailSender.SendNotificationEmail(
                        ConfigManager.Config.SmtpServer,
                        int.Parse(ConfigManager.Config.SmtpPort),
                        ConfigManager.Config.EmailFrom,
                        ConfigManager.Decrypt(ConfigManager.Config.SmtpPassword),
                        ConfigManager.Config.EmailTo,
                        subject,
                        body,
                        ConfigManager.Config.EnableSsl,
                        externalIp // <-- теперь передаём IP!
                    );

                    // Логируем информацию о защите
                    if (ConfigManager.Config.EnableOfflineProtection)
                    {
                        Log("⚠ Я ПЕРЕЗАГРУЗИЛА СИСТЕМУ (эмуляция) ⚠");
                        // В будущем можно раскомментировать:
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
                            Log("Не удалось перезагрузить систему. Возможно, не хватает прав администратора.\n\n" + ex.Message);
                        }
                    }
                }
                else
                {
                    Log($"Проверка IP пройдена успешно: {externalIp}");
                }
            }
            catch (Exception ex)
            {
                Log("Ошибка при проверке IP: " + ex.Message);
            }
        }
        private static void Log(string message, string logType = "INFO")
        {
            string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "service_log.txt");

            Directory.CreateDirectory(logDirectory);

            // Добавим дату в имя файла для разделения логов по дням
            string logFilePath = Path.Combine(logDirectory, $"service_log_{DateTime.Now:yyyyMMdd}.txt");

            // Формируем сообщение для лога
            string logMessage = $"{DateTime.Now:G} | {logType} | {message}";

            // Логирование внешнего IP, если нужно
            if (logType == "INFO" && ConfigManager.Config.IsProtectionEnabled)
            {
                string externalIP = GetExternalIP();
                logMessage += $" | External IP: {externalIP}";
            }

            try
            {
                File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Если не удаётся записать лог — просто игнорируем
                Console.WriteLine($"Ошибка записи в лог файл: {ex.Message}");
            }
        }
        private static string GetExternalIP()
        {
            try
            {
                using (var client = new WebClient())
                {
                    return client.DownloadString("https://api.ipify.org"); // Получаем внешний IP с ipify
                }
            }
            catch (Exception ex)
            {
                return $"Ошибка при получении IP: {ex.Message}";
            }
        }
    }
}
