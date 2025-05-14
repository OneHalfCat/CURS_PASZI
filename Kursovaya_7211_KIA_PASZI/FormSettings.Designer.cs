namespace Kursovaya_7211_KIA_PASZI
{
    partial class FormSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxAllowedIPs = new System.Windows.Forms.ListBox();
            this.textBoxNewIP = new System.Windows.Forms.TextBox();
            this.buttonRemoveIP = new System.Windows.Forms.Button();
            this.buttonAddIP = new System.Windows.Forms.Button();
            this.textBoxEmailFrom = new System.Windows.Forms.TextBox();
            this.textBoxSmtpServer = new System.Windows.Forms.TextBox();
            this.textBoxEmailTo = new System.Windows.Forms.TextBox();
            this.textBoxSmtpPort = new System.Windows.Forms.TextBox();
            this.checkBoxUseSSL = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxStmpPassword = new System.Windows.Forms.TextBox();
            this.buttonTestEmail = new System.Windows.Forms.Button();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonCancelSettings = new System.Windows.Forms.Button();
            this.checkBoxOffline = new System.Windows.Forms.CheckBox();
            this.checkBoxProtection = new System.Windows.Forms.CheckBox();
            this.checkBoxLogToFile = new System.Windows.Forms.CheckBox();
            this.numericRetryMinutes = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonReboot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericRetryMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxAllowedIPs
            // 
            this.listBoxAllowedIPs.FormattingEnabled = true;
            this.listBoxAllowedIPs.ItemHeight = 16;
            this.listBoxAllowedIPs.Location = new System.Drawing.Point(12, 12);
            this.listBoxAllowedIPs.Name = "listBoxAllowedIPs";
            this.listBoxAllowedIPs.Size = new System.Drawing.Size(385, 84);
            this.listBoxAllowedIPs.TabIndex = 0;
            // 
            // textBoxNewIP
            // 
            this.textBoxNewIP.Location = new System.Drawing.Point(423, 74);
            this.textBoxNewIP.Name = "textBoxNewIP";
            this.textBoxNewIP.Size = new System.Drawing.Size(569, 22);
            this.textBoxNewIP.TabIndex = 1;
            // 
            // buttonRemoveIP
            // 
            this.buttonRemoveIP.Location = new System.Drawing.Point(423, 13);
            this.buttonRemoveIP.Name = "buttonRemoveIP";
            this.buttonRemoveIP.Size = new System.Drawing.Size(258, 23);
            this.buttonRemoveIP.TabIndex = 2;
            this.buttonRemoveIP.Text = "Удалить IP";
            this.buttonRemoveIP.UseVisualStyleBackColor = true;
            this.buttonRemoveIP.Click += new System.EventHandler(this.buttonRemoveIP_Click);
            // 
            // buttonAddIP
            // 
            this.buttonAddIP.Location = new System.Drawing.Point(734, 13);
            this.buttonAddIP.Name = "buttonAddIP";
            this.buttonAddIP.Size = new System.Drawing.Size(258, 23);
            this.buttonAddIP.TabIndex = 3;
            this.buttonAddIP.Text = "Добавить IP";
            this.buttonAddIP.UseVisualStyleBackColor = true;
            this.buttonAddIP.Click += new System.EventHandler(this.buttonAddIP_Click);
            // 
            // textBoxEmailFrom
            // 
            this.textBoxEmailFrom.Location = new System.Drawing.Point(26, 178);
            this.textBoxEmailFrom.Name = "textBoxEmailFrom";
            this.textBoxEmailFrom.Size = new System.Drawing.Size(207, 22);
            this.textBoxEmailFrom.TabIndex = 4;
            // 
            // textBoxSmtpServer
            // 
            this.textBoxSmtpServer.Location = new System.Drawing.Point(26, 262);
            this.textBoxSmtpServer.Name = "textBoxSmtpServer";
            this.textBoxSmtpServer.Size = new System.Drawing.Size(207, 22);
            this.textBoxSmtpServer.TabIndex = 5;
            // 
            // textBoxEmailTo
            // 
            this.textBoxEmailTo.Location = new System.Drawing.Point(284, 178);
            this.textBoxEmailTo.Name = "textBoxEmailTo";
            this.textBoxEmailTo.Size = new System.Drawing.Size(215, 22);
            this.textBoxEmailTo.TabIndex = 6;
            // 
            // textBoxSmtpPort
            // 
            this.textBoxSmtpPort.Location = new System.Drawing.Point(284, 262);
            this.textBoxSmtpPort.Name = "textBoxSmtpPort";
            this.textBoxSmtpPort.Size = new System.Drawing.Size(215, 22);
            this.textBoxSmtpPort.TabIndex = 7;
            // 
            // checkBoxUseSSL
            // 
            this.checkBoxUseSSL.AutoSize = true;
            this.checkBoxUseSSL.Location = new System.Drawing.Point(561, 264);
            this.checkBoxUseSSL.Name = "checkBoxUseSSL";
            this.checkBoxUseSSL.Size = new System.Drawing.Size(158, 20);
            this.checkBoxUseSSL.TabIndex = 8;
            this.checkBoxUseSSL.Text = "Использовать SSL?";
            this.checkBoxUseSSL.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Email отправителя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "SMTP-сервер";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email получателя";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "SMTP-порт";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Пароль";
            // 
            // TextBoxStmpPassword
            // 
            this.TextBoxStmpPassword.Location = new System.Drawing.Point(547, 178);
            this.TextBoxStmpPassword.Name = "TextBoxStmpPassword";
            this.TextBoxStmpPassword.Size = new System.Drawing.Size(204, 22);
            this.TextBoxStmpPassword.TabIndex = 16;
            // 
            // buttonTestEmail
            // 
            this.buttonTestEmail.Location = new System.Drawing.Point(795, 228);
            this.buttonTestEmail.Name = "buttonTestEmail";
            this.buttonTestEmail.Size = new System.Drawing.Size(138, 23);
            this.buttonTestEmail.TabIndex = 17;
            this.buttonTestEmail.Text = "Отправить Тест";
            this.buttonTestEmail.UseVisualStyleBackColor = true;
            this.buttonTestEmail.Click += new System.EventHandler(this.buttonTestEmail_Click);
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(776, 451);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(197, 23);
            this.buttonSaveSettings.TabIndex = 18;
            this.buttonSaveSettings.Text = "Сохранить настройки";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // buttonCancelSettings
            // 
            this.buttonCancelSettings.Location = new System.Drawing.Point(776, 505);
            this.buttonCancelSettings.Name = "buttonCancelSettings";
            this.buttonCancelSettings.Size = new System.Drawing.Size(197, 23);
            this.buttonCancelSettings.TabIndex = 19;
            this.buttonCancelSettings.Text = "Отмена/закрыть окно";
            this.buttonCancelSettings.UseVisualStyleBackColor = true;
            // 
            // checkBoxOffline
            // 
            this.checkBoxOffline.AutoSize = true;
            this.checkBoxOffline.Location = new System.Drawing.Point(24, 366);
            this.checkBoxOffline.Name = "checkBoxOffline";
            this.checkBoxOffline.Size = new System.Drawing.Size(133, 20);
            this.checkBoxOffline.TabIndex = 20;
            this.checkBoxOffline.Text = "Офлайн защита";
            this.checkBoxOffline.UseVisualStyleBackColor = true;
            // 
            // checkBoxProtection
            // 
            this.checkBoxProtection.AutoSize = true;
            this.checkBoxProtection.Location = new System.Drawing.Point(26, 319);
            this.checkBoxProtection.Name = "checkBoxProtection";
            this.checkBoxProtection.Size = new System.Drawing.Size(151, 20);
            this.checkBoxProtection.TabIndex = 21;
            this.checkBoxProtection.Text = "Включить защиту?";
            this.checkBoxProtection.UseVisualStyleBackColor = true;
            // 
            // checkBoxLogToFile
            // 
            this.checkBoxLogToFile.AutoSize = true;
            this.checkBoxLogToFile.Location = new System.Drawing.Point(24, 416);
            this.checkBoxLogToFile.Name = "checkBoxLogToFile";
            this.checkBoxLogToFile.Size = new System.Drawing.Size(100, 20);
            this.checkBoxLogToFile.TabIndex = 22;
            this.checkBoxLogToFile.Text = "Вести лог?";
            this.checkBoxLogToFile.UseVisualStyleBackColor = true;
            // 
            // numericRetryMinutes
            // 
            this.numericRetryMinutes.Location = new System.Drawing.Point(24, 505);
            this.numericRetryMinutes.Name = "numericRetryMinutes";
            this.numericRetryMinutes.Size = new System.Drawing.Size(120, 22);
            this.numericRetryMinutes.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 467);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Интервал проверки";
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(284, 366);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(258, 23);
            this.buttonInstall.TabIndex = 25;
            this.buttonInstall.Text = "Установить службу";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(284, 425);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(258, 23);
            this.buttonStart.TabIndex = 26;
            this.buttonStart.Text = "Запустить службу";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(284, 486);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(258, 23);
            this.buttonStop.TabIndex = 27;
            this.buttonStop.Text = "Остановить службу";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(284, 535);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(258, 23);
            this.buttonDelete.TabIndex = 28;
            this.buttonDelete.Text = "Удалить службу";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonReboot
            // 
            this.buttonReboot.Location = new System.Drawing.Point(715, 392);
            this.buttonReboot.Name = "buttonReboot";
            this.buttonReboot.Size = new System.Drawing.Size(258, 23);
            this.buttonReboot.TabIndex = 29;
            this.buttonReboot.Text = "Перезагрузка";
            this.buttonReboot.UseVisualStyleBackColor = true;
            this.buttonReboot.Click += new System.EventHandler(this.buttonReboot_Click_1);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 597);
            this.Controls.Add(this.buttonReboot);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonInstall);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericRetryMinutes);
            this.Controls.Add(this.checkBoxLogToFile);
            this.Controls.Add(this.checkBoxProtection);
            this.Controls.Add(this.checkBoxOffline);
            this.Controls.Add(this.buttonCancelSettings);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.buttonTestEmail);
            this.Controls.Add(this.TextBoxStmpPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxUseSSL);
            this.Controls.Add(this.textBoxSmtpPort);
            this.Controls.Add(this.textBoxEmailTo);
            this.Controls.Add(this.textBoxSmtpServer);
            this.Controls.Add(this.textBoxEmailFrom);
            this.Controls.Add(this.buttonAddIP);
            this.Controls.Add(this.buttonRemoveIP);
            this.Controls.Add(this.textBoxNewIP);
            this.Controls.Add(this.listBoxAllowedIPs);
            this.Name = "FormSettings";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericRetryMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxAllowedIPs;
        private System.Windows.Forms.TextBox textBoxNewIP;
        private System.Windows.Forms.Button buttonRemoveIP;
        private System.Windows.Forms.Button buttonAddIP;
        private System.Windows.Forms.TextBox textBoxEmailFrom;
        private System.Windows.Forms.TextBox textBoxSmtpServer;
        private System.Windows.Forms.TextBox textBoxEmailTo;
        private System.Windows.Forms.TextBox textBoxSmtpPort;
        private System.Windows.Forms.CheckBox checkBoxUseSSL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TextBoxStmpPassword;
        private System.Windows.Forms.Button buttonTestEmail;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonCancelSettings;
        private System.Windows.Forms.CheckBox checkBoxOffline;
        private System.Windows.Forms.CheckBox checkBoxProtection;
        private System.Windows.Forms.CheckBox checkBoxLogToFile;
        private System.Windows.Forms.NumericUpDown numericRetryMinutes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonReboot;
    }
}