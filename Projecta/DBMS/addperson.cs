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
            fillcombo_branch(comboBox2);
            fillcombo_branch(comboBox5);
            fillcombo_branch(comboBox8);
            fillcombo_Department(comboBox7);
        }

        private void fillcombo_branch(ComboBox c)
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
                c.Items.Add(add);
            }
            conn.Close();
        }
        private int getBranchId(ComboBox c)
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
                if (reader["H_Region"].ToString() == c.SelectedItem.ToString())
                {
                    bId = int.Parse(reader["Branch_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return bId;
        }

        private void fillcombo_Department(ComboBox c)
        {
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Department";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["Dpt_Name"].ToString();
                c.Items.Add(add);
            }
            conn.Close();
        }

        private int getDeptId(ComboBox c)
        {
            int bId = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Department";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Dpt_Name"].ToString() == c.SelectedItem.ToString())
                {
                    bId = int.Parse(reader["Dpt_id"].ToString());
                    break;
                }
            }
            conn.Close();
            return bId;
        }
        public int getDoctorId()
        {
            int dId = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Doctor";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["D_CNIC"].ToString() == textBox11.Text)
                {
                    dId = int.Parse(reader["D_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return dId;
        }
        public void fillDocRegistry()
        {
            string dept = comboBox7.SelectedItem.ToString();
            int docID = getDoctorId();
            string regNo = dept + "-" + docID;
            string password = textBox12.Text;
            SqlTransaction tr;

            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);

            conn.Open();
            tr = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                // string cmd = "set autocommit=0;start transaction;insert into H_User values ("+this.name+","+this.gender+","+this.age+","+this.cnic+","+this.salary+","+this.access+","+this.email+","+this.password+","+this.branch_Id+");commit;rollback";
                string cmd = "insert into DocRegistry values (" + docID + ",'" + regNo + "','" + password + "')";
                SqlCommand command = new SqlCommand(cmd, conn);
                command.Transaction = tr;
                int ex = 0;
                ex = command.ExecuteNonQuery();
                tr.Commit();
                conn.Close();
            }
            catch (Exception e)
            {
                try
                {
                    tr.Rollback();
                }
                catch (SqlException ex)
                {
                    if (tr.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + ex.GetType() +
                            " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() +
                    " was encountered while inserting the data.");
                Console.WriteLine("Neither record was written to database.");
            }
        }
        public void displayidpass()
        {
            string reg = null;
            string pass = null;
            int docID = getDoctorId();
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.DocRegistry";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (int.Parse(reader["docID"].ToString()) == docID)
                {
                    reg = reader["docRegNo"].ToString();
                    pass = reader["docPassword"].ToString();
                    break;
                }
            }
            conn.Close();
            MessageBox.Show("your Registration number is "+reg+".\n your password is "+pass+"\n");
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
            int branch_Id = getBranchId(comboBox2);
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
            string name = textBox12.Text;
            string gender = comboBox6.SelectedItem.ToString();
            int age = int.Parse(textBox8.Text);
            int branch_Id = getBranchId(comboBox8);
            string cnic = textBox11.Text;
            int salary = Convert.ToInt32(textBox6.Text);
            Staff s = new Staff(name, gender, age, cnic, branch_Id, salary);
            s.addStaff();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // doctor register
            string designation = comboBox4.SelectedItem.ToString();
            string name = textBox12.Text;
            string gender = comboBox6.SelectedItem.ToString();
            int age = int.Parse(textBox8.Text);
            int branch_Id = getBranchId(comboBox5);
            string cnic = textBox11.Text;
            int dept_Id = getDeptId(comboBox7);
            int salary = Convert.ToInt32(textBox7.Text);
            Doctor d = new Doctor(name, gender, age, cnic, branch_Id, dept_Id, salary, designation);
            d.addDoctor();
            fillDocRegistry();
            displayidpass();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            //doctorLogin f4 = new doctorLogin();
            //this.Hide();
            //f4.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
