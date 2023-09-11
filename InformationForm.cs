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
    public partial class InformationForm : Form
    {
        public InformationForm()
        {
            InitializeComponent();
            label3.Text = "Icon made by Freepik and Pixel Perfect from www.flaticon.com";
            label_title.Text = string.Format("Unilever Facelift Middleware {0}", Config.GetVersion());
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }
    }
}
