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
    public partial class Bedienelement : UserControl
    {
        public Boolean allowEigenschaften = true;

        public const int Blindelement = 0;
        public const int Leuchtmelder = 1;
        public const int Taster = 2;
        public const int LeuchtTaster = 3;
        public const int Schalter = 4;
        public const int FarbSchalter = 5;
        int type = Blindelement;

        String beschriftung="Reserve";

        public String LeuchtmelderAdr = "A1.1";
        public const int LeuchtmlederWeiss = 0;
        public const int LeuchtmlederRot = 1;
        public const int LeuchtmlederGelb = 2;
        public const int LeuchtmlederGruen = 3;
        public const int LeuchtmlederBlau = 4;
        int LeuchtmelderFarbe = LeuchtmlederWeiss;
        Image[,] leuchtmelderImage = new Image[4,5];
        Image einschalterImage;
        Image ausschalterImage;
        Image einschalterPressedImage;
        Image ausschalterPressedImage;
        Image blindImage;
        Boolean leuchtmelderState = false;
        BooleanItem leuchtmelderItem = new BooleanItem(1, 1);

        String TasterAdr = "E2.0";
        char TasterTaste = 'A';
        Boolean schliesser = true;
        Boolean notausVorgeschaltet = false;
        Boolean tasterState = false;
        BooleanItem tasterItem = new BooleanItem(2, 0);
        Image kipp0Image, kipp1Image;
        Boolean storedState;

        public Bedienelement()
        {
            InitializeComponent();
            try {
                leuchtmelderImage[0, 0] = Image.FromFile(Application.StartupPath + "\\Resources\\weiss0.gif");
                leuchtmelderImage[1, 0] = Image.FromFile(Application.StartupPath + "\\Resources\\weiss1.gif");
                leuchtmelderImage[2, 0] = Image.FromFile(Application.StartupPath + "\\Resources\\weiss0s.gif");
                leuchtmelderImage[3, 0] = Image.FromFile(Application.StartupPath + "\\Resources\\weiss1s.gif");

                leuchtmelderImage[0, 1] = Image.FromFile(Application.StartupPath + "\\Resources\\rot0.gif");
                leuchtmelderImage[1, 1] = Image.FromFile(Application.StartupPath + "\\Resources\\rot1.gif");
                leuchtmelderImage[2, 1] = Image.FromFile(Application.StartupPath + "\\Resources\\rot0s.gif");
                leuchtmelderImage[3, 1] = Image.FromFile(Application.StartupPath + "\\Resources\\rot1s.gif");

                leuchtmelderImage[0, 2] = Image.FromFile(Application.StartupPath + "\\Resources\\gelb0.gif");
                leuchtmelderImage[1, 2] = Image.FromFile(Application.StartupPath + "\\Resources\\gelb1.gif");
                leuchtmelderImage[2, 2] = Image.FromFile(Application.StartupPath + "\\Resources\\gelb0s.gif");
                leuchtmelderImage[3, 2] = Image.FromFile(Application.StartupPath + "\\Resources\\gelb1s.gif");

                leuchtmelderImage[0, 3] = Image.FromFile(Application.StartupPath + "\\Resources\\gruen0.gif");
                leuchtmelderImage[1, 3] = Image.FromFile(Application.StartupPath + "\\Resources\\gruen1.gif");
                leuchtmelderImage[2, 3] = Image.FromFile(Application.StartupPath + "\\Resources\\gruen0s.gif");
                leuchtmelderImage[3, 3] = Image.FromFile(Application.StartupPath + "\\Resources\\gruen1s.gif");


                leuchtmelderImage[0, 4] = Image.FromFile(Application.StartupPath + "\\Resources\\blau0.gif");
                leuchtmelderImage[1, 4] = Image.FromFile(Application.StartupPath + "\\Resources\\blau1.gif");
                leuchtmelderImage[2, 4] = Image.FromFile(Application.StartupPath + "\\Resources\\blau0s.gif");
                leuchtmelderImage[3, 4] = Image.FromFile(Application.StartupPath + "\\Resources\\blau1s.gif");

                einschalterImage = Image.FromFile(Application.StartupPath + "\\Resources\\einschalter.gif");
                ausschalterImage = Image.FromFile(Application.StartupPath + "\\Resources\\ausschalter.gif");
                einschalterPressedImage = Image.FromFile(Application.StartupPath + "\\Resources\\einschalterPressed.gif");
                ausschalterPressedImage = Image.FromFile(Application.StartupPath + "\\Resources\\ausschalterPressed.gif");
                kipp0Image = Image.FromFile(Application.StartupPath + "\\Resources\\kipp0.gif");
                kipp1Image = Image.FromFile(Application.StartupPath + "\\Resources\\kipp1.gif");
                blindImage = Image.FromFile(Application.StartupPath + "\\Resources\\blindelement.gif");
                this.pictureBox.Image = blindImage;
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
            }
            catch (Exception e) {
                Console.WriteLine ("Exception bei Init Bedienelemente");
            }
        }

        public void notAus(Boolean b)
        {
            if (b)
            {
                storedState = this.getTasterState();
                this.tasterState = false;
                Form1.form1.Ios.setBoolean(tasterItem.byteAdr, tasterItem.bitAdr, false);
                if (type == FarbSchalter)
                {
                    this.pictureBox.Image = leuchtmelderImage[0, LeuchtmelderFarbe]; ;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
            }
            else
            {
                this.setTasterState(storedState);
                if (type == FarbSchalter)
                {
                    this.setTasterState(false);
                    this.pictureBox.Image = leuchtmelderImage[0, LeuchtmelderFarbe]; ;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
            }
        }

        /**
         * Getter und Setter der Eigenschaften
         */
        public void setType(int t) {
            type = t;
            if (type == Blindelement)
            {
                this.pictureBox.Image = blindImage;
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
            }
            else if (type == Schalter)
            {
                this.pictureBox.Image = kipp0Image;
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
            }
        }
        public int getType() { return type; }

        public void setNotausVorgeschaltet(Boolean b) { notausVorgeschaltet = b; }

        public Boolean mitNotaus() { return notausVorgeschaltet; }

        public void setLeuchtmelderAdr(String a) { 
            LeuchtmelderAdr = a;
            leuchtmelderItem.setAdress(a);
        }
        public String getLeuchtmelderAdr() { return LeuchtmelderAdr; }
        public BooleanItem getLeuchtmelderItem() { return leuchtmelderItem; }

        public void setLeuchtmelderFarbe(int a) {
            LeuchtmelderFarbe = a;
            int fadr=0;
            if (type == Leuchtmelder)
            {
                if (leuchtmelderState) fadr = 1;
                this.pictureBox.Image = leuchtmelderImage[fadr, LeuchtmelderFarbe];
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
            }
            else if (type == LeuchtTaster || type==FarbSchalter)
            {
                if (leuchtmelderState) fadr = 1;
                this.pictureBox.Image = leuchtmelderImage[fadr, LeuchtmelderFarbe];
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
            }
        }
        public int getLeuchtmlederFarbe() { return LeuchtmelderFarbe; }

        public void setTasterAdr(String a) { 
            TasterAdr = a;
            tasterItem.setAdress(a);
        }
        public String getTasterAdr() { return TasterAdr; }
        public BooleanItem getTasterBoleanItem() { return tasterItem; }
        public void setTasterTaste(char a) { TasterTaste = a; }
        public char getTasterTaste() { return TasterTaste; }
        public void setSchliesser(Boolean b) {
            schliesser=b;
            setTasterState(!b);
            int fadr = 0;
            if (type == Taster)
            {
                if (b)
                {
                    this.pictureBox.Image = einschalterImage;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                else
                {
                    this.pictureBox.Image = ausschalterImage;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
            }
            else if (type == LeuchtTaster)
            {
                if (leuchtmelderState) fadr = 1;
                this.pictureBox.Image = leuchtmelderImage[fadr, LeuchtmelderFarbe];
                this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
            }
        }
        public Boolean isSchliesser() {return schliesser;}

        public void setBeschriftung(String s) {
            this.beschriftungslabel.Text = s;
            beschriftung=s;
        }
        public String getBeschriftung() {return beschriftung;}


        public delegate void setImageCallback(Image i);

        public void setLeuchtmelderImage(Image i)
        {
            if (this.pictureBox.InvokeRequired)
            {
                setImageCallback d = new setImageCallback(setLeuchtmelderImage);
                this.Invoke(d, new object[] { i});
            }
            else
            {
                this.pictureBox.Image = i;
            }

        }

        public void calcLeuchtmelderState()
        {
            if (this.getLeuchtmelderAdr().StartsWith("A"))
            {
                this.setLeuchtmelderState(leuchtmelderItem.getState());
            }
        }

        public void calcLeuchtmelderState(BooleanItem bi)
        {
            if (this.type == Bedienelement.Leuchtmelder || this.type == Bedienelement.LeuchtTaster)
            {
                if (bi.isItem(this.getLeuchtmelderItem()))
                {
                    if (this.getLeuchtmelderAdr().StartsWith("E") || this.getLeuchtmelderAdr().StartsWith("e"))
                    {
                        //Console.WriteLine("akt. State=" + this.getLeuchtmelderState() + " Item state=" + bi.getState());
                        if (this.getLeuchtmelderState()== !bi.getState())
                        {
                            Console.WriteLine("Calc Leuchtmelder State:" + bi.ToString()+" aktueller Element state="+this.getLeuchtmelderState());
                            this.setLeuchtmelderState(bi.getState());
                        }
                    }
                }
            }
        }

        public void setLeuchtmelderState(Boolean b)
        {
            if (type == LeuchtTaster || type == Leuchtmelder )
            {
                Console.WriteLine("Set Leuchtmelder State auf " + b+" name="+this.Name);
                leuchtmelderState = b;
                
                if (leuchtmelderState)
                {
                    this.setLeuchtmelderImage(leuchtmelderImage[1, LeuchtmelderFarbe]);
                }
                else
                {
                    this.setLeuchtmelderImage(leuchtmelderImage[0, LeuchtmelderFarbe]);
                }
                
            }
        }
        public Boolean getLeuchtmelderState() { return leuchtmelderState; }
        
        
        public void setAllowEigenschaften(Boolean b)
        {
            eigenschaftenToolStripMenuItem.Enabled = b;
        }



        private void eigenschaftenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            EigenschaftenBedienelemente eg = new EigenschaftenBedienelemente();
            eg.setControl(this);
            eg.ShowDialog();
        }

        private void Bedienelement_MouseEnter(object sender, EventArgs e)
        {
            String s = "Blindelement";
            if (type == Leuchtmelder)
            {
                s="Leuchtmelder "+this.getLeuchtmelderAdr();
            }
            else if (type == Taster)
            {
                if (schliesser) {
                    s = "Schließer " + this.getTasterAdr()+" auf Taste "+this.getTasterTaste();  
                }
                else {
                    s = "Öffner " + this.getTasterAdr()+" auf Taste "+this.getTasterTaste();
                }
            }
            else if (type == Schalter || type==FarbSchalter)
            {
                s = "Schalter " + this.getTasterAdr() + " auf Taste " + this.getTasterTaste();
            }
            else if (type == LeuchtTaster)
            {
                if (schliesser)
                {
                    s = "Leuchttaster Schließer (" + this.getLeuchtmelderAdr() + "/" + this.getTasterAdr() + ") auf Taste " + this.getTasterTaste();
                }
                else
                {
                    s = "Leuchttaster Öffner (" + this.getLeuchtmelderAdr() + "/" + this.getTasterAdr() + ") auf Taste " + this.getTasterTaste(); ;
                }
            }

            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 4000;
            this.toolTip1.SetToolTip(this, s);
        }

        public void setTasterState(Boolean s)
        {
            if (!notausVorgeschaltet || notausVorgeschaltet && NotAus.getInstance().getState() == 1)
            {
                this.tasterState = s;
                Form1.form1.Ios.setBoolean(tasterItem.byteAdr, tasterItem.bitAdr, s);
            }
            else
            {
                storedState = s;
            }
        }

        public Boolean getTasterState() {
            return tasterState; 
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
        
            if (type == Taster)
            {
                if (schliesser)
                {
                    setTasterState(true);
                    this.pictureBox.Image = einschalterPressedImage;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                else
                {
                    this.pictureBox.Image = ausschalterPressedImage;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    setTasterState(false);
                }
            }
            else if (type == Schalter)
            {
                if (this.pictureBox.Image == kipp0Image)
                {
                    this.setTasterState(true);
                    this.pictureBox.Image = kipp1Image;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                else
                {
                    this.setTasterState(false);
                    this.pictureBox.Image = kipp0Image;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
            }
            else if (type == FarbSchalter)
            {
                if (pictureBox.Image == leuchtmelderImage[0, LeuchtmelderFarbe])
                {
                    setTasterState(true);
                    if (!mitNotaus() || mitNotaus() && NotAus.getInstance().getState() == 1)
                    {
                        this.pictureBox.Image = leuchtmelderImage[1, LeuchtmelderFarbe]; ;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                }
                else
                {
                    setTasterState(false);
                    this.pictureBox.Image = leuchtmelderImage[0, LeuchtmelderFarbe]; ;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
            }

            else if (type == LeuchtTaster)
            {
                if (leuchtmelderState)
                {
                    this.pictureBox.Image = leuchtmelderImage[3, LeuchtmelderFarbe];
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                else
                {
                    this.pictureBox.Image = leuchtmelderImage[2, LeuchtmelderFarbe]; ;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                if (schliesser)
                {
                    setTasterState(true);

                }
                else
                {
                    setTasterState(false);
                }
            }
        
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (type == Taster)
            {
                if (schliesser)
                {
                    setTasterState(false);
                    this.pictureBox.Image = einschalterImage;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                else
                {
                    setTasterState(true);
                    this.pictureBox.Image = ausschalterImage;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
            }

            else if (type == LeuchtTaster)
            {
                if (leuchtmelderState)
                {
                    this.pictureBox.Image = leuchtmelderImage[1, LeuchtmelderFarbe]; ;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                else
                {
                    this.pictureBox.Image = leuchtmelderImage[0, LeuchtmelderFarbe]; ;
                    this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                }
                if (schliesser)
                {
                    setTasterState(false);
                }
                else
                {
                    setTasterState(true);
                }
            }
        }

        public void keyPressed(char key)
        {
            if (key == this.getTasterTaste())
            {
                if (type == Taster)
                {
                    if (schliesser)
                    {
                        setTasterState(true);
                        this.pictureBox.Image = einschalterPressedImage;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                    else
                    {
                        this.pictureBox.Image = ausschalterPressedImage;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                        setTasterState(false);
                    }
                }
                else if (type == FarbSchalter)
                {
                    if (pictureBox.Image == leuchtmelderImage[0, LeuchtmelderFarbe])
                    {
                        setTasterState(true);
                        if (!mitNotaus() || mitNotaus() && NotAus.getInstance().getState() == 1)
                        {
                            this.pictureBox.Image = leuchtmelderImage[1, LeuchtmelderFarbe]; ;
                            this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                        }
                    }
                    else
                    {
                        setTasterState(false);
                        this.pictureBox.Image = leuchtmelderImage[0, LeuchtmelderFarbe]; ;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                }
                else if (type == Schalter)
                {
                    if (pictureBox.Image == kipp0Image)
                    {
                        setTasterState(true);
                        this.pictureBox.Image = kipp1Image;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                    else
                    {
                        setTasterState(false);
                        this.pictureBox.Image = kipp0Image;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                }
                else if (type == LeuchtTaster)
                {
                    if (leuchtmelderState)
                    {
                        this.pictureBox.Image = leuchtmelderImage[3, LeuchtmelderFarbe]; ;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                    else
                    {
                        this.pictureBox.Image = leuchtmelderImage[2, LeuchtmelderFarbe]; ;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                    if (schliesser)
                    {
                        setTasterState(true);
                    }
                    else
                    {
                        setTasterState(false);
                    }
                }
            }
        }

        public void keyReleased(char key)
        {
            if (key == this.getTasterTaste())
            {
                if (type == Taster)
                {
                    if (schliesser)
                    {
                        setTasterState(false);
                        this.pictureBox.Image = einschalterImage;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                    else
                    {
                        this.pictureBox.Image = ausschalterImage;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                        setTasterState(true);
                    }
                }
                else if (type == LeuchtTaster)
                {
                    if (leuchtmelderState)
                    {
                        this.pictureBox.Image = leuchtmelderImage[1, LeuchtmelderFarbe]; ;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                    else
                    {
                        this.pictureBox.Image = leuchtmelderImage[0, LeuchtmelderFarbe]; ;
                        this.pictureBox.Size = new System.Drawing.Size(this.pictureBox.Image.Width, this.pictureBox.Image.Height);
                    }
                    if (schliesser)
                    {
                        setTasterState(false);
                    }
                    else
                    {
                        setTasterState(true);
                    }
                }
            }
        }

        public String toXML()
        {
            //Console.WriteLine("Beschriftung=>" + this.getBeschriftung() + "<");
            return "<Belem x=\""+Location.X+"\" y=\""+Location.Y+"\" name=\""+this.Name+"\" type=\""+this.getType()+"\" beschriftung=\""+this.getBeschriftung()+"\" farbe=\""+this.getLeuchtmlederFarbe()+"\" adrLeuchtmelder=\""+this.getLeuchtmelderAdr()+"\" taste=\""+this.getTasterTaste()+"\" adrTaster=\""+this.getTasterAdr()+"\" schliesser=\""+this.isSchliesser()+"\" notaus=\""+this.mitNotaus()+"\"></Belem>";
        }
        public void setAttributes(System.Collections.Hashtable a)
        {
            this.setType(Int16.Parse(a["type"].ToString()));
            this.setSchliesser(Boolean.Parse(a["schliesser"].ToString()));
            this.setBeschriftung(a["beschriftung"].ToString());
            this.setLeuchtmelderAdr(a["adrLeuchtmelder"].ToString());
            this.setLeuchtmelderFarbe(Int16.Parse(a["farbe"].ToString()));
            this.setTasterAdr(a["adrTaster"].ToString());
            if (a["notaus"] != null)
            {
                String na = a["notaus"].ToString();
                this.setNotausVorgeschaltet(Boolean.Parse(na));
            }
            String c = a["taste"].ToString();
            this.setTasterTaste(Char.Parse(c.Substring(0,1)));
            this.Name = a["name"].ToString();
            this.Location = new Point(Int16.Parse(a["x"].ToString()), Int16.Parse(a["y"].ToString()));
        }
    }
}
