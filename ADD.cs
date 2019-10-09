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
    public partial class ADD : Common
    {
        public ADD()
        {
            InitializeComponent();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (username.Text != "")

            {
               // SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

                SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS; Initial Catalog=Chor;Integrated Security=true");
                SqlDataAdapter da = new SqlDataAdapter("Select Username from Evaluator_Profile1 where Username='" + username.Text + "'", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    label22.Text = "username is already taken please choose another ";
                }
                else
                {

                    label22.Text = "Available";

                }
            }
            else
            {
                errorProvider1.SetError(username, "Please username ");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (First_name.Text == "")
            {
                errorProvider1.SetError(First_name, "Please enter");

            }
            
            else if (Middle_name.Text == "")
            {
                errorProvider1.SetError(Middle_name, "Please enter");
            }
            else if (Last_name.Text == "")
            {
                errorProvider1.SetError(Last_name, "Please enter");
            }
            else if (username.Text == "")
            {
                errorProvider1.SetError(username, "Please enter");
            }
            else if (email_id.Text == "")
            {
                errorProvider1.SetError(email_id, "Please enter");
            }
            else if(CollegeList.SelectedItem.ToString()=="")
            {
                errorProvider1.SetError(CollegeList, "Please Select College");
            }
            else if (phone.Text == "")
            {
                errorProvider1.SetError(phone, "Please enter");
            }
            else if (Password.Text == "")
            {
                errorProvider1.SetError(Password, "Please enter");
            }
            else if (textBox8.Text == "")
            {
                errorProvider1.SetError(textBox8, "Please enter");
            }
            else if (BankNameList.Text == "")
            {
                errorProvider1.SetError(BankNameList, "Please enter");
            }


            else if (comboBox1.SelectedItem.ToString() == "")
            {
                errorProvider1.SetError(comboBox1, "Please select");
            }
            else if (designation.Text == "")
            {
                errorProvider1.SetError(designation, "Please enter");
            }
            else if (Account_no.Text == "")
            {
                errorProvider1.SetError(Account_no, "Please enter");
            }
             else if(college_code.Text=="")
            {
                errorProvider1.SetError(college_code, "Insert ");
            }
            else if (Subject_exprience.Text == "")
            {
                errorProvider1.SetError(Subject_exprience, "Please enter");
            }
            else if (textBox2 .Text == "")
            {
                errorProvider1.SetError(textBox2 , "Please enter");
            }
            else if (Address.Text == "")
            {
                errorProvider1.SetError(Address, "Please enter");
            }
            else if(Password.Text!=textBox8.Text)
            {
                MessageBox.Show("password does  not matched", "insert same passowrd", MessageBoxButtons.OK);
            }

        
            else
            {
                if (label22.Text == "Available")
                {
                    //SqlConnection con = new SqlConnection("Data Source=192.168.1.12,1433\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=false; User id=test1; Password=test");

                     SqlConnection con = new SqlConnection("Data Source=ACER\\SQLEXPRESS;Initial Catalog=Chor;Integrated Security=True");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Evaluator_Profile1 values('" + First_name.Text + "','" + Middle_name.Text + "','" + Last_name.Text + "','" + username.Text + "','" + email_id.Text + "'," + Convert.ToInt64(phone.Text) + ",'" + Password.Text + "','" + CollegeList.SelectedItem.ToString() + "','" + designation.Text + "','" + comboBox1.SelectedItem.ToString() + "'," + Convert.ToInt64(Account_no.Text) + ",'" + BankNameList.SelectedItem.ToString() + "'," + Convert.ToInt32(college_code.Text) + "," + Convert.ToInt32(Subject_exprience.Text) + "," + Convert.ToInt32(textBox2.Text) + ",'" + Address.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Inserted", "Data", MessageBoxButtons.OK);
                    this.Hide();
                    new EditProfile().ShowDialog();
                }
                else
                {
                    MessageBox.Show("Username already exit", "Not Available", MessageBoxButtons.OK);
                }
            }
            
        }

        private void ADD_Load(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            First_name.Text = "";
            Last_name.Text = "";
            Middle_name.Text = "";
            username.Text = "";
            email_id.Text = "";
            phone.Text = "";
            Password.Text = "";
            textBox8.Text = "";
            designation.Text = "";
            comboBox1.Items.Clear();
            Account_no.Text = "";
            college_code.Text = "";
            Total_exprience.Text = "";
            Subject_exprience.Text = "";
            Address.Text = "";

        }

        

        private void phone_Validating(object sender, CancelEventArgs e)
        {
           
           if( phone.TextLength >10 || phone.TextLength<10)
            {
                MessageBox.Show("Enter 10 digit numbers ", "Data insuccifient",MessageBoxButtons.OK);
                phone.Focus();
            }
        }

        private void CollegeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CollegeList.Text== "Ramniranjan Jhunjhunwala College")
            {
                college_code.Text = "171";
            }
            else if(CollegeList.Text == "S.K. Somaiya College")
            {
                college_code.Text = "172";
            }
            else if (CollegeList.Text == "Lala Lajpatrai College")
            {
                college_code.Text = "173";
            }
            else if (CollegeList.Text == "S.I.E.S. College")
            {
                college_code.Text = "174";
            }
            else if (CollegeList.Text == "Valia Chhaganlal Laljibhai College")
            {
                college_code.Text = "175";
            }
            else if (CollegeList.Text == "Sathaye College")
            {
                college_code.Text = "176";
            }


           

        }

       

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(textBox2.Text) < Convert.ToInt32(Subject_exprience.Text))
            {
                MessageBox.Show("Cannot Total Experience cannot be less then Subject Experience", "Fail", MessageBoxButtons.OK);
                textBox2.Text = "";
                textBox2.Focus();
            }
        }

        private void Account_no_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;

        }

        private void Subject_exprience_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
