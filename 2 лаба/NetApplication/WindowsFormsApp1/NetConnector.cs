using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public class NetConnector
    {
        static public int startFlag = 1234;
        static public int EndFlag = 3456;


        protected static int buffersize = 64000;
        public int progress = 0;
        public int FullProgress = 1;

        protected int port;
        public string adress;
        protected string message = "";
        public string openpath;
        public string SavePath = "C:/";

        public bool ServerOn = true;

        public virtual string Message
        {
            set
            {
                message = value;
            }
            get
            {
                return message;
            }

        }

        public NetConnector(int _port, string _adress)
        {
            this.adress = _adress;
            this.port = _port;
        }

        public virtual void ConnectTo()
        {

        }

    }
}
