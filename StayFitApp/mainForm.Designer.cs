namespace StayFitApp
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHistory = new System.Windows.Forms.Button();
            this.btStuur = new System.Windows.Forms.Button();
            this.lbBerichten = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btConnect = new System.Windows.Forms.Button();
            this.btDisconnect = new System.Windows.Forms.Button();
            this.cbOefeningen = new System.Windows.Forms.ComboBox();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(161, 11);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(71, 36);
            this.btnHistory.TabIndex = 3;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btStuur
            // 
            this.btStuur.Location = new System.Drawing.Point(190, 65);
            this.btStuur.Name = "btStuur";
            this.btStuur.Size = new System.Drawing.Size(75, 23);
            this.btStuur.TabIndex = 6;
            this.btStuur.Text = "Stuur bericht";
            this.btStuur.UseVisualStyleBackColor = true;
            this.btStuur.Click += new System.EventHandler(this.btStuur_Click);
            // 
            // lbBerichten
            // 
            this.lbBerichten.FormattingEnabled = true;
            this.lbBerichten.Location = new System.Drawing.Point(13, 142);
            this.lbBerichten.Name = "lbBerichten";
            this.lbBerichten.Size = new System.Drawing.Size(252, 212);
            this.lbBerichten.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ontvangen berichten:";
            // 
            // btConnect
            // 
            this.btConnect.BackColor = System.Drawing.Color.Red;
            this.btConnect.Location = new System.Drawing.Point(11, 11);
            this.btConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(71, 36);
            this.btConnect.TabIndex = 9;
            this.btConnect.Text = "Connect";
            this.btConnect.UseVisualStyleBackColor = false;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // btDisconnect
            // 
            this.btDisconnect.Location = new System.Drawing.Point(86, 11);
            this.btDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btDisconnect.Name = "btDisconnect";
            this.btDisconnect.Size = new System.Drawing.Size(71, 36);
            this.btDisconnect.TabIndex = 10;
            this.btDisconnect.Text = "Disconnect";
            this.btDisconnect.UseVisualStyleBackColor = true;
            this.btDisconnect.Click += new System.EventHandler(this.btDisconnect_Click);
            // 
            // cbOefeningen
            // 
            this.cbOefeningen.FormattingEnabled = true;
            this.cbOefeningen.Items.AddRange(new object[] {
            "10 Sit-ups",
            "20 Burpees",
            "5 Radslagen"});
            this.cbOefeningen.Location = new System.Drawing.Point(15, 65);
            this.cbOefeningen.Name = "cbOefeningen";
            this.cbOefeningen.Size = new System.Drawing.Size(121, 21);
            this.cbOefeningen.TabIndex = 11;
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.Location = new System.Drawing.Point(246, 11);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(93, 33);
            this.lbWelcome.TabIndex = 12;
            this.lbWelcome.Text = "label2";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.cbOefeningen);
            this.Controls.Add(this.btDisconnect);
            this.Controls.Add(this.btConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbBerichten);
            this.Controls.Add(this.btStuur);
            this.Controls.Add(this.btnHistory);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btStuur;
        private System.Windows.Forms.ListBox lbBerichten;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btConnect;
        private System.Windows.Forms.Button btDisconnect;
        private System.Windows.Forms.ComboBox cbOefeningen;
        private System.Windows.Forms.Label lbWelcome;
    }
}

