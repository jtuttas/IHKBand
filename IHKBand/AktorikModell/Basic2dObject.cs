using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Basic2dObject : UserControl
    {
        public Point p1, p2, p3, p4; // Randpunkte des Objektes (p1 ist oben links, p2, oben rechts, p3 unten rechts und p4 unten links

        public Basic2dObject()
        {
            InitializeComponent();
        }

        public delegate void setImageCallback(Image i);

        public void setImage(Image i)
        {
            if (this.pictureBox.InvokeRequired)
            {
                setImageCallback d = new setImageCallback(setImage);
                this.Invoke(d, new object[] { i });
            }
            else
            {
                this.pictureBox.Image = i;
            }
        }

        public Boolean pointInObject(Point p)
        {
            p1 = new Point(this.Location.X, this.Location.Y);
            p2 = new Point(this.Location.X + this.Width, this.Location.Y);
            p3 = new Point(this.Location.X + this.Width, this.Location.Y + this.Height);
            p4 = new Point(this.Location.X, this.Location.Y + this.Height);
            if (p.X >= p1.X && p.X <= p2.X && p.Y >= p1.Y && p.Y <= p4.Y) return true;
            else return false;
        }

        /**
         * Objekt wurde neu gezeichnet
         */
        public virtual void pictureBox_Paint(object sender, PaintEventArgs e) { }


        /**
         * Vom Objekt wird das Kontextmenu Eigenschaften aufgerufen
         */
        public virtual void eigenschaftenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EigenschaftenDialog ad = new EigenschaftenDialog();           
            ad.setControl(this);
            ad.ShowDialog();
        }

        public void setAllowEigenschaften(Boolean b)
        {
            Eigenschaften.Enabled = b;
        }

        public virtual String getToolTipText() {
            return "no Text";
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.SetToolTip(this.pictureBox, getToolTipText());

        }

        public virtual void setAttributes(Hashtable a)
        {
            this.Name = a["name"].ToString();
            this.Location = new Point(Int16.Parse(a["x"].ToString()), Int16.Parse(a["y"].ToString()));
        }

        public virtual String getXMLTag()
        {
            return "Basic2dObject";
        }

        public virtual String getXMLAttribute()
        {
            return "x=\"" + this.Location.X + "\" y=\"" + this.Location.Y+"\" name=\""+this.Name+"\"";
        }

        public virtual String toXML()
        {
            if (getXMLTag()!=null) {
                return "<" + getXMLTag() + " " + getXMLAttribute() + "></" + getXMLTag() + ">";
            }
            else {
                return "";
            }
        }
    }
}
