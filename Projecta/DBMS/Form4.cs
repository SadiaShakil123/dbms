﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            //this.Hide();
            f7.ShowDialog();
        }
    }
}
