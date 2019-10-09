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
using System.Data;

namespace Server
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=true");

            // SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Admin where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
             DataSet dt = new DataSet();
            da.Fill(dt);
           if (dt.Tables[0].Rows.Count>0)

           {
                this.Hide();
                new Home().ShowDialog();
               
           }
            
           

            else
            {
                label4.Text = "Please provide correct username and password";
            }
            con.Close();
        }

       
    }
}
