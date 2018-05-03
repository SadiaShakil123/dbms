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
    public partial class patient1 : Form
    {
        public patient1()
        {
            InitializeComponent();
            fillcombo_branch(comboBox2);
            fillcombo_Department(comboBox3);
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
        private void button1_Click_1(object sender, EventArgs e)
        {
            /*
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            //inserting values in LibraryItem table
            string city = "Lahore";
            string id = "SELECT * from Department WHERE Dpt_Name='" + comboBox3.Text + "' ";
            //int id1 = Convert.ToInt32(id);

            SqlCommand command = new SqlCommand(id, conn);
            SqlDataAdapter da = new SqlDataAdapter(id, conn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            int count = Convert.ToInt32(dt.Rows.Contains(comboBox3.Text));

            String add1 = "INSERT Patient(P_Name,P_CNIC,P_Gender,P_Age,Brnch_Id,Hos_City,Dpt_Id) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "',1,'"+city+"','"+count+"')";
            SqlCommand command1 = new SqlCommand(add1, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Patient Added!");*/
            string name = textBox1.Text;
            string gender = comboBox1.SelectedItem.ToString();
            int age = int.Parse(textBox4.Text);
            string cnic = textBox2.Text;
            int branch_Id = getBranchId(comboBox2);
            int detId = getDeptId(comboBox3);
            Patient p = new Patient(name, gender, age, cnic, branch_Id, detId);
            p.addPatient();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
