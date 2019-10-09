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
    public partial class Printout :Common
    {
        public Printout()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS; Initial Catalog=chor; Integrated Security=true");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Student_SeatNo values ('"+textBox1.Text + "','" + comboBox2.SelectedItem.ToString() + "','" +comboBox3.SelectedItem.ToString() + "','" + comboBox1.SelectedItem.ToString()+ "','" + textBox2.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("data inserted", "Successful",MessageBoxButtons.OK);
        }

        private void Printout_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedItem.ToString()== "Sem 5th")
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Network Security");
                comboBox1.Items.Add("AJAVA");
                comboBox1.Items.Add("Software Testing");
                comboBox1.Items.Add("ASP.Net");
                comboBox1.Items.Add("Linux Administrator");
                
  }
            else
            {
                comboBox1.Items.Clear();
                comboBox1.Items.Add("Project Management");
                comboBox1.Items.Add("Internet Technology");
                comboBox1.Items.Add("Data WareHousing");
                comboBox1.Items.Add("Geographic Information System");
                 
            }
        }
    }
}
