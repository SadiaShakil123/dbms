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
        List<string> diseaselist = new List<string>();
        List<string> priscriptionList = new List<string>();
        int flag = 0;
        int flagold = 0;
        int flagnew = 0;
        public doctorLogin()
        {
            InitializeComponent();
            comboBox4.Hide();
            fillcomboCnic(comboBox9);
            fillcomboCnic(comboBox2);
            bunifuFlatButton3.Hide();
            fillcombodisease(comboBox4);
            bunifuThinButton21.Hide();
            bunifuThinButton22.Hide();
            textBox5.Hide();
            comboBox5.Hide();
            label14.Hide();
            label15.Hide();
            button7.Hide();
        }

        public void fillcomboCnic(ComboBox c)
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
                c.Items.Add(add);
            }
            conn.Close();

        }
        public void fillcombodisease(ComboBox c)
        {
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.disease";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["diseaseName"].ToString();
                c.Items.Add(add);
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
        public string getPatName(ComboBox c)
        {
            string pname = null;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Patient";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["P_CNIC"].ToString() == c.SelectedItem.ToString())
                {
                    pname = reader["P_Name"].ToString();
                    break;
                }
            }
            conn.Close();
            return pname;
        }
        public int getPatientId(ComboBox c)
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
                if (reader["P_CNIC"].ToString() == c.SelectedItem.ToString())
                {
                    pId = int.Parse(reader["P_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return pId;
        }
        private int getNumberOfVisits()
        {
            int num = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select count(*) as Num_visits from Examined_Patient group by Patient_Id having Patient_Id="+getPatientId(comboBox2);
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                //if (reader["P_CNIC"].ToString() == c.SelectedItem.ToString())
                {
                    num = int.Parse(reader["Num_visits"].ToString());
                  //  break;
                }
            }
            conn.Close();
            return num;
        }
        private void fillExaminePatint()
        {
            int P_ID = getPatientId(comboBox2);
            int visit = getNumberOfVisits() + 1;
            DateTime dateofExam = DateTime.Today;
            string patientStatus = comboBox3.SelectedItem.ToString();
            SqlTransaction tr;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            conn.Open();
            tr = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                // string cmd = "set autocommit=0;start transaction;insert into H_User values ("+this.name+","+this.gender+","+this.age+","+this.cnic+","+this.salary+","+this.access+","+this.email+","+this.password+","+this.branch_Id+");commit;rollback";
                string cmd = "insert into Examined_Patient values (" + visit +","+P_ID+",'"+dateofExam+"','"+patientStatus+ "')";
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
            int patientID = getPatientId(comboBox9);
            int DoctorID = getDoctorId(regNo);
            addDataOfOutPatient(patientID, today, DoctorID);
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
        private void enetrDisease(string disease)
        {
            SqlTransaction tr;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);

            conn.Open();
            tr = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                // string cmd = "set autocommit=0;start transaction;insert into H_User values ("+this.name+","+this.gender+","+this.age+","+this.cnic+","+this.salary+","+this.access+","+this.email+","+this.password+","+this.branch_Id+");commit;rollback";
                string cmd = "insert into Disease values ('" + disease + "')";
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
        private int getDiseaseId(string disease)
        {
            int diseaseId = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.Disease";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["diseaseName"].ToString() == disease)
                {
                    diseaseId = int.Parse(reader["P_Id"].ToString());
                    break;
                }
            }
            conn.Close();
            return diseaseId;
        }
        private void fillPatientDisease(string disease)
        {
            int patientId = getPatientId(comboBox2);
            int diseaseId = getDiseaseId(disease);
            //add data to database
            SqlTransaction tr;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);

            conn.Open();
            tr = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                string cmd = "insert into patientdisease values (" + patientId + "," + diseaseId + ")";
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
        private void fillDoctorPatient()
        {
            string regNo = textBox1.Text;
            int patientId = getPatientId(comboBox2);
            int DoctorID = getDoctorId(regNo);
            //add data to database
            SqlTransaction tr;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);

            conn.Open();
            tr = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                string cmd = "insert into doctor_examinedPatient values (" + DoctorID +","+patientId+ ")";
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
        private bool isDiseaseAlreadyPresent(string disease)
        {
            int pId = 0;
            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from dbo.disease";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["diseaseName"].ToString() == disease)
                {
                    pId = 1;
                    break;
                }
            }
            conn.Close();
            if(pId==1)
            {
                return true;
            }
            return false;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //adding examine patient 
            if (flagnew == 1)
            {
                if (flag == 0) // if only 1 disease is entered
                {
                    if(!isDiseaseAlreadyPresent(textBox4.Text))
                    {
                        enetrDisease(textBox4.Text);
                    }
                    fillPatientDisease(textBox4.Text);
                }
            }
            else if (flagold == 1)
            {
                string disease = comboBox4.SelectedItem.ToString();
                fillPatientDisease(disease);
            }
            fillExaminePatint();
            fillDoctorPatient();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string disease = textBox4.Text;
            diseaselist.Add(disease);
            textBox4.Text = null;
            foreach (string s in diseaselist)
            {
                if (!isDiseaseAlreadyPresent(s))
                {
                    enetrDisease(s);
                }
                fillPatientDisease(s);
            }
            flag = 1;
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            comboBox4.Show();
            bunifuThinButton22.Hide();
            flagold = 1;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            bunifuThinButton21.Hide();
            textBox4.Show();
            button6.Show();
            flagnew = 1;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int index = comboBox4.FindString(textBox4.Text);
            flagnew = 0;
            flagold = 0;
            if (index < 0)
            {
                // it means that the value that u had enterd in your text box does not match to any of the combomox value
                flagnew = 1;
                return;
            }
            else
            {
                comboBox4.SelectedIndex = index;
                flagold = 1;
                return;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedItem.ToString() == "Admit Patient")
            {
                comboBox5.Show();
                label14.Show();
            }
            else if (comboBox9.SelectedItem.ToString() == "Regular Patient")
            {
                label15.Show();
                textBox5.Show();
                button7.Show();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = getPatName(comboBox2);
        }
        private bool isPriscriptionAlreadyPresent(string prescription)
        {
            return true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string prescription = textBox5.Text;
            priscriptionList.Add(prescription);
            textBox5.Text = null;
            foreach (string s in priscriptionList)
            {
                if (!isPriscriptionAlreadyPresent(s)) 
                {
                    enetrDisease(s);
                }
                fillPatientDisease(s);
            }
            flag = 1;
        }
    }
}
