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
    public partial class ExamUnique : Common
    {
        public ExamUnique()
        {
            InitializeComponent();
        }

        private void ExamUnique_Load(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=true");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from ExamUnique",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];  
        }
    }
}
