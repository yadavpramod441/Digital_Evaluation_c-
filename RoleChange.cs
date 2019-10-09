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
    public partial class RoleChange : Common
    {
        public RoleChange()
        {
            InitializeComponent();
        }

        private void RoleChange_Load(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated security=true ");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Moderator", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated security=true ");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Username from Moderator where Username='" + textBox1.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("Already  Exist","Conflict",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter("Select Subject,Collegecode from Evaluator_Profile1 where Username='" + textBox1.Text + "'", con);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                String sub = ds1.Tables[0].Rows[0][0].ToString();
                String code = ds1.Tables[0].Rows[0][1].ToString();
                Console.WriteLine(sub + " " + code);
                con.Close();
                con.Open();
                String o = String.Format("{0:d}", DateTime.Now);
                DateTime date = Convert.ToDateTime(o);
                using (SqlCommand cmd = new SqlCommand("insert into Moderator values(@data1, @data2, @data3, @data4)", con))
                {

                    cmd.Parameters.Add("@data1", textBox1.Text);
                    cmd.Parameters.Add("@data2", date);
                    cmd.Parameters.Add("@data3", sub);
                    cmd.Parameters.Add("@data4", code);


                    cmd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Role Changed Successfully", "Data", MessageBoxButtons.OK);
                RoleChange_Load(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated security=true ");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Username,Count(AnswerSheetno) as Evaluated1 from Evaluated Group by Username   Having Count(AnswerSheetno) > "+Convert.ToInt32(textBox2.Text), con);
            DataSet ds = new DataSet();
            con.Close();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated security=true ");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Moderator where Username='"+textBox1.Text+"'",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                SqlCommand cmd = new SqlCommand("delete from Moderator where Username='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
            }
           else
            {
                MessageBox.Show("This moderator does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            con.Close();
            RoleChange_Load(sender,e);

        }
    }
}
