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
    public partial class Adrptt : Form
    {
        DataTable dt;
        SqlDataAdapter sda;
        SqlCommandBuilder scb;

        public Adrptt()
        {
            InitializeComponent();
            fillcombosCnic();
            fillcombosName();
            fillcombodCnic();
            fillcombodName();
        }

        public void fillcombodCnic()
        {
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Doctor";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["D_CNIC"].ToString();
                comboBox4.Items.Add(add);
            }
            conn.Close();
        }

        public void fillcombodName()
        {
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Doctor";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["D_Name"].ToString();
                comboBox1.Items.Add(add);
            }
            conn.Close();
        }

        public void fillcombosCnic()
        {
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Staff";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["S_CNIC"].ToString();
                comboBox6.Items.Add(add);
            }
            conn.Close();
        }

        public void fillcombosName()
        {
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Staff";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["S_Name"].ToString();
                comboBox2.Items.Add(add);
            }
            conn.Close();
        }

        public int getDoctorId(string cnic)
        {
            int dId = 0;
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Doctor";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["D_CNIC"].ToString() == cnic)
                {
                    dId = int.Parse(reader["D_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return dId;
        }

        public int getStaffId(string cnic)
        {
            int sId = 0;
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Staff";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["S_CNIC"].ToString() == cnic)
                {
                    sId = int.Parse(reader["S_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return sId;
        }

        public int getStatusId(string sName)
        {
            int sId = 0;
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.sStatus";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Status_Name"].ToString() == sName)
                {
                    sId = int.Parse(reader["Status_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return sId;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel4.Hide();
            panel7.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
            panel4.Hide();
            panel6.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            DateTime today = DateTime.Today;
            int D_Id = getDoctorId(comboBox4.Text);
            int S_Id = getStatusId(comboBox3.SelectedItem.ToString());
            String add3 = "UPDATE DoctorAttendance SET Status_Id='" + S_Id + "'  WHERE Doctor_Id='" + D_Id + "' ";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Status Updated!");
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select * from DoctorAttendance", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select * from DoctorAttendance", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            DateTime today = DateTime.Today;
            int D_Id = getDoctorId(comboBox4.Text);
            int S_Id = getStatusId(comboBox3.SelectedItem.ToString());
            String add3 = "INSERT DoctorAttendance VALUES ('" + D_Id + "','" + today + "','" + S_Id + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Attendance Added!");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            DateTime today = DateTime.Today;
            int S_Id = getStaffId(comboBox6.Text);
            int s_Id = getStatusId(comboBox5.SelectedItem.ToString());
            String add3 = "INSERT StaffAttendance VALUES ('" + S_Id + "','" + today + "','" + s_Id + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Attendance Added!");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            DateTime today = DateTime.Today;
            int S_Id = getStaffId(comboBox6.Text);
            int s_Id = getStatusId(comboBox5.SelectedItem.ToString());
            String add3 = "UPDATE StaffAttendance SET Status_Id='" + s_Id + "'  WHERE Staff_Id='" + S_Id + "' ";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Status Updated!");
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select * from StaffAttendance", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }
    }
    }
