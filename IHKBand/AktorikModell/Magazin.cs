using System;
using System.Collections;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    class Magazin : MovingObject
    {
        private ToolStripMenuItem leerenToolStripMenuItem;  // Magazin hat Kontext Menü zum entleeren des Magazins
        public ArrayList pool = new ArrayList();   // Material, was sich im Magazin befindet

        /**
         * Konstruktor
         * Magazin hat ein eigene Bild und ein extra Kontextmenu
         */
        public Magazin()
        {
            this.InitializeComponent();
            try
            {
                this.pictureBox.Image = Image.FromFile(Application.StartupPath + "\\Resources\\magazin.gif");
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                leerenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                leerenToolStripMenuItem.Name = "mi";
                leerenToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
                leerenToolStripMenuItem.Text = "Leeren";
                leerenToolStripMenuItem.Click += new System.EventHandler(this.mi_Click);
                this.Eigenschaften.Items.Add(leerenToolStripMenuItem);
            }
            catch (Exception e)
            {
                Console.WriteLine("** Exception bei Magazin:"+e.Message);
            }
        }

        public override string getToolTipText()
        {
            return "Magazin";
        }


        /**
         * Material, welches sich in der Nähe des Magazins befindet wird "eingefangen"
         * Aufgerufen aus dem Thread
         */
        public void catchMaterial()
        {
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Material && !(cc is Zylinder))
                    {
                        Material ma = (Material)cc;
                        Point p = new Point(ma.Location.X + ma.Width / 2, ma.Location.Y + ma.Height / 2);
                        if (this.pointInObject(p) && !ma.selected)
                        {
                            if (pool.IndexOf(ma) == -1 && !ma.inMagzin)
                            {
                                ma.Location = new Point(this.Location.X + this.Width / 2 - ma.Width / 2, Location.Y - ma.Height);
                                pool.Add(ma);
                                ma.inMagzin = true;
                            }
                        }
                    }                    
                }
            }
        }


        /**
         * Bewegung des Magazin
         * Alle Material Objekte, die sich im Magazin befinden werden mitbewegt
         */
        public override void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (selected)
            {
                foreach (Material ma in pool)
                {
                    ma.Location = new Point(e.X + ma.Location.X - base.klickX, e.Y + ma.Location.Y - base.klickY);
                }
            }
            
            base.pictureBox_MouseMove(sender, e);
        }

      
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Magazin));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Size = new System.Drawing.Size(34, 52);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            // 
            // Magazin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "Magazin";
            this.Size = new System.Drawing.Size(34, 52);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /**
         * Aufruf Kontextmenu Magain leeren
         */
        private void mi_Click(object sender, EventArgs e)
        {
            foreach (Material ma in pool)
            {
                Form1.instance.Controls.Remove(ma);
            }
            pool.Clear();
        }

        public override string getXMLAttribute()
        {
            return base.getXMLAttribute();
        }
        public override string getXMLTag()
        {
            return "Magazin";
        }
    }
}
