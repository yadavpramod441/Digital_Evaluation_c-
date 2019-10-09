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
using System.Net.Mail;
using System.Net;

namespace Server
{
    public partial class Remainder : Common
    {
        public Remainder()
        {
            InitializeComponent();
        }

        private void Remainder_Load(object sender, EventArgs e)
        {
             SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=true");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Distinct Username,Date,Subject from Evaluated order by Date asc ",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            
                    dataGridView1.DataSource = ds.Tables[0];
                   con.Close();



        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=true");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select Email from Evaluator_Profile1 where Username='" + textBox1.Text+"'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            String email=null;
            if (ds.Tables[0].Rows.Count > 0)
            {
                 email = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                MessageBox.Show("User does not exist", "User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Console.WriteLine(email);
            con.Close();
            
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("rohityadav090909@gmail.com");
                message.To.Add(new MailAddress( email));
                message.Subject = "Remainder";
                message.Body = " Seems You have not evaluated since many days. It's Remainder email to remind you to evaluate ";
                 smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("rohityadav090909@gmail.com", "@airlift@123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("Sent successfull", "Sent", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
