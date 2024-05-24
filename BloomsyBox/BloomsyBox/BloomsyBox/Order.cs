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
    public partial class Order : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-O1L3L30;Initial Catalog=BLOOMSY_BOX;Integrated Security=True;Connect Timeout=30");
        DataTable dt = new DataTable();
        public Order()
        {
            InitializeComponent();
        }
       
      

      
       
      
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = Convert.ToString(Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text));
            }
            catch { }

        }
        protected int n, total = 0;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Confirmed Order");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            label7.Text = "00";
            dataGridView1.Rows.Clear();
            payment f10 = new payment();
            f10.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Do not keep any textbox Blank!");
                return;
            }




            int stock = 0;
                SqlCommand cmd2 = con.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select * from Product where Name = '" + textBox1.Text + "'";
                cmd2.ExecuteNonQuery();
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd2);
                da1.Fill(dt1);

                foreach (DataRow dr1 in dt1.Rows)
                {
                    stock = Convert.ToInt32(dr1["Quantity"].ToString());
                }
                if (Convert.ToInt32(textBox3.Text) > stock)
                {
                    MessageBox.Show("This Much Value is not available");
                }
                else
                {
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "insert into orders values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Value.ToString("dd-MM-yyyy") + "')";
               
                cmd1.ExecuteNonQuery();

                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
                dataGridView1.Rows[n].Cells[3].Value = textBox4.Text;



                total += int.Parse(textBox4.Text);
                label7.Text = Convert.ToString(total);

                int qty = Convert.ToInt32(textBox3.Text);
                SqlCommand cmd0 = con.CreateCommand();
                cmd0.CommandType = CommandType.Text;
                cmd0.CommandText = "update Product set Quantity=Quantity-" + qty + " where Name='" + textBox1.Text + "'";
                cmd0.ExecuteNonQuery();
                //DataRow dr = dt.NewRow();
                //dr["Product"] = textBox1.Text;
                //dr["Product"] = textBox2.Text;
                //dr["Product"] = textBox3.Text;
                //dr["Product"] = textBox4.Text;
                //dt.Rows.Add(dr);
                //dataGridView1.DataSource = dt;
                //total = total + Convert.ToInt16(dr["total"].ToString());
                //label7.Text = total.ToString();
                }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


        }

        int amount;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch { }
        }

        private void Order_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            //dt.Clear();
            //dt.Columns.Add("Product");
            //dt.Columns.Add("Price");
            //dt.Columns.Add("qty");
            //dt.Columns.Add("Total");
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            listBox1.Visible = true;
            listBox1.Items.Clear();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where Name like ('" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add(dr["Name"].ToString());
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                listBox1.Focus();
                listBox1.SelectedIndex = 0;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    textBox1.Text = listBox1.SelectedItem.ToString();
                    listBox1.Visible = false;
                    textBox2.Focus();
                }
            }
            catch (Exception)
            {

            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Product where Name = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                textBox2.Text = dr["Price"].ToString();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            try
            {
                textBox4.Text = Convert.ToString(Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text));
            }
            catch { }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            label7.Text = Convert.ToString(total);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            home f11 = new home();
            f11.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            label7.Text = Convert.ToString(total);

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        bool Authenticate()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                 string.IsNullOrWhiteSpace(textBox4.Text)

                )
                return false;
            else return true;
        }



    }
}
