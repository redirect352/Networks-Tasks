using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MailClasses.MimeWork;
using MailClasses.User;

namespace MyMailClient
{

   

    public class FilesWork
    {

        string[] ImageExists = { "mpg", "odf", "ods", "odt", "otp", "ots", "ott", "pdf", "php", "png", "ppt", "psd", "py", "qt", "rar", "rb", "rtf", "sass", "scss", "sql", "tga", "tgz",
            "tiff", "txt", "wav", "xls", "xlsx", "xml", "yml", "zip", "_blank", "_page", "aac",
            "ai", "aiff", "avi", "bmp", "c", "cpp", "css", "csv", "dat", "dmg", "doc", "dotx", "dwg", "dxf", "eps", "exe", "flv", "gif", "h", "hpp", "html",
            "ics", "iso", "java", "jpg", "js", "key", "less", "mid", "mp3", "mp4" };

        public void GetPathtoicon(string filepath) {
            string ext = filepath.Substring(filepath.LastIndexOf('.')+1);
            foreach(string s in ImageExists)
            {
                if (s==ext) {
                    //profit
                }

            }
            
        }

        public static void CheckAllNeededFoldersExists(string AccountName) {
            if (!Directory.Exists("mail"))
                Directory.CreateDirectory("mail");
            if (AccountName != "") {

                    Directory.CreateDirectory("mail\\" + AccountName + "-mails");
                    Directory.CreateDirectory("mail\\" + AccountName + "-mails\\Inbox");
                    Directory.CreateDirectory("mail\\" + AccountName + "-mails\\Trash");
                    Directory.CreateDirectory("mail\\" + AccountName + "-mails\\Spam");
                    Directory.CreateDirectory("mail\\" + AccountName + "-mails\\Sent");
                
            }

        }

        public static List<int> GetAllLoadedEmailsInForder(string folderPath) {
            List<int> res = null;

            try {
                var dir = Directory.EnumerateFiles(folderPath);
                int tmp = 0;
                string buf = "";
                foreach (string s in dir) {
                    tmp = GetFileNumb(s);
                    if (tmp!=-1) {
                        if (res == null)
                            res = new List<int>();
                        res.Add(tmp);

                    }
                }
            }
            catch { }

            return res;
        }

        public static int GetFileNumb(string s)
        {
            int tmp = -1;
            string buf = buf = (s.Substring(s.LastIndexOf('\\') + 1));
            buf = buf.Remove(buf.IndexOf('.'));
            if (int.TryParse(buf, out tmp))
                return tmp;
            else
                return -1;

        }


        public static void ShowEmailsInFolder(string path, ListView lv,ref mailFolderInfo mf,List<int> UNSEEN)
        {
            
            lv.Items.Clear();
            DirectoryInfo d = new DirectoryInfo(path);
            var f = d.GetFiles();
            int ind = 0;

            DateTime time = new DateTime();
            string groupName = "";
            foreach (FileInfo info in f)
            {

                ListViewItem tmp = new ListViewItem(MimeDecrypter.GetSubjectAndDate(info.FullName, ref time));
                //if () { }
                groupName = time.Day.ToString() + "." + time.Month.ToString() + "." + time.Year.ToString();
                bool NeednewGroup = true;
                foreach (ListViewGroup g in lv.Groups)
                {
                    if (g.Name == groupName)
                    {
                        tmp.Group = g;
                        NeednewGroup = false;
                    }
                }
                if (NeednewGroup)
                {
                    ListViewGroup group = new ListViewGroup();
                    group.Name = groupName;
                    group.Header = groupName;
                    
                    lv.Groups.Add(group);
                    tmp.Group = group;
                }
                int MessageUid = FilesWork.GetFileNumb(info.FullName);
                if (UNSEEN.Contains(MessageUid)) {
                    tmp.ForeColor = System.Drawing.Color.DarkBlue;
                                      
                }

                lv.Items.Add(tmp);
                if (mf!=null)
                     mf.Mails.Add(new MailInfo(tmp.Text, MessageUid));
                ind++;
            }
            lv.ListViewItemSorter = new ListViewComparer(0,SortOrder.Ascending);
            lv.Sort();

            ListViewGroup[] groups = new ListViewGroup[lv.Groups.Count];
            lv.Groups.CopyTo(groups, 0);

            Array.Sort(groups, (IComparer<ListViewGroup>)(new GroupComparer()));

            lv.BeginUpdate();
            lv.Groups.Clear();
            lv.Groups.AddRange(groups);
            lv.EndUpdate();

        }



        public class ListViewComparer : System.Collections.IComparer
        {
            private int ColumnNumber;
            private SortOrder SortOrder;

            public ListViewComparer(int column_number,
                SortOrder sort_order)
            {
                ColumnNumber = column_number;
                SortOrder = sort_order;
            }

            // Сравнение двух списков ListViewItems.
            public int Compare(object object_x, object object_y)
            {
                // Получить объекты как ListViewItems.
                ListViewItem item_x = object_x as ListViewItem;
                ListViewItem item_y = object_y as ListViewItem;

                // Получаем соответствующие значения подпозиции.
                string string_x;
                if (item_x.SubItems.Count <= ColumnNumber)
                {
                    string_x = "";
                }
                else
                {
                    string_x = item_x.SubItems[ColumnNumber].Text;
                }

                string string_y;
                if (item_y.SubItems.Count <= ColumnNumber)
                {
                    string_y = "";
                }
                else
                {
                    string_y = item_y.SubItems[ColumnNumber].Text;
                }

                // Сравните их.
                int result;
                double double_x, double_y;
                if (double.TryParse(string_x, out double_x) &&
            double.TryParse(string_y, out double_y))
                {
                    // Обрабатываем как число.
                    result = double_x.CompareTo(double_y);
                }
                else
                {
                    DateTime date_x, date_y;
                    if (DateTime.TryParse(string_x, out date_x) &&
                DateTime.TryParse(string_y, out date_y))
                    {
                        // Обработать как дату.
                        result = date_x.CompareTo(date_y);
                    }
                    else
                    {
                        // Обработать как строку.
                        result = string_x.CompareTo(string_y);
                    }
                }

                // Вернуть правильный результат в зависимости от того,
                // сортируем по возрастанию или по убыванию.
                if (SortOrder == SortOrder.Ascending)
                {
                    return result;
                }
                else
                {
                    return -result;
                }
            }
        }

        class GroupComparer : IComparer<ListViewGroup>
        {
            public int Compare(ListViewGroup objA, ListViewGroup objB)
            {
                DateTime time1 = DateTime.Parse(objA.Header);
                DateTime time2 = DateTime.Parse(objB.Header);

                return DateTime.Compare(time2,time1);
            }
        }

    }
}
