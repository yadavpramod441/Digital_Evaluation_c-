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
    public partial class Result : Common
    {
        public Result()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            new ResultPrint().ShowDialog();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

             SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS; Initial Catalog=chor; Integrated Security=true");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select Subject,AnswerSheetNo from Student_SeatNo where SeatNo='" + textBox1.Text +"'", con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                String []s = new String[5]; 
                con.Close();
                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {
                    s[i]=ds.Tables[0].Rows[i][1].ToString();
                    Console.WriteLine(""+s[i]);
                }
                con.Open();
               SqlDataAdapter da1 = new SqlDataAdapter("select Subject,marks from Evaluated where AnswerSheetno='" + s[0] + "' or AnswerSheetno='" + s[1] + "' or AnswerSheetno='" + s[2] + "' or AnswerSheetno='" + s[3] + "' or AnswerSheetno='" + s[4] + "'", con);
               DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                dataGridView1.DataSource = ds1.Tables[0];
                pictureBox2.Visible = true;
                
            }
            else
            {
                MessageBox.Show("Not available", "d", MessageBoxButtons.OK);
            }

           

           

                
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
           new ResultPrint().ShowDialog();
            this.Hide();
        }
    }
}
