using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class Staff:Person
    {
        int salary;
        public Staff(string name, string gender, int age, string cnic, int branch_Id, int salary) :base(name, gender, age, cnic, branch_Id)
        {
            this.salary = salary;
        }
        public void addStaff()
        {
            SqlTransaction tr;

            string conUrl = "Data Source=DESKTOP-0DGR9RA; Initial Catalog = Hospital Management System; Integrated Security = True";
            SqlConnection conn = new SqlConnection(conUrl);

            conn.Open();
            tr = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            try
            {
                // string cmd = "set autocommit=0;start transaction;insert into H_User values ("+this.name+","+this.gender+","+this.age+","+this.cnic+","+this.salary+","+this.access+","+this.email+","+this.password+","+this.branch_Id+");commit;rollback";
                string cmd = "insert into dbo.Staff values ('" + this.name + "','" + this.gender + "'," + this.age + ",'" + this.cnic + "'," + this.salary + "," + this.branch_Id + ")";
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
    }
}
