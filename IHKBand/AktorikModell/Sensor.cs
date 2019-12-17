using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Sensor : MovingObject
    {
        Boolean state = false;  // Zustand des Sensors
        int boundXr = 20;       // Eigenschaften Empfindlichkeit des Sensors in X und Y Richtung
        int boundYo = 20;
        int boundXl = 20;
        int boundYu = 20;
        String adress="E0.0";   // Adresse des Sensors
        BooleanItem bi = new BooleanItem(0, 0);

        public Sensor()
        {
            this.InitializeComponent();
        }


        /**
         * Überschreiben des Loca. Changes Methode von Moving Object
         * Sensor hat einen größeren Bereich
         */
        
        public override void MovingObject_LocationChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Sensor Location Changed: x=" + this.Location.X + " Y=" + this.Location.Y);
            p1 = new Point(this.Location.X - boundXl, this.Location.Y - boundYo);
            p2 = new Point(this.Location.X + this.Width + boundXr, this.Location.Y - boundYo);
            p3 = new Point(this.Location.X + this.Width + boundXr, this.Location.Y + this.Height + boundYu);
            p4 = new Point(this.Location.X - boundXl, this.Location.Y + this.Height + boundYu);
            if (Form1.instance != null)
            {
                performAction();
                Form1.instance.Invalidate();
            }
        }
        

        /**
         * Getter und Setter der Eigenschaften Dialoge
         */
        public virtual void setAdress(String a)
        {
            adress = a;
            bi.setAdress(a);
        }

        public BooleanItem getBooleanItem() { return bi; }


        public Boolean getState() { return state; }

        public void setBoundary(int rechts, int oben, int links, int unten)
        {
            boundXl = links;
            boundXr = rechts;
            boundYo = oben;
            boundYu = unten;
            p1 = new Point(this.Location.X - boundXl, this.Location.Y - boundYo);
            p2 = new Point(this.Location.X + this.Width + boundXr, this.Location.Y - boundYo);
            p3 = new Point(this.Location.X + this.Width + boundXr, this.Location.Y + this.Height + boundYu);
            p4 = new Point(this.Location.X - boundXl, this.Location.Y + this.Height + boundYu);
        }

        public int getLeftBound() { return boundXl; }
        public int getRightBound() { return boundXr; }
        public int getTopBound() { return boundYo; }
        public int getBottumBound() { return boundYu; }
        public String getAdress() { return adress; }


        public virtual void setState(Boolean b)
        {
            state = b;
        }

        /**
         * Überschreiben von MouseDown aus Moving Object
         * Es wird zusätzlich noch der Rahmen gezeichnet
         */
        public override void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            base.pictureBox_MouseDown(sender, e);
            if (Form1.instance != null) Form1.instance.Refresh();
        }

        /**
         * Überschreiben von MouseUp aus Moving Object
         * Der Rahmen wird wieder gelöscht
         */
        public override void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            base.pictureBox_MouseUp(sender, e);
            if (Form1.instance != null) Form1.instance.Refresh();

        }
        /**
         * Überschreiben der Paint Methode aus Basic2D Object
         * Wenn Sensor gezeichnet wird, dann zeigt er den Empfangsbereich an, wenn er selectiert ist
         */
        public override void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (selected)
                {
                    Form1.g.DrawRectangle(new Pen(Color.Red), Location.X - boundXl, Location.Y - boundYo,  boundXr + Width + boundXl,  boundYo + Height+boundYu);
                }
            }
            catch (Exception ee)
            {
            }
        }

        private void InitializeComponent()
        {

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // Magazin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "Magazin";
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
