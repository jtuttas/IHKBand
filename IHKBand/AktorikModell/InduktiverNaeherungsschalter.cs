using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class InduktiverNaeherungsschalter : Sensor
    {
        Image onImage;      // Bilder des Ind. Näherungschalters für EIN und AUS
        Image offImage;

        public InduktiverNaeherungsschalter()
        {
            this.InitializeComponent();
            try
            {
                offImage = Image.FromFile(Application.StartupPath + "\\Resources\\sensor0.gif");
                onImage = Image.FromFile(Application.StartupPath + "\\Resources\\sensor1rot.gif");
                this.pictureBox.Image = offImage;
                this.pictureBox.Size = new System.Drawing.Size(onImage.Width, onImage.Height);
            }
            catch (Exception e)
            {
                Console.WriteLine("** Exception bei init IndSensor>" + e.Message);
            }
            
        }

        public override string getToolTipText()
        {
            return "Induktiver Näherungsschalter " + this.Name + " an " + this.getAdress();
        }


        /**
         * Überschreiben der Setstate Methode aus Sensor
         * Wenn sich der Zustand des Sensors ändert, dann ändert sich aus dasImage
         */
        
        public override void setState(Boolean b)
        {
            if (b)
                base.setImage(onImage);
            else
                base.setImage(offImage);
            base.setState(b);
        }
        
      
        /**
         * Bei Bewegung des Senoors, wird geschaut, ob sich Metall im Empfagsbereich befindet
         */
        
        public override void performAction()
        {
            this.setState(false);
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Metall)
                    {                   
                        Metall mo = (Metall)cc;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InduktiverNaeherungsschalter));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(15, 15);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // InduktiverNaeherungsschalter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "InduktiverNaeherungsschalter";
            this.Size = new System.Drawing.Size(15, 24);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override string getXMLAttribute()
        {
            return base.getXMLAttribute()+" adr=\""+this.getAdress()+"\" xr=\""+this.getRightBound()+"\" xl=\""+this.getLeftBound()+"\" yo=\""+this.getTopBound()+"\" yu=\""+getBottumBound()+"\"";
        }
        public override string getXMLTag()
        {
            return "Ind";
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
