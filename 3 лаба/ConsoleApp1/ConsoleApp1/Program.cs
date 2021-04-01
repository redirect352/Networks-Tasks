using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.ASCII;
            Console.WriteLine("Telnet protocol test");
            
            IPHostEntry host1 = Dns.GetHostEntry("fibs.com");
            Console.WriteLine(host1.AddressList.First());
           // string HostIp = host1.AddressList.First();
            int port = 23;
            string username = "admin";
            string password = "admin";


            IPAddress host = host1.AddressList.First();
            IPEndPoint ip = new IPEndPoint(host, port);


            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.ReceiveTimeout = 2000;
            socket.Connect(ip);
            Console.WriteLine("Connected succesfully");
            do
            {
                string command =  Console.ReadLine();
                Console.WriteLine(GetResponse(command + "\r", socket));


            }

            while (true);

            




            Console.ReadLine();
        }

        public static string GetResponse(string req,Socket socket)
        {
            
            
            int bytes = 0;
            string resp = string.Empty;
            byte[] buffer = new byte[1024];
            byte[] bytesReq = Encoding.ASCII.GetBytes(req );
            bytes =  socket.Send(bytesReq, bytesReq.Length, SocketFlags.None);
            if (socket.Connected)
            {
                do
                {
                    try {
                        bytes = socket.Receive(buffer, buffer.Length, SocketFlags.None);
                        resp += Encoding.ASCII.GetString(buffer);
                    }
                    catch (Exception ex)
                    
                    { bytes = 0; }
                   
                }
                while (bytes > 0);
            }
           
            return resp;
        }


        private static string ReadTelnet(TcpClient client, long timeout = 1000)
        {
            for (long i = 0; i < timeout; i++)
            {
                NetworkStream stream = client.GetStream();

                // if (client.ReceiveBufferSize <= 0 || !stream.CanRead || !stream.DataAvailable)
                if (client.ReceiveBufferSize <= 0)
                    continue;

                do
                {
                    System.Threading.Thread.Sleep(1000);

                    byte[] buffer = new byte[client.ReceiveBufferSize];
                    int p = stream.Read(buffer, 0, client.ReceiveBufferSize);

                    string response = Encoding.ASCII.GetString(buffer);
                    Console.WriteLine(string.Format("{0}. {1}", i, response));
                    //for (var j = 0; j < buffer.Length; j++)
                    //	Console.Write(buffer[j]);

                    if (response == "")
                        continue;



                    return response;
                }
                while (stream.DataAvailable);
            }

            return null;
        }

        private static string WriteTelnet(TcpClient client, string command, long timeout)
        {
            return ReadTelnet(client, timeout);
        }

    }
}
