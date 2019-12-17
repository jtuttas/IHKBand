using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class Material : MovingObject
    {
        int dx, dy=0;       // Material kann eine eigne Geschwindigkeit z.B. durch Rutsche erhalten
        public Boolean inMagzin = false; // Befindet sich das Materail im Magazin
        public Boolean block = false;    // Das Material ist blockiert (z.B. da es voreinem ausgef. Zylinder sich befindet

        public Material()
        {
            this.InitializeComponent();
        }

        /**
        * Überschreibt MouseDown aus Moving Object
        * Material, welches auf Rutsche losgelassen wird, wir auf der Rutsche vertikal zentriert
        */
        public override void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Material Mouse Down!");
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Rutsche)
                    {
                        Rutsche ru = (Rutsche)cc;
                        Point pcenter = new Point(Location.X + Width / 2, Location.Y + Height / 2);
                        if (ru.pointInObject(pcenter))
                        {
                            Console.WriteLine("Material über Rutsche losgelassen");
                            this.Location = new Point(this.Location.X, ru.Location.Y + ru.Height / 2 - this.Height / 2);
                        }
                    }
                }
            }
            base.pictureBox_MouseUp(sender, e);
        }


        /**
         * Überschreibt MouseDown aus Moving Object
         * Material welches sich im Magazin befindet wird aus dem Magazin entfernt !
         */
        public override void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Magazin)
                    {
                        Magazin ma = (Magazin)cc;
                        if (ma.pool.IndexOf(this) != -1)
                        {
                            ma.pool.Remove(this);
                            this.inMagzin = false;
                        }
                    }
                }
            }
            block = false;
            base.pictureBox_MouseDown(sender, e);
        }

        /**
         * Befindet sich unter dem Material weiteres Material?
         */
        public Boolean hasGround(int yo)
        {
            Boolean ground = false;
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Material && cc != this)
                    {
                        Material ma = (Material)cc;
                        Point p = new Point(Location.X + Width / 2, Location.Y + Height+yo);
                        if (ma.pointInObject(p))
                        {
                            return true;
                        }
                    }
                }
            }
            return ground;
        }


        /**
         * Material Bewegen (wird Aufgerufen durch den Timer in Form
         */
        public virtual void move()
        {
            dx = 0;
            dy = 0;
            if (!selected)
            {
                foreach (Control cc in Form1.instance.Controls)
                {
                    if (cc.HasChildren)
                    {

                        if (cc is Rutsche)
                        {
                            Rutsche ru = (Rutsche)cc;
                            Point p = new Point(Location.X + Width / 2, Location.Y + Height / 2);
                            if (ru.pointInObject(p) && !this.inMagzin)
                            {
                                dx = 1;
                            }
                        }
                        else if (cc is Band)
                        {
                            Band ba = (Band)cc;
                            Point p = new Point(Location.X + Width / 2, Location.Y + Height / 2);
                            if (ba.pointInObject(p) && !this.inMagzin)
                            {
                                dx = ba.getSpeed();
                            }
                        }
                        else if (cc is Magazin)
                        {
                            Magazin ma = (Magazin)cc;
                            Point p = new Point(Location.X + Width / 2, Location.Y + Height);
                            if (ma.pointInObject(p) && !this.hasGround(4) && ma.pool.IndexOf(this)!=-1)
                            {
                                dy = 4;
                            }
                        }                      
                    }
                }
                offsetX = dx;
                offsetY = dy;
                Location = new Point(Location.X + dx, Location.Y + dy);
            }
        }

        /**
         * Wenn ein Material verschoben wird, dann muss geprüft werden, ob es andere Materialen verscheibt
         */
        public override void performAction()
        {
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is KapazitiverNaeherungsschalter)
                    {
                        Sensor mo = (Sensor)cc;
                        mo.performAction();
                    }
                    else if (cc is Kolben)
                    {
                        Kolben z = (Kolben)cc;
                        if (z != this && z.collision(this))
                        {

                            if (this.offsetX < 0 && (z.pointInObject(p1) || z.pointInObject(p4)))
                            {
                                //Console.WriteLine("Kollision Zylinder von rechts");
                                this.offsetX = 0;
                                this.block = true;
                                this.Location = new Point(z.Location.X +z.Width, Location.Y);
                                //mo.moving = false;
                            }
                            else if (this.offsetX > 0 && (z.pointInObject(p2) || z.pointInObject(p3)))
                            {
                                //Console.WriteLine("Kollision Zylinder von links");
                                this.offsetX = 0;
                                this.block = true;
                                this.Location = new Point(z.Location.X - Width, Location.Y);
                                //mo.moving = false;
                            }
                            else if (this.offsetY < 0 && (z.pointInObject(p1) || z.pointInObject(p2)))
                            {
                                //Console.WriteLine("Kollision Me Me von unten");
                                this.offsetY = 0;
                                this.Location = new Point(z.Location.X, Location.Y - this.Height);
                                //mo.moving = false;

                            }
                            else if (this.offsetY > 0 && (z.pointInObject(p3) || z.pointInObject(p4)))
                            {
                                //Console.WriteLine("Kollision Me Me von oben offsety=" + offsetY);
                                this.offsetY = 0;
                                this.Location = new Point(z.Location.X, this.Location.Y + this.Height);
                                //mo.moving = false;
                            }

                            else
                            {
                                block = false;
                            }
                        }
                    }
                    else if (cc is Material)
                    {
                        Material mo = (Material)cc;
                        if (mo != this && mo.collision(this) && !mo.inMagzin)
                        {
                            if (this.offsetX < 0 && (mo.pointInObject(p1) || mo.pointInObject(p4)))
                            {
                                //Console.WriteLine("Kollision Me Me von rechts  selbst="+block+" anderer="+mo.block);
                                if (!mo.block)
                                {
                                    mo.offsetX = offsetX;
                                    mo.Location = new Point(this.Location.X - mo.Width, mo.Location.Y);
                                }
                                else
                                {
                                    this.offsetX = 0;
                                    this.block = true;
                                    this.Location = new Point(mo.Location.X + mo.Width, Location.Y);
                                }
                            }
                            else if (this.offsetX > 0 && (mo.pointInObject(p2) || mo.pointInObject(p3)))
                            {
                                //Console.WriteLine("Kollision Me Me von links selbst="+block+" anderer="+mo.block);
                                if (!mo.block)
                                {
                                    mo.offsetX = offsetX;
                                    mo.Location = new Point(this.Location.X + this.Width, mo.Location.Y);
                                }
                                else
                                {
                                    this.offsetX = 0;
                                    this.block = true;
                                    this.Location = new Point(mo.Location.X - mo.Width, Location.Y);
                                }
                                //mo.moving = false;
                            }
                            else if (this.offsetY < 0 && (mo.pointInObject(p1) || mo.pointInObject(p2)))
                            {
                                //Console.WriteLine("Kollision Me Me von unten");
                                mo.offsetY = offsetY;
                                mo.Location = new Point(mo.Location.X, Location.Y - mo.Height);
                                //mo.moving = false;

                            }
                            else if (this.offsetY > 0 && (mo.pointInObject(p3) || mo.pointInObject(p4)))
                            {
                                //Console.WriteLine("Kollision Me Me von oben offsety=" + offsetY);
                                mo.offsetY = offsetY;
                                mo.Location = new Point(mo.Location.X, this.Location.Y + this.Height);
                                //mo.moving = false;
                            }
                        }
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.pictureBox.Size = new System.Drawing.Size(127, 54);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            // 
            // Material
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Name = "Material";
            //this.Size = new System.Drawing.Size(127, 54);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
