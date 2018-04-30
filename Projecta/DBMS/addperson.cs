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
    public partial class addperson : Form
    {
        public addperson()
        {
            InitializeComponent();
            fillcombo_branch();
        }

        private void fillcombo_branch()
        {
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Hospital";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["H_Region"].ToString();
                comboBox2.Items.Add(add);
            }
            conn.Close();
        }
        private int getBranchId()
        {
            int bId = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Hospital";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["H_Region"].ToString() == comboBox2.SelectedItem.ToString())
                {
                    bId = int.Parse(reader["Branch_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return bId;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel8.Hide();
            panel7.Hide();
            panel4.Hide();
            panel6.Visible = true;

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel8.Hide();
            panel6.Hide();
            panel4.Hide();
            panel7.Visible = true;
            
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel8.Hide();
            panel6.Hide();
            panel7.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //user reg
            string user_type = comboBox3.SelectedItem.ToString(); // for admin we use 1,  for user/receptionist we use 0
            string name = textBox1.Text;
            string gender = comboBox1.SelectedItem.ToString();
            int age = int.Parse(textBox2.Text);
            int branch_Id = getBranchId();
            string cnic = textBox3.Text;
            string email = textBox4.Text;
            string password = textBox5.Text;

            int salary = Convert.ToInt32(textBox6.Text);
            int access = 0;
            if (user_type == "Admin")
                access = 1;
            else
                access = 0;
            User u = new User(name, gender, age, cnic, branch_Id, access, email, password, salary);
            u.addUser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //staff reg
        }
    }
}
