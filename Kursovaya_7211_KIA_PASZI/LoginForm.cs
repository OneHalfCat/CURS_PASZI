using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace Kursovaya_7211_KIA_PASZI
{
    public partial class LoginForm : Form
    {
        public static string CalculateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())  // Создаём объект MD5
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));  // Вычисляем хеш
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();  // Преобразуем хеш в строку
            }
        }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            ConfigManager.LoadConfig();
            string enteredPassword = textBoxPassword.Text;
            // Проверяем, если конфиг не содержит пароля (первый запуск программы)
            if (string.IsNullOrEmpty(ConfigManager.Config.MasterPasswordHash))
            {
                // Если пароль пустой в конфиге, считаем это первым запуском программы.
                // Сохраняем новый пароль, введённый пользователем.
                if (!string.IsNullOrEmpty(enteredPassword))
                {
                    // Хешируем введённый пароль
                    string newPasswordHash = ConfigManager.CalculateMD5(enteredPassword);

                    // Сохраняем новый хеш пароля в конфигурацию
                    ConfigManager.Config.MasterPasswordHash = newPasswordHash;
                    ConfigManager.SaveConfig();

                    // Переходим на главную форму
                    this.Hide(); // Скрываем форму авторизации
                    MainForm main = new MainForm();
                    main.Show();
                }
                else
                {
                    // Если пароль пустой, показываем ошибку
                    labelError.Text = "Пароль не может быть пустым!";
                    labelError.ForeColor = Color.Red;
                }
            }
            else
            {
                // Если пароль уже есть в конфиге, проверяем введённый пароль
                string enteredHash = ConfigManager.CalculateMD5(enteredPassword);

                if (enteredHash == ConfigManager.Config.MasterPasswordHash)
                {
                    this.Hide(); // Скрываем LoginForm
                    MainForm main = new MainForm();
                    main.Show();
                }
                else
                {
                    labelError.Text = ConfigManager.Config.MasterPasswordHash;
                    labelError.ForeColor = Color.Red;
                }
            }
        }
    }
}