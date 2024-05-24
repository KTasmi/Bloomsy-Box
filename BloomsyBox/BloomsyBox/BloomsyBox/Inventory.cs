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
    
    public partial class Inventory : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-O1L3L30;Initial Catalog=BLOOMSY_BOX;Integrated Security=True;Connect Timeout=30");
        
        
        public Inventory()
        {
            InitializeComponent();
        }
        public void display()
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvInfo.DataSource = dt;


            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_Login f1 = new Admin_Login();
            f1.Show();
            this.Hide();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            display();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Do not keep any textbox Blank!");
                return;
            }
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Product values('" + txtName.Text + "','" + txtPrice.Text + "','" + txtQuantity.Text + "')";
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            display();

            MessageBox.Show("Inserted successfully.");

            txtName.Text = txtPrice.Text = txtQuantity.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Do not keep any textbox Blank!");
                return;
            }

            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Product set  Price='" + txtPrice.Text + "',Quantity='" + txtQuantity.Text + "'  where Name= '" + txtName.Text + "'";
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            display();

            MessageBox.Show("Updated successfully.");
            txtName.Text = txtPrice.Text = txtQuantity.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Do not keep any textbox Blank!");
                return;
            }

            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Product where Name= '" + txtName.Text + "'";
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            display();

            MessageBox.Show("Deleted successfully.");
            txtName.Text = txtPrice.Text = txtQuantity.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text) 
                
                )
                return false;
            else return true;
        }

        private void dgvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Order_info f13 = new Order_info();
            f13.Show();
            this.Hide();
        }
    }
    
}
