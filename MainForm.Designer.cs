namespace FaceliftMW
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lvTags = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label_buzzerStatus = new System.Windows.Forms.Label();
            this.label_buzzerIP = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_error_message2 = new System.Windows.Forms.Label();
            this.label_readerStatus2 = new System.Windows.Forms.Label();
            this.label_readerIP2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.PictureBox();
            this.pbSetting = new System.Windows.Forms.PictureBox();
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_apiStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_webservice_message = new System.Windows.Forms.Label();
            this.label_location = new System.Windows.Forms.Label();
            this.label_apiAddress = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_error_message = new System.Windows.Forms.Label();
            this.label_readerStatus = new System.Windows.Forms.Label();
            this.label_readerIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_tagCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.clock = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_delivery_note = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Facelift Middleware is running.";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // lvTags
            // 
            this.lvTags.HideSelection = false;
            this.lvTags.Location = new System.Drawing.Point(12, 346);
            this.lvTags.Name = "lvTags";
            this.lvTags.Size = new System.Drawing.Size(1112, 343);
            this.lvTags.TabIndex = 0;
            this.lvTags.UseCompatibleStateImageBehavior = false;
            this.lvTags.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lvTags_ColumnWidthChanging);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnRestart);
            this.panel1.Controls.Add(this.pbSetting);
            this.panel1.Controls.Add(this.pbInfo);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(12, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 272);
            this.panel1.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label_buzzerStatus);
            this.groupBox4.Controls.Add(this.label_buzzerIP);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(551, 165);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(478, 93);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buzzer Properties";
            // 
            // label_buzzerStatus
            // 
            this.label_buzzerStatus.AutoSize = true;
            this.label_buzzerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_buzzerStatus.Location = new System.Drawing.Point(128, 62);
            this.label_buzzerStatus.Name = "label_buzzerStatus";
            this.label_buzzerStatus.Size = new System.Drawing.Size(121, 18);
            this.label_buzzerStatus.TabIndex = 10;
            this.label_buzzerStatus.Text = "Not Connected";
            // 
            // label_buzzerIP
            // 
            this.label_buzzerIP.AutoSize = true;
            this.label_buzzerIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_buzzerIP.Location = new System.Drawing.Point(128, 33);
            this.label_buzzerIP.Name = "label_buzzerIP";
            this.label_buzzerIP.Size = new System.Drawing.Size(131, 18);
            this.label_buzzerIP.TabIndex = 9;
            this.label_buzzerIP.Text = "255.255.255.255";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 18);
            this.label11.TabIndex = 6;
            this.label11.Text = "Status";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 18);
            this.label14.TabIndex = 7;
            this.label14.Text = "IP Address";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_error_message2);
            this.groupBox1.Controls.Add(this.label_readerStatus2);
            this.groupBox1.Controls.Add(this.label_readerIP2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(529, 120);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reader 2 Properties";
            // 
            // label_error_message2
            // 
            this.label_error_message2.AutoSize = true;
            this.label_error_message2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_error_message2.Location = new System.Drawing.Point(6, 93);
            this.label_error_message2.Name = "label_error_message2";
            this.label_error_message2.Size = new System.Drawing.Size(88, 15);
            this.label_error_message2.TabIndex = 13;
            this.label_error_message2.Text = "Error Message";
            // 
            // label_readerStatus2
            // 
            this.label_readerStatus2.AutoSize = true;
            this.label_readerStatus2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_readerStatus2.Location = new System.Drawing.Point(128, 62);
            this.label_readerStatus2.Name = "label_readerStatus2";
            this.label_readerStatus2.Size = new System.Drawing.Size(121, 18);
            this.label_readerStatus2.TabIndex = 10;
            this.label_readerStatus2.Text = "Not Connected";
            // 
            // label_readerIP2
            // 
            this.label_readerIP2.AutoSize = true;
            this.label_readerIP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_readerIP2.Location = new System.Drawing.Point(128, 33);
            this.label_readerIP2.Name = "label_readerIP2";
            this.label_readerIP2.Size = new System.Drawing.Size(131, 18);
            this.label_readerIP2.TabIndex = 9;
            this.label_readerIP2.Text = "255.255.255.255";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 18);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 7;
            this.label8.Text = "IP Address";
            // 
            // btnRestart
            // 
            this.btnRestart.Image = global::FaceliftMW.Properties.Resources.refresh;
            this.btnRestart.Location = new System.Drawing.Point(1051, 80);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(40, 40);
            this.btnRestart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestart.TabIndex = 16;
            this.btnRestart.TabStop = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // pbSetting
            // 
            this.pbSetting.Image = global::FaceliftMW.Properties.Resources.settings;
            this.pbSetting.Location = new System.Drawing.Point(1050, 23);
            this.pbSetting.Name = "pbSetting";
            this.pbSetting.Size = new System.Drawing.Size(40, 40);
            this.pbSetting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSetting.TabIndex = 15;
            this.pbSetting.TabStop = false;
            this.pbSetting.Click += new System.EventHandler(this.pbSetting_Click);
            // 
            // pbInfo
            // 
            this.pbInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbInfo.Image")));
            this.pbInfo.Location = new System.Drawing.Point(1051, 142);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(40, 40);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInfo.TabIndex = 14;
            this.pbInfo.TabStop = false;
            this.pbInfo.Click += new System.EventHandler(this.pbInfo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label_apiStatus);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label_webservice_message);
            this.groupBox3.Controls.Add(this.label_location);
            this.groupBox3.Controls.Add(this.label_apiAddress);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(551, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 154);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Web-service Properties";
            // 
            // label_apiStatus
            // 
            this.label_apiStatus.AutoSize = true;
            this.label_apiStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_apiStatus.Location = new System.Drawing.Point(95, 62);
            this.label_apiStatus.Name = "label_apiStatus";
            this.label_apiStatus.Size = new System.Drawing.Size(121, 18);
            this.label_apiStatus.TabIndex = 13;
            this.label_apiStatus.Text = "Not Connected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Status";
            // 
            // label_webservice_message
            // 
            this.label_webservice_message.AutoSize = true;
            this.label_webservice_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_webservice_message.Location = new System.Drawing.Point(6, 129);
            this.label_webservice_message.Name = "label_webservice_message";
            this.label_webservice_message.Size = new System.Drawing.Size(151, 18);
            this.label_webservice_message.TabIndex = 11;
            this.label_webservice_message.Text = "Sending 10 Data ...";
            // 
            // label_location
            // 
            this.label_location.AutoSize = true;
            this.label_location.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_location.Location = new System.Drawing.Point(95, 93);
            this.label_location.Name = "label_location";
            this.label_location.Size = new System.Drawing.Size(0, 18);
            this.label_location.TabIndex = 10;
            // 
            // label_apiAddress
            // 
            this.label_apiAddress.AutoSize = true;
            this.label_apiAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_apiAddress.Location = new System.Drawing.Point(95, 33);
            this.label_apiAddress.Name = "label_apiAddress";
            this.label_apiAddress.Size = new System.Drawing.Size(347, 18);
            this.label_apiAddress.TabIndex = 9;
            this.label_apiAddress.Text = "https://255.255.255.255:8433/FaceliftMW/Api/";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 18);
            this.label12.TabIndex = 6;
            this.label12.Text = "Location";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 18);
            this.label13.TabIndex = 7;
            this.label13.Text = "URL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_error_message);
            this.groupBox2.Controls.Add(this.label_readerStatus);
            this.groupBox2.Controls.Add(this.label_readerIP);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(529, 120);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reader 1 Properties";
            // 
            // label_error_message
            // 
            this.label_error_message.AutoSize = true;
            this.label_error_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_error_message.Location = new System.Drawing.Point(6, 93);
            this.label_error_message.Name = "label_error_message";
            this.label_error_message.Size = new System.Drawing.Size(88, 15);
            this.label_error_message.TabIndex = 13;
            this.label_error_message.Text = "Error Message";
            // 
            // label_readerStatus
            // 
            this.label_readerStatus.AutoSize = true;
            this.label_readerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_readerStatus.Location = new System.Drawing.Point(128, 62);
            this.label_readerStatus.Name = "label_readerStatus";
            this.label_readerStatus.Size = new System.Drawing.Size(121, 18);
            this.label_readerStatus.TabIndex = 10;
            this.label_readerStatus.Text = "Not Connected";
            // 
            // label_readerIP
            // 
            this.label_readerIP.AutoSize = true;
            this.label_readerIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_readerIP.Location = new System.Drawing.Point(128, 33);
            this.label_readerIP.Name = "label_readerIP";
            this.label_readerIP.Size = new System.Drawing.Size(131, 18);
            this.label_readerIP.TabIndex = 9;
            this.label_readerIP.Text = "255.255.255.255";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP Address";
            // 
            // label_tagCount
            // 
            this.label_tagCount.AutoSize = true;
            this.label_tagCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tagCount.ForeColor = System.Drawing.Color.White;
            this.label_tagCount.Location = new System.Drawing.Point(155, 315);
            this.label_tagCount.Name = "label_tagCount";
            this.label_tagCount.Size = new System.Drawing.Size(20, 24);
            this.label_tagCount.TabIndex = 11;
            this.label_tagCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Pallet(s) :";
            // 
            // clock
            // 
            this.clock.AutoSize = true;
            this.clock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clock.ForeColor = System.Drawing.Color.White;
            this.clock.Location = new System.Drawing.Point(12, 7);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(57, 24);
            this.clock.TabIndex = 12;
            this.clock.Text = "Clock";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(583, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 24);
            this.label4.TabIndex = 28;
            this.label4.Text = "Scan/ Input QR Code :";
            // 
            // txt_delivery_note
            // 
            this.txt_delivery_note.Enabled = false;
            this.txt_delivery_note.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_delivery_note.Location = new System.Drawing.Point(787, 313);
            this.txt_delivery_note.Name = "txt_delivery_note";
            this.txt_delivery_note.Size = new System.Drawing.Size(337, 28);
            this.txt_delivery_note.TabIndex = 29;
            this.txt_delivery_note.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_delivery_note_KeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(1141, 699);
            this.Controls.Add(this.txt_delivery_note);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.label_tagCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lvTags);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facelift Middleware {0}";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ListView lvTags;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_tagCount;
        private System.Windows.Forms.Label label_readerStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_error_message;
        private System.Windows.Forms.Label label_readerIP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label_location;
        private System.Windows.Forms.Label label_apiAddress;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.PictureBox pbSetting;
        private System.Windows.Forms.Label clock;
        private System.Windows.Forms.PictureBox btnRestart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_error_message2;
        private System.Windows.Forms.Label label_readerStatus2;
        private System.Windows.Forms.Label label_readerIP2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_webservice_message;
        private System.Windows.Forms.Label label_apiStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_delivery_note;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_buzzerStatus;
        private System.Windows.Forms.Label label_buzzerIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
    }
}

