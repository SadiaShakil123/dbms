using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DBMS
{
    class Dpt
    {
        string dName;
        string branch_address;
        public Dpt(string dName, string branch_address)
        {
            this.dName = dName;
            this.branch_address = branch_address;
        }
        public void addDpt()
        {
            //defining connecction URL
            String conURL = "Data Source =Khunsha_103; Initial Catalog =Hospital Management System; User ID=sa; Password=1998; Integrated Security = True; MultipleActiveResultSets = True";

            //establishing connection
            SqlConnection conn = new SqlConnection(conURL);

            //opening connection
            conn.Open();

            String add3 = "INSERT Department(Dpt_Name,Branch_Address) VALUES ('" + dName + "','" + branch_address + "')";
            SqlCommand command1 = new SqlCommand(add3, conn);
            command1.ExecuteNonQuery();
            MessageBox.Show("Department Added!");
        }

    }
}
