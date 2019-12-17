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
    public partial class EigenschaftenSegment7 : Form
    {
        Segment7 myControl;

        public EigenschaftenSegment7()
        {
            InitializeComponent();
        }

        public void setControl(Segment7 c)
        {
            myControl = c;
            nametextBox.Text = c.Name;
            adr0textBox.Text = c.getAdr0();
            adr1textBox.Text = c.getAdr1();
            adr2textBox.Text = c.getAdr2();
            adr4textBox.Text = c.getAdr4();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myControl.Name = nametextBox.Text;
            myControl.setAdr0(adr0textBox.Text);
            myControl.setAdr1(adr1textBox.Text);
            myControl.setAdr2(adr2textBox.Text);
            myControl.setAdr4(adr4textBox.Text);
            this.Close();
        }
    }
}
