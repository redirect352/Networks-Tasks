using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net.Mime;
using MimeKit;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int port = 993;
        string host = "imap.mail.ru";
        bool EnteredInAccount = false;
        string UserEmail = "";
        string UserPassword = "";
        const string CRLF = "\r\n";

        SslStream mainStream = null;

        public string Host {
            get {
                return host;
            }
            set {
                host = value;
            }

        }
        public int Port {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }

        

        public Form1()
        {
            InitializeComponent();



            /* string s = "* 722 EXISTS";
            if (Regex.IsMatch(s, @"\* \d+ EXISTS"))
            {
                Match m = Regex.Match(s, @"\d+");
                int k = int.Parse(m.Value);
                MessageBox.Show(k.ToString());
               */
        }

        public static bool OutputText(string s, ListBox lb) 
        {
            lb.Items.Add(s);
            return true;
        }


        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*if (!EnteredInAccount) {
                OutputText("Войдите в аккаунт для отправки сообщений", listBox1);
                return;
            }*/
            /*
            string RecEmail = EmailBox.Text;
            if (!IsValidEmail(RecEmail))
            {
                OutputText("Укажите корректный email получателя",listBox1);
                return;
            }

            string subject = SubjectBox.Text;
            string content = MainTextBox.Text;
            if (subject == "") {
                OutputText("Заполните поле \"тема\"", listBox1);
                return;
            }
            if (content == "")
            {
                OutputText("Заполните поле \"содержание\"", listBox1);
                return;
            }
            

            string My_IP = "";
            try {
                My_IP = new WebClient().DownloadString("http://icanhazip.com/");
            }
            catch (Exception ex){
                OutputText("Не удается определить IP устройства", listBox1);
                OutputText(ex.Message, listBox1);
                return;
            }

            */
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(host, port);
                OutputText("Подключено к серверу " + host, listBox1);
            }
            catch (Exception ex)
            {
                OutputText("Невозможно подключиться к данному smtp серверу", listBox1);
                OutputText(ex.Message, listBox1);
                return;
            }
            
             mainStream = new SslStream( client.GetStream());

            mainStream.ReadTimeout = 1000;
            mainStream.WriteTimeout = 1000;

            mainStream.AuthenticateAsClient(host, null, System.Security.Authentication.SslProtocols.Tls,false) ;

            string[] commands = { "A002 CAPABILITY" ,
                "a001 LOGIN testmail898989@mail.ru 8aofts6M06dvKV7aiaBD",
                "A142 LIST \"/\" \"\""
                };

            //"А004 LIST \"/\" *", 
            //"A142 SELECT INBOX"
            // "А005 EXAMINE INBOX"
            //SEARCH




            for (int i =0; i < commands.Length; i++) {

                if (SendMessage(mainStream, commands[i]))
                {
                    OutputText(commands[i], listBox1);
                }
                else {
                    OutputText("Error Sending: " + commands[i], listBox1);
                    break;
                }
                
                OutputText( ReadAnswer(mainStream),listBox1);
                OutputText(ReadAnswer(mainStream), listBox1);
                if (i == 3) {
                    OutputText(ReadAnswer(mainStream), listBox1); ;
                    OutputText(ReadAnswer(mainStream), listBox1);
                    OutputText(ReadAnswer(mainStream), listBox1);
                    OutputText(ReadAnswer(mainStream), listBox1);
                    OutputText(ReadAnswer(mainStream), listBox1);
                        }
            }

            string s = (string)listBox1.Items[listBox1.Items.Count-2];
            string[] sq = s.Split(new char[] { '\n'});

        }
        

        public static bool SendMessage(SslStream stream, string Message) 
        {
            try{
                const string CRLF = "\r\n";

                byte[] messbytes = Encoding.UTF8.GetBytes(Message + CRLF);
                stream.Write(messbytes, 0, messbytes.Length);
                return true;
            }
            catch {
                return false;
            }
        
        }

        public static string ReadAnswer(SslStream stream) 
        {
            try
            {

                byte[] messbytes = new byte[1024];
                int byteread = stream.Read(messbytes, 0, 1024) ;
                string answer = Encoding.ASCII.GetString(messbytes,0,byteread); 
                return answer;
            }
            catch
            {
                return "";
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        public static int GetAnswerCode(string message) {
            int ret = -1;
            message = message.Substring(0,3);
            ret = int.Parse(message);
            return ret;

        }

        private void EnterInAccount_Click(object sender, EventArgs e)
        {
            EnterForm ent = new EnterForm(Host,Port);
            if (ent.ShowDialog() == DialogResult.OK) {
                EnteredInAccount = true;
                UserEmail = ent.Login;
                UserPassword = ent.Password;
            }
        }

        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string command = SubjectBox.Text;



                if (SendMessage(mainStream, command))
                {
                    OutputText(command, listBox1);
                }
                else
                {
                    OutputText("Error Sending: " + command, listBox1);
                   
                }

                OutputText(ReadAnswer(mainStream), listBox1);
                OutputText(ReadAnswer(mainStream), listBox1);

           
        }
    }
}
