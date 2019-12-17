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
    public partial class EigenschaftenBedienelemente : Form
    {
        Control myControl;

        public EigenschaftenBedienelemente()
        {
            InitializeComponent();
        }

        public void setControl(Control c)
        {
            myControl = c;
            Bedienelement b = (Bedienelement)myControl;
            beschriftungtextBox.Text = b.getBeschriftung();
            tastergroupBox.Enabled = false;
            leuchtmeldergroupBox.Enabled = false;
            if (b.getType() == Bedienelement.Blindelement) blindelementradioButton.Checked = true;
            else if (b.getType() == Bedienelement.Leuchtmelder)
            {
                leuchtmlederradioButton.Checked = true;
            }
            else if (b.getType() == Bedienelement.Taster)
            {
                tasterradioButton.Checked = true;
            }
            else if (b.getType() == Bedienelement.LeuchtTaster)
            {
                leuchttasterradioButton.Checked = true;
            }
            else if (b.getType() == Bedienelement.Schalter)
            {
                schalterradioButton1.Checked = true;
            }
            else if (b.getType() == Bedienelement.FarbSchalter)
            {
                farbschalterradioButton.Checked = true;
            }

            farbecomboBox.SelectedIndex = b.getLeuchtmlederFarbe();
            LeuchtmelderAdrtextBox.Text = b.getLeuchtmelderAdr();

            tasterAdrtextBox.Text = b.getTasterAdr();
            tastertastetextBox.Text = b.getTasterTaste().ToString();
            schliesserradioButton.Checked = b.isSchliesser();
            oeffnerradioButton.Checked = !b.isSchliesser();
            notuuscheckBox.Checked = b.mitNotaus();
            textBoxname.Text = b.Name;

        }


        private void obbutton_Click(object sender, EventArgs e)
        {
            Bedienelement b = (Bedienelement)myControl;
            b.setBeschriftung(beschriftungtextBox.Text);
            if (blindelementradioButton.Checked) b.setType(Bedienelement.Blindelement);
            else if (leuchttasterradioButton.Checked) b.setType(Bedienelement.LeuchtTaster);
            else if (leuchtmlederradioButton.Checked) b.setType(Bedienelement.Leuchtmelder);
            else if (tasterradioButton.Checked) b.setType(Bedienelement.Taster);
            else if (schalterradioButton1.Checked) b.setType(Bedienelement.Schalter);
            else if (farbschalterradioButton.Checked) b.setType(Bedienelement.FarbSchalter);

            if (b.getType() == Bedienelement.FarbSchalter)
            {
                b.setLeuchtmelderFarbe(farbeschaltercomboBox.SelectedIndex);
            }
            else
            {
                b.setLeuchtmelderFarbe(farbecomboBox.SelectedIndex);
            }
            b.setLeuchtmelderAdr(LeuchtmelderAdrtextBox.Text);
            b.setTasterAdr(tasterAdrtextBox.Text);
            char c = Char.Parse(tastertastetextBox.Text.Substring(0,1));
            b.setTasterTaste(c);
            b.setSchliesser(schliesserradioButton.Checked);
            b.Name = textBoxname.Text;
            b.setNotausVorgeschaltet(notuuscheckBox.Checked);
            b.pictureBox.Focus();
            this.Close();
        }

        private void abbrechenbutton_Click(object sender, EventArgs e)
        {
            Bedienelement b = (Bedienelement)myControl;
            b.pictureBox.Focus();

            this.Close();

        }

        private void blindelementradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (blindelementradioButton.Checked)
            {
                leuchtmeldergroupBox.Enabled = false;
                tastergroupBox.Enabled = false;
            }
        }

        private void leuchtmlederradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (leuchtmlederradioButton.Checked)
            {
                tastergroupBox.Enabled = false;
                leuchtmeldergroupBox.Enabled = true;
            }

        }

        private void leuchttasterradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (leuchttasterradioButton.Checked)
            {
                tastergroupBox.Enabled = true;
                leuchtmeldergroupBox.Enabled = true;
                oeffnerradioButton.Enabled = true;
                schliesserradioButton.Enabled = true;
                farbeschaltercomboBox.Enabled = false;


            }

        }

        private void tasterradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (tasterradioButton.Checked)
            {
                leuchtmeldergroupBox.Enabled = false;
                tastergroupBox.Enabled = true;
                oeffnerradioButton.Enabled = true;
                schliesserradioButton.Enabled = true;
                farbeschaltercomboBox.Enabled = false;

            }

        }

        private void schalterradioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (schalterradioButton1.Checked)
            {
                leuchtmeldergroupBox.Enabled = false;
                tastergroupBox.Enabled = true;
                oeffnerradioButton.Checked = false;
                schliesserradioButton.Checked = true;
                oeffnerradioButton.Enabled = false;
                schliesserradioButton.Enabled = false;
                farbeschaltercomboBox.Enabled = false;
            }

        }

        private void farbschalterradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (farbschalterradioButton.Checked)
            {
                farbeschaltercomboBox.Enabled = true;
                tastergroupBox.Enabled = true;
                oeffnerradioButton.Checked = false;
                schliesserradioButton.Checked = true;
                oeffnerradioButton.Enabled = false;
                schliesserradioButton.Enabled = false;

            }
        }


    }
}
