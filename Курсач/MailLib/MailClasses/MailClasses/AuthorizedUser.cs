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
}
