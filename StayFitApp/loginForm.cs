using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StayFitApp
{
    public partial class loginForm : Form
    {
        Database db = new Database();
        public loginForm()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (db.ExecuteScalar($"SELECT COUNT(*) FROM user WHERE username = '{tbUsername.Text}' AND password = '{tbPassword.Text}';") == "1")
            {
                DataTable dt = db.ExecuteStringQuery($"SELECT * FROM user WHERE username = '{tbUsername.Text}';");
                MessageBox.Show("You're logged in");
                mainForm mainform = new mainForm(dt);
                mainform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username of password is incorrect");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            registerForm registerform = new registerForm();
            registerform.Show();
            this.Hide();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btLogin_Click(this, new EventArgs());
            }
        }
    }
}
