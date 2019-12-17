using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Alert : Form
    {
        public Alert(String s)
        {
            InitializeComponent();
            detailstextBox.Text = s;
            //label2.Text = s;
        }
    }
}