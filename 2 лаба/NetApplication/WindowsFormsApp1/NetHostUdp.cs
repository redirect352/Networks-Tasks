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
    class NetHostUdp:NetConnector
    {


        public NetHostUdp(int _port, string _adress) : base(_port, _adress)
        {       }

        public override void ConnectTo()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
            var endPoint = new IPEndPoint(IPAddress.Parse("192.168.43.60"), port);

            int bytes;
            byte[] data = new byte[buffersize];
            FileStream F = null;
            try
            {



                socket.Bind(endPoint);
                

                

                while (ServerOn)
                {

                    int flag = 0;
                    EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);
                    do
                    {
                        bytes = socket.ReceiveFrom(data, 4, SocketFlags.None,ref remoteIp);
                        if (bytes >= 4)
                            flag = BitConverter.ToInt32(data,0);

                    }
                    while (flag != startFlag);

                    StringBuilder builder = new StringBuilder();

                    //Получение имени и расширения файла.
                    bytes = socket.ReceiveFrom(data, 256, SocketFlags.None, ref remoteIp);
                    
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    string path = SavePath + builder.ToString();


                    bytes = bytes = socket.ReceiveFrom(data, 4, SocketFlags.None, ref remoteIp);
                    FullProgress = BitConverter.ToInt32(data,0);
                    progress = 0;


                    F = new FileStream(path, FileMode.Create);
                    remoteIp = new IPEndPoint(IPAddress.Any, 0);

                    data = new byte[buffersize];
                     byte[] answer = new byte[4];
                    flag = 0;
                    int i = 0;
                    do
                    {
                        if (i<=0)
                            bytes = socket.ReceiveFrom(data,ref remoteIp);




                        if (bytes > 0)
                        {
                            flag = BitConverter.ToInt32(data, 0);
                            if (flag != EndFlag && bytes >= 4)
                            {
                                F.Write(data, 0, bytes);
                                progress += bytes;
                                
                                answer = BitConverter.GetBytes(i);

                                do
                                { 
                                    socket.SendTo(answer, 4, SocketFlags.None, remoteIp);
                                    bytes = socket.ReceiveFrom(data, ref remoteIp);
                                }
                                while (bytes <= 0);
                                i++;
                            }
                        }

                    }
                    while (flag != EndFlag && bytes!=4);
                    if (flag == EndFlag)
                        MessageBox.Show("Файл получен.");
                    F.Close();

                    

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
