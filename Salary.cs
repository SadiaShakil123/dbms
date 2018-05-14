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
    public partial class Salary : Form
    {
        SqlDataAdapter sda = new SqlDataAdapter();
        public Salary()
        {
            InitializeComponent();
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
            string q = "Select D_Name,D_CNIC,Amount from Doctor JOIN Doc_Pay ON Doctor.D_Id=Doc_pay.Doctor_Id";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            cmd1.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["D_Name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["D_CNIC"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Amount"].ToString();
            }
        }

        private void fillcombo_cnic(ComboBox c)
        {
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from Doctor";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["D_CNIC"].ToString();
                c.Items.Add(add);
            }
            conn.Close();
        }

        private void fillcombo_name(ComboBox c)
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
                c.Items.Add(add);
            }
            conn.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        public int getDoctorId()
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
                if (reader["D_CNIC"].ToString() == comboBox3.Text)
                {
                    dId = int.Parse(reader["D_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return dId;
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
            string q = "Select D_Name,D_CNIC,Amount from Doctor JOIN Doc_Pay ON Doctor.D_Id=Doc_pay.Doctor_Id";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            cmd1.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["D_Name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["D_CNIC"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Amount"].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //defining connection URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommandBuilder scb;
            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
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
            int id = getDoctorId();
            String add3 = "INSERT Doc_Pay VALUES ('"+today+ "','" + id + "',1,'" + textBox1.Text + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
