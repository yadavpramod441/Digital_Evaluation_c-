using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Server
{
    public partial class ChangePassword :Common
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {

                MessageBox.Show("Some Field You are missing", "Data Inadequate", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

                // SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("update Evaluator_Profile1 set Password='" + textBox3.Text + "' where Username='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Password has been changed", "Password", MessageBoxButtons.OK);
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }
    }
}
