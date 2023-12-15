using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLDAPAuth
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var ldap = new LdapAuthentication();
                if (ldap.Authenticate(txtUserName.Text.ToLower(), txtPassword.Text))
                {
                    MessageBox.Show("Login Succeed");

                }
                else
                {
                    MessageBox.Show("Login Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
