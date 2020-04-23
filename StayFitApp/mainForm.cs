using StayFitApp.Classes;
using StayFitApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StayFitApp
{

    public partial class mainForm : Form
    {
        List<string> oefeningen = new List<string>();
        Random rnd;
        int random;
        SerialMessenger serialMessenger;
        MessageBuilder messageBuilder;
        Queries query;
        DataTable dtuser;
        User user;
        string PortName = "COM3";
        int BaudRate = 9600;
        int startTime;
        int endTime;

        Timer readMessageTimer = new Timer();

        public int time;
        
        public mainForm(DataTable dtuser)
        {
            InitializeComponent();

            query = new Queries();

            rnd = new Random();

            oefeningen.Add("10 sit-ups");
            oefeningen.Add("10 push-ups");
            oefeningen.Add("10 burpees");
            oefeningen.Add("20 sit-ups");
            oefeningen.Add("20 push-ups");
            oefeningen.Add("20 burpees");

            this.dtuser = dtuser;

            fillUser(dtuser);

            messageBuilder = new MessageBuilder();
            serialMessenger = new SerialMessenger(PortName, BaudRate, messageBuilder);

            readMessageTimer.Interval = 10;
            readMessageTimer.Tick += new EventHandler(ReadMessageTimer_Tick);

        }

        private void ReadMessageTimer_Tick(object sender, EventArgs e)
        {
            string message = serialMessenger.ReadMessages();
            if (message != null && message != "")
            {
                processReceivedMessage(message);
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            HistoryView historyview = new HistoryView(dtuser, user);
            historyview.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btStuur_Click(object sender, EventArgs e)
        {
            string message = $"#exercise:<{cbOefeningen.Text}>%";
            //MessageBox.Show(message);
            serialMessenger.SendMessage(message);
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                serialMessenger.Connect();
                readMessageTimer.Enabled = true;               
                Console.WriteLine("Connected to Arduino" + PortName);
                btConnect.BackColor = Color.Green;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            disconnect();
            Console.WriteLine("not connected");
            btConnect.BackColor = Color.Red;
        }

        private void disconnect()
        {
            try
            {
                readMessageTimer.Enabled = false;
                serialMessenger.Disconnect();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void processReceivedMessage(string message)
        {
            message = message.Trim();
            string[] commands = getParamValue(message);
            if (commands[0] == "startTime")
            {
                startTime = Int32.Parse(commands[1]);
                lbBerichten.Items.Add("Start tijd: " + DateTime.Now.ToString("HH:mm:ss"));
            }
            else if (commands[0] == "endTime")
            {
                endTime = Int32.Parse(commands[1]);
                int totalTimeInMS = endTime - startTime;
                int totalTimeInSeconds = totalTimeInMS / 1000;
                lbBerichten.Items.Add($"Eind tijd: " + DateTime.Now.ToString("HH:mm:ss"));
                lbBerichten.Items.Add($"Totale tijd: {totalTimeInSeconds} seconden");

                query.updateHistory(user.ID, random + 1, totalTimeInMS);
            }
            
        }

        private string[] getParamValue(string message)
        {
            string[] words = message.Split(':');

            return words;
        }

        void fillUser(DataTable dtuser)
        {
            foreach (DataRow row in dtuser.Rows)
            {
                int id = Int32.Parse(row["ID"].ToString());
                string name = row["name"].ToString();
                string username = row["username"].ToString();

                DataTable history = query.getHistory(id);

                user = new User(username, name, id, history);
            }

            lbWelcome.Text = $"Welcome {user.name}";
        }
        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btRandom_Click(object sender, EventArgs e)
        {
            random = rnd.Next(0, 6);
            lbBerichten.Items.Add(oefeningen[random]);
            serialMessenger.SendMessage(oefeningen[random]);
        }
    }
}
