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
    public partial class Admin_Login : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Admin_Login()
        {
            InitializeComponent();
        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from login_tbl where username=@user and pass=@pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    MessageBox.Show("Lognin Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Inventory f2 = new Inventory();
                    f2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Login Failed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                con.Close();
                //    string query = "Select * from login_tbl where username = '" + textBox1.Text.Trim() + "' and pass='" + textBox2.Text.Trim() + "' ";
                //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);
                //    DataTable dt = new DataTable();
                //    sqlDataAdapter.Fill(dt);

                //    if (dt.Rows.Count == 1)
                //    {
                //        MessageBox.Show("Login Successful");
                //        Inventory f2 = new Inventory();
                //        f2.Show();
                //        this.Hide();

                //    }
                //    else
                //    {
                //        MessageBox.Show("Check your username and password");
                //    }

                //}
                //else
                //{
                //    MessageBox.Show("Fill both box", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}


                //}


            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            welcome f5 = new welcome();
            f5.Show();
            this.Hide();
        }

    }
}