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
    public partial class Order_info : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-O1L3L30;Initial Catalog=BLOOMSY_BOX;Integrated Security=True;Connect Timeout=30");


        public Order_info()
        {
            InitializeComponent();
        }

        private void Order_info_Load(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from orders";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            sqlConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Login f1 = new Admin_Login();
            f1.Show();
            this.Hide();
        }
    }
}
