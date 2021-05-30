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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Основные", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Дополнительные", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("wefewefw");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UserAccountData = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddMessage = new System.Windows.Forms.Button();
            this.usersBox = new System.Windows.Forms.ComboBox();
            this.AccountsButton = new System.Windows.Forms.Button();
            this.mailtopsBox = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.MessageContentBox = new System.Windows.Forms.GroupBox();
            this.UserAccountData.SuspendLayout();
            this.mailtopsBox.SuspendLayout();
            this.MessageContentBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserAccountData
            // 
            this.UserAccountData.Controls.Add(this.listView1);
            this.UserAccountData.Controls.Add(this.AddMessage);
            this.UserAccountData.Controls.Add(this.usersBox);
            this.UserAccountData.Controls.Add(this.AccountsButton);
            this.UserAccountData.Location = new System.Drawing.Point(10, 4);
            this.UserAccountData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UserAccountData.Name = "UserAccountData";
            this.UserAccountData.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UserAccountData.Size = new System.Drawing.Size(165, 577);
            this.UserAccountData.TabIndex = 0;
            this.UserAccountData.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listViewGroup3.Header = "Основные";
            listViewGroup3.Name = "Based";
            listViewGroup3.Tag = "";
            listViewGroup4.Header = "Дополнительные";
            listViewGroup4.Name = "others";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(4, 154);
            this.listView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(157, 400);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // AddMessage
            // 
            this.AddMessage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddMessage.Location = new System.Drawing.Point(0, 19);
            this.AddMessage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AddMessage.Name = "AddMessage";
            this.AddMessage.Size = new System.Drawing.Size(165, 39);
            this.AddMessage.TabIndex = 2;
            this.AddMessage.Text = "Cоздать сообщение";
            this.AddMessage.UseVisualStyleBackColor = true;
            this.AddMessage.Click += new System.EventHandler(this.AddMessage_Click);
            // 
            // usersBox
            // 
            this.usersBox.Enabled = false;
            this.usersBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usersBox.FormattingEnabled = true;
            this.usersBox.Location = new System.Drawing.Point(0, 118);
            this.usersBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.usersBox.Name = "usersBox";
            this.usersBox.Size = new System.Drawing.Size(166, 27);
            this.usersBox.TabIndex = 1;
            // 
            // AccountsButton
            // 
            this.AccountsButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AccountsButton.Location = new System.Drawing.Point(0, 73);
            this.AccountsButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.AccountsButton.Name = "AccountsButton";
            this.AccountsButton.Size = new System.Drawing.Size(165, 39);
            this.AccountsButton.TabIndex = 0;
            this.AccountsButton.Text = "Добавить аккаунт";
            this.AccountsButton.UseVisualStyleBackColor = true;
            this.AccountsButton.Click += new System.EventHandler(this.AccountsButton_Click);
            // 
            // mailtopsBox
            // 
            this.mailtopsBox.Controls.Add(this.listView2);
            this.mailtopsBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mailtopsBox.Location = new System.Drawing.Point(188, 12);
            this.mailtopsBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mailtopsBox.Name = "mailtopsBox";
            this.mailtopsBox.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.mailtopsBox.Size = new System.Drawing.Size(280, 569);
            this.mailtopsBox.TabIndex = 1;
            this.mailtopsBox.TabStop = false;
            this.mailtopsBox.Text = "Сообщения";
            this.mailtopsBox.Enter += new System.EventHandler(this.mailtopsBox_Enter);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listView2.HideSelection = false;
            this.listView2.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.listView2.Location = new System.Drawing.Point(0, 25);
            this.listView2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(276, 521);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Tile;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(5, 110);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(17, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(564, 369);
            this.webBrowser1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Отправитель:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Кому:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(22, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "27.22.2123";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectLabel.Location = new System.Drawing.Point(5, 17);
            this.SubjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(166, 26);
            this.SubjectLabel.TabIndex = 7;
            this.SubjectLabel.Text = "Тема Сообщения";
            // 
            // listView3
            // 
            this.listView3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView3.HideSelection = false;
            this.listView3.LargeImageList = this.imageList1;
            this.listView3.Location = new System.Drawing.Point(139, 485);
            this.listView3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView3.MultiSelect = false;
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(362, 61);
            this.listView3.StateImageList = this.imageList1;
            this.listView3.TabIndex = 4;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Tile;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "_blank.png");
            this.imageList1.Images.SetKeyName(1, "_page.png");
            this.imageList1.Images.SetKeyName(2, "aac.png");
            this.imageList1.Images.SetKeyName(3, "ai.png");
            this.imageList1.Images.SetKeyName(4, "aiff.png");
            this.imageList1.Images.SetKeyName(5, "avi.png");
            this.imageList1.Images.SetKeyName(6, "bmp.png");
            this.imageList1.Images.SetKeyName(7, "c.png");
            this.imageList1.Images.SetKeyName(8, "cpp.png");
            this.imageList1.Images.SetKeyName(9, "css.png");
            this.imageList1.Images.SetKeyName(10, "csv.png");
            this.imageList1.Images.SetKeyName(11, "dat.png");
            this.imageList1.Images.SetKeyName(12, "dmg.png");
            this.imageList1.Images.SetKeyName(13, "doc.png");
            this.imageList1.Images.SetKeyName(14, "dotx.png");
            this.imageList1.Images.SetKeyName(15, "dwg.png");
            this.imageList1.Images.SetKeyName(16, "dxf.png");
            this.imageList1.Images.SetKeyName(17, "eps.png");
            this.imageList1.Images.SetKeyName(18, "exe.png");
            this.imageList1.Images.SetKeyName(19, "flv.png");
            this.imageList1.Images.SetKeyName(20, "gif.png");
            this.imageList1.Images.SetKeyName(21, "h.png");
            this.imageList1.Images.SetKeyName(22, "hpp.png");
            this.imageList1.Images.SetKeyName(23, "html.png");
            this.imageList1.Images.SetKeyName(24, "ics.png");
            this.imageList1.Images.SetKeyName(25, "iso.png");
            this.imageList1.Images.SetKeyName(26, "java.png");
            this.imageList1.Images.SetKeyName(27, "jpg.png");
            this.imageList1.Images.SetKeyName(28, "js.png");
            this.imageList1.Images.SetKeyName(29, "key.png");
            this.imageList1.Images.SetKeyName(30, "less.png");
            this.imageList1.Images.SetKeyName(31, "mid.png");
            this.imageList1.Images.SetKeyName(32, "mp3.png");
            this.imageList1.Images.SetKeyName(33, "mp4.png");
            this.imageList1.Images.SetKeyName(34, "mpg.png");
            this.imageList1.Images.SetKeyName(35, "odf.png");
            this.imageList1.Images.SetKeyName(36, "ods.png");
            this.imageList1.Images.SetKeyName(37, "odt.png");
            this.imageList1.Images.SetKeyName(38, "otp.png");
            this.imageList1.Images.SetKeyName(39, "ots.png");
            this.imageList1.Images.SetKeyName(40, "ott.png");
            this.imageList1.Images.SetKeyName(41, "pdf.png");
            this.imageList1.Images.SetKeyName(42, "php.png");
            this.imageList1.Images.SetKeyName(43, "png.png");
            this.imageList1.Images.SetKeyName(44, "ppt.png");
            this.imageList1.Images.SetKeyName(45, "psd.png");
            this.imageList1.Images.SetKeyName(46, "py.png");
            this.imageList1.Images.SetKeyName(47, "qt.png");
            this.imageList1.Images.SetKeyName(48, "rar.png");
            this.imageList1.Images.SetKeyName(49, "rb.png");
            this.imageList1.Images.SetKeyName(50, "rtf.png");
            this.imageList1.Images.SetKeyName(51, "sass.png");
            this.imageList1.Images.SetKeyName(52, "scss.png");
            this.imageList1.Images.SetKeyName(53, "sql.png");
            this.imageList1.Images.SetKeyName(54, "tga.png");
            this.imageList1.Images.SetKeyName(55, "tgz.png");
            this.imageList1.Images.SetKeyName(56, "tiff.png");
            this.imageList1.Images.SetKeyName(57, "txt.png");
            this.imageList1.Images.SetKeyName(58, "wav.png");
            this.imageList1.Images.SetKeyName(59, "xls.png");
            this.imageList1.Images.SetKeyName(60, "xlsx.png");
            this.imageList1.Images.SetKeyName(61, "xml.png");
            this.imageList1.Images.SetKeyName(62, "yml.png");
            this.imageList1.Images.SetKeyName(63, "zip.png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(32, 482);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Вложения:";
            // 
            // MessageContentBox
            // 
            this.MessageContentBox.Controls.Add(this.SubjectLabel);
            this.MessageContentBox.Controls.Add(this.listView3);
            this.MessageContentBox.Controls.Add(this.label4);
            this.MessageContentBox.Controls.Add(this.label1);
            this.MessageContentBox.Controls.Add(this.label3);
            this.MessageContentBox.Controls.Add(this.webBrowser1);
            this.MessageContentBox.Controls.Add(this.label2);
            this.MessageContentBox.Location = new System.Drawing.Point(484, 12);
            this.MessageContentBox.Name = "MessageContentBox";
            this.MessageContentBox.Size = new System.Drawing.Size(578, 569);
            this.MessageContentBox.TabIndex = 9;
            this.MessageContentBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 591);
            this.Controls.Add(this.MessageContentBox);
            this.Controls.Add(this.mailtopsBox);
            this.Controls.Add(this.UserAccountData);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "MailClient0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.UserAccountData.ResumeLayout(false);
            this.mailtopsBox.ResumeLayout(false);
            this.MessageContentBox.ResumeLayout(false);
            this.MessageContentBox.PerformLayout();
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
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SubjectLabel;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox MessageContentBox;
    }
}

