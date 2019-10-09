using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Server
{
    public partial class Common : Form
    {
        public Common()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = String.Format("{0:F}", DateTime.Now);
        }

        private void Common_Load(object sender, EventArgs e)
        {
            String host = Dns.GetHostName();
            IPHostEntry entry = Dns.GetHostEntry(host);
            IPAddress[] ip = entry.AddressList;
            String q = ip[ip.Length - 1].ToString();
            label1.Text = label1.Text + q;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Home h = new Home();
            h.ShowDialog();
            this.Close();

        }
    }
}
