using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new TStudForm()).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (new TTestForm()).ShowDialog();
        }
    }
}
