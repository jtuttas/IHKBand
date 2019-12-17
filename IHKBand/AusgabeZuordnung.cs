using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AusgabeZuordnung : Form
    {
        public AusgabeZuordnung()
        {
            InitializeComponent();
        }

        public void setText(String s)
        {
            this.textBox1.Text = s+Environment.NewLine;
        }

        public void appendText(String s)
        {
            s = s + Environment.NewLine;
            this.textBox1.AppendText(s);
        }
    }
}
