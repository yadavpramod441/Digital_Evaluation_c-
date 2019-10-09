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
    public partial class Pending :Common
    {
        public Pending()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Pending_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=True");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("Select Subject,Count(AnswerSheetno)as Pending from Answersheets Group by Subject", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            con.Close();
            dataGridView3.DataSource = ds2.Tables[0];
            SqlDataAdapter da1 = new SqlDataAdapter("Select Subject,Count(AnswerSheetno)as Rejected from Rejected Group by Subject", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            con.Close();
            dataGridView2.DataSource = ds1.Tables[0];
           
            SqlDataAdapter da = new SqlDataAdapter("Select Subject,Count(AnswerSheetno)as Evaluated from Evaluated Group by Subject", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                dataGridView1.DataSource = ds.Tables[0];
           
           

            /*
            SqlDataAdapter da = new SqlDataAdapter("Select Subject,Count(AnswerSheetNo)  from Evaluated  Group By Subject", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][1].ToString()!="")
                {
                    label14.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else label14.Text = "0";
                if (ds.Tables[0].Rows[1][1].ToString() != "")
                {
                    label17.Text = ds.Tables[0].Rows[1][1].ToString();
                }
                else label17.Text = "0";
                if (ds.Tables[0].Rows[2][1].ToString() != "")
                {
                    label20.Text = ds.Tables[0].Rows[2][1].ToString();
                }
                else label20.Text = "0";
                if (ds.Tables[0].Rows[3][1].ToString() != "")
                {
                    label23.Text = ds.Tables[0].Rows[3][1].ToString();
                }
                else label23.Text = "0";
                if (ds.Tables[0].Rows[4][1].ToString() != "")
                {
                    label26.Text = ds.Tables[0].Rows[4][1].ToString();
                }
                else
                {
                    label26.Text = "0";
                }
            }
            con.Close();



           con.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("Select Subject,Count(AnswerSheetNo)  from Rejected Group By Subject", con);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            if (ds1.Tables[0].Rows.Count > 0)
            {

                label15.Text = ds1.Tables[0].Rows[0][1].ToString();
                label18.Text = ds.Tables[0].Rows[1][1].ToString();
                label21.Text = ds.Tables[0].Rows[2][1].ToString();
                label24.Text = ds.Tables[0].Rows[3][1].ToString();
                label27.Text = ds.Tables[0].Rows[4][1].ToString();
            }
            else
            {
                label15.Text = "0";
                label18.Text = "0";
                label21.Text = "0";
                label24.Text = "0";
                label27.Text = "0";
            }
            con.Close();
            con.Open();
            SqlDataAdapter da2 = new SqlDataAdapter("Select Subject,Count(AnswerSheetNo)  from Rejected  Group By Subject", con);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                label16.Text = ds1.Tables[0].Rows[0][1].ToString();
                label19.Text = ds.Tables[0].Rows[1][1].ToString();
                label22.Text = ds.Tables[0].Rows[2][1].ToString();
                label25.Text = ds.Tables[0].Rows[3][1].ToString();
                label28.Text = ds.Tables[0].Rows[4][1].ToString();
            }
            else
            { 
            label16.Text = "0";
            label19.Text = "0";
            label22.Text = "0";
            label25.Text = "0";
            label28.Text = "0";
            }
            con.Close();
            */

        }
        
    }
}
