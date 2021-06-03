using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using System.IO;
using System.Windows.Forms;


namespace MailClasses.MimeWork
{
    public class MimeDecrypter
    {

        public static string SetHeaders(string path, Label Subject, Label Date, Label From, Label To)
        {
            string res = "";
            FileStream f = new FileStream(path, FileMode.Open, FileAccess.Read);
            try
            {
                MimeParser b = new MimeParser(f);
                var mime1 = b.ParseHeaders();
                foreach (Header header in mime1)
                {
                    if (HeaderId.Subject == header.Id)
                        Subject.Text = header.Value;
                    if (HeaderId.To == header.Id)
                        To.Text = "Кому: " +header.Value;
                    if (HeaderId.From == header.Id)
                        From.Text = "От: "+header.Value;
                    if (HeaderId.Date == header.Id)
                        Date.Text = header.Value;
                }
            }
            catch { }
            finally
            {
                f.Close();
            }


            return res;

        }

        public static string GetSubject(string path) {

            string res = "";
            FileStream f = new FileStream(path,FileMode.Open,FileAccess.Read);
            try
            {
                MimeParser b = new MimeParser(f);
                var mime1=  b.ParseHeaders();
                foreach (Header header in mime1)
                {
                    if (HeaderId.Subject == header.Id)
                    {
                        res = header.Value;

                        if (res == "" || res.Trim(' ') == "") {
                            res = "* No subject";
                        }
                    }
                
                }
            }
            catch { }
            finally
            {
                f.Close();
            }


            return res;

        }

        public static string GetSubjectAndDate(string path, ref DateTime tm)
        {

            string res = "";
            FileStream f = new FileStream(path, FileMode.Open, FileAccess.Read);
            try
            {
                MimeParser b = new MimeParser(f);
                var mime1 = b.ParseHeaders();
                foreach (Header header in mime1)
                {
                    if (HeaderId.Subject == header.Id)
                    {
                        res = header.Value;

                        if (res == "" || res.Trim(' ') == "")
                        {
                            res = "* No subject";
                        }
                    }

                    if (HeaderId.Date == header.Id) {
                        tm = DateTime.Parse(header.Value);
                    }

                }
            }
            catch { }
            finally
            {
                f.Close();
            }


            return res;

        }


        public static void  DecryptMessage(string path, WebBrowser wb, ListView attachments)
        {

            
            FileStream f = new FileStream(path, FileMode.Open, FileAccess.Read);
            try
            {
                MimeParser b = new MimeParser(f);
                

                var mime = b.ParseMessage();
                string s = mime.HtmlBody;
                if (mime.HtmlBody == null)
                    s = mime.TextBody;
                wb.DocumentText = s;
                attachments.Clear();
                //Рас
                var Attach = mime.Attachments;
                string AttachPath = path.Substring(0, path.LastIndexOf('.')) + "_attachments";

                if (Attach.Count<MimeEntity>()> 0)
                {
                    Directory.CreateDirectory(AttachPath);
                    var dir = Directory.EnumerateFiles(AttachPath);
                    foreach (MimeEntity m in Attach)
                    {
                        var t = m.Headers;
                        ListViewItem viewItem = new ListViewItem(m.ContentDisposition.FileName);
                        string tmp = Path.GetExtension(m.ContentDisposition.FileName).Replace(".","");
                        if (File.Exists("icons\\"+tmp+".png")) 
                            viewItem.ImageKey = tmp + ".png";
                        else
                            viewItem.ImageKey =  "blank.png";

                        attachments.Items.Add(viewItem);

                        if (!dir.Contains<string>(AttachPath+"\\"+ m.ContentDisposition.FileName))
                        {
                            FileStream attach = new FileStream(AttachPath + "\\" + m.ContentDisposition.FileName, FileMode.Create,FileAccess.Write);
                            try {


                                MimePart m1 = m as MimePart;
                                m1.ContentTransferEncoding = ContentEncoding.Binary;
                                m1.WriteTo(FormatOptions.Default, attach, true);
                            }
                            finally {
                                attach.Close();
                            }

                        }
                    }
                }
                

            }
            catch (Exception ex) {

            }
            finally
            {
                f.Close();
            }




        }

     

        
    }
}
