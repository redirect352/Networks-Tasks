using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Net.Security;

namespace WindowsFormsApp2
{
    public partial class EnterForm : Form
    {
        string host;
        int port;
        public EnterForm()
        {
            InitializeComponent();
            Password = "";
            Login = "";
        }
        public EnterForm(string h, int p)
        {
            InitializeComponent();
            host = h;
            port = p;
            Password = "";
            Login = "";
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        public String Password { get; set; }
        public String Login { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Form1.IsValidEmail(UserEmailBox.Text))
            {
                label3.Text = "Введите корректный email";
                return;
            }
            string email = UserEmailBox.Text, passw = UserPasswordBox.Text;
            Form1 f = (Form1)this.Owner;


            TcpClient client = new TcpClient();
            try
            {
                client.Connect(host, port);
               // MessageBox.Show("Подключено к серверу " + host);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            SslStream mainStream = new SslStream(client.GetStream());

            //authPasswordForSmtpMailRu

            mainStream.ReadTimeout = 10000;
            mainStream.WriteTimeout = 10000;

            try
            {
                mainStream.AuthenticateAsClient(host, null, System.Security.Authentication.SslProtocols.Tls, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }


            mainStream.ReadTimeout = 1000;
            mainStream.WriteTimeout = 1000;
            string My_IP = new WebClient().DownloadString("http://icanhazip.com/");

            string[] commands = { "EHLO "+My_IP,"AUTH LOGIN",Form1.Base64Encode(email),
                                   Form1.Base64Encode(passw),"QUIT"};

            Form1.SendMessage(mainStream, commands[0]);
            Form1.ReadAnswer(mainStream);

            Form1.SendMessage(mainStream, commands[1]);
            Form1.ReadAnswer(mainStream);

            Form1.SendMessage(mainStream, commands[2]);
            Form1.ReadAnswer(mainStream);

            Form1.SendMessage(mainStream, commands[3]);
            Form1.ReadAnswer(mainStream);
            string ver ="333";
            while (Form1.GetAnswerCode(ver) <400 && Form1.GetAnswerCode(ver) > 300 )
                ver = Form1.ReadAnswer(mainStream);
            if (Form1.GetAnswerCode(ver) != 235) {
                label3.Text = "Неверный логин или пароль";
                mainStream.Close();
                client.Close();
                return;
            }
            Password = passw;
            Login = email;
            //Закрытие соединения
            Form1.SendMessage(mainStream, commands[4]);
            MessageBox.Show(Form1.ReadAnswer(mainStream));
            mainStream.Close();
            client.Close();


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EnterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
