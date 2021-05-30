using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MailClasses.User
{
     public class AuthorizedUser
    {
        public string login = "";
        public string passw = "";
        public ImapClient imapClient;
        public AuthorizedUser(string log, string pas) {
            login = log;
            passw = pas;
        }
        public AuthorizedUser(string log, string pas, ImapClient im)
        {
            login = log;
            passw = pas;
            imapClient = im;
        }
    }

    public class mailFolderInfo
    {
        public int number = -1;
        public string path = "";
        public List<MailInfo> Mails = new List<MailInfo>();

       

        public int GetUidByIndex(string Name)
        {
            int res = -1;
            foreach (MailInfo m in Mails) {
                if (m.Text == Name)
                    res = m.UID;
            }
            return res;
        }

    }

    public class MailInfo {
        public int UID = -1;
        public string Text = "";
        public MailInfo(string Tt, int uId) {
            UID = uId;
            Text = Tt;
        }

        public bool IsUNSEEN = false;
    }
}
