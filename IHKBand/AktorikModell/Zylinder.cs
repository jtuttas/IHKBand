using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Zylinder : MovingObject
    {
      
        Boolean druckVor;     // Druckanschluss Zylinder Ausfahren
        Boolean druckZurueck; // Druckanschluss Zylinder einfahren
        String eingefahrenAdress = "E6.0", ausgefahrenAdress = "E6.1", einfahrenAdress = "A5.0", ausfahrenAdress = "A5.1";
        Image endschalter0Image;
        Image endschalter1Image;
        Image pinImage;
        public Kolben kolben;
        BooleanItem biVor = new BooleanItem(5, 1);
        BooleanItem biZurueck = new BooleanItem(5, 0);
        BooleanItem biVorne = new BooleanItem(6, 0);
        BooleanItem biHinten = new BooleanItem(6, 1);
 

        /**
         * Konstruktor mit eigenen Bildern
         */
        public Zylinder()
        {
            this.InitializeComponent();            
            try
            {
                endschalter0Image = Image.FromFile(Application.StartupPath + "\\Resources\\endschalter0.gif");
                endschalter1Image = Image.FromFile(Application.StartupPath + "\\Resources\\endschalter1.gif");
                pinImage = Image.FromFile(Application.StartupPath + "\\Resources\\pin.gif");
                //Console.WriteLine("Zylinder initialisiert");
            }
            catch (Exception e)
            {
                Console.WriteLine("** Exception bei Zylinder!"+e.Message);
            }

            
        }

        /**
         * Getter und Setter der Eigenschaften 
         */
        public void setAdresses(String ie, String ia, String qe, String qa)
        {
            eingefahrenAdress = ie;
            ausgefahrenAdress = ia;
            einfahrenAdress = qe;
            ausfahrenAdress = qa;
            biHinten.setAdress(ie);
            biVorne.setAdress(ia);
            biVor.setAdress(qa);
            biZurueck.setAdress(qe);
        }

        public String getEinfahrenAdress() { return einfahrenAdress; }
        public String getEingefahrenAdress() { return eingefahrenAdress; }
        public String getAusfahrenAdress() { return ausfahrenAdress; }
        public String getAusgefahrenAdress() { return ausgefahrenAdress; }

        public BooleanItem getVorItem() { return biVor; }
        public BooleanItem getZurueckItem() {return biZurueck;}
        public BooleanItem getVorneItem() { return biVorne; }
        public BooleanItem getHintenItem() { return biHinten; }


        /**
         * Überschreibt TooolTip aus Basic2D 
         */
        public override string getToolTipText()
        {
            return "Zylinder " + this.Name + " vor (" + einfahrenAdress + "/" + eingefahrenAdress + ") zurück (" + ausfahrenAdress + "/" + ausgefahrenAdress + ")";
        }

        /**
         * Druck auf Vor
         */
        public void vor(Boolean b)
        {
            druckVor=b;
            //this.Refresh();
        }

        public void calc()
        {
            this.vor(biVor.getState());
            this.zurueck(biZurueck.getState());
        }

        /**
         * Druck auf Zurück
         */
        public void zurueck(Boolean b)
        {
            druckZurueck = b;
            //this.Refresh();

        }

        /**
         * Zeichnen der Zylinder 
         */
        public override void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pinImage != null)
            {
                if (kolben == null)
                {
                    kolben = new Kolben();
                    kolben.Location = new Point(this.Location.X+this.pictureBox.Image.Width/2-kolben.pictureBox.Image.Width/2, this.Location.Y);
                    kolben.setOrgPosition(this.Location.X+this.pictureBox.Image.Width/2-kolben.pictureBox.Image.Width/2, this.Location.Y);
                    Form1.form1.insertControl(kolben,this);

                }
                if (druckVor)
                {
                    e.Graphics.DrawImage(pinImage, this.Width - pinImage.Width - 1, 0, pinImage.Width, pinImage.Height);
                }
                if (druckZurueck)
                {
                    e.Graphics.DrawImage(pinImage, this.Width - pinImage.Width - 1, this.Height - pinImage.Height, pinImage.Width, pinImage.Height);
                }
                if (kolben.getPosition() == 0)
                {
                    e.Graphics.DrawImage(endschalter1Image, 0, 0, endschalter0Image.Width, endschalter1Image.Height);
                }
                else
                {
                    e.Graphics.DrawImage(endschalter0Image, 0, 0, endschalter0Image.Width, endschalter1Image.Height);
                }
                if (kolben.getPosition() == 100)
                {
                    e.Graphics.DrawImage(endschalter1Image, 0, this.Height - endschalter0Image.Height, endschalter0Image.Width, endschalter1Image.Height);
                }
                else
                {
                    e.Graphics.DrawImage(endschalter0Image, 0, this.Height - endschalter0Image.Height, endschalter0Image.Width, endschalter1Image.Height);
                }
            }
        }

        /**
         * Zylinder Bewegen, aufgerufen aus Timer von Form
         * Bewegt sich nur, wenn Druck auf einer Seite ist,Position wird neu Berechnet
         */
        public void move()
        {
            if (druckVor && !druckZurueck) kolben.vor();
            else if (!druckVor && druckZurueck) kolben.zurueck();
            this.Refresh();
        }

        public override void MovingObject_LocationChanged(object sender, EventArgs e)
        {
            if (kolben != null)
            {
                kolben.setOrgPosition(this.Location.X + this.pictureBox.Image.Width / 2 - kolben.pictureBox.Image.Width / 2, this.Location.Y);
            }
            if (Form1.instance != null) this.performAction();
            base.MovingObject_LocationChanged(sender, e);
        }

        /**
         * Kontextmenu Objekt wird gelöscht
         */
        public override void Loeschen_Click(object sender, EventArgs e)
        {
            Form1.instance.Controls.Remove(kolben);
            base.Loeschen_Click(sender, e);
        }
       
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zylinder));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(24, 53);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // Zylinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "Zylinder";
            this.Size = new System.Drawing.Size(24, 53);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override string getXMLAttribute()
        {
            return base.getXMLAttribute()+" vor=\""+this.getAusfahrenAdress()+"\" zurueck=\""+this.getEinfahrenAdress()+"\" istvorne=\""+this.getAusgefahrenAdress()+"\" isthinten=\""+this.getEingefahrenAdress()+"\"";
        }
        public override string getXMLTag()
        {
            return "Zylinder";
        }
        public override void setAttributes(System.Collections.Hashtable a)
        {
            base.setAttributes(a);
            this.setAdresses(a["isthinten"].ToString(),
                             a["istvorne"].ToString(),
                             a["zurueck"].ToString(),
                             a["vor"].ToString());
            
        }
    }
}
