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
    public partial class doctorLogin : Form
    {
        public doctorLogin()
        {
            InitializeComponent();
            fillcomboCnic();
            bunifuFlatButton3.Hide();
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
        public int getDoctorId(string regno)
        {
            int dId = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.DocRegistry";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["docRegNo"].ToString() == regno)
                {
                    dId = int.Parse(reader["docID"].ToString());
                    break;
                }
            }
            conn.Close();
            return dId;
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
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            /* panel4 f4 = new addpe();
             this.Hide();
             f4.ShowDialog();*/
            panel4.Visible = true;
            panel6.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel4.Hide();
            panel7.Hide();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuTileButton3_Click_1(object sender, EventArgs e)
        {
            panel7.Visible = true;
            //panel7.Hide();
            panel6.Hide();
        }
        public void addDataOfOutPatient(int patId, DateTime date, int docId)
        {
            SqlTransaction tr;

            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);

            conn.Open();
            tr = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                // string cmd = "set autocommit=0;start transaction;insert into H_User values ("+this.name+","+this.gender+","+this.age+","+this.cnic+","+this.salary+","+this.access+","+this.email+","+this.password+","+this.branch_Id+");commit;rollback";
                string cmd = "insert into OutPatient values (" + patId + ",'" + date + "'," + docId + ")";
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

        private void button3_Click(object sender, EventArgs e)
        {
            string regNo = textBox1.Text;
            DateTime today = DateTime.Today;
            //insert into table name ('"+today+"');
            int patientID = getPatientId();
            int DoctorID = getDoctorId(regNo);
            addDataOfOutPatient(patientID,today,DoctorID);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel6.Show();
            panel4.Hide();
            panel7.Hide();
            panel8.Hide();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            panel8.Show();
            panel6.Hide();
            panel4.Hide();
            panel7.Hide();
        }

        private void doctorLogin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            panel9.Show();
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            panel10.Show();
        }
    }
}
