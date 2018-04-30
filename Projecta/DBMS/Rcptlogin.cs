using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class Rcptlogin : Form
    {
        public Rcptlogin()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            RcptPanel f5 = new RcptPanel();
            this.Hide();
            f5.ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
