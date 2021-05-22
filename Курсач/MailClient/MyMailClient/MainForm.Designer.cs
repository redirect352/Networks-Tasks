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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Основные", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Дополнительные", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Спам"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.WhiteSmoke, new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))));
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Полученные сообщения"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.WhiteSmoke, new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))));
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Отправленные сообщения"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.WhiteSmoke, new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204))));
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Today", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Привет");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UserAccountData = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddMessage = new System.Windows.Forms.Button();
            this.usersBox = new System.Windows.Forms.ComboBox();
            this.AccountsButton = new System.Windows.Forms.Button();
            this.mailtopsBox = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.UserAccountData.SuspendLayout();
            this.mailtopsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserAccountData
            // 
            this.UserAccountData.Controls.Add(this.listView1);
            this.UserAccountData.Controls.Add(this.AddMessage);
            this.UserAccountData.Controls.Add(this.usersBox);
            this.UserAccountData.Controls.Add(this.AccountsButton);
            this.UserAccountData.Location = new System.Drawing.Point(12, 4);
            this.UserAccountData.Name = "UserAccountData";
            this.UserAccountData.Size = new System.Drawing.Size(198, 392);
            this.UserAccountData.TabIndex = 0;
            this.UserAccountData.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listViewGroup1.Header = "Основные";
            listViewGroup1.Name = "Based";
            listViewGroup1.Tag = "";
            listViewGroup2.Header = "Дополнительные";
            listViewGroup2.Name = "others";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.HideSelection = false;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView1.Location = new System.Drawing.Point(0, 142);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(198, 130);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // AddMessage
            // 
            this.AddMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddMessage.Location = new System.Drawing.Point(0, 19);
            this.AddMessage.Name = "AddMessage";
            this.AddMessage.Size = new System.Drawing.Size(198, 39);
            this.AddMessage.TabIndex = 2;
            this.AddMessage.Text = "Cоздать сообщение";
            this.AddMessage.UseVisualStyleBackColor = true;
            this.AddMessage.Click += new System.EventHandler(this.AddMessage_Click);
            // 
            // usersBox
            // 
            this.usersBox.Enabled = false;
            this.usersBox.FormattingEnabled = true;
            this.usersBox.Location = new System.Drawing.Point(0, 118);
            this.usersBox.Name = "usersBox";
            this.usersBox.Size = new System.Drawing.Size(198, 21);
            this.usersBox.TabIndex = 1;
            // 
            // AccountsButton
            // 
            this.AccountsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccountsButton.Location = new System.Drawing.Point(0, 73);
            this.AccountsButton.Name = "AccountsButton";
            this.AccountsButton.Size = new System.Drawing.Size(198, 39);
            this.AccountsButton.TabIndex = 0;
            this.AccountsButton.Text = "Добавить аккаунт";
            this.AccountsButton.UseVisualStyleBackColor = true;
            this.AccountsButton.Click += new System.EventHandler(this.AccountsButton_Click);
            // 
            // mailtopsBox
            // 
            this.mailtopsBox.Controls.Add(this.listView2);
            this.mailtopsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mailtopsBox.Location = new System.Drawing.Point(226, 12);
            this.mailtopsBox.Name = "mailtopsBox";
            this.mailtopsBox.Size = new System.Drawing.Size(273, 383);
            this.mailtopsBox.TabIndex = 1;
            this.mailtopsBox.TabStop = false;
            this.mailtopsBox.Text = "Сообщения";
            // 
            // listView2
            // 
            listViewGroup3.Header = "Today";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup3.Tag = "ААА";
            this.listView2.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3});
            this.listView2.HideSelection = false;
            listViewItem4.Group = listViewGroup3;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4});
            this.listView2.Location = new System.Drawing.Point(6, 44);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(261, 298);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Tile;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 414);
            this.Controls.Add(this.mailtopsBox);
            this.Controls.Add(this.UserAccountData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MailClient0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.UserAccountData.ResumeLayout(false);
            this.mailtopsBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UserAccountData;
        private System.Windows.Forms.ComboBox usersBox;
        private System.Windows.Forms.Button AccountsButton;
        private System.Windows.Forms.Button AddMessage;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox mailtopsBox;
        private System.Windows.Forms.ListView listView2;
    }
}

