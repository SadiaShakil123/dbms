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
    public partial class department : Form
    {

        public department()
        {
            InitializeComponent();
        }

        private void department_Load(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            //displaying data in DataGridView
            DataTable dt = new DataTable();
            string q = "Select * from Department";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            cmd1.Fill(dt);
            //dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Dpt_Id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Dpt_Name"].ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            //inserting values in LibraryItem table
            String add3 = "INSERT Department(Dpt_Name) VALUES ('" + textBox1.Text + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Department Added!");

            //inserting values in class
            Dpt d1 = new Dpt();
            d1.addDpt(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //defining connection URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            //displaying data in DataGridView
            string q = "Select * from Department";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Dpt_Id"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Dpt_Name"].ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
