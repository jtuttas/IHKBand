namespace WindowsFormsApplication1
{
    partial class EigenschaftenBedienelemente
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.leuchtmeldergroupBox = new System.Windows.Forms.GroupBox();
            this.farbecomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LeuchtmelderAdrtextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tastergroupBox = new System.Windows.Forms.GroupBox();
            this.oeffnerradioButton = new System.Windows.Forms.RadioButton();
            this.schliesserradioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tastertastetextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tasterAdrtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.abbrechenbutton = new System.Windows.Forms.Button();
            this.obbutton = new System.Windows.Forms.Button();
            this.beschriftungtextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.farbeschaltercomboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.farbschalterradioButton = new System.Windows.Forms.RadioButton();
            this.schalterradioButton1 = new System.Windows.Forms.RadioButton();
            this.tasterradioButton = new System.Windows.Forms.RadioButton();
            this.leuchttasterradioButton = new System.Windows.Forms.RadioButton();
            this.leuchtmlederradioButton = new System.Windows.Forms.RadioButton();
            this.blindelementradioButton = new System.Windows.Forms.RadioButton();
            this.notuuscheckBox = new System.Windows.Forms.CheckBox();
            this.leuchtmeldergroupBox.SuspendLayout();
            this.tastergroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leuchtmeldergroupBox
            // 
            this.leuchtmeldergroupBox.Controls.Add(this.farbecomboBox);
            this.leuchtmeldergroupBox.Controls.Add(this.label2);
            this.leuchtmeldergroupBox.Controls.Add(this.LeuchtmelderAdrtextBox);
            this.leuchtmeldergroupBox.Controls.Add(this.label1);
            this.leuchtmeldergroupBox.Enabled = false;
            this.leuchtmeldergroupBox.Location = new System.Drawing.Point(13, 229);
            this.leuchtmeldergroupBox.Name = "leuchtmeldergroupBox";
            this.leuchtmeldergroupBox.Size = new System.Drawing.Size(331, 63);
            this.leuchtmeldergroupBox.TabIndex = 3;
            this.leuchtmeldergroupBox.TabStop = false;
            this.leuchtmeldergroupBox.Text = "Leuchtmelder";
            // 
            // farbecomboBox
            // 
            this.farbecomboBox.FormattingEnabled = true;
            this.farbecomboBox.Items.AddRange(new object[] {
            "weiß",
            "rot",
            "gelb",
            "grün",
            "blau"});
            this.farbecomboBox.Location = new System.Drawing.Point(212, 27);
            this.farbecomboBox.Name = "farbecomboBox";
            this.farbecomboBox.Size = new System.Drawing.Size(52, 21);
            this.farbecomboBox.TabIndex = 3;
            this.farbecomboBox.Text = "weiß";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Farbe:";
            // 
            // LeuchtmelderAdrtextBox
            // 
            this.LeuchtmelderAdrtextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.LeuchtmelderAdrtextBox.Location = new System.Drawing.Point(98, 27);
            this.LeuchtmelderAdrtextBox.Name = "LeuchtmelderAdrtextBox";
            this.LeuchtmelderAdrtextBox.Size = new System.Drawing.Size(52, 20);
            this.LeuchtmelderAdrtextBox.TabIndex = 1;
            this.LeuchtmelderAdrtextBox.Text = "A1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SPS Ausgang:";
            // 
            // tastergroupBox
            // 
            this.tastergroupBox.Controls.Add(this.notuuscheckBox);
            this.tastergroupBox.Controls.Add(this.oeffnerradioButton);
            this.tastergroupBox.Controls.Add(this.schliesserradioButton);
            this.tastergroupBox.Controls.Add(this.label5);
            this.tastergroupBox.Controls.Add(this.tastertastetextBox);
            this.tastergroupBox.Controls.Add(this.label4);
            this.tastergroupBox.Controls.Add(this.tasterAdrtextBox);
            this.tastergroupBox.Controls.Add(this.label3);
            this.tastergroupBox.Enabled = false;
            this.tastergroupBox.Location = new System.Drawing.Point(13, 298);
            this.tastergroupBox.Name = "tastergroupBox";
            this.tastergroupBox.Size = new System.Drawing.Size(327, 111);
            this.tastergroupBox.TabIndex = 4;
            this.tastergroupBox.TabStop = false;
            this.tastergroupBox.Text = "Taster / Schalter";
            // 
            // oeffnerradioButton
            // 
            this.oeffnerradioButton.AutoSize = true;
            this.oeffnerradioButton.Location = new System.Drawing.Point(208, 81);
            this.oeffnerradioButton.Name = "oeffnerradioButton";
            this.oeffnerradioButton.Size = new System.Drawing.Size(54, 17);
            this.oeffnerradioButton.TabIndex = 7;
            this.oeffnerradioButton.Text = "Öffner";
            this.oeffnerradioButton.UseVisualStyleBackColor = true;
            // 
            // schliesserradioButton
            // 
            this.schliesserradioButton.AutoSize = true;
            this.schliesserradioButton.Checked = true;
            this.schliesserradioButton.Location = new System.Drawing.Point(208, 58);
            this.schliesserradioButton.Name = "schliesserradioButton";
            this.schliesserradioButton.Size = new System.Drawing.Size(69, 17);
            this.schliesserradioButton.TabIndex = 6;
            this.schliesserradioButton.TabStop = true;
            this.schliesserradioButton.Text = "Schließer";
            this.schliesserradioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Type:";
            // 
            // tastertastetextBox
            // 
            this.tastertastetextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tastertastetextBox.Location = new System.Drawing.Point(95, 85);
            this.tastertastetextBox.Name = "tastertastetextBox";
            this.tastertastetextBox.Size = new System.Drawing.Size(54, 20);
            this.tastertastetextBox.TabIndex = 4;
            this.tastertastetextBox.Text = "A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Taste:";
            // 
            // tasterAdrtextBox
            // 
            this.tasterAdrtextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tasterAdrtextBox.Location = new System.Drawing.Point(95, 59);
            this.tasterAdrtextBox.Name = "tasterAdrtextBox";
            this.tasterAdrtextBox.Size = new System.Drawing.Size(54, 20);
            this.tasterAdrtextBox.TabIndex = 2;
            this.tasterAdrtextBox.Text = "A1.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SPS Eingang:";
            // 
            // abbrechenbutton
            // 
            this.abbrechenbutton.Location = new System.Drawing.Point(268, 429);
            this.abbrechenbutton.Name = "abbrechenbutton";
            this.abbrechenbutton.Size = new System.Drawing.Size(75, 23);
            this.abbrechenbutton.TabIndex = 5;
            this.abbrechenbutton.Text = "Abbrechen";
            this.abbrechenbutton.UseVisualStyleBackColor = true;
            this.abbrechenbutton.Click += new System.EventHandler(this.abbrechenbutton_Click);
            // 
            // obbutton
            // 
            this.obbutton.Location = new System.Drawing.Point(12, 429);
            this.obbutton.Name = "obbutton";
            this.obbutton.Size = new System.Drawing.Size(75, 23);
            this.obbutton.TabIndex = 6;
            this.obbutton.Text = "OK";
            this.obbutton.UseVisualStyleBackColor = true;
            this.obbutton.Click += new System.EventHandler(this.obbutton_Click);
            // 
            // beschriftungtextBox
            // 
            this.beschriftungtextBox.Location = new System.Drawing.Point(256, 53);
            this.beschriftungtextBox.Multiline = true;
            this.beschriftungtextBox.Name = "beschriftungtextBox";
            this.beschriftungtextBox.Size = new System.Drawing.Size(79, 50);
            this.beschriftungtextBox.TabIndex = 7;
            this.beschriftungtextBox.Text = "Reserve";
            this.beschriftungtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(253, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Beschriftung";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Name";
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(51, 6);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(284, 20);
            this.textBoxname.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.farbeschaltercomboBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.farbschalterradioButton);
            this.groupBox1.Controls.Add(this.schalterradioButton1);
            this.groupBox1.Controls.Add(this.tasterradioButton);
            this.groupBox1.Controls.Add(this.leuchttasterradioButton);
            this.groupBox1.Controls.Add(this.leuchtmlederradioButton);
            this.groupBox1.Controls.Add(this.blindelementradioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 181);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // farbeschaltercomboBox
            // 
            this.farbeschaltercomboBox.Enabled = false;
            this.farbeschaltercomboBox.FormattingEnabled = true;
            this.farbeschaltercomboBox.Items.AddRange(new object[] {
            "weiß",
            "rot",
            "gelb",
            "grün"});
            this.farbeschaltercomboBox.Location = new System.Drawing.Point(150, 152);
            this.farbeschaltercomboBox.Name = "farbeschaltercomboBox";
            this.farbeschaltercomboBox.Size = new System.Drawing.Size(52, 21);
            this.farbeschaltercomboBox.TabIndex = 12;
            this.farbeschaltercomboBox.Text = "weiß";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(112, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Farbe:";
            // 
            // farbschalterradioButton
            // 
            this.farbschalterradioButton.AutoSize = true;
            this.farbschalterradioButton.Location = new System.Drawing.Point(19, 153);
            this.farbschalterradioButton.Name = "farbschalterradioButton";
            this.farbschalterradioButton.Size = new System.Drawing.Size(64, 17);
            this.farbschalterradioButton.TabIndex = 10;
            this.farbschalterradioButton.Text = "Schalter";
            this.farbschalterradioButton.UseVisualStyleBackColor = true;
            this.farbschalterradioButton.CheckedChanged += new System.EventHandler(this.farbschalterradioButton_CheckedChanged);
            // 
            // schalterradioButton1
            // 
            this.schalterradioButton1.AutoSize = true;
            this.schalterradioButton1.Location = new System.Drawing.Point(19, 130);
            this.schalterradioButton1.Name = "schalterradioButton1";
            this.schalterradioButton1.Size = new System.Drawing.Size(83, 17);
            this.schalterradioButton1.TabIndex = 9;
            this.schalterradioButton1.Text = "Kippschalter";
            this.schalterradioButton1.UseVisualStyleBackColor = true;
            this.schalterradioButton1.CheckedChanged += new System.EventHandler(this.schalterradioButton1_CheckedChanged);
            // 
            // tasterradioButton
            // 
            this.tasterradioButton.AutoSize = true;
            this.tasterradioButton.Location = new System.Drawing.Point(19, 107);
            this.tasterradioButton.Name = "tasterradioButton";
            this.tasterradioButton.Size = new System.Drawing.Size(55, 17);
            this.tasterradioButton.TabIndex = 8;
            this.tasterradioButton.Text = "Taster";
            this.tasterradioButton.UseVisualStyleBackColor = true;
            this.tasterradioButton.CheckedChanged += new System.EventHandler(this.tasterradioButton_CheckedChanged);
            // 
            // leuchttasterradioButton
            // 
            this.leuchttasterradioButton.AutoSize = true;
            this.leuchttasterradioButton.Location = new System.Drawing.Point(19, 84);
            this.leuchttasterradioButton.Name = "leuchttasterradioButton";
            this.leuchttasterradioButton.Size = new System.Drawing.Size(84, 17);
            this.leuchttasterradioButton.TabIndex = 7;
            this.leuchttasterradioButton.Text = "Leuchttaster";
            this.leuchttasterradioButton.UseVisualStyleBackColor = true;
            this.leuchttasterradioButton.CheckedChanged += new System.EventHandler(this.leuchttasterradioButton_CheckedChanged);
            // 
            // leuchtmlederradioButton
            // 
            this.leuchtmlederradioButton.AutoSize = true;
            this.leuchtmlederradioButton.Location = new System.Drawing.Point(19, 61);
            this.leuchtmlederradioButton.Name = "leuchtmlederradioButton";
            this.leuchtmlederradioButton.Size = new System.Drawing.Size(89, 17);
            this.leuchtmlederradioButton.TabIndex = 6;
            this.leuchtmlederradioButton.Text = "Leuchtmelder";
            this.leuchtmlederradioButton.UseVisualStyleBackColor = true;
            this.leuchtmlederradioButton.CheckedChanged += new System.EventHandler(this.leuchtmlederradioButton_CheckedChanged);
            // 
            // blindelementradioButton
            // 
            this.blindelementradioButton.AutoSize = true;
            this.blindelementradioButton.Checked = true;
            this.blindelementradioButton.Location = new System.Drawing.Point(19, 38);
            this.blindelementradioButton.Name = "blindelementradioButton";
            this.blindelementradioButton.Size = new System.Drawing.Size(85, 17);
            this.blindelementradioButton.TabIndex = 5;
            this.blindelementradioButton.TabStop = true;
            this.blindelementradioButton.Text = "Blindelement";
            this.blindelementradioButton.UseVisualStyleBackColor = true;
            this.blindelementradioButton.CheckedChanged += new System.EventHandler(this.blindelementradioButton_CheckedChanged);
            // 
            // notuuscheckBox
            // 
            this.notuuscheckBox.AutoSize = true;
            this.notuuscheckBox.Location = new System.Drawing.Point(19, 19);
            this.notuuscheckBox.Name = "notuuscheckBox";
            this.notuuscheckBox.Size = new System.Drawing.Size(128, 17);
            this.notuuscheckBox.TabIndex = 8;
            this.notuuscheckBox.Text = "NotAus vorgeschaltet";
            this.notuuscheckBox.UseVisualStyleBackColor = true;
            // 
            // EigenschaftenBedienelemente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.beschriftungtextBox);
            this.Controls.Add(this.obbutton);
            this.Controls.Add(this.abbrechenbutton);
            this.Controls.Add(this.tastergroupBox);
            this.Controls.Add(this.leuchtmeldergroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EigenschaftenBedienelemente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EigenschaftenBedienelemente";
            this.leuchtmeldergroupBox.ResumeLayout(false);
            this.leuchtmeldergroupBox.PerformLayout();
            this.tastergroupBox.ResumeLayout(false);
            this.tastergroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox leuchtmeldergroupBox;
        private System.Windows.Forms.ComboBox farbecomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LeuchtmelderAdrtextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox tastergroupBox;
        private System.Windows.Forms.RadioButton oeffnerradioButton;
        private System.Windows.Forms.RadioButton schliesserradioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tastertastetextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tasterAdrtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button abbrechenbutton;
        private System.Windows.Forms.Button obbutton;
        private System.Windows.Forms.TextBox beschriftungtextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton schalterradioButton1;
        private System.Windows.Forms.RadioButton tasterradioButton;
        private System.Windows.Forms.RadioButton leuchttasterradioButton;
        private System.Windows.Forms.RadioButton leuchtmlederradioButton;
        private System.Windows.Forms.RadioButton blindelementradioButton;
        private System.Windows.Forms.ComboBox farbeschaltercomboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton farbschalterradioButton;
        private System.Windows.Forms.CheckBox notuuscheckBox;
    }
}