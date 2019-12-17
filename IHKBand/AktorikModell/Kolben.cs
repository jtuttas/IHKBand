using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Kolben : Material
    {
        int position = 0;     // Position des Zylinders in % (100% = voll ausgefahren)
        int y0,x0;

        public Kolben()
        {
            InitializeComponent();
            base.freeze(true);
        }

        
        public void vor()
        {
            position = position + 5;
            this.offsetY = 1;
            if (position > 100) position = 100;
            this.Location = new Point(Location.X, y0 + this.Height * position / 100);
            //Console.WriteLine("Kolben vor bei x=" + this.Location.X + " y=" + this.Location.Y);
        }

        public void zurueck()
        {
            this.offsetY = -1;
            position = position - 5;
            if (position < 0) position = 0;
            this.Location = new Point(Location.X, y0 + this.Height * position / 100);
        }

        /**
         * Kolben wird nicht vom Band oder Rutsche bewegt
         */
        public override void move()
        {
            
        }

        public Boolean istHinten()
        {
            return position == 0;
        }

        public Boolean istVorne()
        {
            return position == 100;
        }

        public int getPosition() { return position; }

        public void setOrgPosition(int x, int y)
        {
            x0 = x;
            y0= y;
            this.Location = new Point(x, y+position*this.Height/100);

            //Console.WriteLine("SetOrgPosition x=" + x + " y=" + y);
        }

        public override string getXMLAttribute()
        {
            return null;
        }
        public override string getXMLTag()
        {
            return null;
        }
    }

        

}
