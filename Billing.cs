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
    public partial class Billing : Common
    {
         SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=true");
        //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

        int sum = 0;
        public Billing()
        {
            InitializeComponent();
        }

        private void Billing_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("Select Date,Count(AnswerSheetno) as Papers from Evaluated where Username='" + textBox1.Text + "' and Exam_Name='" + comboBox2.SelectedItem.ToString() + "' group by Date", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            con.Close();
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {

                sum = sum + Convert.ToInt32(ds1.Tables[0].Rows[i][1]);
            }
            Console.WriteLine(sum);
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Distinct Exam_Name from Evaluated", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                comboBox2.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Subject from Evaluator_Profile1 where Username='" + textBox1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                String Subject = ds.Tables[0].Rows[0][0].ToString();
                comboBox1.Items.Add(Subject);
            }
            else
            {
                comboBox1.Items.Clear();
                MessageBox.Show("Username Does not exist", "Fail", MessageBoxButtons.OK);

            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sum > 0)
            {
                int a = Convert.ToInt32(textBox2.Text);
                int b = Convert.ToInt32(textBox3.Text);
                int c = (sum / 30) * a;
                int d = sum * b + c;
                label10.Text = "" + d;
                Console.WriteLine(sum * b + c);
                button4.Visible = true;
            }
            else
            {
                MessageBox.Show("User Have not evaluated paper yet", "Fail", MessageBoxButtons.OK);
            }


           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into Payments values('"+textBox1.Text+"','"+comboBox1.SelectedItem.ToString()+"','"+comboBox2.SelectedItem.ToString()+"',"+Convert.ToInt32(textBox2.Text)+","+Convert.ToInt32(textBox3.Text)+","+Convert.ToDouble(label10.Text)+")",con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Payment has been Transfered into Account", "Success", MessageBoxButtons.OK);

            
        }
    }
}
