using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Kursovaya_7211_KIA_PASZI
{
    internal class EmailSender
    {
        public static void SendTestEmail(string smtpServer, int smtpPort, string emailFrom, string password, string emailTo, bool enableSsl)
        {
            try
            {
                // Создаём сообщение
                MailMessage message = new MailMessage();
                message.From = new MailAddress(emailFrom);
                message.To.Add(emailTo);
                message.Subject = "Проверка SMTP подключения";
                message.Body = "Это тестовое письмо от приложения защиты ноутбука.";

                // Настройка SMTP клиента
                SmtpClient client = new SmtpClient(smtpServer, smtpPort)
                {
                    EnableSsl = enableSsl, // ← Используем значение из конфигурации
                    Credentials = new NetworkCredential(emailFrom, password)
                };

                // Отправляем письмо
                client.Send(message);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим её
                Console.WriteLine("Ошибка при отправке письма: " + ex.Message);
            }
        }
        public static void SendNotificationEmail(string smtpServer, int smtpPort, string emailFrom, string password, string emailTo,
     string subject, string body, bool enableSsl, string externalIp)
        {
            try
            {
                // Получаем данные геолокации для IP
                string geoData = new WebClient().DownloadString($"http://ip-api.com/json/{externalIp}");
                dynamic geoJson = JsonConvert.DeserializeObject(geoData);

                // Добавим геоинформацию в тело письма
                string geoInfo = $"\n\n--- Геолокация IP {externalIp} ---\n" +
                                 $"Страна: {geoJson.country}\n" +
                                 $"Регион: {geoJson.regionName}\n" +
                                 $"Город: {geoJson.city}\n" +
                                 $"Широта: {geoJson.lat}\n" +
                                 $"Долгота: {geoJson.lon}\n" +
                                 $"Организация: {geoJson.org}";

                body += geoInfo;

                MailMessage message = new MailMessage
                {
                    From = new MailAddress(emailFrom),
                    Subject = subject,
                    Body = body
                };
                message.To.Add(emailTo);

                SmtpClient client = new SmtpClient(smtpServer, smtpPort)
                {
                    EnableSsl = enableSsl,
                    Credentials = new NetworkCredential(emailFrom, password)
                };

                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при отправке письма: " + ex.Message);
            }
        }

    }
}