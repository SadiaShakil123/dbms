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
    public partial class Adrpt : Form
    {
        public Adrpt()
        {
            InitializeComponent();
            panel6.Visible = false;
            panel7.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel6.Visible = true;
            
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            panel4.Hide();
            panel7.Visible = true;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            doc at = new doc();
            crystalReportViewer1.ReportSource = at;
            crystalReportViewer1.Refresh();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {
            stf at = new stf();
            crystalReportViewer2.ReportSource = at;
            crystalReportViewer2.Refresh();
        }
    }
}
