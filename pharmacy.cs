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
    public partial class pharmacy : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public pharmacy()
        {
            InitializeComponent();
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
           
            sda = new SqlDataAdapter(@"Select Med_Id,Med_Name,MCost_Per_Unit from Medicine", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pharmacy_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            /*String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            //dataGridView1.Rows.Clear();
            /*sda = new SqlDataAdapter(@"Select Med_Name,MCost_Per_Unit from Medicine", conn);
            //displaying data in DataGridView
            dt = new DataTable();
            string q = "Select Med_Name,MCost_Per_Unit from Medicine";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            cmd1.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Med_Name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["MCost_Per_Unit"].ToString();
            }
            sda.Fill(dt);
            dataGridView1.DataSource = dt;


            sda = new SqlDataAdapter(@"Select Med_Name,MCost_Per_Unit from Medicine", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;*/
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel7.Visible = false;
            panel7.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel4.Hide();
            panel4.Visible = false;
            panel7.Visible = false;
            panel7.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            RcptPanel f = new RcptPanel();
            this.Hide();
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            String add3 = "INSERT Medicine VALUES ('" + textBox3.Text + "','" + textBox5.Text + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();

        }

        public void fillcombo_pname(ComboBox c)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            string cmd = "select * from dbo.Patient";
            SqlCommand command = new SqlCommand(cmd, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string add = reader["P_Name"].ToString();
                c.Items.Add(add);
            }
            conn.Close();
        }

        public int costPerUnit()
        {
            int c = 0;
            string conUrl = "Data Source=Khunsha_103; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);
            string cmd = "select * from Medicine";
            SqlCommand command = new SqlCommand(cmd, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Med_Name"].ToString() == textBox3.Text)
                {
                    c = int.Parse(reader["MCost_Per_Unit"].ToString());
                    break;
                }
            }
            conn.Close();
            return c;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            fillcombo_pname(comboBox1);
            //defining connection URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            //displaying data in DataGridView
            DataTable dt = new DataTable();
            string q = "Select Med_Name,MCost_Per_Unit from Medicine";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            cmd1.Fill(dt);
            string quantity = "textBox4.Text";
            int total = costPerUnit();
            int quant = Convert.ToInt32(textBox4.Text);
            total = total * quant;
            string Total_Price = total.ToString();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Med_Name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = Total_Price;
                dataGridView1.Rows[n].Cells[2].Value = item["MCost_Per_Unit"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = quantity;
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //defining connection URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            //displaying data in DataGridView
            dataGridView1.Rows.Clear();
            DataTable dt = new DataTable();
            string q = "Select Med_Name,MCost_Per_Unit from Medicine";
            SqlDataAdapter cmd1 = new SqlDataAdapter(q, conn);
            cmd1.Fill(dt);
            string quantity = "textBox4.Text";
            int total = costPerUnit();
            int quant = Convert.ToInt32(textBox4.Text);
            total = total * quant;
            string Total_Price = total.ToString();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["Med_Name"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = Total_Price;
                dataGridView1.Rows[n].Cells[2].Value = item["MCost_Per_Unit"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = quantity;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();
            String add3 = "INSERT Medicine VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select Med_Id,Med_Name,MCost_Per_Unit from Medicine", conn);
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }   
 }
