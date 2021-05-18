namespace MyMailClient
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UserAccountData = new System.Windows.Forms.GroupBox();
            this.usersBox = new System.Windows.Forms.ComboBox();
            this.AccountsButton = new System.Windows.Forms.Button();
            this.UserAccountData.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserAccountData
            // 
            this.UserAccountData.Controls.Add(this.usersBox);
            this.UserAccountData.Controls.Add(this.AccountsButton);
            this.UserAccountData.Location = new System.Drawing.Point(12, 4);
            this.UserAccountData.Name = "UserAccountData";
            this.UserAccountData.Size = new System.Drawing.Size(198, 392);
            this.UserAccountData.TabIndex = 0;
            this.UserAccountData.TabStop = false;
            // 
            // usersBox
            // 
            this.usersBox.Enabled = false;
            this.usersBox.FormattingEnabled = true;
            this.usersBox.Location = new System.Drawing.Point(0, 86);
            this.usersBox.Name = "usersBox";
            this.usersBox.Size = new System.Drawing.Size(198, 21);
            this.usersBox.TabIndex = 1;
            // 
            // AccountsButton
            // 
            this.AccountsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccountsButton.Location = new System.Drawing.Point(0, 41);
            this.AccountsButton.Name = "AccountsButton";
            this.AccountsButton.Size = new System.Drawing.Size(198, 39);
            this.AccountsButton.TabIndex = 0;
            this.AccountsButton.Text = "Добавить аккаунт";
            this.AccountsButton.UseVisualStyleBackColor = true;
            this.AccountsButton.Click += new System.EventHandler(this.AccountsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 414);
            this.Controls.Add(this.UserAccountData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MailClient0.1";
            this.UserAccountData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UserAccountData;
        private System.Windows.Forms.ComboBox usersBox;
        private System.Windows.Forms.Button AccountsButton;
    }
}

