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
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

            int port = 465;
            const  string CRLF = "\r\n";
            string server = "smtp.mail.ru";
            TcpClient client = new TcpClient();
            client.Connect(server, port);
            SslStream mainStream = new SslStream( client.GetStream());
            //X509CertificateCollection sert = new X509CertificateCollection();
            // X509Certificate st = new X509Certificate();
            mainStream.ReadTimeout = 5000;
            mainStream.WriteTimeout = 5000;
            //authPasswordForSmtpMailRu
            mainStream.AuthenticateAsClient(server, null, System.Security.Authentication.SslProtocols.Tls,false) ;

            string[] commands = { "EHLO 46.56.241.115","AUTH LOGIN",Base64Encode("testmail898989@mail.ru"),Base64Encode("8aofts6M06dvKV7aiaBD"),
                                   "MAIL FROM:<testmail898989@mail.ru>","RCPT TO:<redirect352@gmail.com>", "DATA", "Subject:Hello", "Some text." + CRLF+".",
                                   "QUIT"};

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
            }



            OutputText("Подключено к серверу " + server, listBox1);
            

            client.Close();
            OutputText("Соединение разорвано " + server, listBox1);

        }


        public static bool SendMessage(SslStream stream, string Message) 
        {
            try{
                const string CRLF = "\r\n";

                byte[] messbytes = Encoding.ASCII.GetBytes(Message + CRLF);
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
    }
}
