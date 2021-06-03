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
        string mailFileExtension = ".txt";
        // работа со вкладками
        public List<InsideBox> boxes = new List<InsideBox>();
        public int InboxNum = -1;
        public int SpamNum = -1;
        public int TrashNum = -1;
        public int SendNum = -1;
        public int DraftsNum = -1;

        private int num = 100;
        private char Symb = 'A';

        //Информация для подключения к серверу
        public string ImapServerName = "";
        public int port = 993;


        //Пользовательская информация для верификации на сервере
        private string userPassword;
        private string userLogin;
        private bool isLogined = false;
        public bool IsBoxSelected;


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


        public int FindBox(string name) {
            int res = -1,k=0;
            foreach (InsideBox i in boxes)
            { if (i.NameOnServer == name)
                {
                    res = k;
                }
                k++;
            }
            return res;
        }

        //********************************************
        // Процедуры работы с почтой

        //Подключение к почтовому серверу
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

        public void ChangeFolder(int SourceBoxNumber, int DestinationBoxNumber,int MessageUID) {
            try
            {
                SelectBox(boxes.ElementAt(SourceBoxNumber).ServerPath);
            }
            catch (Exception ex)
            {
                SaveLogs("Select exeption\n\n");
                return;
            }

            int l= CopyCommand(MessageUID,boxes.ElementAt(DestinationBoxNumber).ServerPath,"UID");
            if (l == 0)
            {
                l = StoreCommand(MessageUID, "+FLAGS.SILENT (\\Deleted)", "UID");
                if (l == 0)
                    EXPUNGECommand();
                else
                { throw new ImapExeption("Cannot delete"); }

            }
            else {
                throw new ImapExeption("Cannot copy");
            }

        }

        public void DeleteMessage(int MessageId, int BoxNumber)
        {
            try
            {
                SelectBox(boxes.ElementAt(BoxNumber).ServerPath);
            }
            catch (Exception ex)
            {
                SaveLogs("Select exeption\n\n");
                return;
            }

            int l = StoreCommand(MessageId, "+FLAGS.SILENT (\\Deleted)", "UID");
            if (l == 0)
                EXPUNGECommand();
            else
               { throw new ImapExeption("Cannot delete"); }

        }


        //Вход в аккаунт
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

        //Выбор вкладки почтового сервера
        public void SelectBox(string BoxName) {
                SelectCommand(BoxName, 0);
        }

        //Получение всех писем в почтовом ящике
        public void GetAllEmailsInBox(string folderPath) {
            string filename = folderPath+"\\" ;
            for (int i = 0; i< exists;i++) {
                FetchCommand(i,"BODY[]", filename+i.ToString()+mailFileExtension,"");
            
            }

        }

        public List<int> GetNewEmailsInBox(int BoxNumber, List<int> AlreadyLoaded, string folderPath) {
            try {
                SelectBox(boxes.ElementAt(BoxNumber).ServerPath);
            }
            catch (Exception ex)
            { SaveLogs("Select exeption\n\n");
            }

            List <int> unseen  =  new List<int>();
            try {
                unseen = GetUnseenNums();
            }
           
            catch {
                SaveLogs("Cannot unseen\n\n");
            }

            List<int> AllEmailsInbox = new List<int>();
                string[] Emails = SearchCommand(" ALL", " UID ");
                foreach (string s in Emails)
                {
                    if (Regex.IsMatch(s, @"\* SEARCH"))
                    {
                        var M = Regex.Matches(s, @"\s(\d)+");
                        foreach (Match match in M)
                        {
                            AllEmailsInbox.Add(int.Parse(match.Value));
                        }
                    
                    }
                }

            if (AlreadyLoaded != null)
                foreach (int index in AlreadyLoaded) {
                if (!AllEmailsInbox.Contains(index)) {
                    try
                    {
                        if (AlreadyLoaded.Max<int>() >= index)
                        {
                            string filepath = folderPath + "\\" + index.ToString() + mailFileExtension;
                            File.Delete(filepath);
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!(ex is ArgumentNullException))
                            SaveLogs(ex.Message);
                    }
                }
                }
            List<int> NeedToLoad = new List<int>();
            if (AlreadyLoaded != null)
            {
                for (int i = 0; i < AllEmailsInbox.Count; i++)
                {
                    int tmp = AllEmailsInbox.ElementAt(i);
                    if (!AlreadyLoaded.Contains(tmp))
                    {
                        NeedToLoad.Add(tmp);
                    }







                }
            }
            else
                NeedToLoad = AllEmailsInbox;

            foreach (int k in NeedToLoad)
               {
                    FetchCommand(k, "BODY[]", folderPath+"\\"+k.ToString() + mailFileExtension," UID ");
              }

            return unseen;

        }

        public void LoadAllBoxes(string path) {

            try
            {
                string results = "";
                //"\"\\\""
                ListCommand(path, "*", ref results);
                if (results == "")
                    throw new Exception("No results from LIST " +path + " *" );

                string[] res = results.Split(new char[] { '\n','\r'});
                string type, name;
                string pattern = @"\* LIST \((\\[A-Za-z]+\)|(.?)) ""\/"" "".+""";
                foreach (string s in res ) {
                    if (Regex.IsMatch(s,pattern)) {
                        Match b = Regex.Match(s, @"\(\\[a-zA-Z]+\)");
                        type = (b.Value).Trim(new char[] { '(', ')','\\' });

                        b = Regex.Match(s, @"""[^""]{2,}""");

                        name = (b.Value).Trim(new char[] { '"'});

                        this.boxes.Add(new InsideBox(type,name));
                    }

                }
                int k = 0;
                foreach (InsideBox b in boxes) {
                    if (Regex.IsMatch(b.NameOnServer, "inbox", RegexOptions.IgnoreCase))
                        InboxNum = k;
                    if (Regex.IsMatch(b.NameOnServer, "spam", RegexOptions.IgnoreCase))
                        SpamNum = k;
                    if (Regex.IsMatch(b.NameOnServer, "sent", RegexOptions.IgnoreCase))
                        SendNum = k;
                    if (Regex.IsMatch(b.NameOnServer, "drafts", RegexOptions.IgnoreCase))
                        DraftsNum = k;
                    if (Regex.IsMatch(b.NameOnServer, "trash", RegexOptions.IgnoreCase))
                        TrashNum = k;
                    k++;
                }

            }
            catch (ImapExeption IEx)

            { }
             
        }



        public void DisconnectFromServer()
        {


            try
            {
                this.LogOutCommand();
                this.mainStream.Close();
            }
            catch (Exception ex) {
                SaveLogs(ex.Message);
            }

        }
        public void CloseBox()
        {           
            if (IsBoxSelected) {
               CloseCommand();

            }  
        }

        //
        
        public List<int> GetUnseenNums()
        {
            List<int> results = new List<int>();
            string[] answer = null;
            try {
                answer = SearchCommand(" UNSEEN", " UID ");


            }
            catch {
                return results;
            }
            if (answer == null)
                return results;

            foreach (string s in answer) {
                if (Regex.IsMatch(s,@"\* SEARCH")) {
                   string[] tmp =  s.Substring(s.IndexOf("H")+1).Split(' ');
                    int tr = 0;
                    foreach (string k in tmp) {
                        if (k!="" && int.TryParse(k,out tr) ) {
                            results.Add(tr);
                        }
                   }
                    
                }
            }
            return results;
        }

    
        //********************************************
        // Команды 

        private int template()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + "Command name";
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
            string command = answCode + " CAPABILITY";
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
            string command = answCode + " NOOP" ;
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
            string command = answCode + " LOGOUT" ;
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
                        if (sel == 0)
                            IsBoxSelected = true;
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK ") >= 0)
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


        private int CloseCommand()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + "CLOSE";
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
                        if (answer.IndexOf(answCode + " OK CLOSE") >= 0)
                        {
                            res = false;
                            IsBoxSelected = false;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }
                        if (answer.IndexOf(answCode + " NO ") >= 0)
                        {
                            res = false;
                            IsBoxSelected = false;
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


        private int FetchCommand(int MailNumber, string MailContent, string filename, string USEUid)
        {
            string answCode = Symb + num.ToString();
            string command = answCode + USEUid + " FETCH " + MailNumber.ToString()+" "+MailContent;
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
                        if (answer.IndexOf(answCode + " OK FETCH ") >= 0)
                        {
                            string[] strs = answer.Split(new char[] { '\n'});
                            

                            res = false;
                            FileStream F = new FileStream(filename, FileMode.Create,FileAccess.Write);
                            try
                            {
                                
                                //доработать
                                foreach (string s in strs)
                                {
                                    if (s.IndexOf(answCode + " OK FETCH ") < 0 && s.IndexOf("* " + MailNumber.ToString() + " FETCH ") < 0 && 
                                        s.IndexOf("FETCH (UID ") < 0)
                                    {
                                        byte[] buf = Encoding.UTF8.GetBytes(s + "\n");
                                        
                                        F.WriteAsync(buf, 0, buf.Length);
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


        private int ListCommand(string FirstListArg, string SecondListArg, ref string results)
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " LIST " + FirstListArg+" "+ SecondListArg;
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
                string answer,tmp = "";
                
                do
                {
                    answer = GetAnswerFromServer(ref res);
                    
                    if (res)
                    {
                        SaveLogs(answer);
                        tmp = tmp + answer;
                        if (answer.IndexOf(answCode + " OK LIST ") >= 0)
                        {
                            res = false;
                            tmp = tmp.Substring(0,tmp.IndexOf(answCode + " OK LIST "));
                            results = tmp;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }
                        if (answer.IndexOf(answCode + " NO ") >= 0)
                        {
                            throw new ImapExeption("No  " + command);
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



        private string[] SearchCommand(string Args, string UseUID)
        {
            string answCode = Symb + num.ToString();
            string command = answCode + UseUID+  " Search "+ Args;
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
                        if (answer.IndexOf(answCode + " OK") >= 0)
                        {
                            res = false;
                            string[] tmp = answer.Split(new char[] {'\n', '\r' });
                            return tmp;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }
                        if (answer.IndexOf(answCode + " NO ") >= 0)
                        {
                            throw new ImapExeption("No " + command);
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
                return null;

            }

            return new string[]{ };
        }
        



        private int CopyCommand(int MailNumber, string DestinationBoxName, string USEUid)
        {
            string answCode = Symb + num.ToString();
            string command = answCode+" " + USEUid + " COPY " + MailNumber.ToString() + " " + DestinationBoxName;
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
                    answer = answer + GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK ") >= 0)
                        {
                            return 0;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }
                        if (answer.IndexOf(answCode + " NO ") >= 0)
                        {
                            throw new ImapExeption("Cannot copy message " + command);
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

        private int StoreCommand(int MailNumber, string Content, string USEUid)
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " " + USEUid + " STORE " + MailNumber.ToString() + " " + Content;
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
                    answer = answer + GetAnswerFromServer(ref res);
                    if (res)
                    {
                        SaveLogs(answer);
                        if (answer.IndexOf(answCode + " OK ") >= 0)
                        {
                            return 0;
                        }
                        // анализ информации...
                        if (answer.IndexOf(answCode + " BAD ") >= 0)
                        {
                            throw new ImapExeption("Wrong command " + command);
                        }
                        if (answer.IndexOf(answCode + " NO ") >= 0)
                        {
                            throw new ImapExeption("Cannot  change flags message " + command);
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

        private int EXPUNGECommand()
        {
            string answCode = Symb + num.ToString();
            string command = answCode + " EXPUNGE";
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
                        if (answer.IndexOf(answCode + " OK EXPUNGE") >= 0)
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


        // конец команд



        private bool SendMessageToServer(string command) {
            if (mainStream == null)
                return false;
            try
            {
                const string CRLF = "\r\n";

                byte[] messbytes = Encoding.UTF8.GetBytes(command + CRLF);
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
            FileStream f;
            try
            {
                 f = new FileStream("d:/log.txt", FileMode.OpenOrCreate);
            }
            catch {
                return;
            }

            try
            {
                f.Position = f.Length;
                byte[] buf = Encoding.UTF8.GetBytes(s+"\n");
                f.WriteAsync(buf,0,buf.Length);
            
            }
            finally{
                f.Close();
            }

        }


    }
}


