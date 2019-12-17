using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Band : Basic2dObject
    {
        private int speedX=0;           // aktuelle Geschwindigkeit des Förderbandes in X
        public  const int maxSpeed=2;   // Maximale Geschwindigkeit
        public  const int minSpeed=1;   // Minimale Geschwindigkeit
        String rechtsAdress = "A4.0", linksAdress = "A4.1", speedrechtsAdress="A4.2", speedlinksAdress="A4.2";
        Image[] images = new Image[8];
        int imageindex = 0;
        BooleanItem biRechts = new BooleanItem(4, 0);
        BooleanItem biLinks = new BooleanItem(4, 1);
        BooleanItem biSchnellrechts = new BooleanItem(4, 2);
        BooleanItem biSchnelllinks = new BooleanItem(4, 3);


        private Motor m = new Motor();  // Der Motor f. das Förderband

        /**
         * Konstruktor mit eigenem Bild
         */
        public Band()
        {
            this.InitializeComponent();
            try
            {
                images[0] = Image.FromFile(Application.StartupPath + "\\Resources\\band1.gif");
                images[1] = Image.FromFile(Application.StartupPath + "\\Resources\\band2.gif");
                images[2] = Image.FromFile(Application.StartupPath + "\\Resources\\band3.gif");
                images[3] = Image.FromFile(Application.StartupPath + "\\Resources\\band4.gif");
                images[4] = Image.FromFile(Application.StartupPath + "\\Resources\\band5.gif");
                images[5] = Image.FromFile(Application.StartupPath + "\\Resources\\band6.gif");
                images[6] = Image.FromFile(Application.StartupPath + "\\Resources\\band7.gif");
                images[7] = Image.FromFile(Application.StartupPath + "\\Resources\\band8.gif");
                this.pictureBox.Image = images[0];
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);

            }
            catch (Exception e)
            {
            }
        }

        /**
         * Überschreibt Tool Tip asu Basic2D Model
         */
        public override string getToolTipText()
        {
            return "Förderband rechts=" + rechtsAdress + " links=" + linksAdress + " schnellrechts=" + speedrechtsAdress+" schnelllinks="+speedlinksAdress;
        }

        /**
         * Getter und Setter der Eigenschaften
         */
        public void setAdresses(String r, String l, String sr, String sl )
        {
            Console.WriteLine("Band Set adress: r" + r + " l=" + l + " sr=" + sr + " sl=" + sl);
            rechtsAdress = r;
            linksAdress = l;
            speedrechtsAdress = sr;
            speedlinksAdress = sl;
            if (r != "") biRechts.setAdress(r);
            else biRechts.byteAdr = -1;
            if (l != "") biLinks.setAdress(l);
            else biLinks.byteAdr = -1;
            if (sr != "") biSchnellrechts.setAdress(sr);
            else biSchnellrechts.byteAdr = -1;
            if (sl != "") biSchnelllinks.setAdress(sl);
            else biSchnelllinks.byteAdr = -1;
        }
        public String getRightAdress() { return rechtsAdress; }
        public String getLeftAdress() { return linksAdress; }
        public String getSpeedRightAdress() { return speedrechtsAdress; }
        public String getSpeedLeftAdress() { return speedlinksAdress; }
        public BooleanItem getRightItem() { return biRechts; }
        public BooleanItem getLeftItem() { return biLinks; }
        public BooleanItem getSpeedrechtsItem() { return biSchnellrechts; }
        public BooleanItem getSpeedlinksItem() { return biSchnelllinks; }


        /**
         * Motor Reparieren
         */
        public void reset()
        {
            m.setok(true);
            m.halt();
            this.calc();
        }



        public void move()
        {
            imageindex = imageindex + speedX;
            //Console.WriteLine("Move speedX="+speedX+" imaageindex="+
            if (imageindex > 7) imageindex = imageindex-8;
            if (imageindex < 0) imageindex = 8+imageindex;
            this.pictureBox.Image = images[imageindex];
            m.move();
        }

        public void calc()
        {
            int i = 0;
            Console.WriteLine("CLACL r=" + biRechts.ToString() + " l=" + biLinks.ToString() + " sr=" + biSchnellrechts.ToString() + " sl=" + biSchnelllinks.ToString());
            if (biLinks.getState()) i++;
            if (biRechts.getState()) i++;
            if (biSchnelllinks.getState()) i++;
            if (biSchnellrechts.getState()) i++;
            if (i>1)
            {
                m.setok(false);
                this.setSpeed(0);
                speedX = 0;
            }
            else if (biRechts.getState())
            {
                setSpeed(minSpeed);
            }
            else if (biLinks.getState())
            {
                setSpeed(-minSpeed);
            }
            else if (biSchnelllinks.getState())
            {
                setSpeed(-maxSpeed);
            }
            else if (biSchnellrechts.getState())
            {
                setSpeed(maxSpeed);
            }
            else
            {
                this.setSpeed(0);
            }
        }

        /**
         * Geschwindigkeit des Förderbandes Setzen
         * Setzt auch DRehrichtung vom Motor
         */
        public void setSpeed(int s)
        {
            if (m.isok())
            {
                speedX = s;
                if (s == minSpeed)
                {
                    m.right();
                    m.setSpeed(2);
                }
                else if (s == maxSpeed)
                {
                    m.right();
                    m.setSpeed(1);
                }
                else if (s == -minSpeed)
                {
                    m.left();
                    m.setSpeed(2);
                }
                else if (s == -maxSpeed)
                {
                    m.left();
                    m.setSpeed(1);
                }
                else if (s == 0)
                {
                    m.halt();
                }

                if (!m.isok())
                {
                    speedX = 0;
                }
            }

        }

        /**
         * Abfrage der Förderbandgeschwindigkeit
         */
        public int getSpeed()
        {
            return speedX;
        }



       

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Band));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(250, 50);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // Band
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "Band";
            this.Size = new System.Drawing.Size(250, 50);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override string getXMLAttribute()
        {
            return base.getXMLAttribute()+" rechts=\""+this.getRightAdress()+"\" links=\""+this.getLeftAdress()+"\" schnellrechts=\""+this.getSpeedRightAdress()+"\" schnelllinks=\""+this.getSpeedLeftAdress()+"\"";
        }
        public override string getXMLTag()
        {
            return "Band";
        }
        public override void setAttributes(System.Collections.Hashtable a)
        {
            base.setAttributes(a);
            this.setAdresses(a["rechts"].ToString(), a["links"].ToString(), a["schnellrechts"].ToString(),a["schnelllinks"].ToString());
        }

    }
}
