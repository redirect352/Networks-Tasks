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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int port = 465;
        string host = "smtp.mail.ru";
        bool EnteredInAccount = false;
        string UserEmail = "";
        string UserPassword = "";
        const string CRLF = "\r\n";

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
            
            SslStream mainStream = new SslStream( client.GetStream());

            mainStream.ReadTimeout = 1000;
            mainStream.WriteTimeout = 1000;
            //authPasswordForSmtpMailRu
            mainStream.AuthenticateAsClient(host, null, System.Security.Authentication.SslProtocols.Tls,false) ;
            //testmail898989@mail.ru
            //8aofts6M06dvKV7aiaBD

            string[] commands = { "EHLO "+My_IP,"AUTH LOGIN",Base64Encode("testmail898989@mail.ru"),Base64Encode("8aofts6M06dvKV7aiaBD"),
                                   "MAIL FROM:<testmail898989@mail.ru>","RCPT TO:<"+RecEmail+">", "DATA", "Subject:"+subject, content + CRLF+".",
                                   "QUIT"};





            commands[8] = @"
      Return-Path: eryq@rhine.gsfc.nasa.gov
Sender: john-bigboote
Date: Thu, 11 Apr 1996 01:10:30 -0500
From: Eryq <eryq@rhine.gsfc.nasa.gov>
Organization: Yoyodyne Propulsion Systems
X-Mailer: Mozilla 2.0 (X11; I; Linux 1.1.18 i486)
MIME-Version: 1.0
To: john-bigboote@eryq.pr.mcs.net
Subject: test of double-boundary behavior
Content-Type: multipart/mixed; boundary=""------------299A70B339B65A93542D2AE""

This is a multi - part message in MIME format.

--------------299A70B339B65A93542D2AE
--------------299A70B339B65A93542D2AE
Content - Type: text / html; charset = us - ascii
Content - Transfer - Encoding: 7bit
    Subject: [2] this should be text/html, but double-bound may mess it up

    <p> This message contains double boundaries all over the
    place.  We want to make sure that bad things don't happen.

<p>One bad thing is that the doubled-boundary above can
    be mistaken for a single boundary plus a bogus premature
    end of headers.

--------------299A70B339B65A93542D2AE
    --------------299A70B339B65A93542D2AE
    Content-Type: text/html; charset= us - ascii
    Subject: [4] this should be text/html, but double-bound may mess it up

    <p> Hello?  Am I here?
    
--------------299A70B339B65A93542D2AE
    
--------------299A70B339B65A93542D2AE
    Content-Type: text/html; charset= us - ascii
    Subject: [6] this should be text/html, but double-bound may mess it up

    <p> Hello?  Am I here?
    
--------------299A70B339B65A93542D2AE
    Content-Type: text/html; charset= us - ascii
    Subject: [7] this header is improperly terminated
--------------299A70B339B65A93542D2AE
    Content-Type: text/html; charset= us - ascii
    Subject: [8] this body is empty
    
--------------299A70B339B65A93542D2AE
    Content-Type: text/html; charset= us - ascii
    Subject: [9] this body also empty
    
--------------299A70B339B65A93542D2AE
    Content-Type: message/rfc822; name= ""/evil/filename"";


    From: (mailbox in US-ASCII)
To: (address in US-ASCII)
Subject: [10] an embedded message with broken headers
--------------299A70B339B65A93542D2AE
Content-Type: image/gif; name=""3d-eye.gif""
Content-Transfer-Encoding: base64
Subject: [11] just an image

R0lGODdhKAAoAPMAAAAAAAAAzN3u/76+voiIiG5ubszd7v///+fn5wAAAAAAAAAAAAAAAAAA
AAAAAAAAACwAAAAAKAAoAAAE/hDJSau9eJbMOy4bMoxkaZ5oCkoD6L5wLMfiWns41oZt7lM7
VujnC96IRVsPWQE4nxPjkvmsQmu8oc/KBUSVWk7XepGGLeNrxoxJO1MjILjthg/kWXQ6wO/7
+3dCeRRjfAKHiImJAV+DCF0BiW5VAo1CElaRh5NjlkeYmpyTgpcTAKGiaaSfpwKpVQaxVatL
rU8GaQdOBAQAB7+yXliXTrgAxsW4vFabv8BOtBsBt7cGvwCIT9nOyNEIxuC4zrqKzc9XbODJ
vs7Y5ewH3d7Fxe3jB4rj8t6PuNa6r2bhKQXN17FYCBMqTGiBzSNhx5g0nEMhlsSJjiRYvDjw
E0cdGxQ/gswosoKUkmuU2FnJcsSKGTBjypxJsyaICAA7
--------------299A70B339B65A93542D2AE
Content-Type: message/rfc822; name=""/evil/filename"";

From: (mailbox in US-ASCII)
To: (address in US-ASCII)
Subject: [12] another embedded message with broken headers
--------------299A70B339B65A93542D2AE--"
						
 + CRLF + "." ;

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
            mainStream.Close();
            client.Close();
            OutputText("Соединение разорвано " + host, listBox1);

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
    }
}
