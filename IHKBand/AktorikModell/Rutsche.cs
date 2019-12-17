using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Rutsche : Basic2dObject
    {
        const int speed=1; // Geschwindigkeit mit der Materialien Rutschen

        /**
         * Konstruktor mit eigenem Bild
         */
        public Rutsche()
        {
            this.InitializeComponent();
            try
            {
                this.pictureBox.Image = Image.FromFile(Application.StartupPath + "\\Resources\\rutsche.gif");
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);

            }
            catch (Exception e)
            {
                Console.WriteLine("** Exception bei init Rutsche"+e.Message);
            }
        }

        /**
         * Überschreibt Tool Tip aus Basic2d Model
         */
        public override string getToolTipText()
        {
            return "Rutsche";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rutsche));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(120, 40);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // Rutsche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "Rutsche";
            this.Size = new System.Drawing.Size(120, 40);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public override string getXMLAttribute()
        {
            return base.getXMLAttribute();
        }
        public override string getXMLTag()
        {
            return "Rutsche";
        }
    }
}
