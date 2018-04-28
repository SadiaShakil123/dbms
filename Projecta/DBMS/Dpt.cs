using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class Dpt
    {
        ArrayList d_name = new ArrayList();
        public Dpt()
        {
            this.d_name = null;
        }
        public Dpt(ArrayList d_name)
        {
            this.d_name = d_name;
        }
        public void addDpt(string d)
        {
            this.d_name.Add(d);
        }
        public void deleteDpt()
        {

        }
    }
}
