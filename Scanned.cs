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
using System.IO;

namespace Server
{
    public partial class Scanned : Common
    {
        
        String pdf;
        public Scanned()
        {
            InitializeComponent();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "pdf files (*.pdf) |*.pdf;";
            dlg.ShowDialog();
            if(dlg.FileName !=null)
            {
                pdf = dlg.FileName;
                foreach (string s in dlg.FileNames)
                {
                    string[] FName = s.Split('\\');
                    textBox1.Text = FName[FName.Length - 1];
                 }
               
                 }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            new ChangePassword().ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String o = String.Format("{0:d}", DateTime.Now);
            DateTime date = Convert.ToDateTime(o);
            //Enter into database
            try {
                 SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated security=true");
                //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

                con.Open();
                FileStream fStream = File.OpenRead(pdf);
                byte[] contents = new byte[fStream.Length];
                fStream.Read(contents, 0, (int)fStream.Length);
                fStream.Close();
                using (SqlCommand cmd = new SqlCommand("insert into Answersheets values(@data1,@data2,@data3,@data4,@data5,@data6,@data7,@data8)", con))
                {
                    cmd.Parameters.Add("@data1", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.Add("@data2", textBox2.Text);
                    cmd.Parameters.Add("@data3", contents);
                    cmd.Parameters.Add("@data4", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.Add("data5", "0");
                    cmd.Parameters.Add(@"data6", "BSC(IT)");
                    cmd.Parameters.Add("@data7", " ");
                    cmd.Parameters.Add("@data8", date);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Inserted", "Data", MessageBoxButtons.OK);
                textBox1.Clear();
                textBox2.Clear();
            }
            catch(Exception m)
            {
                MessageBox.Show("AnswerSheet Already exist ", "AnswerSheet", MessageBoxButtons.OK);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            new Result().ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox3.Items.Clear();
            
           

            if (comboBox2.SelectedItem.Equals("Network Security"))
            {
               
                comboBox3.Items.Add("NS Nov 2015");
                comboBox3.Items.Add("NS Oct 2015");
            }
            if (comboBox2.SelectedItem.Equals("ASP.Net"))
            {
               
                comboBox3.Items.Add("ASP Nov 2015");
                comboBox3.Items.Add("ASP Oct 2015");
            }
            if (comboBox2.SelectedItem.Equals("Software Testing"))
            {
                
                comboBox3.Items.Add("ST Nov 2015");
                comboBox3.Items.Add("ST Oct 2015");
            }
            if (comboBox2.SelectedItem.Equals("AJAVA"))
            {
                
                comboBox3.Items.Add("AJAVA Nov 2015");
                comboBox3.Items.Add("AJAVA Oct 2015");
            }
            if (comboBox2.SelectedItem.Equals("Linux Administrator"))
            {
                
                comboBox3.Items.Add("LA Nov 2015");
                comboBox3.Items.Add("LA Oct 2015");
            }


        }

        private void Scanned_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
