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
    public partial class NeuesProjekt : Form
    {
        public NeuesProjekt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.projektnametextBox.Text != "")
            {
                Form1.projektName = projektnametextBox.Text;
                this.Close();
            }
        }
    }
}
