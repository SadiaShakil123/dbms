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
    public partial class appointment : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public appointment()
        {
            InitializeComponent();
            fillcombo_pName(comboBox1);
            fillcombo_pCNIC(comboBox3);
        }

        private void fillcombo_pName(ComboBox c)
        {
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Patient";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["P_Name"].ToString();
                c.Items.Add(add);
            }
            conn.Close();
        }

        private void fillcombo_pCNIC(ComboBox c)
        {
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Patient";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["P_CNIC"].ToString();
                c.Items.Add(add);
            }
            conn.Close();
        }

        private void appointment_Load(object sender, EventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select App_Id,App_Date,P_Id from Appointment", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public int getPatientId()
        {
            int pId = 0;
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Patient";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["P_CNIC"].ToString() == comboBox3.Text)
                {
                    pId = int.Parse(reader["P_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return pId;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //inserting values in class
            int pId = getPatientId();
            DateTime d = Convert.ToDateTime(dateTimePicker1.Text);
            App a1 = new App( d , pId);
            a1.addApp();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select App_Id,App_Date,P_Id from Appointment", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //defining connection URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            scb = new SqlCommandBuilder(sda);
            sda.Update(dt);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            DateTime today = DateTime.Today;
            sda = new SqlDataAdapter(@"Select App_Id,App_Date,P_Id from Appointment WHERE App_Date='" + today+ "' ", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
