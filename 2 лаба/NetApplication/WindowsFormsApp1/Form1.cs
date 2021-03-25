using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        public bool ServerOn = true;
        private NetConnector Nc;
        private Thread Server;


        public Form1()
        {
            InitializeComponent();

            
        }

        void Progress1()
        {
            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = 0));

            while (progressBar1.Value < progressBar1.Maximum)
            {

                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value= (int)(1000 * (float)Nc.progress / Nc.FullProgress)) );
                Thread.Sleep(10);;
            }
            Thread.Sleep(5000);
            progressBar1.Invoke((MethodInvoker)(() => progressBar1.Value = 0));

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Visible = false;
            textBox1.Visible = false;
            string ip = textBox2.Text;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    button1.Text = "Запуск сервера для принятия файлов";
                    Nc = new NetHost(8005, ip);
                    break;
                case 1:
                    Nc = new NetClient(8005, ip);
                    button1.Text = "Отправить файл";

                    try
                    {
                        if (Server.Name == "Host")
                        {
                            Server.Name = "Stopped";
                            Server.Abort();

                        }
                    }
                    catch { }
                    break;
                case 2:
                    button1.Text = "Запуск сервера для принятия файлов";
                    Nc = new NetHostUdp(8005, ip);
                    break;
                case 3:
                    Nc = new NetClientUdp(8005, ip);
                    button1.Text = "Отправить файл";

                    try
                    {
                        if (Server.Name == "Host")
                        {
                            Server.Name = "Stopped";
                            Server.Abort();

                        }
                    }
                    catch { }
                    break;


            }
            Nc.SavePath = textBox1.Text + '/';



            if (comboBox1.SelectedIndex == 1)
            {




            }
            else
            {

            }
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
            {
                button2.Visible = true;
                textBox1.Visible = true;

                Server = new Thread(new ThreadStart(Nc.ConnectTo));
                Server.Name = "Host";
                Server.Start();
                Thread progr = new Thread(new ThreadStart(this.Progress1));
                progr.Start();
            }
            else
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                        Nc.openpath = openFileDialog1.FileName;
                    else
                        return;
                }
                Thread progr = new Thread(new ThreadStart(this.Progress1));
                progr.Start();
                Server = new Thread(new ThreadStart(Nc.ConnectTo));
                Server.Name = "Client";
                Server.Start();
                listBox1.Items.Add(Nc.Message);

 

            }
            
        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (Nc is NetHost)
                {
                    (Nc as NetHost).ServerOn = false;
                    Environment.Exit(0);   
                    
                } 
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Nc.adress = textBox2.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                Nc.SavePath = folderBrowserDialog1.SelectedPath + "/";

            }
        }
    }








}
