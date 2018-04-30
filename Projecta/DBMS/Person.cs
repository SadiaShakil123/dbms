using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class Person
    {
        public string name;
        public string gender;
        public int age;
        public string cnic;
        public int branch_Id;

        public Person(string name, string gender, int age, string cnic, int branch_Id)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.cnic = cnic;
            this.branch_Id = branch_Id;
        }
    }
}
