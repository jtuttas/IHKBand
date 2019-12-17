using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
using System.Reflection;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form, PlcListener
    {

        public static Form1 form1;
        public static Panel instance;
        public static Panel instanceBedienpanel;
        public static Graphics g;
        public static String projektName = "project";
        public  String titelName;
        int xMaus, yMaus;
        private IOServerModbus ios;
        ModbusConfig mc = new ModbusConfig();
        internal IOServerModbus Ios { get => ios; set => ios = value; }

        public Form1()
        {
            titelName =  "Aktorikmodell Sortieranlage Version 1.4 (c) 2009/10/20 by Dr. Jörg Tuttas: ";
            form1 = this;
            this.InitializeComponent();
            instance = this.prozessPanel;
            instanceBedienpanel = this.bedienpanel;
            g = instance.CreateGraphics();
            
            try
            {
                this.buildProject(Application.StartupPath + "\\Resources\\default.eat");
            }
            catch (Exception e)
            {
                toolStripStatusLabel1.Text = "Kann Defaultkonfiguration nicht finden!";
                this.Text = titelName;
            }
        }
        
              

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Bedienelement)
                    {
                        Bedienelement z = (Bedienelement)cc;
                        if (z.getType() == Bedienelement.Taster || z.getType() == Bedienelement.LeuchtTaster || z.getType()==Bedienelement.Schalter)
                        {
                            if (Ios!=null && Ios.isConnected()) Ios.setBoolean(z.getTasterBoleanItem().byteAdr, z.getTasterBoleanItem().bitAdr, z.getTasterState());
                        }
                    }
                }
            }

            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Zylinder)
                    {
                        Zylinder z = (Zylinder)cc;
                        z.move();
                        if (Ios!=null &&  Ios.isConnected()) Ios.setBoolean(z.getVorneItem().byteAdr, z.getVorneItem().bitAdr, z.kolben.istVorne());
                        if (Ios!=null  && Ios.isConnected()) Ios.setBoolean(z.getHintenItem().byteAdr, z.getHintenItem().bitAdr, z.kolben.istHinten());
                    }
                    else if (cc is Material)
                    {
                        Material ma = (Material)cc;
                        ma.move();
                    }
                    else if (cc is Magazin)
                    {
                        Magazin ma = (Magazin)cc;
                        ma.catchMaterial();
                    }
                    else if (cc is Band)
                    {
                        Band b = (Band)cc;
                        b.move();
                        //b.paint(Form1.g);
                    }
                    else if (cc is Sensor)
                    {
                        Sensor s = (Sensor)cc;
                        if (Ios!=null &&  Ios.isConnected()) Ios.setBoolean(s.getBooleanItem().byteAdr, s.getBooleanItem().bitAdr, s.getState());
                    }
                    
                    else if (cc is NotAus)
                    {
                        NotAus s = (NotAus)cc;
                        if (Ios!=null && Ios.isConnected()) Ios.setBoolean(s.getFreigabeItem().byteAdr, s.getFreigabeItem().bitAdr, s.isFree());
                    }
                }
            }
       
        }

        
        
        private void setControls(Boolean b)
        {
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Zylinder)
                    {
                        Zylinder z = (Zylinder)cc;
                        z.freeze(b);
                    }
                    else if (cc is Magazin)
                    {
                        Magazin ma = (Magazin)cc;
                        ma.freeze(b);
                    }
                    else if (cc is Sensor)
                    {
                        Sensor se = (Sensor)cc;
                        se.freeze(b);
                    }
                    else if (cc is Band)
                    {
                        Band ba = (Band)cc;
                        if (!b) ba.setSpeed(0);
                    }
                    if (cc is Basic2dObject)
                    {
                        Basic2dObject ba = (Basic2dObject)cc;
                        ba.setAllowEigenschaften(!b);
                    }
                }
            }
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Bedienelement)
                    {
                        Bedienelement z = (Bedienelement)cc;
                        z.setAllowEigenschaften(!b);
                    }
                }
            }
            maddMagazin.Enabled = !b;
            maddSensor.Enabled = !b;
            maddZylinder.Enabled = !b;
            mneu.Enabled = !b;
            mladen.Enabled = !b;
            speichernToolStripMenuItem.Enabled = !b;

        }

        private void mverbinden_Click(object sender, EventArgs e)
        {
            if (Ios!=null && Ios.isConnected())
            {
                
                Ios.disconnect();
                Ios.remoteAllItems();
                toolStripStatusLabel1.Text = "Von Steuerung getrennt!!";
                toolStripStatusLabel1.BackColor = Color.Yellow;
                mverbinden.Text = "Verbinden";
                setControls(false);
                
            }
            else
            {
                Ios = new IOServerModbus(mc.ipTextBox.Text, Int32.Parse(mc.portTextBox.Text),ushort.Parse(mc.coilOffsetTextBox.Text), ushort.Parse(mc.inputCoilTextBox.Text));
                Ios.setListener(this);
                Boolean b = this.Ios.connect();
                statusStrip1.BackColor = Color.Transparent;
                if (b)
                {
                    mverbinden.Text = "Trennen";
                    setControls(true);
                    foreach (Control cc in Form1.instance.Controls)
                    {
                        if (cc.HasChildren)
                        {

                            if (cc is Band)
                            {
                                Band z = (Band)cc;
                                if (z.getRightItem().byteAdr!=-1) Ios.add(z.getRightItem());
                                if (z.getLeftItem().byteAdr!=-1) Ios.add(z.getLeftItem());
                                if (z.getSpeedrechtsItem().byteAdr!=-1) Ios.add(z.getSpeedrechtsItem());
                                if (z.getSpeedlinksItem().byteAdr!=-1) Ios.add(z.getSpeedlinksItem());
                                
                            }
                            else if (cc is Zylinder)
                            {
                                Zylinder z = (Zylinder)cc;
                                Ios.add(z.getVorItem());
                                Ios.add(z.getZurueckItem());
                            }
                            else if (cc is Sensor)
                            {
                                Sensor se = (Sensor)cc;
                                Ios.setBoolean(se.getBooleanItem().byteAdr, se.getBooleanItem().bitAdr, se.getState());
                            }
                            else if (cc is NotAus)
                            {
                                NotAus na = (NotAus)cc;
                                Ios.setBoolean(na.getBooleanItem().byteAdr, na.getBooleanItem().bitAdr, na.isFree());
                            }
                        }
                    }
                    foreach (Control cc in Form1.instanceBedienpanel.Controls)
                    {
                        if (cc.HasChildren)
                        {

                            if (cc is Bedienelement)
                            {
                                Bedienelement z = (Bedienelement)cc;
                                if (z.getType() == Bedienelement.Taster || z.getType() == Bedienelement.LeuchtTaster || z.getType() == Bedienelement.Schalter || z.getType() == Bedienelement.FarbSchalter)
                                {
                                    Ios.setBoolean(z.getTasterBoleanItem().byteAdr, z.getTasterBoleanItem().bitAdr, z.getTasterState());
                                }
                                if (z.getType() == Bedienelement.Leuchtmelder || z.getType() == Bedienelement.LeuchtTaster)
                                {
                                    Ios.add(z.getLeuchtmelderItem());
                                }
                            }
                            if (cc is Segment7)
                            {
                                Segment7 s = (Segment7)cc;
                                Ios.add(s.getBooleanItem0());
                                Ios.add(s.getBooleanItem1());
                                Ios.add(s.getBooleanItem2());
                                Ios.add(s.getBooleanItem4());
                            }
                        }
                    }
                    
                    Ios.runner.Start();

                }
                else
                {
                    toolStripStatusLabel1.Text = "Verbindung fehlgeschlagen!";
                    toolStripStatusLabel1.BackColor = Color.Red;
                }
            }
        }

        private void mRepair_Click(object sender, EventArgs e)
        {
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Band)
                    {
                        Band b = (Band)cc;
                        b.reset();
                    }
                }
            }
        }

        private void mHolz_Click(object sender, EventArgs e)
        {
            Holz holz = new Holz();
            holz.Location = new System.Drawing.Point(xMaus, yMaus);           
            insertControl(holz);
        }

        public void insertControl(Control c)
        {
            this.insertControl(c, null);
        }

        public void insertControl(Control c,Control bevoreControll)
        {
            Control[] a = new Control[Form1.instance.Controls.Count + 1];
            int index=0;
            int controlIndex=0;

            if (bevoreControll == null) index = 1;

            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (bevoreControll != null && cc == bevoreControll)
                    {
                        Console.WriteLine("Found Bevore Control at " + index);
                        controlIndex = index;
                        a[index] = cc;
                        index = index + 2;
                    }
                    else
                    {
                        a[index] = cc;
                        index++;
                    }
                }
            }
            if (bevoreControll!=null)
            {
                a[controlIndex+1] = c;
            }
            else
            {
                a[0] = c;
            }
            Form1.instance.Controls.Clear();
            Form1.instance.Controls.AddRange(a);

        }

        private void mMetall_Click(object sender, EventArgs e)
        {
            Metall holz = new Metall();
            holz.Location = new System.Drawing.Point(xMaus, yMaus);         
            insertControl(holz);
        }

        private void maddZylinder_Click(object sender, EventArgs e)
        {
            Zylinder holz = new Zylinder();
            holz.Location = new System.Drawing.Point(xMaus, yMaus);
            insertControl(holz);
        }

        private void maddMagazin_Click(object sender, EventArgs e)
        {
            Magazin holz = new Magazin();
            holz.Location = new System.Drawing.Point(xMaus, yMaus);         
            insertControl(holz);
        }

        private void mInd_Click(object sender, EventArgs e)
        {
            InduktiverNaeherungsschalter holz = new InduktiverNaeherungsschalter();
            holz.Location = new System.Drawing.Point(xMaus, yMaus);
            insertControl(holz);
        }

        private void mKap_Click(object sender, EventArgs e)
        {
            KapazitiverNaeherungsschalter holz = new KapazitiverNaeherungsschalter();
            holz.Location = new System.Drawing.Point(xMaus, yMaus);
            Console.WriteLine("xMaus=" + xMaus + " yMaus=" + yMaus);
            insertControl(holz);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            xMaus = e.X;
            yMaus = e.Y;
        }

        private void basic2dObject1_DoubleClick(object sender, EventArgs e)
        {
            this.menuStrip1.Visible = true;
        }

        private void mabout_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //Console.WriteLine("Sel"+e.TabPageIndex);
            if (e.TabPageIndex == 1)
            {
                buildDataGrid();
            }
        }


        private void buildDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Band)
                    {
                        Band b = (Band)cc;
                        if (b.getRightAdress() != "") dataGridView1.Rows.Add(new String[] { b.Name + " rechts", b.getRightAdress(), "Förderband nach rechts" });
                        if (b.getLeftAdress() != "") dataGridView1.Rows.Add(new String[] { b.Name + " links", b.getLeftAdress(), "Förderband nach links" });
                        if (b.getSpeedRightAdress() != "") dataGridView1.Rows.Add(new String[] { b.Name + " schnell-rechts", b.getSpeedRightAdress(), "Förderband 2. Drehzahl (schnell) rechts" });
                        if (b.getSpeedLeftAdress() != "") dataGridView1.Rows.Add(new String[] { b.Name + " schnell-links", b.getSpeedLeftAdress(), "Förderband 2. Drehzahl (schnell) links" });
                    }
                    else if (cc is InduktiverNaeherungsschalter)
                    {
                        InduktiverNaeherungsschalter s = (InduktiverNaeherungsschalter)cc;
                        dataGridView1.Rows.Add(new String[] { s.Name, s.getAdress(), "Ind.Näherungsschalter" });
                    }
                    else if (cc is KapazitiverNaeherungsschalter)
                    {
                        KapazitiverNaeherungsschalter s = (KapazitiverNaeherungsschalter)cc;
                        dataGridView1.Rows.Add(new String[] { s.Name, s.getAdress(), "Kap.Näherungsschalter" });
                    }
                    else if (cc is Zylinder)
                    {
                        Zylinder z = (Zylinder)cc;
                        dataGridView1.Rows.Add(new String[] { z.Name + " hinten", z.getEingefahrenAdress(), "Zylinder Endlage eingefahren" });
                        dataGridView1.Rows.Add(new String[] { z.Name + " vorne", z.getAusgefahrenAdress(), "Zylinder Endlage ausgefahren" });
                        dataGridView1.Rows.Add(new String[] { z.Name + " zurueck", z.getEinfahrenAdress(), "Zylinder einfahren" });
                        dataGridView1.Rows.Add(new String[] { z.Name + " vor", z.getAusfahrenAdress(), "Zylinder ausfahren" });
                    }
                    else if (cc is NotAus)
                    {
                        NotAus na = (NotAus)cc;
                        dataGridView1.Rows.Add(new String[] { na.Name + " Freigabe", na.getFreigabeAdress(), "NotAus Freigabe" });
                        dataGridView1.Rows.Add(new String[] { na.Name + " Quittierung", na.getQuitAdress(), "NotAus Quittierung" });

                    }
                }
            }
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Segment7)
                    {
                        Segment7 b = (Segment7)cc;
                        dataGridView1.Rows.Add(new String[] { b.Name, b.getAdr0(), "Adresse 0" });
                        dataGridView1.Rows.Add(new String[] { b.Name, b.getAdr1(), "Adresse 1" });
                        dataGridView1.Rows.Add(new String[] { b.Name, b.getAdr2(), "Adresse 2" });
                        dataGridView1.Rows.Add(new String[] { b.Name, b.getAdr4(), "Adresse 4" });

                    }
                    else if (cc is Bedienelement)
                    {
                        Bedienelement b = (Bedienelement)cc;
                        if (b.getType() == Bedienelement.Leuchtmelder)
                        {
                            dataGridView1.Rows.Add(new String[] { b.Name, b.getLeuchtmelderAdr(), "Leuchtmelder " + b.getBeschriftung() });
                        }
                        else if (b.getType() == Bedienelement.Schalter)
                        {
                            dataGridView1.Rows.Add(new String[] { b.Name, b.getTasterAdr(), "Schalter " + b.getBeschriftung() });
                        }
                        else if (b.getType() == Bedienelement.Taster)
                        {
                            if (b.isSchliesser() == true)
                            {
                                dataGridView1.Rows.Add(new String[] { b.Name, b.getTasterAdr(), "Taster (Schließer) " + b.getBeschriftung() });
                            }
                            else
                            {
                                dataGridView1.Rows.Add(new String[] { b.Name, b.getTasterAdr(), "Taster (Öffner) " + b.getBeschriftung() });
                            }
                        }
                        else if (b.getType() == Bedienelement.LeuchtTaster)
                        {
                            dataGridView1.Rows.Add(new String[] { b.Name, b.getLeuchtmelderAdr(), "Leuchtmelder " + b.getBeschriftung() });
                            if (b.isSchliesser() == true)
                            {
                                dataGridView1.Rows.Add(new String[] { b.Name, b.getTasterAdr(), "Taster (Schließer) " + b.getBeschriftung() });
                            }
                            else
                            {
                                dataGridView1.Rows.Add(new String[] { b.Name, b.getTasterAdr(), "Taster (Öffner) " + b.getBeschriftung() });
                            }
                        }
                    }

                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("Key Down "+e.KeyValue );
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Bedienelement)
                    {
                        Bedienelement b = (Bedienelement)cc;
                        b.keyPressed((char)e.KeyValue);
                    }
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Bedienelement)
                    {
                        Bedienelement b = (Bedienelement)cc;
                        b.keyReleased((char)e.KeyValue);
                    }
                }
            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.FileName = projektName + ".eat";
            this.saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            String s="<?xml version=\"1.0\" encoding=\"UTF-32\"?>\n";
            s = s + "<project name=\""+projektName+"\">\n";
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Basic2dObject)
                    {
                        Basic2dObject b = (Basic2dObject)cc;
                        s = s + b.toXML()+"\n";
                    }
                }
            }
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {
                    if (cc is Bedienelement)
                    {
                        Bedienelement b = (Bedienelement)cc;
                        s = s + b.toXML()+"\n";
                    }
                    else if (cc is Segment7)
                    {
                        Segment7 b = (Segment7)cc;
                        s = s + b.toXML()+"\n";
                    }
                }
            }
            s = s + "</project>\n";
//            Console.WriteLine("Filename=" + this.saveFileDialog1.FileName);


            StreamWriter WStream = new StreamWriter(this.saveFileDialog1.FileName,false, new System.Text.UTF32Encoding());
            WStream.Write(s);
            WStream.Close();
            toolStripStatusLabel1.Text = "Konfig. gespeichert unter " + this.saveFileDialog1.FileName;
        }


        private void mladen_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
        }

        private void buildProject(String name) 
        {
            try
            {
                
                XmlTextReader reader = new XmlTextReader(name);

                Console.WriteLine("Build Projekt >" + name + "<");
                if (File.Exists(name)) {
                    Form1.instance.Controls.Clear();
                    Form1.instanceBedienpanel.Controls.Clear();
                }
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            Hashtable attributes = new Hashtable();
                            String strURI = reader.NamespaceURI;
                            String strName = reader.Name;
                            Console.WriteLine("URI=" + strURI + " name=" + strName);
                            if (reader.HasAttributes)
                            {
                                for (int i = 0; i < reader.AttributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    attributes.Add(reader.Name, reader.Value);
                                    Console.WriteLine("read: " + reader.Name + " value=" + reader.Value);
                                }
                            }
                            if (strName == "project")
                            {
                                projektName = attributes["name"].ToString();
                            }
                            if (strName == "Holz")
                            {
                                Holz h = new Holz();
                                h.setAttributes(attributes);
                                Form1.instance.Controls.Add(h);
                            }
                            else if (strName == "Metall")
                            {
                                Metall m = new Metall();
                                m.setAttributes(attributes);
                                Form1.instance.Controls.Add(m);
                            }
                            else if (strName == "Rutsche")
                            {
                                Console.WriteLine("Rutsche hinzufügen");
                                Rutsche r = new Rutsche();
                                r.setAttributes(attributes);
                                Form1.instance.Controls.Add(r);
                            }
                            else if (strName == "Magazin")
                            {
                                Magazin m = new Magazin();
                                m.setAttributes(attributes);
                                Form1.instance.Controls.Add(m);
                            }
                            else if (strName == "Band")
                            {
                                Band m = new Band();
                                m.setAttributes(attributes);
                                Form1.instance.Controls.Add(m);

                            }
                            else if (strName == "Ind")
                            {
                                InduktiverNaeherungsschalter m = new InduktiverNaeherungsschalter();
                                m.setAttributes(attributes);
                                Form1.instance.Controls.Add(m);
                            }
                            else if (strName == "Kap")
                            {
                                KapazitiverNaeherungsschalter m = new KapazitiverNaeherungsschalter();
                                m.setAttributes(attributes);
                                Form1.instance.Controls.Add(m);
                            }
                            else if (strName == "Not")
                            {
                                NotAus na = new NotAus();
                                na.setAttributes(attributes);
                                Form1.instance.Controls.Add(na);
                            }
                            else if (strName == "Zylinder")
                            {
                                Zylinder m = new Zylinder();
                                m.setAttributes(attributes);
                                Form1.instance.Controls.Add(m);
                            }
                            else if (strName == "seg7")
                            {
                                Segment7 m = new Segment7();
                                m.setAttributes(attributes);
                                Form1.instanceBedienpanel.Controls.Add(m);
                            }
                            else if (strName == "Belem")
                            {
                                Bedienelement m = new Bedienelement();
                                m.setAttributes(attributes);
                                Form1.instanceBedienpanel.Controls.Add(m);
                            }


                            break;
                        default:
                            break;
                    }
                }
                reader.Close();
                this.buildDataGrid();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception beim XML-Lesen:" + e.Message);
                throw e;
            }
            this.Text = titelName + projektName;

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.buildProject(this.openFileDialog1.FileName);
            toolStripStatusLabel1.Text = "Konfig. geladen von " + this.openFileDialog1.FileName;
        }

        private void mexit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (Ios!=null && Ios.isConnected())
            {
                Ios.disconnect();
            }
            this.Close();
        }

        private void mneu_Click(object sender, EventArgs e)
        {
            String s = projektName;
            NeuesProjekt np = new NeuesProjekt();
            np.ShowDialog();
            if (projektName != s)
            {
                String p = projektName;
                try
                {
                    this.buildProject(Application.StartupPath + "\\Resources\\default.eat");
                    projektName = p;
                    this.Text = titelName + projektName;
                }
                catch (Exception ee)
                {
                    toolStripStatusLabel1.Text = "Kann Defaultkonfiguration nicht finden!";
                    this.Text = titelName;
                }
            }

        }

        /**
         * Implementierung der Schnittstelle von PLC Listener
         */
        public void stateChanged(String state)
        {
            toolStripStatusLabel1.Text = "Verbunden: " + state;
            Console.WriteLine("**State changed: >" + state+"<");
            if (state == "Steuerung im Zustand STOP")
            {
                toolStripStatusLabel1.BackColor = Color.LightGreen;
            }
            else
            {
                toolStripStatusLabel1.BackColor = Color.Green;
            }
        }

        public void inputChanged(BooleanItem bi)
        {
            //Console.WriteLine("**Input changed:" +bi.ToString());
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Bedienelement)
                    {
                        Bedienelement z = (Bedienelement)cc;
                        z.calcLeuchtmelderState(bi);
                    }
                }
            }

            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is NotAus)
                    {
                        //Console.WriteLine("**Input changed:" + bi.ToString());
                        NotAus na = (NotAus)cc;
                        na.calc(bi);
                    }
                }
            }              
        }

        public void outputChanged(BooleanItem bi)
        {
            //Console.WriteLine("**Output changed:" +bi.ToString());
            foreach (Control cc in Form1.instanceBedienpanel.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Bedienelement)
                    {
                        Bedienelement z = (Bedienelement)cc;
                        z.calcLeuchtmelderState();
                    }
                    else if (cc is Segment7)
                    {
                        Segment7 s = (Segment7)cc;
                        s.calcValue();
                    }
                }
            }
            foreach (Control cc in Form1.instance.Controls)
            {
                if (cc.HasChildren)
                {

                    if (cc is Zylinder)
                    {
                        Zylinder z = (Zylinder)cc;
                        z.calc();
                    }
                    else if (cc is Band)
                    {
                        Band b = (Band)cc;
                        b.calc();
                    }
                    /*
                    else if (cc is NotAus)
                    {
                        NotAus na = (NotAus)cc;
                        na.calc();
                    }
                     */
                }
            }
        }

        public delegate void setLostConnectionCallback(Object o);

        public void setLostConnection(Object o)
        {
            if (this.InvokeRequired)
            {
                setLostConnectionCallback d = new setLostConnectionCallback(setLostConnection);
                this.Invoke(d, new object[] { null });
            }
            else
            {
                toolStripStatusLabel1.BackColor = Color.Red;
                toolStripStatusLabel1.Text = "Verbindung zur PLC Sim verloren!";
                mverbinden.Text = "Verbinden";
                setControls(false);
            }
        }

        public void lostConnection(String s)
        {
            
            //ios.disconnect();
            if (Ios!=null)
            {
                Ios.remoteAllItems();
            }
            setLostConnection(null);
            
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (Ios!=null && Ios.isConnected())
            {
                Ios.disconnect();
            }
        }

        private void verbindungsConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            mc.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AusgabeZuordnung az = new AusgabeZuordnung();
            String s = "";
            foreach (DataGridViewRow r in dataGridView1.Rows) {
                s = "";
                foreach (DataGridViewCell c in r.Cells) {
                    s = s + c.Value;
                    //Console.WriteLine("Width=" + c.Size.Width);
                    for (int i = c.Value.ToString().Length; i < c.Size.Width / 5; i++)
                    {
                        s = s + " ";
                    }
                }
                az.appendText(s);
            }
            az.ShowDialog();

        }






    }
}
