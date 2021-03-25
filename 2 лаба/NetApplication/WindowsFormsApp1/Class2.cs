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
    public class NetHost : NetConnector
    {


        
        public NetHost(int _port, string _adress) : base(_port, _adress)
        { }

        public override void ConnectTo()
        {
            var ipPoint = new IPEndPoint(IPAddress.Any, port);

            var listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            FileStream F = null;

            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);

                while (ServerOn)
                {
                    Socket handler = listenSocket.Accept();
                    byte[] data = new byte[buffersize];
                    string message = "NO";
                    DialogResult res = MessageBox.Show("Входящий запрос на принятие файла", "Потвердите действие", MessageBoxButtons.YesNo);

                    if (res == DialogResult.No)
                    {


                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                        continue;
                    }
                    else
                    {

                        message = "Yes";
                        data = Encoding.Unicode.GetBytes(message);
                        handler.Send(data);
                    }




                    var builder = new StringBuilder();
                    int bytes = 0; // количество полученных байтов
                    byte[] ext = new byte[256];
                    string path = SavePath;




                    //Получение имени и расширения файла.
                    bytes = handler.Receive(ext, ext.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(ext, 0, bytes));
                    path = path + builder.ToString();

                    ext = new byte[sizeof(int)];
                    //Получение размера файла
                    bytes = handler.Receive(ext, ext.Length, 0);

                    FullProgress = BitConverter.ToInt32(ext, 0);

                    



                     data = new byte[buffersize];

                    F = new FileStream(path, FileMode.Create);
                    progress = 0;

                    do
                    {
                        bytes = handler.Receive(data);
                        progress += bytes;
                        F.Write(data, 0, bytes);
                    }
                    while (bytes != 0);
                    F.Close();

                     message = "ваше сообщение доставлено";
                    data = Encoding.Unicode.GetBytes(message);
                    handler.Send(data);
                    // закрываем сокет
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    MessageBox.Show("Файл получен");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Server Error!" + ex.Message);
            }
            finally
            {
                if (F != null)
                    F.Close();
            }


        }
    }
}
