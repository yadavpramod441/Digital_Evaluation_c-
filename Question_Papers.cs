using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace Server
{
    public partial class Question_Papers : Common
    {
        String image;

        public Question_Papers()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPEG files (*.jpg) |*.jpg;";
            dlg.ShowDialog();
            if (dlg.FileName != null)
            {
                image = dlg.FileName;
                foreach (string s in dlg.FileNames)
                {
                    string[] FName = s.Split('\\');
                    label3.Text = FName[FName.Length - 1];
                }
               
                pictureBox1.Load(image);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
              SqlConnection con = new SqlConnection("Data Source= ACER\\SQLEXPRESS; Initial Catalog = Chor; Integrated Security=true");
            //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

            con.Open();
            FileStream fStream = File.OpenRead(image);
            byte[] contents = new byte[fStream.Length];
            fStream.Read(contents, 0, (int)fStream.Length);
            fStream.Close();
            using (SqlCommand cmd = new SqlCommand("insert into QuestionPaper values(@data1,@data2,@data3)", con))
            {
                cmd.Parameters.Add("@data1", comboBox1.SelectedItem.ToString());
                cmd.Parameters.Add("@data2", contents);
                cmd.Parameters.Add("@data3", comboBox2.SelectedItem.ToString());
                cmd.ExecuteNonQuery();

            }
            con.Close();
            MessageBox.Show("Inserted", "Data", MessageBoxButtons.OK);
            
        }
    }
}
