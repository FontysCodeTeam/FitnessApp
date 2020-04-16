using StayFitApp.Classes;
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

    public partial class Form1 : Form
    {
        SerialMessenger serialMessenger;
        MessageBuilder messageBuilder;
        string PortName = "COM3";
        int BaudRate = 9600;
        int startTime;
        int endTime;

        Timer readMessageTimer = new Timer();

        public int time;
        
        public Form1()
        {
            InitializeComponent();

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
            HistoryView historyview = new HistoryView();
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
                int totalTime = endTime - startTime;
                totalTime = totalTime / 1000;
                lbBerichten.Items.Add($"Eind tijd: " + DateTime.Now.ToString("HH:mm:ss"));
                lbBerichten.Items.Add($"Totale tijd: {totalTime} seconden");
            }
            
        }

        private string[] getParamValue(string message)
        {
            string[] words = message.Split(':');

            return words;
        }
    }
}
