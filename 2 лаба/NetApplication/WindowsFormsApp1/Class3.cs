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
    public class NetClient : NetConnector
    {
        public NetClient(int _port, string _adress) : base(_port, _adress)
        { }

        public override string Message
        {
            get => base.Message;
            set
            {
                message = value;
                this.ConnectTo();

            }
        }

        private string GetName(string src)
        {
            string result = "";
            for (int i = src.Length - 1; i >= 0; i--)
            {

                if (src[i] == '\\' || src[i] == '/')
                {
                    break;
                }
                result = src[i] + result;
            }
            return result;
        }

        public override void ConnectTo()
        {
            FileStream F = null;

            try
            {
                F = new FileStream(this.openpath, FileMode.Open);
                StringBuilder builder = new StringBuilder();

                var ipPoint = new IPEndPoint(IPAddress.Parse(adress), port);
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ipPoint);
                int bytes = 0; // количество полученных байт

                byte[] tmp = new byte[128];
                bytes = socket.Receive(tmp, tmp.Length, 0);
                builder.Append(Encoding.UTF8.GetString(tmp, 0, bytes));
                if (builder.ToString() == "NO")
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    return;
                }



                byte[] data = new byte[256];
                data = Encoding.Unicode.GetBytes(GetName(openpath));
                socket.Send(data);
                data = new byte[sizeof(int)];


                this.FullProgress = (int)F.Length;
                data = BitConverter.GetBytes(FullProgress);
                socket.Send(data);

                progress = 0;

                data = new byte[buffersize];
                int ByteRead = 0;
                do
                {
                    ByteRead = F.Read(data, 0, buffersize);
                    this.progress = progress + ByteRead;
                    if (ByteRead > 0)
                        socket.Send(data, ByteRead, 0);

                }
                while (ByteRead > 0);
                socket.Shutdown(SocketShutdown.Send);
                F.Close();


                data = new byte[256]; // буфер для ответа
                builder = new StringBuilder();


                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                message = builder.ToString();

                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                MessageBox.Show("Файл доставлен");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Client Error!" + ex.Message);
            }
            finally
            {
                if (F != null)
                    F.Close();

                Thread tr = Thread.CurrentThread;
                tr.Abort();
            }



        }



    }
}
