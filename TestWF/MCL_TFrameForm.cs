using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MathCL;

namespace TestWF
{
    public partial class MCL_TFrameForm : TestWF.MCL_CSV_Form
    {
        public MCL_TFrameForm()
        {
            InitializeComponent();

            md2Html.H1("Отчет");
            md2Html.HR();

            Reader.FileName = "gdp_csv";

            md2Html.P(Reader.Exists.ToString());
            md2Html.MDText += Reader.Head;
            md2Html.HR();

            Reader.ReadCSV();

            f.FromStringsV(Reader.Strings,true,0,null,"0");

            md2Html.P(f.GetHead(1000));

            textBox1.Text += md2Html.MDText;
        }

        public CSVReader Reader { get; set; } = new CSVReader();
        private MD2HTML md2Html = new MD2HTML();

        public TFrame f = new TFrame();

    }
}
