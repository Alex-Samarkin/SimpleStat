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
    public partial class TStudForm : Form
    {
        public TStudForm()
        {
            InitializeComponent();

            propertyGrid1.SelectedObject = Student;
        }

        public TStudent Student { get; set; } = new TStudent();
    }
}
