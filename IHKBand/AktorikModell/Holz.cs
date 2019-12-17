using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Holz : Material
    {
        
        /**
         * Holz Konstruktor mit eigenen Bilder
         */
        public Holz()
        {
            //Console.WriteLine("!!Konstruktor Holz!");
            this.InitializeComponent();
            Image image;

            try
            {
                image = Image.FromFile(Application.StartupPath + "\\Resources\\holz.jpg");
                
                base.pictureBox.Image = image;
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n ***  Exception bei init Holz:" + e.Message);

            }
        }

        /**
         * Überschreiben aus Basic2D Objekt (eigener Name
         */
        public override string getToolTipText()
        {
            return "Holzwürfel";
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Holz));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(16, 16);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // Holz
            // 
            this.Name = "Holz";
            this.Size = new System.Drawing.Size(16, 16);
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
            return "Holz";
        }
    }
}
