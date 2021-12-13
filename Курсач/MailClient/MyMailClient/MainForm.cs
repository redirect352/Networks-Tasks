using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2;
using MailClasses;
using MailClasses.User;
using MailClasses.MimeWork;
using System.IO;
using System.Net.Mail;

namespace MyMailClient
{
    public partial class MainForm : Form
    {


        List<int> LastUNSEEN = new List<int>();

        const string mailFolder = "mail";
        mailFolderInfo mailFolderInfo = null;
        int selectedmail = -1;

        LinkedList<AuthorizedUser> authorizedUsers = new LinkedList<MailClasses.User.AuthorizedUser> { };
        AuthorizedUser currentUser = null;
        public MainForm()
        {
            InitializeComponent();
            FilesWork.CheckAllNeededFoldersExists("");
            MessageContentBox.Visible = true;
            groupBox1.Visible = false;
            /*
            DateTime time = new DateTime();
            MimeDecrypter.DecryptMessage("mail\\testmail898989-mails\\Inbox\\15.txt",webBrowser1, listView3,imageList1);
            MimeDecrypter.GetSubjectAndDate("mail\\testmail898989-mails\\Inbox\\15.txt",ref time);
            MimeDecrypter.SetHeaders("mail\\testmail898989-mails\\Inbox\\15.txt", SubjectLabel, label3, label1,  label2);
         
            List<int> und = new List<int>();
            und.Add(1);
            und.Add(2);
            und.Add(3);
            FilesWork.ShowEmailsInFolder("mail\\testmail898989-mails\\Inbox",listView2,ref mailFolderInfo,und);*/    
        }
        //testmail898989@mail.ru
        //8aofts6M06dvKV7aiaBD
        private void AccountsButton_Click(object sender, EventArgs e)
        {
            EnterForm ent = new EnterForm();
            if (ent.ShowDialog() == DialogResult.OK)
            {
                usersBox.Items.Add(ent.Login);
                authorizedUsers.AddLast(new AuthorizedUser(ent.Login, ent.Password, ent.client));
                currentUser = authorizedUsers.Last.Value;
                usersBox.SelectedIndex = usersBox.Items.Count - 1;
                usersBox.Enabled = true;
                currentUser.imapClient.LoadAllBoxes("\"/\"");
                FilesWork.CheckAllNeededFoldersExists(ent.Login.Substring(0, ent.Login.IndexOf("@")));
                SetNamesToListWiev();


            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*FileStream F = new FileStream("users.dat", FileMode.Create, FileAccess.Write);

            try
            {
                foreach (AuthorizedUser au in authorizedUsers) {
                    au.imapClient.DisconnectFromServer();
                    string s = au.login + "|" + au.passw + "|";
                    byte[] buf = Encoding.UTF8.GetBytes(s);
                    F.WriteAsync(buf, 0, buf.Length);
                    //Закрыть все соединения
                }
            }
            finally
            {
                F.Close();
            }*/
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            try {
                FileStream F = new FileStream("users.dat", FileMode.Open, FileAccess.Read);

                try
                {
                    byte[] buf = new byte[4048];
                    int byteRead = F.Read(buf, 0, 4048);
                    string[] s = (Encoding.UTF8.GetString(buf, 0, byteRead)).Split(new char[] { '|' });

                    if (s.Length < 2)
                        return;
                    for (int i = 0; i < s.Length - 1; i += 2)
                    {
                        //MessageBox.Show(s[i] + " " +s[i+1]);

                        ImapClient im = new ImapClient();
                        im.ImapServerName = "imap.mail.ru";
                        im.port = 993;
                        im.UserLogin = s[i];
                        im.UserPassword = s[i + 1];
                        im.ConnectToServer();

                        try
                        {
                            im.AuthOnServer();
                            authorizedUsers.AddLast(new AuthorizedUser(s[i], s[i + 1], im));
                            currentUser = authorizedUsers.Last.Value;
                            usersBox.Items.Add(s[i]);
                            if (!usersBox.Enabled)
                            {
                                usersBox.Enabled = true;
                                usersBox.SelectedIndex = usersBox.Items.Count - 1;
                            }
                            //Загрузка ящиков
                            currentUser.imapClient.LoadAllBoxes("\"/\"");
                            SetNamesToListWiev();

                        }
                        catch (IncorrectLoginorPasswExeption ex)
                        {
                            MessageBox.Show("Неверный пароль аккаунта " + s[i] + ". Возможно вы поменяли пароль.Авторизуйтесь снова");
                            return;
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка входа в аккаунт " + s[i]);
                            return;
                        }

                    }
                    try { currentUser = authorizedUsers.Last.Value; }
                    catch { }


                }
                finally
                {
                    F.Close();
                }

            }
            catch (FileNotFoundException F) {
                //файла не существует, ну в другой раз))
            }

        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (currentUser == null)
                return;
            string AccountName = currentUser.login.Substring(0, currentUser.login.IndexOf("@"));
            FilesWork.CheckAllNeededFoldersExists(AccountName);

            var selItem = listView1.SelectedItems;
            if (selItem.Count <= 0)
                return;
            mailFolderInfo = new mailFolderInfo();

            string foldPath = "mail\\" + AccountName + "-mails\\" + selItem[0].Text;
            mailFolderInfo.path = foldPath;

            int BoxNum = currentUser.imapClient.FindBox(selItem[0].Text) ;

            // здесб
            if (BoxNum >= 0)
            {
                LastUNSEEN = await Task.Run(()=>currentUser.imapClient.GetNewEmailsInBox(BoxNum, FilesWork.GetAllLoadedEmailsInForder(foldPath), foldPath));
                //LastUNSEEN = currentUser.imapClient.GetNewEmailsInBox(BoxNum, FilesWork.GetAllLoadedEmailsInForder(foldPath), foldPath);
                mailFolderInfo.number = BoxNum;
    

            }
            
            //FilesWork.ShowEmailsInFolder("mail\\" + AccountName + "-mails\\" + selItem[0].Text,listView2,ref mailFolderInfo);       
            FilesWork.ShowEmailsInFolder(mailFolderInfo.path, listView2, ref mailFolderInfo, LastUNSEEN);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mailFolderInfo == null)
                return;


            var selItem = listView2.SelectedItems;
            if (selItem.Count <= 0)
                return;
     
            var item = selItem[0];
            int id = mailFolderInfo.GetUidByIndex(item.Text);
            if (item.ForeColor == Color.DarkBlue) {
                item.ForeColor = Color.Black;
                int l = LastUNSEEN.IndexOf(id);
                if (l >= 0)
                    LastUNSEEN.RemoveAt(l);
            }

           
            selectedmail = id;
            if (id >=0 ) {
                string path = mailFolderInfo.path + "\\" + (id).ToString() + ".txt";
                MimeDecrypter.DecryptMessage(path, webBrowser1, listView3,imageList1);
                MimeDecrypter.SetHeaders(path, SubjectLabel, label3, label1, label2);
            }        
        }

        //---------------------------
        private void SetNamesToListWiev()
        {
            if (currentUser == null)
                return;
            ImapClient imap = currentUser.imapClient;
            if (imap.InboxNum >= 0)
            {
                ListViewItem l = new ListViewItem("Inbox");
                l.Group = listView1.Groups[0];
                listView1.Items.Add(l);
               
            }

               
            if (imap.SendNum >= 0)
            {
                ListViewItem l = new ListViewItem("Sent");
                l.Group = listView1.Groups[0];
                listView1.Items.Add(l);
            }

            if (imap.SpamNum >= 0)
            {
                ListViewItem l = new ListViewItem("Spam");
                l.Group = listView1.Groups[0];
                listView1.Items.Add(l);
            }

            if (imap.TrashNum>= 0)
            {
                ListViewItem l = new ListViewItem("Trash");
                l.Group = listView1.Groups[0];
                listView1.Items.Add(l);
            }






        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private void mailtopsBox_Enter(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mailFolderInfo == null) {
                return;
            }
            var selItem = listView3.SelectedItems;
            if (selItem.Count <= 0)
                return;
            var item = selItem[0];

            string path =mailFolderInfo.path+"\\"+selectedmail.ToString()+ "_attachments"+"\\"+ item.Text;
            try
            {
                System.Diagnostics.Process.Start(path);
            }
            catch {
                MessageBox.Show("Невозможно отрыть файл стандарными сре");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void поместитьВСпамToolStripMenuItem_Click(object sender, EventArgs e)
        {


            var selItem = listView2.SelectedItems;
            if (selItem.Count <= 0)
                return;
            var item = selItem[0];
            try {
                int id = mailFolderInfo.GetUidByIndex(item.Text);
                if (id >= 0)
                {
                    string path = mailFolderInfo.path + "\\" + (id).ToString() + ".txt";
                    int BoxNum = currentUser.imapClient.FindBox("Spam");
                    try
                    {
                        string AccountName = currentUser.login.Substring(0, currentUser.login.IndexOf("@"));
                        string foldPath = "mail\\" + AccountName + "-mails\\" +"Spam" ;
                        if (mailFolderInfo.number != BoxNum)
                        {
                            
                            File.Copy(path, foldPath + "\\" + (id).ToString() + ".txt");
                            File.Delete(path);

                            FilesWork.ShowEmailsInFolder(mailFolderInfo.path, listView2, ref mailFolderInfo, LastUNSEEN);
                            await Task.Run(() => currentUser.imapClient.ChangeFolder(mailFolderInfo.number, BoxNum, id));
                            LabelInfo.Text = "Cообщение помещено в спам";
                            timer1.Enabled = true;
                        }
                    }
                    catch {
                        MessageBox.Show("Ошибка, попробуйте снова");

                    }
                }

                }
            catch { }

        }

        private void поместитьВКорзинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selItem = listView2.SelectedItems;
            if (selItem.Count <= 0)
                return;
            var item = selItem[0];
            try
            {
                int id = mailFolderInfo.GetUidByIndex(item.Text);
                if (id >= 0)
                {
                    string path = mailFolderInfo.path + "\\" + (id).ToString() + ".txt";
                    int BoxNum = currentUser.imapClient.FindBox("Trash");
                    try
                    {
                        string AccountName = currentUser.login.Substring(0, currentUser.login.IndexOf("@"));
                        string foldPath = "mail\\" + AccountName + "-mails\\" + "Trash";
                        if (mailFolderInfo.number != BoxNum)
                        {
                            currentUser.imapClient.ChangeFolder(mailFolderInfo.number, BoxNum, id);
                            File.Copy(path, foldPath + "\\" + (id).ToString() + ".txt");
                            File.Delete(path);

                            FilesWork.ShowEmailsInFolder(mailFolderInfo.path, listView2, ref mailFolderInfo, LastUNSEEN);
                            LabelInfo.Text = "Cообщение помещено в Корзину";
                            timer1.Enabled = true;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, попробуйте снова");

                    }
                }

            }
            catch { }
        }

        private void удалитьБезвозвратноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selItem = listView2.SelectedItems;
            if (selItem.Count <= 0)
                return;
            var item = selItem[0];

            try
            {
                int id = mailFolderInfo.GetUidByIndex(item.Text);
                if (id >= 0)
                {
                    string path = mailFolderInfo.path + "\\" + (id).ToString() + ".txt";
                    try
                    {
                        string AccountName = currentUser.login.Substring(0, currentUser.login.IndexOf("@"));
                        currentUser.imapClient.DeleteMessage(id, mailFolderInfo.number);
                        File.Delete(path);
                        FilesWork.ShowEmailsInFolder(mailFolderInfo.path, listView2, ref mailFolderInfo, LastUNSEEN);
                        LabelInfo.Text = "Cообщение удалено";
                        timer1.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка, попробуйте снова");
                    }
                }

            }
            catch { }

        }

        private void MainForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            FileStream F = new FileStream("users.dat", FileMode.Create, FileAccess.Write);

            try
            {
                foreach (AuthorizedUser au in authorizedUsers)
                {
                    au.imapClient.DisconnectFromServer();
                    string s = au.login + "|" + au.passw + "|";
                    byte[] buf = Encoding.UTF8.GetBytes(s);
                    F.Write(buf, 0, buf.Length);
                    //Закрыть все соединения
                }
            }
            finally
            {
                F.Close();
            }
        }


        // =========================================================
        // =========================================================
        //Отправка сообщений

        List<string> MessageAttachments = new List<string>();

        private void AddMessage_Click(object sender, EventArgs e)
        {
            listView2.Enabled = false;
            listView1.Enabled = false;
            if (currentUser==null) {
                return;
            }
            groupBox1.Visible = true;
            MessageContentBox.Visible = false;
            ClearInputs();

        }

        private void SendButtton_Click(object sender, EventArgs e)
        {


            string From = textBoxFrom.Text;
            string To = textBoxTo.Text;
            string Content = textBox1.Text;

            if (!IsValidEmail(To)) {
                MessageBox.Show("Некорректный email получателя");
                return;
            }

            if (From == "")
                From = currentUser.login;
            MailAddress from = new MailAddress(currentUser.login, From);

            MailAddress to = new MailAddress(To);

            MailMessage m = new MailMessage(from, to);

            m.Subject = textBoxSubject.Text;
            m.Body = Content;
            m.IsBodyHtml = true;
            foreach (string s in MessageAttachments) {
                if (File.Exists(s)) {
                    m.Attachments.Add(new Attachment(s));
         
                }

            }
            try
            {
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                // логин и пароль
                smtp.Credentials = new System.Net.NetworkCredential (currentUser.login, currentUser.passw);
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch(Exception ex)
            
            {
                MessageBox.Show("Cannot send a message");
                return;

            }

            listView2.Enabled = true;
            listView1.Enabled = true;
            MessageContentBox.Visible = true;
            groupBox1.Visible = false;
            LabelInfo.Text = "Cообщение отправлено";
            timer1.Enabled = true;
        }



        private void CancelSendButtton_Click(object sender, EventArgs e)
        {
            MessageContentBox.Visible = true;
            groupBox1.Visible = false;
            listView2.Enabled = true ;
            listView1.Enabled = true;
        }


        void ClearInputs()
        {
            textBoxFrom.Text = "";
            textBoxTo.Text = "";
            textBoxSubject.Text = "";
            textBox1.Text = "";
            listView4.Clear();
            MessageAttachments.Clear();
        }

        private void AddAttachment_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                var files = openFileDialog1.FileNames;
                foreach (string s in files)
                {
                    ListViewItem viewItem = new ListViewItem(Path.GetFileName(s));
                    string tmp = Path.GetExtension(s).Replace(".", "");
                    if (File.Exists("icons\\" + tmp + ".png"))
                        viewItem.ImageKey = tmp + ".png";
                    else
                        viewItem.ImageKey = "blank.png";
                    listView4.Items.Add(viewItem);
                    MessageAttachments.Add(s);


                }
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem l in listView4.SelectedItems )
            {
                listView4.Items.Remove(l);
                string filename = l.Text;
                var DeleteVals = new List<string>();
                foreach (string s in MessageAttachments) {
                    if (!(filename == Path.GetFileName(s)))
                    {
                        DeleteVals.Add(s);
                    }
                }
                MessageAttachments = DeleteVals;
            }
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            if (currentUser == null || mailFolderInfo==null)
                return;
            RefreshButton.Enabled = false;
            listView1.Enabled = false;
            int BoxNum = mailFolderInfo.number;
            
            // здесб
            if (BoxNum >= 0)
            {
                LastUNSEEN = await Task.Run(() => currentUser.imapClient.GetNewEmailsInBox(BoxNum, FilesWork.GetAllLoadedEmailsInForder(mailFolderInfo.path), mailFolderInfo.path));
                //LastUNSEEN = currentUser.imapClient.GetNewEmailsInBox(BoxNum, FilesWork.GetAllLoadedEmailsInForder(foldPath), foldPath);
            }

            //FilesWork.ShowEmailsInFolder("mail\\" + AccountName + "-mails\\" + selItem[0].Text,listView2,ref mailFolderInfo);       
            FilesWork.ShowEmailsInFolder(mailFolderInfo.path, listView2, ref mailFolderInfo, LastUNSEEN);
            listView1.Enabled = true;
            RefreshButton.Enabled = true;
            LabelInfo.Text = "Cообщения обновлены";
            timer1.Enabled = true;
        }

        private void LabelInfo_Click(object sender, EventArgs e)
        {
            LabelInfo.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false; 
            LabelInfo.Text = "";
        }

        private void выходИзАккаунтаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходИзАккаунтаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
                return;
            usersBox.Items.Remove(currentUser.login);
            usersBox.SelectedText = "";
            currentUser.imapClient.DisconnectFromServer();

            authorizedUsers.Remove(currentUser);
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            ClearInputs();

            webBrowser1.DocumentText = "";
            SubjectLabel.Text = "";
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            usersBox.Text = "";
            currentUser = null;
            mailFolderInfo = null;
     
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            if (listView2.Items.Count == 0) { return; }

            if (SortButton.Text == "V")
            {
                SortButton.Text = @"/\";
                FilesWork.SortListView(SortOrder.Descending, listView2);
            }
            else
            {
                SortButton.Text = "V";
                FilesWork.SortListView(SortOrder.Ascending,listView2);
            }
        }
    }
}
