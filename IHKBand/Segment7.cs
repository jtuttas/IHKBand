using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Segment7 : UserControl
    {
        Image[] images = new Image[16];
        int value;
        String adr0 = "A3.0";
        String adr1 = "A3.1";
        String adr2 = "A3.2";
        String adr4 = "A3.3";
        BooleanItem i0 = new BooleanItem(3, 0);
        BooleanItem i1 = new BooleanItem(3, 1);
        BooleanItem i2 = new BooleanItem(3, 2);
        BooleanItem i4 = new BooleanItem(3, 3);

        public Segment7()
        {
            InitializeComponent();
            try
            {
                for (int i = 0; i <= 15; i++)
                {
                    images[i] = Image.FromFile(Application.StartupPath + "\\Resources\\s" + i + ".gif");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception create 7 Segment");
            }
        }

        public delegate void setImageCallback(Image i);

        public void setImage(Image i)
        {
            if (this.pictureBox1.InvokeRequired)
            {
                setImageCallback d = new setImageCallback(setImage);
                this.Invoke(d, new object[] { i });
            }
            else
            {
                this.pictureBox1.Image = i;
            }

        }

        /**
         * Getter und Setter der Eigenschaften
        */
        public void setValue(int v)
        {
            value = v;
            setImage(images[value]);

        }
        public int getValue() { return value; }
        public void setValue(Boolean b0, Boolean b1, Boolean b2, Boolean b4)
        {
            value = 0;
            if (b0) value = 1;
            if (b1) value = value + 2;
            if (b2) value = value + 4;
            if (b4) value = value + 8;
            this.setValue(value);
        }
        public void calcValue()
        {
            this.setValue(i0.getState(), i1.getState(), i2.getState(), i4.getState());
        }



        public void setAdr0(String a) { 
            adr0 = a;
            i0.setAdress(a);
        }
        public String getAdr0() {return adr0;}

        public void setAdr1(String a) { 
            adr1 = a;
            i1.setAdress(a);
        }
        public String getAdr1() {return adr1;}

        public void setAdr2(String a) { 
            adr2 = a;
            i2.setAdress(a);
        }
        public String getAdr2() {
            return adr2;
        }

        public void setAdr4(String a) { 
            adr4 = a;
            i4.setAdress(a);
        }
        public String getAdr4() {return adr4;}

        public BooleanItem getBooleanItem0() { return i0; }
        public BooleanItem getBooleanItem1() { return i1; }
        public BooleanItem getBooleanItem2() { return i2; }
        public BooleanItem getBooleanItem4() { return i4; }

        public void setAllowEigenschaften(Boolean b)
        {
            eigenschaftenToolStripMenuItem.Enabled = b;
        }



        private void eigenschaftenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EigenschaftenSegment7 eg = new EigenschaftenSegment7();
            eg.setControl(this);
            eg.ShowDialog();
        }


        private void Segment7_MouseEnter(object sender, EventArgs e)
        {
            String s = this.Name + " (0:" + this.getAdr0() + " 1:" + this.getAdr1() + " 2:" + this.getAdr2() + " 4:" + this.getAdr4() + ")";
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 1000;
            
            this.toolTip1.SetToolTip(this, s);
        }

        public String toXML()
        {
            return "<seg7 x=\""+Location.X+"\" y=\""+Location.Y+"\" name=\""+this.Name+"\" adr0=\""+this.getAdr0()+"\" adr1=\""+this.getAdr1()+"\" adr2=\""+this.getAdr2()+"\" adr4=\""+this.getAdr4()+"\"></seg7>";
        }

        public void setAttributes(System.Collections.Hashtable a)
        {
            this.setAdr0(a["adr0"].ToString());
            this.setAdr1(a["adr1"].ToString());
            this.setAdr2(a["adr2"].ToString());
            this.setAdr4(a["adr4"].ToString());
            this.Name=a["name"].ToString();
            this.Location = new Point(Int16.Parse(a["x"].ToString()), Int16.Parse(a["y"].ToString()));
        }


    }
}
