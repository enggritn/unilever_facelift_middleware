using Impinj.OctaneSdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using TimerSW = System.Timers.Timer;

namespace FaceliftMW
{
    public partial class MainForm : Form
    {
        private ContextMenu trayMenu = new ContextMenu();

        Config config = new Config();
        WebService webService = new WebService();

        Timer tClock = new Timer();
        TimerSW timerPost = new TimerSW();

        List<RfidTag> list = new List<RfidTag>();
        List<string> items = new List<string>();

        static List<ImpinjReader> readers = new List<ImpinjReader>();

        int num = 1;


        BackgroundWorker bw;
        BackgroundWorker bw2;
        BackgroundWorker bw3;


        private string TransactionId = "";
        private string ShipmentType = "";
        private int totalPallet = 0;


        bool BuzzerConnected = false;

        public MainForm()
        {
            InitializeComponent();
            trayMenu.MenuItems.Add("Show", OnShow);
            trayMenu.MenuItems.Add("Exit", OnExit);
            notifyIcon.ContextMenu = trayMenu;

            string title = Text;
            Text = string.Format(title, Config.GetVersion());
            label_error_message.Text = "";
            label_error_message2.Text = "";
            label_webservice_message.Text = "";
            timerPost.Interval = 10 * 1000;
            timerPost.Elapsed += timerPost_Tick;

            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(DoWork);

            bw2 = new BackgroundWorker();
            bw2.DoWork += new DoWorkEventHandler(DoWork2);
            bw2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Complete2);

            bw3 = new BackgroundWorker();
            bw3.DoWork += new DoWorkEventHandler(DoWork3);
            bw3.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Complete3);
        }


        private void timerPost_Tick(object sender, EventArgs e)
        {
            PostData();
        }


        private void tClock_Tick(object sender, EventArgs e)
        {
            clock.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnShow(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.BalloonTipText = "Facelift Middleware still running in background.";
                notifyIcon.ShowBalloonTip(1000);
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void pbSetting_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
        }

        private void pbInfo_Click(object sender, EventArgs e)
        {
            InformationForm informationForm = new InformationForm();
            informationForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DoSettings();
        }

        private void showNotification(string msg)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon.BalloonTipText = msg;
                notifyIcon.ShowBalloonTip(30000);
            }
           
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            //DoSettings();
        }

        private void DoSettings()
        {
            if (config.IsConfigured)
            {
                if (!bw2.IsBusy)
                    bw2.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Please check application settings and please make sure all connection online.");
                SettingForm settingForm = new SettingForm();
                settingForm.ShowDialog();
            }
        }

        
        private void MainForm_Shown(object sender, EventArgs e)
        {
            tClock.Interval = 1000;
            tClock.Tick += new EventHandler(tClock_Tick);
            tClock.Start();
            LoadData();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Restarting application ...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            Application.Restart();
        }

        private void LoadData()
        {
            lvTags.View = View.Details;
            lvTags.GridLines = true;

            lvTags.Columns.Add("No.", 50, HorizontalAlignment.Left);
            lvTags.Columns.Add("Tag ID", 200, HorizontalAlignment.Left);
            lvTags.Columns.Add("Count", 80, HorizontalAlignment.Left);
            lvTags.Columns.Add("Reader", 180, HorizontalAlignment.Left);
            lvTags.Columns.Add("Antenna", 140, HorizontalAlignment.Left);
            lvTags.Columns.Add("Read At", 180, HorizontalAlignment.Left);

        }

        private void AddData(ReaderData tag)
        {
            if (lvTags.InvokeRequired)
            {
                lvTags.Invoke(new MethodInvoker(delegate
                {
                    lvTags.Items.Add(new ListViewItem(new string[] { num.ToString(), tag.Tag, "1", tag.Host, tag.Port, DateTime.Now.ToString() }));
                }));
            }

            if (label_tagCount.InvokeRequired)
            {
                label_tagCount.Invoke(new MethodInvoker(delegate
                {
                    label_tagCount.Text = num.ToString();
                    num++;
                }));
            }
        }

        private void UpdateData(ReaderData tag)
        {
            if (lvTags.InvokeRequired)
            {
                lvTags.Invoke(new MethodInvoker(delegate
                {
                    ListViewItem lvi = lvTags.FindItemWithText(tag.Tag);
                    if (lvi != null)
                    {
                        int count = Convert.ToInt32(lvi.SubItems[2].Text) + 1;
                        lvi.SubItems[2].Text = count.ToString();
                        lvi.SubItems[3].Text = tag.Host;
                        lvi.SubItems[4].Text = tag.Port;
                        lvi.SubItems[5].Text = DateTime.Now.ToString();
                    }
                }));
            }
           
        }


        public void UpdateApiStatus(bool status)
        {
            label_apiStatus.Invoke((MethodInvoker)delegate
            {
                label_apiStatus.Text = status ? "Connected" : "Not Connected";
                label_apiStatus.ForeColor = status ? Color.DarkGreen : Color.DarkRed;
            });
        }

        public void UpdateBuzzerStatus(bool status)
        {
            label_buzzerStatus.Invoke((MethodInvoker)delegate
            {
                label_buzzerStatus.Text = status ? "Connected" : "Not Connected";
                label_buzzerStatus.ForeColor = status ? Color.DarkGreen : Color.DarkRed;
            });
        }

        private void UpdateWebserviceMsg(string msg)
        {
            if (label_webservice_message.InvokeRequired)
            {
                label_webservice_message.Invoke(new MethodInvoker(delegate
                {
                    label_webservice_message.Text = msg;
                }));
            }
        }

        private void UpdateWebserviceColor(bool status)
        {
            if (label_webservice_message.InvokeRequired)
            {
                label_webservice_message.Invoke(new MethodInvoker(delegate
                {
                    label_webservice_message.ForeColor = status ? Color.Green : Color.Red;
                }));
            }
        }

        private void ClearData()
        {
            if (lvTags.InvokeRequired)
            {
                lvTags.Invoke(new MethodInvoker(delegate
                {
                    items.Clear();
                    list.Clear();
                    lvTags.Items.Clear();
                    num = 1;
                }));
            }

            if (label_tagCount.InvokeRequired)
            {
                label_tagCount.Invoke(new MethodInvoker(delegate
                {
                    label_tagCount.Text = "0";
                }));
            }

        }

        private void lvTags_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lvTags.Columns[e.ColumnIndex].Width;
        }

        public void UpdateReaderStatus(bool status, int curReader)
        {
            if(curReader == 0)
            {
                label_readerStatus.Invoke((MethodInvoker)delegate
                {
                    label_readerStatus.Text = status ? "Connected" : "Not Connected";
                    label_readerStatus.ForeColor = status ? Color.DarkGreen : Color.DarkRed;
                });
            }
            else
            {
                label_readerStatus2.Invoke((MethodInvoker)delegate
                {
                    label_readerStatus2.Text = status ? "Connected" : "Not Connected";
                    label_readerStatus2.ForeColor = status ? Color.DarkGreen : Color.DarkRed;
                });
            }
        }

        public void UpdateReaderErrorMsg(String message, int curReader)
        {
            if(curReader == 0)
            {
                label_error_message.Invoke((MethodInvoker)delegate
                {
                    label_error_message.Text = message;
                    label_error_message.ForeColor = Color.DarkRed;
                });
            }
            else
            {
                label_error_message2.Invoke((MethodInvoker)delegate
                {
                    label_error_message2.Text = message;
                    label_error_message2.ForeColor = Color.DarkRed;
                });
            }
        }

        private void StartRfidReader()
        {
            if (!bw.IsBusy)
                bw.RunWorkerAsync();
           
        }

        private void StartBuzzer()
        {
            if (!bw3.IsBusy)
                bw3.RunWorkerAsync();

        }


        void DoWork(object sender, DoWorkEventArgs e)
        {
            StartRFID();
        }

        private void StartRFID()
        {
            int curReader = 0;
            try
            {
                string hostname1 = config.ReaderIPs[0];

                // Create two reader instances and add them to the List of readers.
                readers.Add(new ImpinjReader(hostname1, "Reader #1"));
                label_readerStatus.Invoke((MethodInvoker)delegate
                {
                    label_readerStatus.Text = "Connecting ...";
                });


                if (!config.ReaderIPs[1].Equals(""))
                {
                    string hostname2 = config.ReaderIPs[1];
                    readers.Add(new ImpinjReader(hostname2, "Reader #2"));
                    label_readerStatus2.Invoke((MethodInvoker)delegate
                    {
                        label_readerStatus2.Text = "Connecting ...";
                    });
                }

                foreach (ImpinjReader reader in readers)
                {
                    try
                    {
                        // Connect to the reader
                        reader.Connect();
                        Console.WriteLine("Attempting to connect to {0}.", reader.Name);
                        Settings settings = reader.QueryDefaultSettings();
                        settings.Report.IncludeAntennaPortNumber = true;
                        settings.ReaderMode = ReaderMode.AutoSetDenseReader;
                        settings.SearchMode = SearchMode.DualTarget;
                        settings.Session = 2;

                        int totalAntenna = 4;
                        for (int i = 1; i <= totalAntenna; i++)
                        {
                            ushort idx = (ushort)i;
                            settings.Antennas.GetAntenna(idx).MaxRxSensitivity = true;
                            settings.Antennas.GetAntenna(idx).MaxTransmitPower = true;
                        }


                        reader.ApplySettings(settings);

                        reader.ReaderStarted += OnReaderStarted;
                        reader.ReaderStopped += OnReaderStopped;
                        reader.ConnectionLost += OnConnectionLost;
                        reader.TagsReported += OnTagsReported;
                        UpdateReaderStatus(true, curReader);
                        txt_delivery_note.Invoke((MethodInvoker)delegate
                        {
                            txt_delivery_note.Enabled = true;
                            txt_delivery_note.Focus();
                        });
                    }
                    catch (OctaneSdkException ex)
                    {
                        string msg = string.Format("{0}", ex.Message);
                        Console.WriteLine(msg);
                        UpdateReaderStatus(false, curReader);
                        UpdateReaderErrorMsg(msg, curReader);
                    }

                    curReader++;
                }


            }
            catch (Exception ex)
            {
                string msg = string.Format("Exception: {0}", ex.Message);
                Console.WriteLine(msg);
                UpdateReaderStatus(false, curReader);
                UpdateReaderErrorMsg(msg, curReader);
            }
        }

        void DoWork2(object sender, DoWorkEventArgs e)
        {
            bool ApiConnected = false;
            try
            {
                label_readerIP.Invoke((MethodInvoker)delegate
                {
                    label_readerIP.Text = config.ReaderIPs[0];
                });

                label_readerIP2.Invoke((MethodInvoker)delegate
                {
                    label_readerIP2.Text = config.ReaderIPs[1];
                });

                label_apiAddress.Invoke((MethodInvoker)delegate
                {
                    label_apiAddress.Text = config.ApiAddress;
                });

                label_location.Invoke((MethodInvoker)delegate
                {
                    label_location.Text = config.Location;
                });

                label_apiStatus.Invoke((MethodInvoker)delegate
                {
                    label_apiStatus.Text = "Connecting ...";
                });

                label_buzzerIP.Invoke((MethodInvoker)delegate
                {
                    label_buzzerIP.Text = config.BuzzerIP;
                });

                label_buzzerStatus.Invoke((MethodInvoker)delegate
                {
                    label_buzzerStatus.Text = "Connecting ...";
                });


                //check webservice connection, check warehouse exist in database
                BaseResponse response = webService.CheckWarehouse(config.Location);
                ApiConnected  = response.status;

            }
            catch (Exception ex)
            {
                string msg = string.Format("Exception: {0}", ex.Message);
                Console.WriteLine(msg);
            }

            e.Result = ApiConnected;

        }

        void Complete2(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = (bool)e.Result;
            UpdateApiStatus(result);
            if (!result)
            {
                MessageBox.Show("Please check application settings and please make sure all connection online.");
                SettingForm settingForm = new SettingForm();
                settingForm.ShowDialog();
            }
            else
            {
                Thread threadReader = new Thread(new ThreadStart(StartRfidReader));
                threadReader.Start();

                Thread threadBuzzer = new Thread(new ThreadStart(StartBuzzer));
                threadBuzzer.Start();
            }
        }

        void DoWork3(object sender, DoWorkEventArgs e)
        {
            try
            {
                //check buzzer connection
                BuzzerConnected = webService.CheckBuzzer();
            }
            catch (Exception ex)
            {
                string msg = string.Format("Exception: {0}", ex.Message);
                Console.WriteLine(msg);
            }

            e.Result = BuzzerConnected;
        }

        void Complete3(object sender, RunWorkerCompletedEventArgs e)
        {
            bool result = (bool)e.Result;
            UpdateBuzzerStatus(result);
            if (result)
            {
                webService.SendBuzzer("S", "5");
                Thread.Sleep(2000);
                webService.SendBuzzer("S", "0");
                webService.SendBuzzer("1", "2");
                webService.SendBuzzer("2", "2");
                webService.SendBuzzer("3", "2");
                Thread.Sleep(5000);
                webService.SendBuzzer("1", "3");
                webService.SendBuzzer("2", "3");
                webService.SendBuzzer("3", "3");
            }
           
        }

        void OnConnectionLost(ImpinjReader reader)
        {
            // This event handler is called if the reader  
            // stops sending keepalive messages (connection lost).
            Console.WriteLine("Connection lost : {0} ({1})", reader.Name, reader.Address);

            label_readerStatus.Invoke((MethodInvoker)delegate
            {
                label_readerStatus.Text = "Not Connected";
                label_readerStatus.ForeColor = Color.DarkRed;
            });

            label_error_message.Invoke((MethodInvoker)delegate
            {
                label_error_message.Text = string.Format("Connection lost : {0})", reader.Address);
                label_error_message.ForeColor = Color.DarkRed;
            });

            // Cleanup
            reader.Disconnect();

        }

        // This event handler gets called when the reader is started.
        void OnReaderStarted(ImpinjReader reader, ReaderStartedEvent e)
        {
            Console.WriteLine("Successfully connected.");
            int curIndex = readers.IndexOf(readers.Where(p => p.Address == reader.Address).FirstOrDefault());
            //UpdateReaderStatus(true, curIndex);
        }

        // This event handler gets called when the reader is stopped.
        void OnReaderStopped(ImpinjReader reader, ReaderStoppedEvent e)
        {
            Console.WriteLine("Successfully disconnected.");
            int curIndex = readers.IndexOf(readers.Where(p => p.Address == reader.Address).FirstOrDefault());
            //UpdateReaderStatus(false, curIndex);
        }

        private void OnTagsReported(ImpinjReader sender, TagReport report)
        {
            lock (report)
            {
                foreach (Tag tag in report)
                {

                    RfidTag rfidTag = new RfidTag()
                    {
                        TagId = tag.Epc.ToString().Trim(),
                        Antenna = tag.AntennaPortNumber.ToString(),
                        ReadAt = DateTime.Now,
                        Location = config.Location
                    };
                    ReaderData readerData = new ReaderData()
                    {
                        Tag = rfidTag.TagId,
                        Location = rfidTag.Location,
                        Host = sender.Address,
                        Port = rfidTag.Antenna
                    };
                    try
                    {
                        RfidTag tagExist = null;
                        if(list.Count() > 0)
                        {
                            tagExist = list.FirstOrDefault(r => r.TagId.Equals(tag.Epc.ToString().Trim()));
                        }

                        if (tagExist == null)
                        {
                            timerPost.Stop();
                            list.Add(rfidTag);
                            items.Add(rfidTag.TagId);
                            AddData(readerData);
                            timerPost.Start();
                        }
                        else
                        {
                            UpdateData(readerData);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
            }
        }


        private void txt_delivery_note_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                string deliveryNote = txt_delivery_note.Text;
                if (!deliveryNote.Equals(""))
                {
                    //check warehouse exist in database
                    BaseResponse response = webService.CheckWarehouse(config.Location);
                    if (response.status)
                    {
                        BaseResponse baseResponse = webService.FindDeliveryNote(deliveryNote);
                        if (baseResponse.status)
                        {
                            TransactionId = baseResponse.TransactionId;
                            ShipmentType = baseResponse.ShipmentType;
                            totalPallet = baseResponse.TotalPallet;
                            //get total inbound
                            StartReader();
                        }
                        else
                        {
                            MessageBox.Show(baseResponse.message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response.message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("Delivery Note cannot be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void StartReader()
        {
            txt_delivery_note.Invoke((MethodInvoker)delegate
            {
                txt_delivery_note.Enabled = false;
            });
            int curReader = 0;
            foreach (ImpinjReader reader in readers)
            {
                try
                {
                    if (reader.IsConnected)
                    {
                        reader.Start();
                    }
                }
                catch (OctaneSdkException ex)
                {
                    //string msg = string.Format("Octane SDK exception: {0}", ex.Message);
                    string msg = string.Format("{0}", ex.Message);
                    Console.WriteLine(msg);
                    UpdateReaderStatus(false, curReader);
                    UpdateReaderErrorMsg(msg, curReader);
                }

                curReader++;
            }
        }

        private void StopReader()
        {
            int curReader = 0;
            foreach (ImpinjReader reader in readers)
            {
                try
                {
                    if (reader.IsConnected)
                    {
                        reader.Stop();
                    }
                }
                catch (OctaneSdkException ex)
                {
                    //string msg = string.Format("Octane SDK exception: {0}", ex.Message);
                    string msg = string.Format("{0}", ex.Message);
                    Console.WriteLine(msg);
                    UpdateReaderStatus(false, curReader);
                    UpdateReaderErrorMsg(msg, curReader);
                }

                curReader++;
            }
        }


        private void PostData()
        {
            timerPost.Stop();
            StopReader();
            int palletCount = items.Count();
            if (palletCount > 0)
            {
                string msg = string.Format("Sending {0} Data ...", palletCount);
                Console.WriteLine(msg);
                UpdateWebserviceMsg(msg);
                UpdateWebserviceColor(true);


                Shipment shipment = new Shipment
                {
                    TransactionId = TransactionId,
                    items = items
                };


                BaseResponse baseResponse = webService.PostData(shipment);

                MessageBoxIcon messageBoxIcon = MessageBoxIcon.Exclamation;
                string message = "";
                bool status = false;
                if (baseResponse.status)
                {
                    //check if shipment type inbound, compare quantity dispatch and receive
                    if (ShipmentType.Equals("INBOUND"))
                    {
                        //get total scanned, if complete give green alert
                        int unScanned = baseResponse.TotalPallet;
                        if(unScanned == 0)
                        {
                            status = true;
                            messageBoxIcon = MessageBoxIcon.Information;
                            message = string.Format("{0} succeeded. Please proceed shipment.", "Inbound");
                        }
                        else
                        {
                            message = string.Format("{0} failed, {1} not scanned or not found. Please try again or contact PIC.", "Inbound", unScanned);
                        }
                       
                    }
                    else
                    {
                        status = true;
                        messageBoxIcon = MessageBoxIcon.Information;
                        message = string.Format("{0} succeeded. Please proceed shipment.", "Outbound");
                    }

                    if (palletCount - baseResponse.QtyPalletShipmnet > 0)
                    {
                        msg = string.Format("Send {0} data succeded, {1} data unregistered...", palletCount, palletCount - baseResponse.QtyPalletShipmnet);
                    }
                    else
                    {
                        msg = string.Format("Send {0} data succeded...", palletCount);
                    }
                    UpdateWebserviceColor(true);
                    UpdateWebserviceMsg(msg);
                }
                else
                {
                    message = string.Format("{0} failed. {1}", ShipmentType, baseResponse.message);
                    msg = string.Format("Send {0} data failed...", palletCount);
                    UpdateWebserviceColor(false);
                    UpdateWebserviceMsg(msg);
                }

                if (BuzzerConnected)
                {
                    if (status)
                    {
                        //turn on green buzzer
                        //Turn On Lamp
                        webService.SendBuzzer("3", "2");
                        //Turn On Sound
                        webService.SendBuzzer("S", "4");
                        //Interval
                        Thread.Sleep(10000);
                        //Turn Off Lamp
                        webService.SendBuzzer("3", "3");
                        //Turn Off Sound
                        webService.SendBuzzer("S", "0");
                    }
                    else
                    {
                        //turn on red buzzer
                        //Turn On Lamp
                        webService.SendBuzzer("1", "2");
                        //Turn On Sound
                        webService.SendBuzzer("S", "5");
                        //Interval
                        Thread.Sleep(10000);
                        //Turn Off Lamp
                        webService.SendBuzzer("1", "3");
                        //Turn Off Sound
                        webService.SendBuzzer("S", "0");
                    }
                }
                

                ClearData();

                if (txt_delivery_note.InvokeRequired)
                {
                    txt_delivery_note.Invoke(new MethodInvoker(delegate
                    {
                        txt_delivery_note.Enabled = true;
                        txt_delivery_note.Text = "";
                        txt_delivery_note.Focus();
                    }));
                }

                MessageBox.Show(message, "Information", MessageBoxButtons.OK, messageBoxIcon, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
