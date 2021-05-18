using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2;
using MailClasses.User;

namespace MyMailClient
{
    public partial class MainForm : Form
    {
        LinkedList<AuthorizedUser> authorizedUsers = new LinkedList<MailClasses.User.AuthorizedUser> { };

        public MainForm()
        {
            InitializeComponent(); 
            
        }

        private void AccountsButton_Click(object sender, EventArgs e)
        {
            EnterForm ent = new EnterForm();
            if (ent.ShowDialog() == DialogResult.OK)
            {
                usersBox.Items.Add(ent.Login);
                authorizedUsers.AddLast( new AuthorizedUser(ent.Login, ent.Password));

            }

        }
    }
}
