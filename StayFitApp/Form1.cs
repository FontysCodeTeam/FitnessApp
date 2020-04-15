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
    public partial class Form1 : Form
    {
        public int time;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            var newForm = new HistoryView();
            newForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
