using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloomsyBox
{
    public partial class welcome : Form
    {
       
        public welcome()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            createaccount f6 = new createaccount ();
            f6.Show(); 
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            login f7 = new login();
            f7.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin_Login f1 = new Admin_Login();
            f1.Show();
            this.Hide();
        }
    }
}
