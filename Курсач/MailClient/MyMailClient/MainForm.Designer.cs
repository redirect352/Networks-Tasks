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
            System.Windows.Forms.ListViewGroup listViewGroup21 = new System.Windows.Forms.ListViewGroup("Основные", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup22 = new System.Windows.Forms.ListViewGroup("Дополнительные", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.UserAccountData = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddMessage = new System.Windows.Forms.Button();
            this.usersBox = new System.Windows.Forms.ComboBox();
            this.AccountsButton = new System.Windows.Forms.Button();
            this.mailtopsBox = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.MessagesListVievContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.поместитьВСпамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСообщениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поместитьВКорзинуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьБезвозвратноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.MessageContentBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AddAttachment = new System.Windows.Forms.Button();
            this.CancelSendButtton = new System.Windows.Forms.Button();
            this.SendButtton = new System.Windows.Forms.Button();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTo = new System.Windows.Forms.TextBox();
            this.textBoxFrom = new System.Windows.Forms.TextBox();
            this.listView4 = new System.Windows.Forms.ListView();
            this.Attachments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.отменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.LabelInfo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выходИзАккаунтаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходИзАккаунтаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserAccountData.SuspendLayout();
            this.mailtopsBox.SuspendLayout();
            this.MessagesListVievContextMenu.SuspendLayout();
            this.MessageContentBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Attachments.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserAccountData
            // 
            this.UserAccountData.Controls.Add(this.listView1);
            this.UserAccountData.Controls.Add(this.AddMessage);
            this.UserAccountData.Controls.Add(this.usersBox);
            this.UserAccountData.Controls.Add(this.AccountsButton);
            this.UserAccountData.Location = new System.Drawing.Point(11, 23);
            this.UserAccountData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UserAccountData.Name = "UserAccountData";
            this.UserAccountData.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.UserAccountData.Size = new System.Drawing.Size(165, 573);
            this.UserAccountData.TabIndex = 0;
            this.UserAccountData.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            listViewGroup21.Header = "Основные";
            listViewGroup21.Name = "Based";
            listViewGroup21.Tag = "";
            listViewGroup22.Header = "Дополнительные";
            listViewGroup22.Name = "others";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup21,
            listViewGroup22});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(4, 154);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
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
            this.AddMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.AccountsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
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
            this.mailtopsBox.Controls.Add(this.LabelInfo);
            this.mailtopsBox.Controls.Add(this.RefreshButton);
            this.mailtopsBox.Controls.Add(this.listView2);
            this.mailtopsBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mailtopsBox.Location = new System.Drawing.Point(181, 27);
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
            this.listView2.ContextMenuStrip = this.MessagesListVievContextMenu;
            this.listView2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView2.ForeColor = System.Drawing.Color.Black;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 56);
            this.listView2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(276, 507);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Tile;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // MessagesListVievContextMenu
            // 
            this.MessagesListVievContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поместитьВСпамToolStripMenuItem,
            this.удалитьСообщениеToolStripMenuItem});
            this.MessagesListVievContextMenu.Name = "MessagesListVievContextMenu";
            this.MessagesListVievContextMenu.Size = new System.Drawing.Size(186, 48);
            // 
            // поместитьВСпамToolStripMenuItem
            // 
            this.поместитьВСпамToolStripMenuItem.Name = "поместитьВСпамToolStripMenuItem";
            this.поместитьВСпамToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.поместитьВСпамToolStripMenuItem.Text = "Поместить в спам";
            this.поместитьВСпамToolStripMenuItem.Click += new System.EventHandler(this.поместитьВСпамToolStripMenuItem_Click);
            // 
            // удалитьСообщениеToolStripMenuItem
            // 
            this.удалитьСообщениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.поместитьВКорзинуToolStripMenuItem,
            this.удалитьБезвозвратноToolStripMenuItem});
            this.удалитьСообщениеToolStripMenuItem.Name = "удалитьСообщениеToolStripMenuItem";
            this.удалитьСообщениеToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.удалитьСообщениеToolStripMenuItem.Text = "Удалить сообщение";
            // 
            // поместитьВКорзинуToolStripMenuItem
            // 
            this.поместитьВКорзинуToolStripMenuItem.Name = "поместитьВКорзинуToolStripMenuItem";
            this.поместитьВКорзинуToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.поместитьВКорзинуToolStripMenuItem.Text = "Поместить в корзину";
            this.поместитьВКорзинуToolStripMenuItem.Click += new System.EventHandler(this.поместитьВКорзинуToolStripMenuItem_Click);
            // 
            // удалитьБезвозвратноToolStripMenuItem
            // 
            this.удалитьБезвозвратноToolStripMenuItem.Name = "удалитьБезвозвратноToolStripMenuItem";
            this.удалитьБезвозвратноToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.удалитьБезвозвратноToolStripMenuItem.Text = "Удалить безвозвратно";
            this.удалитьБезвозвратноToolStripMenuItem.Click += new System.EventHandler(this.удалитьБезвозвратноToolStripMenuItem_Click);
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
            this.label3.Size = new System.Drawing.Size(0, 19);
            this.label3.TabIndex = 6;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubjectLabel.Location = new System.Drawing.Point(5, 17);
            this.SubjectLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(0, 26);
            this.SubjectLabel.TabIndex = 7;
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
            this.MessageContentBox.Location = new System.Drawing.Point(484, 23);
            this.MessageContentBox.Name = "MessageContentBox";
            this.MessageContentBox.Size = new System.Drawing.Size(578, 558);
            this.MessageContentBox.TabIndex = 9;
            this.MessageContentBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.AddAttachment);
            this.groupBox1.Controls.Add(this.CancelSendButtton);
            this.groupBox1.Controls.Add(this.SendButtton);
            this.groupBox1.Controls.Add(this.textBoxSubject);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxTo);
            this.groupBox1.Controls.Add(this.textBoxFrom);
            this.groupBox1.Controls.Add(this.listView4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(478, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 569);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(21, 133);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 273);
            this.textBox1.TabIndex = 19;
            // 
            // AddAttachment
            // 
            this.AddAttachment.BackColor = System.Drawing.SystemColors.Control;
            this.AddAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAttachment.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddAttachment.Location = new System.Drawing.Point(113, 428);
            this.AddAttachment.Name = "AddAttachment";
            this.AddAttachment.Size = new System.Drawing.Size(24, 23);
            this.AddAttachment.TabIndex = 18;
            this.AddAttachment.Text = "+";
            this.AddAttachment.UseCompatibleTextRendering = true;
            this.AddAttachment.UseVisualStyleBackColor = false;
            this.AddAttachment.Click += new System.EventHandler(this.AddAttachment_Click);
            // 
            // CancelSendButtton
            // 
            this.CancelSendButtton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelSendButtton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelSendButtton.Location = new System.Drawing.Point(21, 512);
            this.CancelSendButtton.Name = "CancelSendButtton";
            this.CancelSendButtton.Size = new System.Drawing.Size(116, 34);
            this.CancelSendButtton.TabIndex = 17;
            this.CancelSendButtton.Text = "Отмена";
            this.CancelSendButtton.UseVisualStyleBackColor = true;
            this.CancelSendButtton.Click += new System.EventHandler(this.CancelSendButtton_Click);
            // 
            // SendButtton
            // 
            this.SendButtton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButtton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButtton.Location = new System.Drawing.Point(429, 512);
            this.SendButtton.Name = "SendButtton";
            this.SendButtton.Size = new System.Drawing.Size(116, 34);
            this.SendButtton.TabIndex = 16;
            this.SendButtton.Text = "Отправить";
            this.SendButtton.UseVisualStyleBackColor = true;
            this.SendButtton.Click += new System.EventHandler(this.SendButtton_Click);
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSubject.Location = new System.Drawing.Point(104, 20);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(465, 27);
            this.textBoxSubject.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(17, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Тема:";
            // 
            // textBoxTo
            // 
            this.textBoxTo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTo.Location = new System.Drawing.Point(104, 91);
            this.textBoxTo.Name = "textBoxTo";
            this.textBoxTo.Size = new System.Drawing.Size(220, 23);
            this.textBoxTo.TabIndex = 12;
            // 
            // textBoxFrom
            // 
            this.textBoxFrom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFrom.Location = new System.Drawing.Point(104, 58);
            this.textBoxFrom.Name = "textBoxFrom";
            this.textBoxFrom.Size = new System.Drawing.Size(220, 23);
            this.textBoxFrom.TabIndex = 11;
            // 
            // listView4
            // 
            this.listView4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView4.ContextMenuStrip = this.Attachments;
            this.listView4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listView4.HideSelection = false;
            this.listView4.LargeImageList = this.imageList1;
            this.listView4.Location = new System.Drawing.Point(143, 428);
            this.listView4.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(402, 61);
            this.listView4.StateImageList = this.imageList1;
            this.listView4.TabIndex = 10;
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.Tile;
            // 
            // Attachments
            // 
            this.Attachments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменаToolStripMenuItem});
            this.Attachments.Name = "Attachments";
            this.Attachments.Size = new System.Drawing.Size(119, 26);
            // 
            // отменаToolStripMenuItem
            // 
            this.отменаToolStripMenuItem.Name = "отменаToolStripMenuItem";
            this.отменаToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.отменаToolStripMenuItem.Text = "Удалить";
            this.отменаToolStripMenuItem.Click += new System.EventHandler(this.отменаToolStripMenuItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(17, 428);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Вложения:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(17, 90);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Кому:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(17, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "От:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RefreshButton
            // 
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RefreshButton.ForeColor = System.Drawing.Color.Cornsilk;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.Location = new System.Drawing.Point(236, 11);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(40, 43);
            this.RefreshButton.TabIndex = 1;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // LabelInfo
            // 
            this.LabelInfo.AutoSize = true;
            this.LabelInfo.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelInfo.Location = new System.Drawing.Point(5, 28);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(0, 18);
            this.LabelInfo.TabIndex = 2;
            this.LabelInfo.Click += new System.EventHandler(this.LabelInfo_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходИзАккаунтаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1076, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходИзАккаунтаToolStripMenuItem
            // 
            this.выходИзАккаунтаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходИзАккаунтаToolStripMenuItem1,
            this.закрытьToolStripMenuItem});
            this.выходИзАккаунтаToolStripMenuItem.Name = "выходИзАккаунтаToolStripMenuItem";
            this.выходИзАккаунтаToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.выходИзАккаунтаToolStripMenuItem.Text = "Опции";
            this.выходИзАккаунтаToolStripMenuItem.Click += new System.EventHandler(this.выходИзАккаунтаToolStripMenuItem_Click);
            // 
            // выходИзАккаунтаToolStripMenuItem1
            // 
            this.выходИзАккаунтаToolStripMenuItem1.Name = "выходИзАккаунтаToolStripMenuItem1";
            this.выходИзАккаунтаToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.выходИзАккаунтаToolStripMenuItem1.Text = "Выход из аккаунта";
            this.выходИзАккаунтаToolStripMenuItem1.Click += new System.EventHandler(this.выходИзАккаунтаToolStripMenuItem1_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1076, 602);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MessageContentBox);
            this.Controls.Add(this.mailtopsBox);
            this.Controls.Add(this.UserAccountData);
            this.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "MailClient0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.UserAccountData.ResumeLayout(false);
            this.mailtopsBox.ResumeLayout(false);
            this.mailtopsBox.PerformLayout();
            this.MessagesListVievContextMenu.ResumeLayout(false);
            this.MessageContentBox.ResumeLayout(false);
            this.MessageContentBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Attachments.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ContextMenuStrip MessagesListVievContextMenu;
        private System.Windows.Forms.ToolStripMenuItem поместитьВСпамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСообщениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поместитьВКорзинуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьБезвозвратноToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTo;
        private System.Windows.Forms.TextBox textBoxFrom;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button CancelSendButtton;
        private System.Windows.Forms.Button SendButtton;
        private System.Windows.Forms.Button AddAttachment;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ContextMenuStrip Attachments;
        private System.Windows.Forms.ToolStripMenuItem отменаToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходИзАккаунтаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходИзАккаунтаToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
    }
}

