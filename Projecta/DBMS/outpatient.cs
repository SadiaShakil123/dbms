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
    public partial class outpatient : Form
    {
        public outpatient()
        {
            InitializeComponent();
            fillcomboCnic();
        }

        public void fillcomboCnic()
        {
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Patient";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["P_CNIC"].ToString();
                comboBox9.Items.Add(add);
            }
            conn.Close();
        }
        public void getPatName()
        {
            //int bId = 0;
            //string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            //SqlConnection conn = new SqlConnection(conUrl);
            //string cmd = "select * from dbo.Department";
            //SqlCommand command = new SqlCommand(cmd, conn);
            //conn.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    if (reader["Dpt_Name"].ToString() == c.SelectedItem.ToString())
            //    {
            //        bId = int.Parse(reader["Dpt_id"].ToString());
            //        break;
            //    }
            //}
            //conn.Close();
            //return bId;
        }
        public int getPatientId()
        {
            int pId = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Patient";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["P_CNIC"].ToString() == comboBox9.SelectedItem.ToString())
                {
                    pId = int.Parse(reader["P_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return pId;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
