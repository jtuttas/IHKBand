using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EigenschaftenDialog : Form
    {
        Control mycontrol;
        public EigenschaftenDialog()
        {
            InitializeComponent();
        }

        public void setControl(Control c) {
            mycontrol = c;
            nametextBox.Text = c.Name;
            if (c is Rutsche)
            {
                this.Text = "Eigenschaften Rutsche";
            }
            else if (c is Magazin)
            {
                this.Text = "Eigenschaften Magazin";
            }
            else if (c is NotAus)
            {
                this.Text = "Eigenschaften NotAus";
                NotAus z = (NotAus)mycontrol;
                panel1.Controls.Add(Notauspanel);
                Notauspanel.Dock = System.Windows.Forms.DockStyle.Fill;
                Notauspanel.Visible = true;
                quittextBox.Text = z.getQuitAdress();
                freigabetextBox.Text = z.getFreigabeAdress();
            }
            else if (c is Zylinder)
            {
                this.Text = "Eigenschaften Zylinder";

                Zylinder z = (Zylinder)mycontrol;
                panel1.Controls.Add(zylinderpanel);
                zylinderpanel.Dock = System.Windows.Forms.DockStyle.Fill;
                zylinderpanel.Visible = true;
                zeinfahrentextBox.Text = z.getEinfahrenAdress();
                zeingefahrentextBox.Text = z.getEingefahrenAdress();
                zausfahrentextBox.Text = z.getAusfahrenAdress();
                zausgefahrentextBox.Text = z.getAusgefahrenAdress();
            }
            else if (c is Sensor)
            {
                this.Text = "Eigenschaften Sensor";

                Sensor s = (Sensor)mycontrol;
                panel1.Controls.Add(sensorpanel);
                sensorpanel.Dock = System.Windows.Forms.DockStyle.Fill;
                sensorpanel.Visible = true;
                sensorLinkstextBox.Text = s.getLeftBound().ToString();
                sensorRechtstextBox.Text = s.getRightBound().ToString();
                sensorObentextBox.Text = s.getTopBound().ToString();
                sensorUntentextBox.Text = s.getBottumBound().ToString();
                sensorEingangtextBox.Text = s.getAdress();
            }
            else if (c is Band)
            {
                this.Text = "Eigenschaften Band";

                Band b = (Band)mycontrol;
                panel1.Controls.Add(bandpanel);
                bandpanel.Dock = System.Windows.Forms.DockStyle.Fill;
                bandpanel.Visible = true;
                rechtstextBox.Text = b.getRightAdress();
                linkstextBox.Text = b.getLeftAdress();
                schnellrechtstextBox.Text = b.getSpeedRightAdress();
                schnelllinkstextBox.Text = b.getSpeedLeftAdress();
                if (b.getRightAdress() == "")
                {
                    checkBox1.Checked = false;
                }
                if (b.getLeftAdress() == "")
                {
                    checkBox2.Checked = false;
                }
                if (b.getSpeedRightAdress() == "")
                {
                    checkBox3.Checked = false;
                }
                if (b.getSpeedLeftAdress() == "")
                {
                    checkBox4.Checked = false;
                }

            }
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            mycontrol.Name = nametextBox.Text;
            if (mycontrol is Rutsche)
            {

            }
            else if (mycontrol is NotAus)
            {
                NotAus s = (NotAus)mycontrol;
                s.setAdress(quittextBox.Text, freigabetextBox.Text);
            }
            else if (mycontrol is Sensor)
            {
                Sensor s = (Sensor)mycontrol;
                s.setBoundary(Int32.Parse(sensorRechtstextBox.Text), Int32.Parse(sensorObentextBox.Text), Int32.Parse(sensorLinkstextBox.Text), Int32.Parse(sensorUntentextBox.Text));
                s.setAdress(sensorEingangtextBox.Text);
            }
            else if (mycontrol is Band)
            {
                Band b = (Band)mycontrol;
                String re = rechtstextBox.Text;
                String li = linkstextBox.Text;
                String sre = schnellrechtstextBox.Text;
                String sli = schnelllinkstextBox.Text;
                if (!checkBox1.Checked) re = "";
                if (!checkBox2.Checked) li = "";
                if (!checkBox3.Checked) sre = "";
                if (!checkBox4.Checked) sli = "";
                b.setAdresses(re, li, sre, sli);
            }
            else if (mycontrol is Zylinder)
            {
                Zylinder z = (Zylinder)mycontrol;
                z.setAdresses(zeingefahrentextBox.Text, zausgefahrentextBox.Text, zeinfahrentextBox.Text, zausfahrentextBox.Text);
            }
            this.Close();
        }

        private void abbruchbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rechtstextBox.Enabled = checkBox1.Checked;
            if (rechtstextBox.Text == "") rechtstextBox.Text = "A1.0";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            linkstextBox.Enabled = checkBox2.Checked;
            if (linkstextBox.Text == "") linkstextBox.Text = "A1.1";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            schnellrechtstextBox.Enabled = checkBox3.Checked;
            if (schnellrechtstextBox.Text == "") schnellrechtstextBox.Text = "A1.2";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            schnelllinkstextBox.Enabled = checkBox4.Checked;
            if (schnelllinkstextBox.Text==  "") schnelllinkstextBox.Text = "A1.3";
        }
    }    
}
