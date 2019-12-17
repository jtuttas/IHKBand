using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class NotAus : Basic2dObject
    {
        Image freiImage;      
        Image ausgeloestImage;
        const int AUSGELOEST = 0; // NotAus ist betätigt
        public const int FREI = 1;       // Notaus ist frei
        const int AKTIVE = 2;     // Notaus wurde betätigt und wartet auf quittierung
        static NotAus instance;

        int state = FREI;
        BooleanItem bi = new BooleanItem(0, 0);
        BooleanItem fi = new BooleanItem(0, 0);
        String adressQuit = "E0.0";   // Adresse F9
        String adressFreigabe = "A0.0";   // Adresse Leuchtmelder

        public static NotAus getInstance()
        {
            return instance;
        }

        public NotAus()
        {
            InitializeComponent();
            try
            {
                freiImage = Image.FromFile(Application.StartupPath + "\\Resources\\notaus0.gif");
                ausgeloestImage = Image.FromFile(Application.StartupPath + "\\Resources\\notaus1.gif");
                pictureBox.Image = freiImage;
            }
            catch (Exception e)
            {
                Console.WriteLine("** Exception bei init Notaus>" + e.Message);
            }
            instance = this;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (state == AUSGELOEST)
            {
                this.pictureBox.Image = freiImage;
                state = AKTIVE;
            }
            else
            {
                state = AUSGELOEST;
                this.pictureBox.Image = ausgeloestImage;
                foreach (Control cc in Form1.instanceBedienpanel.Controls)
                {
                    if (cc.HasChildren)
                    {

                        if (cc is Bedienelement)
                        {
                            Bedienelement z = (Bedienelement)cc;
                            if (z.mitNotaus())
                            {
                                z.notAus(true);
                            }                            
                        }
                    }
                }

            }
        }


        public void calc(BooleanItem b)
        {
            if (b.isItem(bi))
            {
                Console.WriteLine("Quittieren! state=" + state+" bi="+b.ToString());
                this.freigabe(b.getState());
            }
        }

        public Boolean isFree()
        {
            if (state == FREI) return false;
            else return true;
        }


        private void freigabe(Boolean b)
        {
            if (state == AKTIVE)
            {
                if (b)
                {
                    this.setState(FREI);
                    foreach (Control cc in Form1.instanceBedienpanel.Controls)
                    {
                        if (cc.HasChildren)
                        {

                            if (cc is Bedienelement)
                            {
                                Bedienelement z = (Bedienelement)cc;
                                if (z.mitNotaus())
                                {
                                    z.notAus(false);
                                }
                            }
                        }
                    }
                }
            }
        }
        

        /**
         * Getter und Setter der Eigenschaften Dialoge
         */

        public virtual void setAdress(String ain, String aout)
        {
            adressQuit = ain;
            adressFreigabe= aout;
            bi.setAdress(ain);
            fi.setAdress(aout);
        }
        public String getQuitAdress() { return adressQuit; }
        public String getFreigabeAdress() { return adressFreigabe; }

        public BooleanItem getBooleanItem() { return bi; }
        public BooleanItem getFreigabeItem() { return fi; }

        public int getState() { return state; }

        public virtual void setState(int b)
        {
            state = b;
        }



        public override string getToolTipText()
        {
            return "Notausschalter " + this.Name + " Freigabe an " + adressFreigabe + " Quittierung an "+ adressQuit;
        }

        public override string getXMLAttribute()
        {
            return base.getXMLAttribute() + " adrQuit=\"" + adressQuit + "\" adrFreigabe=\"" + adressFreigabe + "\"";
        }
        public override string getXMLTag()
        {
            return "Not";
        }
        public override void setAttributes(System.Collections.Hashtable a)
        {
            base.setAttributes(a);
            this.setAdress(a["adrQuit"].ToString(), a["adrFreigabe"].ToString());
        }
    }
}
