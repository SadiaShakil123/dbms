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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }


        private void button4_Click(object sender, EventArgs e)
        {
           
 
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            department d = new department();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            patient1 p1 = new patient1();
            p1.Show();
        }
    }
}
