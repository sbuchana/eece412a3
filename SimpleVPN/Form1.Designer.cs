namespace SimpleVPN
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.radioButton_server = new System.Windows.Forms.RadioButton();
            this.radioButton_client = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_continue = new System.Windows.Forms.Button();
            this.textBox_sent = new System.Windows.Forms.TextBox();
            this.textBox_received = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.label_status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_sharedsecretkey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(198, 263);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 7;
            this.button_send.Text = "Send";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 48);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 1;
            // 
            // radioButton_server
            // 
            this.radioButton_server.AutoSize = true;
            this.radioButton_server.Checked = true;
            this.radioButton_server.Location = new System.Drawing.Point(268, 26);
            this.radioButton_server.Name = "radioButton_server";
            this.radioButton_server.Size = new System.Drawing.Size(86, 17);
            this.radioButton_server.TabIndex = 9;
            this.radioButton_server.TabStop = true;
            this.radioButton_server.Text = "Server Mode";
            this.radioButton_server.UseVisualStyleBackColor = true;
            this.radioButton_server.CheckedChanged += new System.EventHandler(this.radioButton_server_CheckedChanged);
            // 
            // radioButton_client
            // 
            this.radioButton_client.AutoSize = true;
            this.radioButton_client.Location = new System.Drawing.Point(268, 49);
            this.radioButton_client.Name = "radioButton_client";
            this.radioButton_client.Size = new System.Drawing.Size(81, 17);
            this.radioButton_client.TabIndex = 10;
            this.radioButton_client.Text = "Client Mode";
            this.radioButton_client.UseVisualStyleBackColor = true;
            this.radioButton_client.CheckedChanged += new System.EventHandler(this.radioButton_client_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "IP Address";
            // 
            // button_continue
            // 
            this.button_continue.Location = new System.Drawing.Point(279, 263);
            this.button_continue.Name = "button_continue";
            this.button_continue.Size = new System.Drawing.Size(75, 23);
            this.button_continue.TabIndex = 8;
            this.button_continue.Text = "Continue";
            this.button_continue.UseVisualStyleBackColor = true;
            // 
            // textBox_sent
            // 
            this.textBox_sent.Location = new System.Drawing.Point(118, 91);
            this.textBox_sent.Multiline = true;
            this.textBox_sent.Name = "textBox_sent";
            this.textBox_sent.Size = new System.Drawing.Size(236, 64);
            this.textBox_sent.TabIndex = 3;
            // 
            // textBox_received
            // 
            this.textBox_received.Location = new System.Drawing.Point(118, 161);
            this.textBox_received.Multiline = true;
            this.textBox_received.Name = "textBox_received";
            this.textBox_received.Size = new System.Drawing.Size(236, 62);
            this.textBox_received.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Data to be Sent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Data as Received";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(118, 263);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(75, 23);
            this.button_connect.TabIndex = 6;
            this.button_connect.Text = "Connect";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(118, 299);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(109, 13);
            this.label_status.TabIndex = 15;
            this.label_status.Text = "Status: Disconnected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Shared Secret Value";
            // 
            // textBox_sharedsecretkey
            // 
            this.textBox_sharedsecretkey.Location = new System.Drawing.Point(118, 229);
            this.textBox_sharedsecretkey.Name = "textBox_sharedsecretkey";
            this.textBox_sharedsecretkey.Size = new System.Drawing.Size(236, 20);
            this.textBox_sharedsecretkey.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 323);
            this.Controls.Add(this.textBox_sharedsecretkey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_received);
            this.Controls.Add(this.textBox_sent);
            this.Controls.Add(this.button_continue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton_client);
            this.Controls.Add(this.radioButton_server);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SimpleVPN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RadioButton radioButton_server;
        private System.Windows.Forms.RadioButton radioButton_client;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_continue;
        private System.Windows.Forms.TextBox textBox_sent;
        private System.Windows.Forms.TextBox textBox_received;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_sharedsecretkey;
    }
}

