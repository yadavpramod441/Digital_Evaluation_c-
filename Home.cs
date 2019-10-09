using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Home :Common
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            Scanned s = new Scanned();
            s.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            new RoleChange().ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
            EditProfile f = new EditProfile();
            f.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            Result r = new Result();
            r.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            new Revaluation().ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
          
            new Pending().ShowDialog();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
          
            new Billing().ShowDialog();
            this.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
            new PhotoCopy().ShowDialog();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            new Printout().ShowDialog();
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
          
            new ChangePassword().ShowDialog();
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
           
            new Remainder().ShowDialog();
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            
            new Questions().ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            new ExamUnique().ShowDialog();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            Question_Papers f1 = new Question_Papers();
            f1.ShowDialog();
            this.Close();
        }
    }
}
