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
    public partial class sSalary : Form
    {
        public sSalary()
        {
            InitializeComponent();
            SqlDataAdapter sda = new SqlDataAdapter();
                fillcombo_name(comboBox1);
                fillcombo_cnic(comboBox3);
                //defining connecction URL
                String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

                //establishing connection
                SqlConnection conn = new SqlConnection(conURL);

                //opening connection
                conn.Open();

                //displaying data in DataGridView
                DataTable dt = new DataTable();
                string q = "Select S_Name,S_CNIC,Amount from Staff JOIN Staff_Pay ON Staff.S_Id=Staff_Pay.Staff_Id";
                SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
                cmd1.Fill(dt);
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["S_Name"].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item["S_CNIC"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["Amount"].ToString();
                }
            }

            private void fillcombo_cnic(ComboBox c)
            {
                string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
                SqlConnection conn = new SqlConnection(conUrl);
                string cmd = "select * from Staff";
                SqlCommand command = new SqlCommand(cmd, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string add = reader["S_CNIC"].ToString();
                    c.Items.Add(add);
                }
                conn.Close();
            }

            private void fillcombo_name(ComboBox c)
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
                    c.Items.Add(add);
                }
                conn.Close();
            }

        

        public int getStaffId()
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
                if (reader["S_CNIC"].ToString() == comboBox3.Text)
                {
                    sId = int.Parse(reader["S_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return sId;
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
            int id = getStaffId();
            String add3 = "INSERT Staff_Pay VALUES ('" + today + "','" + id + "',1,'" + textBox1.Text + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            //displaying data in DataGridView
            DataTable dt = new DataTable();
            string q = "Select S_Name,S_CNIC,Amount from Staff JOIN Staff_Pay ON Staff.S_Id=Staff_Pay.Staff_Id";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            cmd1.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["S_Name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["S_CNIC"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Amount"].ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
