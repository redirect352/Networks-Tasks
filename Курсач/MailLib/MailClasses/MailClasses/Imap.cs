using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.Security;
using System.Text.RegularExpressions;
using System.IO;


namespace MailClasses
{


    public class IncorrectLoginorPasswExeption : ImapExeption {
        public IncorrectLoginorPasswExeption(string message) : base(message)
        { }
    }
    public class BadCommandExeption : ImapExeption
    {
        public BadCommandExeption(string message) : base(message)
        { }
    }

    public class ImapExeption : Exception
    {
        public ImapExeption(string message) : base(message)
        { }

    }

    public class ImapClient
    {
        const string CLRF = "\r\n";

        private int num = 100;
        private char Symb = 'A';

        //Информация для подключения к серверу
        public string ImapServerName = "";
        public int port = 993;


        //Пользовательская информация для верификации на сервере
        private string userPassword;
        private string userLogin;
        private bool isLogined = false;

        public string UserPassword
        {
            set {
                userPassword = value;
            }
        }
        public string UserLogin
        {
            set
            {
                userLogin = value;
            }
        }
        public bool IsLogined {
            get {
                return isLogined;
            }
        }

        //Информация о состоянии текущей папки ящика 
        private int exists = -1;
        private int recent = -1;
        private int UIDNEXT = -1;
        private int UNSEEN = -1;
        private int UIDVALIDITY = -1;


        // 
        
        private SslStream mainStream = null;


        //работа с почтой

        public void ConnectToServer()
        {
            TcpClient client = new TcpClient();
            try
            {
                string host = ImapServerName;
                client.Connect(host, port);
                SaveLogs("Подключено к серверу " + host); 
            }
            catch (Exception ex)
            {
                SaveLogs("Невозможно подключиться к данному серверу");
                return;
            }

            mainStream = new SslStream(client.GetStream());

            mainStream.ReadTimeout = 1000;
            mainStream.WriteTimeout = 1000;
            //authPasswordForSmtpMailRu
            mainStream.AuthenticateAsClient(ImapServerName, null, System.Security.Authentication.SslProtocols.Tls, false);
        }

        public void AuthOnServer() {

            try
            {
                AuthPlainCommand();

            }
            catch (IncorrectLoginorPasswExeption ex) {
                throw ex;
            }
            catch {
                LoginCommand();           
            }
        }

        public void SelectBox(string BoxName) {
                SelectCommand(BoxName, 0);
        }

        public void GetAllEmailsInBox(string folderPath, string nameTemplate, string mailFileExtension) {
            string filename = folderPath+"/"+nameTemplate ;
            for (int i = 0; i< exists;i++) {
                FetchCommand(1,"BODY[]",filename+"_"+i.ToString()+mailFileExtension);
            
            }

        }

        // Команды 

        private int template()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + "Command name" + CLRF;
            SaveLogs(command);
            num++;
            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");

            try
            {
                res = false;
                string answer;
                do
                {
                    answer = GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK <Command name> completed") >= 0)
                        {
                            res = false;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0 )
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }
                        if (answer.IndexOf(answCode + " NO ") >= 0)
                        {
                            //обработка отказа
                        }


                    }
                }
                while (res);

            }
            catch (ImapExeption iex)
            {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return 0;

        }

        //Возможности сервера

        private int CapabilityCommand()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " CAPABILITY" + CLRF;
            SaveLogs(command);
            num++;
            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");

            try
            {
                res = false;
                string answer;
                do
                {
                    answer = GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK CAPABILITY completed") >= 0)
                        {
                            res = false;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }

                    }
                }
                while (res);

            }
            catch (ImapExeption iex) {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return 0;
        }

        //обновление таймера
        private int NoopCommand()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " NOOP" + CLRF;
            num++;

            SaveLogs(command);

            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");

            try
            {
                res = false;
                string answer;
                do
                {
                    answer = GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK NOOP completed") >= 0)
                        {
                            res = false;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0 || answer.IndexOf(answCode + " no ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }

                    }
                }
                while (res);

            }
            catch (ImapExeption iex)
            {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return 0;
        }

        // Конец сеанса
        private int LogOutCommand()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " LOGOUT" + CLRF;
            num++;

            SaveLogs(command);

            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");
            int tmp = 0;
            try
            {
                res = false;
                string answer;
                do
                {
                    answer = GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + "* BYE") >= 0 || answer.IndexOf(answCode + "*BYE") >= 0) {
                            tmp++;
                        }
                        if (answer.IndexOf(answCode + " OK") >= 0)
                        {
                            tmp++;
                            res = false;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0 )
                        {

                            throw new ImapExeption("Wrong command " + command);
                        }


                    }
                }
                while (res);

            }
            catch (ImapExeption iex)
            {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return tmp;

        }

        //*******************
        // Команды логина
        private int AuthPlainCommand()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " AUTHENTICATE PLAIN " + EncodingForMails.Encoder.Base64Encode("\0" + userLogin + "\0" + userPassword);
            num++;
            SaveLogs(command);

            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");

            try
            {
                res = false;
                string answer;
                do
                {
                    answer = GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK Authentication successful") >= 0)
                        {
                            isLogined = true;
                            res = false;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " NO Authentication  ") >= 0 || answer.IndexOf(answCode + " no ") >= 0)
                        {
                            string exMessage = answer.Substring(answer.IndexOf(answCode + " NO") + (answCode + " NO").Length);

                            throw new IncorrectLoginorPasswExeption(exMessage);
                        }

                    }
                }
                while (res);

            }
            catch (ImapExeption iex)
            {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return 0;
        }


        private int LoginCommand()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " LOGIN " + userLogin + " " + userPassword;
            num++;
            SaveLogs(command);

            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");

            try
            {
                res = false;
                string answer;
                do
                {
                    answer = GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK Authentication successful") >= 0)
                        {
                            res = false;
                            isLogined = true;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " NO Authentication  ") >= 0 || answer.IndexOf(answCode + " no ") >= 0)
                        {
                            string exMessage = answer.Substring(answer.IndexOf(answCode + " NO") + (answCode + " NO").Length);

                            throw new IncorrectLoginorPasswExeption(exMessage);
                        }
                        if (answer.IndexOf(answCode + " BAD ") >= 0 )
                        {
                            string exMessage = answer.Substring(answer.IndexOf(answCode) + (answCode).Length);

                            throw new BadCommandExeption(exMessage);
                        }


                    }
                }
                while (res);

            }
            catch (ImapExeption iex)
            {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return 0;

        }


        //*******************
        // Команды работы с почтовыми ящиками
        //для Select - 0, для Examine - любое другое значение
        private int SelectCommand(string MailPath, int sel)
        {
            string comBase = " SELECT ";
            if (sel !=0)
            {
                 comBase = " EXAMINE ";
            }
            
            string answCode = Symb + num.ToString();
            string command = answCode + comBase + MailPath;
            SaveLogs(command);
            num++;
            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");

            try
            {
                res = false;
                string answer = "";
                do
                {
                    answer =  answer + GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK CAPABILITY completed") >= 0)
                        {
                            res = false;
                            // анализ информации...
                            string[] sq = answer.Split(new char[] { '\n' });
                            foreach (string s in sq) {
                                if (s.ElementAt<char>(0) != '*')
                                    continue;
                                //private string[] patterns = new string[] { @"\* \d+ EXISTS", @"\* \d+ RECENT", @"\* OK [UNSEEN \d+]", @"\* OK [UIDVALIDITY \d+]",, @"\* OK [UIDNEXT \d+]" };
                                if (Regex.IsMatch(s, @"\* \d+ EXISTS")) {
                                    Match m = Regex.Match(s,@"\d+");
                                    exists = int.Parse(m.Value);
                                    continue;
                                }
                                if (Regex.IsMatch(s, @"\* \d+ RECENT"))
                                {
                                    Match m = Regex.Match(s, @"\d+");
                                    recent = int.Parse(m.Value);
                                    continue;
                                }
                                if (Regex.IsMatch(s, @"\* OK [UNSEEN \d+]"))
                                {
                                    Match m = Regex.Match(s, @"\d+");
                                    UNSEEN = int.Parse(m.Value);
                                    continue;
                                }
                                if (Regex.IsMatch(s, @"\* OK [UIDVALIDITY \d+]"))
                                {
                                    Match m = Regex.Match(s, @"\d +");
                                    UIDVALIDITY= int.Parse(m.Value);
                                    continue;
                                }
                                if (Regex.IsMatch(s, @"\* OK [UIDNEXT \d+]"))
                                {
                                    Match m = Regex.Match(s, @"\d +");
                                    UIDNEXT = int.Parse(m.Value);
                                    continue;
                                }
                            }
                        }
                        
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }

                    }
                }
                while (res);

            }
            catch (ImapExeption iex)
            {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return 0;


        }


        private int FetchCommand(int MailNumber, string MailContent, string filename)
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " FETCH" + MailNumber.ToString()+" "+MailContent;
            SaveLogs(command);
            num++;
            if (mainStream == null)
                throw new ImapExeption("Not connected to server");

            bool res = SendMessageToServer(command);
            if (!res)
                throw new ImapExeption("Cannot send message to server");

            try
            {
                res = false;
                string answer = "";
                do
                {
                    answer = answer+  GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK FETCH completed") >= 0)
                        {
                            string[] strs = answer.Split(new char[] { '\n'});
                            

                            res = false;
                            FileStream F = new FileStream(filename, FileMode.Create,FileAccess.Write);
                            try
                            {
                                //доработать
                                foreach (string s in strs)
                                {
                                    if (s.IndexOf(answCode + " OK FETCH completed")<0 && s.IndexOf("* " + MailNumber.ToString() + " FETCH ") < 0)
                                    {
                                    byte[] buf = Encoding.UTF8.GetBytes(s);
                                    F.Write(buf, 0, answer.Length);
                                }

                                }
                                
                            }
                            finally {
                                F.Close();
                            }


                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }
                        if (answer.IndexOf(answCode + " NO ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                            break;
                        }


                    }
                }
                while (res);

            }
            catch (ImapExeption iex)
            {
                SaveLogs(iex.Message);
                throw iex;
            }
            catch (Exception ex)
            {
                SaveLogs(ex.Message);
                return 1;

            }
            return 0;


        }
    



        // конец команд




        private bool SendMessageToServer(string command) {
            if (mainStream == null)
                return false;
            try
            {
                const string CRLF = "\r\n";

                byte[] messbytes = Encoding.UTF8.GetBytes(command);
                mainStream.Write(messbytes, 0, messbytes.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GetAnswerFromServer(ref bool result)
        {
            result = false;
            string answer = "";
            try
            {
                 
                byte[] messbytes = new byte[1024];
                int byteread = 0;
                do
                {
                    byteread = mainStream.Read(messbytes, 0, 1024);
                    answer = answer + Encoding.ASCII.GetString(messbytes, 0, byteread);
                }
                while (byteread>0);

                if (answer !="")
                    result = true;


                return answer;
            }
            catch
            {
                if (answer != "")
                {
                    result = true;
                    return answer;
                }
                return "";
            }
        }



        //Заполнение логов
        private void SaveLogs(string s)
        {
            //сохранение куда-то там...


        }


    }
}


