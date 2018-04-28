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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
        //define connection URL
        String conUrl = "Data Source = Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; MultipleActiveResultsets = True";

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
                //login successful so proceed to next form
                Form4 f4 = new Form4();
                this.Hide();
                f4.ShowDialog();
            }
    }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
