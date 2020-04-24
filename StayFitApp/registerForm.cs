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
    public partial class registerForm : Form
    {
        Database db = new Database();
        public registerForm()
        {
            InitializeComponent();
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            //Check if the passwords are the same
            if (tbPassword.Text == tbRetype.Text)
            {
                //Check if the username already exists
                if (db.ExecuteScalar($"SELECT COUNT(*) FROM user WHERE username = '{tbUsername.Text}';") == "1")
                {
                    MessageBox.Show("Username already exists");
                }
                else
                {
                    //Create user with the provide information
                    if (db.ExecuteNonQuery($"INSERT INTO `fhictDB`.`user` (`username`, `password`, `name`) VALUES ('{tbUsername.Text}', '{tbPassword.Text} ', '{tbName.Text }');") == 1)
                    {
                        MessageBox.Show("User created");
                        loginForm loginform = new loginForm();
                        loginform.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong in creating your account");
                    }
                }
                               
            }
            else
            {
                MessageBox.Show("Passwords do not match");
            }
        }

        private void tbRetype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btRegister_Click(this, new EventArgs());
            }
        }
    }
}
