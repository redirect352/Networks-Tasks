using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClasses
{
    public class InsideBox
    {
        public string ServerPath;
        public string NameOnServer;//
        public string NameForClient;
        public InsideBox(string name, string path) {

            ServerPath = path;
            NameOnServer  = name;
        }
    }
}
