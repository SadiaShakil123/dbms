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
    public partial class branches : Form
    {
        SqlDataAdapter sda;
        SqlCommandBuilder scb;
        DataTable dt;
        public branches()
        {
            InitializeComponent();
        }
        private void branches_Load(object sender, EventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select Branch_Id,Branch_Address from Branch", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            //conn.Open();

            String add3 = "INSERT Branch(Branch_Address) VALUES ('" + textBox1.Text + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Branch Added!");
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
            sda = new SqlDataAdapter(@"Select Branch_Id,Branch_Address from Branch", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            String conURL = "Data Source =Khunsha_103; Initial Catalog = Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);
            sda = new SqlDataAdapter(@"Select Branch_Id,Branch_Address from Branch", conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
