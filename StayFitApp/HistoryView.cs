using StayFitApp.Classes;
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
    public partial class HistoryView : Form
    {
        DataTable dtuser;
        User user;
        public HistoryView(DataTable dtuser, User user)
        {
            InitializeComponent();

            this.dtuser = dtuser;
            this.user = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm mainform = new mainForm(dtuser);
            mainform.Show();
            this.Hide();
        }

        private void HistoryView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void HistoryView_Load(object sender, EventArgs e)
        {
            dgvHistory.DataSource = user.history;
        }
    }
}
