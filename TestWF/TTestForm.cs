using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserCL;

namespace TestWF
{
    public partial class TTestForm : Form
    {
        public TTestForm()
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = Test;
        }

        public TTest Test { get; set; } = new TTest();
    }
}
