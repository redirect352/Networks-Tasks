using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailClasses;

namespace MyMailClient
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
            Password = "";
            Login = "";
            this.DialogResult = DialogResult.Cancel;
        }
        public String Password { get; set; }
        public String Login { get; set; }

        public ImapClient client = null;


        private void EnterButton_Click(object sender, EventArgs e)
        {
            if (!ValidChecker.IsValidEmail(UserEmailBox.Text))
            {
                label3.Text = "Введите корректный email";
                return;
            }
            string email = UserEmailBox.Text, passw = UserPasswordBox.Text;
            ImapClient im = new ImapClient();
            im.ImapServerName = "imap.mail.ru";
            im.port = 993;
            im.UserLogin = email;
            im.UserPassword = passw;
            im.ConnectToServer();

            try
            {
                im.AuthOnServer();
            }
            catch (IncorrectLoginorPasswExeption ex)
            {

                label3.Text = "Некорректный пароль или email";
               
                return;

            }
            catch {
                label3.Text = "Ошибка входа. Попробуйте снова";
                return;
            }
            Password = passw;
            Login = email;
            client = im;
            this.DialogResult = DialogResult.OK;
            this.Close();


        }
    }
}
