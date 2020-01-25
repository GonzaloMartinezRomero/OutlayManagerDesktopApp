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
        private readonly Form formSender;

        public Dialog()
        {
            InitializeComponent();
            
        }

        public Dialog(string text):this()
        {
            textBox1.Text = text;
        }

        public Dialog(string text,Form sender) : this(text: text)
        {
            FormClosed += ReleaseSenderBlock;

            sender.Enabled = false;
            formSender = sender;
        }


        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReleaseSenderBlock(object sender, FormClosedEventArgs e)
        {
            formSender.Enabled = true;
        }
    }
}
