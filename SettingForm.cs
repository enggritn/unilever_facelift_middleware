using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceliftMW
{
    public partial class SettingForm : Form
    {
        Config config = new Config();
        Helper helper = new Helper();
        private string EncryptionKey = "DKPFACELIFTULI";

        public SettingForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //check if file exist or not
            FileConfig fileConfig = new FileConfig();
            fileConfig.ReaderIPs = new List<string>();
            string readerIP1 = helper.Encrypt(txt_readerIP.Text, EncryptionKey);
            string readerIP2 = helper.Encrypt(txt_readerIP2.Text, EncryptionKey);
            string apiAddress = helper.Encrypt(txt_apiAddress.Text, EncryptionKey);
            string buzzerIP = helper.Encrypt(txt_BuzzerIP.Text, EncryptionKey);
            fileConfig.ReaderIPs.Add(readerIP1);
            fileConfig.ReaderIPs.Add(readerIP2);
            fileConfig.ApiAddress = apiAddress;
            fileConfig.BuzzerIP = buzzerIP;


            //check connection DB

            //check readerIP

            //check webservice connection

            //if all settled, then proceed.
            //encrypt value
            config.SaveConfig(fileConfig);
            Close();
            MessageBox.Show("Update settings successfuly. Restarting application ...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            Application.Restart();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (config.IsConfigured)
            {
                Close();
            }
            else
            {
                MessageBox.Show("Please setup the configuration first.");
            }
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if(config.ReaderIPs != null && config.ReaderIPs.Count() > 0)
            {
                txt_readerIP.Text = config.ReaderIPs[0];
                txt_readerIP2.Text = config.ReaderIPs[1];
            }
            
            txt_apiAddress.Text = config.ApiAddress;
            txt_BuzzerIP.Text = config.BuzzerIP;
            this.Cursor = Cursors.Default;
        }
    }
}
