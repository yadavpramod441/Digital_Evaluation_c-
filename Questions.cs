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
    public partial class Questions : Common
    {
        public Questions()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                 SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=true");
                //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

                con.Open();
                 SqlCommand cmd1 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 1 + ",'" + textBox1.Text + "')", con);
                 cmd1.ExecuteNonQuery();
                 
                SqlCommand cmd2 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 2 + ",'" + textBox2.Text + "')", con);
                cmd2.ExecuteNonQuery();
                SqlCommand cmd3 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 3 + ",'" + textBox3.Text + "')", con);
                cmd3.ExecuteNonQuery();
                SqlCommand cmd4 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 4 + ",'" + textBox4.Text + "')", con);
                cmd4.ExecuteNonQuery();
                SqlCommand cmd5 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 5 + ",'" + textBox5.Text + "')", con);
                cmd5.ExecuteNonQuery();
                SqlCommand cmd6 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 6 + ",'" + textBox6.Text + "')", con);
                cmd6.ExecuteNonQuery();
                SqlCommand cmd7 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 7 + ",'" + textBox7.Text + "')", con);
                cmd7.ExecuteNonQuery();
                SqlCommand cmd8 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 8 + ",'" + textBox8.Text + "')", con);
                cmd8.ExecuteNonQuery();
                SqlCommand cmd9 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 9 + ",'" + textBox9.Text + "')", con);
                cmd9.ExecuteNonQuery();
                SqlCommand cmd10 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 10 + ",'" + textBox10.Text + "')", con);
                cmd10.ExecuteNonQuery();
                SqlCommand cmd11 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 11 + ",'" + textBox11.Text + "')", con);
                cmd11.ExecuteNonQuery();
                SqlCommand cmd12 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 12 + ",'" + textBox12.Text + "')", con);
                cmd12.ExecuteNonQuery();
                SqlCommand cmd13 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 13 + ",'" + textBox13.Text + "')", con);
                cmd13.ExecuteNonQuery();
                SqlCommand cmd14 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 14 + ",'" + textBox14.Text + "')", con);
                cmd14.ExecuteNonQuery();
                SqlCommand cmd15 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 15 + ",'" + textBox15.Text + "')", con);
                cmd15.ExecuteNonQuery();
                SqlCommand cmd16 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 16 + ",'" + textBox16.Text + "')", con);
                cmd16.ExecuteNonQuery();
                SqlCommand cmd17 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 17 + ",'" + textBox17.Text + "')", con);
                cmd17.ExecuteNonQuery();
                SqlCommand cmd18 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 18 + ",'" + textBox18.Text + "')", con);
                cmd18.ExecuteNonQuery();
                SqlCommand cmd19 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 19 + ",'" + textBox19.Text + "')", con);
                cmd19.ExecuteNonQuery();
                SqlCommand cmd20 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 20 + ",'" + textBox20.Text + "')", con);
                cmd20.ExecuteNonQuery();
                SqlCommand cmd21 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 21 + ",'" + textBox21.Text + "')", con);
                cmd21.ExecuteNonQuery();
                SqlCommand cmd22 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 22 + ",'" + textBox22.Text + "')", con);
                cmd22.ExecuteNonQuery();
                SqlCommand cmd23 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 23 + ",'" + textBox23.Text + "')", con);
                cmd23.ExecuteNonQuery();
                SqlCommand cmd24 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 24 + ",'" + textBox24.Text + "')", con);
                cmd24.ExecuteNonQuery();
                SqlCommand cmd25 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 25 + ",'" + textBox25.Text + "')", con);
                cmd25.ExecuteNonQuery();
                SqlCommand cmd26 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 26 + ",'" + textBox26.Text + "')", con);
                cmd26.ExecuteNonQuery();
                SqlCommand cmd27 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 27 + ",'" + textBox27.Text + "')", con);
                cmd27.ExecuteNonQuery();
                SqlCommand cmd28 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 28 + ",'" + textBox28.Text + "')", con);
                cmd28.ExecuteNonQuery();
                SqlCommand cmd29 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 29 + ",'" + textBox29.Text + "')", con);
                cmd29.ExecuteNonQuery();
                SqlCommand cmd30 = new SqlCommand("insert into [" + comboBox1.SelectedItem.ToString() + "] values(" + 30 + ",'" + textBox30.Text + "')", con);
                cmd30.ExecuteNonQuery();
                
                con.Close();
                MessageBox.Show("Inserted", "Successful", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please selet Subject ", "Not selected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void Questions_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please \"Do not use special characters like @,\\,'\" in the textbox else questions will not be added ", " Guidelines", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
