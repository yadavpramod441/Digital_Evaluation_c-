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
    public partial class EditProfile : Common
    {
        // SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");
           SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=True");
        
        public EditProfile()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            ADD a = new ADD();
            a.ShowDialog();
            this.Close();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
           
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Firstname,Middlename,Lastname,Username,Email,Phone,Collegename,Designation,Subject,Account,Bankname,Collegecode,Subjectexp,Totalexp,Address from Evaluator_Profile1", con);
           
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
       }

        private void button4_Click(object sender, EventArgs e)
        {
            
                 con.Open();
                   SqlDataAdapter da = new SqlDataAdapter("select * from Evaluator_Profile1 where Username='"+textBox1.Text + "'", con);
                DataSet ds = new DataSet();
                con.Close();
                da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Evaluator_Profile1 where Username='" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                EditProfile_Load(sender, e);
                label5.Text = "User Deleted Successfully" + textBox1.Text;
            }
            
        }
    }
}
