using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    public class MovingObject : Basic2dObject 
    {
        public Boolean selected; // Objekt wurde ausgewählt
        public int klickX = 0; // Position (rel. zum Objekt) des Mausklicks
        public int klickY = 0;
        public int offsetX, offsetY; // Geschwindigkeit des Objektes in X und Y richtung
        public Boolean frozen = false; // Wenn das Objekt eingefroren wurde (z.B. bei Verbindung mit SPS

        /**
         * Bewegende Objekte erhalten noch ein zusätzliches KontextMenu "Löschen"
         */
        public MovingObject()
        {
            this.InitializeComponent();
            offsetX = 0;
            offsetY = 0;
            ToolStripMenuItem loe = new System.Windows.Forms.ToolStripMenuItem();
            loe.Name = "mi";
            loe.Size = new System.Drawing.Size(153, 22);
            loe.Text = "Löschen";
            loe.Click += new System.EventHandler(this.Loeschen_Click);
            this.Eigenschaften.Items.Add(loe);
        }

        /**
         * Objekt einfrieren
         */
        public void freeze(Boolean b)
        {
            frozen = b;
            if (b)
            {
                selected = false;
                offsetX = 0;
                offsetY = 0;
                this.Cursor = System.Windows.Forms.Cursors.Cross;
                this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            }
            else
            {
                this.Cursor = System.Windows.Forms.Cursors.NoMove2D;
                this.pictureBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            }
        }

        /**
         * Objekt kann eine Aktion (Kollision, Ind. Näherungsschalter etc.) ausführen auf andere Objekte
         */
        public virtual void performAction() {        }

        /**
 * Objekt wurde angeklickt
 */
        public virtual void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!frozen)
            {
                selected = true;
                Console.WriteLine("Select x=" + e.X + " Y=" + e.Y);
                klickX = e.X;
                klickY = e.Y;
                this.Focus();
            }
        }

        /**
         * Objekt wurde wieder losgelassen
         */
        public virtual void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            selected = false;
            offsetX = 0;
            offsetY = 0;
            this.Focus();
        }

        /**
         * Objekt wird bewegt
         */
        public virtual void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {

            if (selected)
            {
                
                offsetX = this.Location.X;
                offsetY = this.Location.Y;
                offsetX = e.X + this.Location.X - klickX - offsetX;
                offsetY = e.Y + this.Location.Y - klickY - offsetY;

                if (offsetX != offsetY)
                {
                    if (Math.Abs(offsetX) > Math.Abs(offsetY)) offsetY = 0;
                    else offsetX = 0;
                }
                else
                {
                    offsetX = 0;
                    offsetY = 0;
                }
                
                //Console.WriteLine("Mouse Move OffsetX=" + offsetX + "  Offset Y=" + offsetY+ " klickX="+klickX+" klickY="+klickY+" e.x="+e.X+" e.y="+e.Y);
                this.Location = new Point(e.X + this.Location.X - klickX, e.Y + this.Location.Y - klickY);
            }
        }

        private void MovingObject_SizeChanged(object sender, EventArgs e)
        {
            this.MovingObject_LocationChanged(sender, e);
        }

        /**
         * Objekt Position hat sich geändert, entweder durch Bewegung oder Kollision mit anderen Objekten
         */
        public virtual void MovingObject_LocationChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("Moving Object Location Changed: x=" + this.Location.X + " Y=" + this.Location.Y);
            p1 = new Point(this.Location.X , this.Location.Y );
            p2 = new Point(this.Location.X + this.Width , this.Location.Y);
            p3 = new Point(this.Location.X + this.Width , this.Location.Y + this.Height );
            p4 = new Point(this.Location.X , this.Location.Y + this.Height);
            if (Form1.instance != null) this.performAction();
        }



        /**
         * Kollisionserkennung mit einem anderen Movin Object
         */
        public Boolean collision(MovingObject mo)
        {
            if (p2.X > mo.p1.X && p1.X < mo.p2.X)
            {
                if (p4.Y > mo.p1.Y && p1.Y < mo.p4.Y)
                {
                    return true;
                }
            }

            return false;
        }




        public void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // MovingObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.Name = "MovingObject";
            this.LocationChanged += new System.EventHandler(this.MovingObject_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MovingObject_SizeChanged);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }


        /**
         * Kontextmenu Objekt wird gelöscht
         */
        public virtual void Loeschen_Click(object sender, EventArgs e)
        {
            Form1.instance.Controls.Remove(this);
            Form1.instance.Refresh();
        }
    }
}
