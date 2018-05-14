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
    public partial class salary1 : Form
    {
        public salary1()
        {
            InitializeComponent();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            Salary s = new Salary();
            s.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            sSalary ss = new sSalary();
            ss.Show();
            this.Hide();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            sSalary s = new sSalary();
            s.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
