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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            department d = new department();
            d.Show();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            Adrpt f6 = new Adrpt();
            f6.ShowDialog();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            addperson f5 = new addperson();
            this.Hide();
            f5.ShowDialog();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            Branch f5 = new Branch();
            this.Hide();
            f5.ShowDialog();
        }

        private void bunifuTileButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
