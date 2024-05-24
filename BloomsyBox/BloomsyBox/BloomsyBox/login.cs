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
using System.Configuration;

namespace BloomsyBox
{
    public partial class login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public login()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="")
            {
                SqlConnection con = new SqlConnection(cs);

                //string query = "select * form user_info where name=@name and pass=@pass";
                //SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                //cmd.Parameters.AddWithValue("@pass", textBox2.Text.Trim());
                //con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows == true)
                //{
                //    MessageBox.Show("Login Successful");
                //    home f11 = new home();
                //    f11.Show();
                //    this.Hide();
                //}
                //else
                //{
                //    MessageBox.Show("Login Failed");
                //}
                //con.Close();
                string query = "Select * from user_info where name = '" + textBox1.Text.Trim() + "' and pass='" + textBox2.Text.Trim() + "' ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Login Successful");
                    home f11 = new home();
                    f11.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Check your username and password");
                }



            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            welcome f5 = new welcome();
            f5.Show();
            this.Hide();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
