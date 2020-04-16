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

        private void processReceivedMessage(string message)
        {
            // First trim whitespace characters like a trailing '\r'.
            // This is needed because the Arduino Serial.println adds \r\n.
            // '\n' will be removed because this is used as the message separation character,
            // but the '\r' must also be removed, otherwise comparing the message strings will not work.
            message = message.Trim();
            // Add message to the listBox.
            lbBerichten.Items.Add(message);
            // TODO: Below fill in your message handling.

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
            MessageBox.Show(message);
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
    }
}
