using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class Patient
    {
        string name;
        string gender;
        int CNIC;
        int age;
        Dpt disease;
        public Patient()
        {
            name = null;
            gender = null;
            CNIC = 0;
            age = 0;
            disease = null;
        }
        public Patient(string name, string gender, int CNIC, int age, Dpt disease)
        {
            this.name = name;
            this.gender = gender;
            this.CNIC = CNIC;
            this.age = age;
            this.disease = disease;
        }
        public void addPatient()
        {

        }
        public void deletePatient()
        {

        }
        

    }
}
