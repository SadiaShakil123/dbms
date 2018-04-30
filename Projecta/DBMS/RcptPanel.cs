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
    public partial class RcptPanel : Form
    {
        public RcptPanel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            patient1 p = new patient1();
            p.ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            pharmacy p = new pharmacy();
            p.ShowDialog();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
