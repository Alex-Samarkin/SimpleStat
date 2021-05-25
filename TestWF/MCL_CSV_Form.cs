using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathCL;


namespace TestWF
{
    public partial class MCL_CSV_Form : Form
    {
        public MCL_CSV_Form()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var md = textBox1.Text;
            var html = Markdig.Markdown.ToHtml(md);
            webBrowser1.DocumentText = html;
        }

        public CSVReader CsvReader { get; set; } = new CSVReader();
    }
}
