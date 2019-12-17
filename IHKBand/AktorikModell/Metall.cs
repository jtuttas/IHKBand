using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Metall : Material
    {
        
        /**
         * Metall mit eigenem Bild
         */
        public Metall()
        {
            this.InitializeComponent();
            try
            {
                base.pictureBox.Image = Image.FromFile(Application.StartupPath + "\\Resources\\metall.jpg");
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);

            }
            catch (Exception e)
            {

            }
        }

        /**
         * ToolTip aus Basic2D Object überschreiben
         */
        public override string getToolTipText()
        {
            return "Metallwürfel";
        }

        /**
         * Wenn ein Metallwürfel mit der Hand verschoben wird, muss geprüft werden, ob ein Ind. Sensor in der Nähe ist
         */
        public override void performAction()
        {
            base.performAction();
        
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is InduktiverNaeherungsschalter)
                    {
                        InduktiverNaeherungsschalter mo = (InduktiverNaeherungsschalter)cc;
                        mo.performAction();
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Metall));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(16, 16);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // Metall
            // 
            this.Name = "Metall";
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
            return "Metall";
        }
    }
}
