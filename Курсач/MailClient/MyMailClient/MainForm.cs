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
using System.IO;

namespace MyMailClient
{
    public partial class MainForm : Form
    {
        LinkedList<AuthorizedUser> authorizedUsers = new LinkedList<MailClasses.User.AuthorizedUser> { };

        public MainForm()
        {
            InitializeComponent();

            
        }
        //testmail898989@mail.ru
        //8aofts6M06dvKV7aiaBD
        private void AccountsButton_Click(object sender, EventArgs e)
        {
            EnterForm ent = new EnterForm();
            if (ent.ShowDialog() == DialogResult.OK)
            {
                usersBox.Items.Add(ent.Login);
                authorizedUsers.AddLast( new AuthorizedUser(ent.Login, ent.Password,ent.client));
                usersBox.SelectedIndex = usersBox.Items.Count - 1;
                usersBox.Enabled = true;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream F = new FileStream("users.dat", FileMode.Create,FileAccess.Write);

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
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
          
            listView1.Items[0].Selected = true;


            try {
                FileStream F = new FileStream("users.dat", FileMode.Open, FileAccess.Read);

                try
                {
                    byte[] buf = new byte[4048];
                    int byteRead = F.Read(buf, 0 ,4048);
                    string[] s = (Encoding.UTF8.GetString(buf,0, byteRead)).Split(new char[] {'|' });
                  
                    if (s.Length < 2)
                        return;
                    for (int i = 0; i < s.Length-1; i += 2) 
                    {
                        //MessageBox.Show(s[i] + " " +s[i+1]);
                        
                        ImapClient im = new ImapClient();
                        im.ImapServerName = "imap.mail.ru";
                        im.port = 993;
                        im.UserLogin = s[i];
                        im.UserPassword = s[i+1];
                        im.ConnectToServer();

                        try
                        {
                            im.AuthOnServer();
                            authorizedUsers.AddLast(new AuthorizedUser(s[i],s[i+1],im));
                            usersBox.Items.Add(s[i]);
                            if (!usersBox.Enabled)
                            {
                                usersBox.Enabled = true;
                                usersBox.SelectedIndex = usersBox.Items.Count - 1;
                            }
                        }
                        catch (IncorrectLoginorPasswExeption ex)
                        {
                            MessageBox.Show("Неверный пароль аккаунта " + s[i]+ ". Возможно вы поменяли пароль.Авторизуйтесь снова");
                            return;
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка входа в аккаунт "+ s[i]);
                            return;
                        }

                    }



                }
                finally
                {
                    F.Close();
                }

            }
            catch(FileNotFoundException F) {
                //файла не существует, ну в другой раз))
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddMessage_Click(object sender, EventArgs e)
        {
            ImapClient im = authorizedUsers.First.Value.imapClient;
            im.SelectBox("INBOX");
            im.GetAllEmailsInBox("D:\\tmp","email",".txt");
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
