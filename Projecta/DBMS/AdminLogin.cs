using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*//define connection URL
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";

            //establish connection with database
            SqlConnection conn = new SqlConnection(conUrl);

            //writing statement
            String cmd = "SELECT * from Admin where  Email='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn);

            //open connection
            conn.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            int count = Convert.ToInt32(dt.Rows.Count.ToString());

            //validate email and password of user
            if (count == 0)
            {
                MessageBox.Show("Invalid name,email and Password");
                MessageBox.Show("Please enter valid email and Password");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Login Successful");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                //login successful so proceed to next form*/
                AdminPanel f4 = new AdminPanel();
                this.Hide();
                f4.ShowDialog();
         //   }
        }
    

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //MDIParent1 f5 = new MDIParent1();
            this.Hide();
            //f5.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
