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
    public partial class pharmacy : Form
    {
        public pharmacy()
        {
            InitializeComponent();
        }

        private void pharmacy_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel7.Visible = false;
            panel7.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel4.Hide();
            panel4.Visible = false;
            panel7.Visible = false;
            panel7.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            RcptPanel f = new RcptPanel();
            this.Hide();
            f.ShowDialog();
        }
    }
}
