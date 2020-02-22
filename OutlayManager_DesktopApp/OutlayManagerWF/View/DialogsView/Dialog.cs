using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OutlayManagerWF
{
    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();
        }

        public Dialog(string text):this()
        {
            textBox1.Text = text;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
