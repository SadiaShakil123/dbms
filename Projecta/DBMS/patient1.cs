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
            MessageBox.Show("Patient Added!");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
