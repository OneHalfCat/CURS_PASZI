namespace Kursovaya_7211_KIA_PASZI
{
    partial class MainForm
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
            this.labelCurrentIP = new System.Windows.Forms.Label();
            this.textBoxCurrentIP = new System.Windows.Forms.TextBox();
            this.labelServiceStatus = new System.Windows.Forms.Label();
            this.labelSecurity = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.buttonOpenLog = new System.Windows.Forms.Button();
            this.listBoxGeoLocation = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelCurrentIP
            // 
            this.labelCurrentIP.AutoSize = true;
            this.labelCurrentIP.Location = new System.Drawing.Point(144, 66);
            this.labelCurrentIP.Name = "labelCurrentIP";
            this.labelCurrentIP.Size = new System.Drawing.Size(121, 16);
            this.labelCurrentIP.TabIndex = 0;
            this.labelCurrentIP.Text = "Текущий IP адрес";
            // 
            // textBoxCurrentIP
            // 
            this.textBoxCurrentIP.Location = new System.Drawing.Point(100, 97);
            this.textBoxCurrentIP.Name = "textBoxCurrentIP";
            this.textBoxCurrentIP.Size = new System.Drawing.Size(260, 22);
            this.textBoxCurrentIP.TabIndex = 1;
            // 
            // labelServiceStatus
            // 
            this.labelServiceStatus.AutoSize = true;
            this.labelServiceStatus.Location = new System.Drawing.Point(625, 163);
            this.labelServiceStatus.Name = "labelServiceStatus";
            this.labelServiceStatus.Size = new System.Drawing.Size(115, 16);
            this.labelServiceStatus.TabIndex = 2;
            this.labelServiceStatus.Text = "\"Статус службы\"";
            // 
            // labelSecurity
            // 
            this.labelSecurity.AutoSize = true;
            this.labelSecurity.Location = new System.Drawing.Point(611, 201);
            this.labelSecurity.Name = "labelSecurity";
            this.labelSecurity.Size = new System.Drawing.Size(149, 16);
            this.labelSecurity.TabIndex = 3;
            this.labelSecurity.Text = "Статус безопасности";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(415, 97);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(229, 23);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Обновить состояние";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(559, 345);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(229, 23);
            this.buttonSettings.TabIndex = 5;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(559, 395);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(229, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.ItemHeight = 16;
            this.listBoxLogs.Location = new System.Drawing.Point(12, 163);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(522, 100);
            this.listBoxLogs.TabIndex = 7;
            // 
            // buttonOpenLog
            // 
            this.buttonOpenLog.Location = new System.Drawing.Point(559, 297);
            this.buttonOpenLog.Name = "buttonOpenLog";
            this.buttonOpenLog.Size = new System.Drawing.Size(229, 23);
            this.buttonOpenLog.TabIndex = 8;
            this.buttonOpenLog.Text = "Открыть Лог";
            this.buttonOpenLog.UseVisualStyleBackColor = true;
            this.buttonOpenLog.Click += new System.EventHandler(this.buttonOpenLog_Click);
            // 
            // listBoxGeoLocation
            // 
            this.listBoxGeoLocation.FormattingEnabled = true;
            this.listBoxGeoLocation.ItemHeight = 16;
            this.listBoxGeoLocation.Location = new System.Drawing.Point(12, 281);
            this.listBoxGeoLocation.Name = "listBoxGeoLocation";
            this.listBoxGeoLocation.Size = new System.Drawing.Size(522, 148);
            this.listBoxGeoLocation.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 450);
            this.Controls.Add(this.listBoxGeoLocation);
            this.Controls.Add(this.buttonOpenLog);
            this.Controls.Add(this.listBoxLogs);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.labelSecurity);
            this.Controls.Add(this.labelServiceStatus);
            this.Controls.Add(this.textBoxCurrentIP);
            this.Controls.Add(this.labelCurrentIP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentIP;
        private System.Windows.Forms.TextBox textBoxCurrentIP;
        private System.Windows.Forms.Label labelServiceStatus;
        private System.Windows.Forms.Label labelSecurity;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.Button buttonOpenLog;
        private System.Windows.Forms.ListBox listBoxGeoLocation;
    }
}