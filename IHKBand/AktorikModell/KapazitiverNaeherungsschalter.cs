using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    class KapazitiverNaeherungsschalter : Sensor
    {
        Image onImage;
        private System.ComponentModel.IContainer components;  // Bilder f. EIN und AUS
        Image offImage;

        public KapazitiverNaeherungsschalter()
        {
            this.InitializeComponent();
            try
            {
                onImage = Image.FromFile(Application.StartupPath + "\\Resources\\sensor1gruen.gif");
                offImage = Image.FromFile(Application.StartupPath + "\\Resources\\sensor0.gif");
                this.pictureBox.Image = offImage;
                this.pictureBox.Size = new System.Drawing.Size(onImage.Width, onImage.Height);
            }
            catch (Exception e)
            {
                Console.WriteLine("** Exception bei init KapSensor>" + e.Message);
            }
            
        }

        public override string getToolTipText()
        {
            return "Kapazitiver Näherungsschalter " + this.Name + " an " + this.getAdress();
        }

        /**
         * Überschreiben v. SetAdr aus Sensor
         * Tooltip Aktualisieren
         */
        public override void setAdress(String a)
        {
            base.setAdress(a);
        }


        /**
         * Überschreiben von Mouse Down aus Sensor
         * Tooltip ändern
         */
        public override void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            base.pictureBox_MouseDown(sender, e);
        }

        /**
         * Bei Zustandsänderung wird das Bild umgeschaltet
         */
        public override void setState(Boolean b)
        {
            if (b)
                this.pictureBox.Image = onImage;
            else
                this.pictureBox.Image = offImage;
            base.setState(b);
        }

        /**
         * Wenn sich Metall oder Hold in der Nähe befinden, löst der Sensor aus
         */
        public override void performAction()
        {
            this.setState(false);
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Metall || cc is Holz)
                    {
                        Material mo = (Material)cc;
                        if (mo.collision(this))
                        {
                            this.setState(true);
                            break;
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KapazitiverNaeherungsschalter));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(15, 15);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // KapazitiverNaeherungsschalter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "KapazitiverNaeherungsschalter";
            this.Size = new System.Drawing.Size(15, 15);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override string getXMLAttribute()
        {
            return base.getXMLAttribute() + " adr=\"" + this.getAdress() + "\" xr=\"" + this.getRightBound() + "\" xl=\"" + this.getLeftBound() + "\" yo=\"" + this.getTopBound() + "\" yu=\"" + getBottumBound()+"\"";
        }
        public override string getXMLTag()
        {
            return "Kap";
        }
        public override void setAttributes(System.Collections.Hashtable a)
        {
            base.setAttributes(a);
            this.setAdress(a["adr"].ToString());
            this.setBoundary(Int16.Parse(a["xr"].ToString()),
                             Int16.Parse(a["yo"].ToString()),
                             Int16.Parse(a["xl"].ToString()),
                             Int16.Parse(a["yu"].ToString()));
        }

    }
}
