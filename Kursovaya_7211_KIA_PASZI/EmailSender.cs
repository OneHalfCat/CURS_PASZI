using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
    }
}
