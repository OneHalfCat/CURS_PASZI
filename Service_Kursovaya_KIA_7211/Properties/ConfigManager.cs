using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace Kursovaya_7211_KIA_PASZI
{
    internal class ConfigManager
    {
        private static readonly string ConfigPath = Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory, "config.json");
        // 16 байтный ключ для AES-128 (128 бит)
        private static readonly string Key = "1234567890abcdef"; // 16 байт

        // 16 байтный вектор инициализации (IV)
        private static readonly string IV = "abcdef1234567890"; // 16 байт
        public class AppConfig
        {
            public string MasterPasswordHash { get; set; }
            public List<string> AllowedIPAddresses { get; set; }
            public string SmtpServer { get; set; }
            public string SmtpPort { get; set; }
            public string EmailFrom { get; set; }  // Отправитель
            public string EmailTo { get; set; }    // Получатель
            public string SmtpPassword { get; set; }  // Пароль для SMTP (пароль приложения)
            public bool IsProtectionEnabled { get; set; } = true;
            public bool EnableOfflineProtection { get; set; } = false;
            public int CheckIntervalMinutes { get; set; } = 5;
            public bool LogToFileEnabled { get; set; } = true;
            public bool EnableSsl { get; set; } = true;


            public AppConfig()
            {
                AllowedIPAddresses = new List<string>();
            }
        }

        public static AppConfig Config;

        static ConfigManager()
        {
            LoadConfig();
        }

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor();
                byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);

                // Возвращаем зашифрованный текст как строку в формате Base64
                return Convert.ToBase64String(encrypted);
            }
        }

        // Метод для расшифровки
        public static string Decrypt(string cipherText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor();
                byte[] encryptedBytes = Convert.FromBase64String(cipherText);  // Декодируем из Base64
                byte[] decrypted = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                return Encoding.UTF8.GetString(decrypted);
            }
        }
        public static void LoadConfig()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
            if (File.Exists(ConfigPath))
            {
                string json = File.ReadAllText(ConfigPath);
                Config = JsonConvert.DeserializeObject<AppConfig>(json);  // Десериализация строки JSON в объект AppConfig
            }
            else
            {
                // Первая настройка или аварийная ситуация
                Config = new AppConfig
                {
                    MasterPasswordHash = "",  // Пустой хеш пароля, пользователю предстоит ввести новый
                    AllowedIPAddresses = new List<string>(),  // Пустой список IP
                    SmtpServer = "smtp.gmail.com",  // Значение по умолчанию для SMTP сервера
                    SmtpPort = "587",              // Порт по умолчанию (TLS)
                    EmailFrom = "",                // Пустое поле для ввода адреса отправителя
                    EmailTo = "",                  // Пустое поле для ввода адреса получателя
                    SmtpPassword = "",             // Пустое поле для ввода пароля SMTP
                    IsProtectionEnabled = true,    // Защита включена по умолчанию
                    EnableOfflineProtection = false,  // Защита от офлайн по умолчанию
                    CheckIntervalMinutes = 5,      // Интервал проверки в минутах
                    LogToFileEnabled = true,       // Логирование включено по умолчанию
                    EnableSsl = true // SSL включён по умолчанию
                };
                SaveConfig();
            }
        }

        public static void SaveConfig()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
                string json = JsonConvert.SerializeObject(Config, Formatting.Indented);
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка сохранения конфигурации: " + ex.Message);
            }
        }
        public static string CalculateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();  // Преобразуем хеш в строку
            }
        }
        // Метод для изменения пароля
        public static bool ChangeMasterPassword(string oldPassword, string newPassword)
        {
            // Проверка старого пароля
            if (Config.MasterPasswordHash != CalculateMD5(oldPassword))
            {
                return false;  // Неверный старый пароль
            }

            // Обновление хеша пароля
            Config.MasterPasswordHash = CalculateMD5(newPassword);

            // Сохранение конфигурации с новым паролем
            SaveConfig();

            return true;  // Пароль успешно изменён
        }
        public static bool IsIpAllowed(string ip)
        {
            return Config.AllowedIPAddresses.Contains(ip);
        }
        public static void AddAllowedIp(string ip)
        {
            if (!Config.AllowedIPAddresses.Contains(ip))
            {
                Config.AllowedIPAddresses.Add(ip);
                SaveConfig();
            }
        }
        public static void RemoveAllowedIp(string ip)
        {
            if (Config.AllowedIPAddresses.Contains(ip))
            {
                Config.AllowedIPAddresses.Remove(ip);
                SaveConfig();
            }
        }
        public static void ClearAllowedIps()
        {
            Config.AllowedIPAddresses.Clear();
            SaveConfig();
        }
        public static void ResetConfig()
        {
            Config = new AppConfig
            {
                MasterPasswordHash = "",
                SmtpServer = "smtp.gmail.com",  // Значение по умолчанию
                SmtpPort = "587",                // Порт по умолчанию (TLS)
                EmailFrom = "",
                EmailTo = "",
                SmtpPassword = ""
            };
            SaveConfig();
        }
    }
}
