namespace WindowsFormsApplication1
{
    partial class Bedienelement
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bedienelement));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Eigenschaften = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eigenschaftenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.beschriftungslabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.Eigenschaften.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(10, 40);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // Eigenschaften
            // 
            this.Eigenschaften.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eigenschaftenToolStripMenuItem});
            this.Eigenschaften.Name = "Eigenschaften";
            this.Eigenschaften.Size = new System.Drawing.Size(143, 26);
            // 
            // eigenschaftenToolStripMenuItem
            // 
            this.eigenschaftenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eigenschaftenToolStripMenuItem.Image")));
            this.eigenschaftenToolStripMenuItem.Name = "eigenschaftenToolStripMenuItem";
            this.eigenschaftenToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.eigenschaftenToolStripMenuItem.Text = "Eigenschaften";
            this.eigenschaftenToolStripMenuItem.Click += new System.EventHandler(this.eigenschaftenToolStripMenuItem_Click_1);
            // 
            // beschriftungslabel
            // 
            this.beschriftungslabel.BackColor = System.Drawing.Color.Black;
            this.beschriftungslabel.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.beschriftungslabel.ForeColor = System.Drawing.Color.White;
            this.beschriftungslabel.Location = new System.Drawing.Point(0, 0);
            this.beschriftungslabel.Margin = new System.Windows.Forms.Padding(0);
            this.beschriftungslabel.MaximumSize = new System.Drawing.Size(53, 32);
            this.beschriftungslabel.MinimumSize = new System.Drawing.Size(53, 32);
            this.beschriftungslabel.Name = "beschriftungslabel";
            this.beschriftungslabel.Size = new System.Drawing.Size(53, 32);
            this.beschriftungslabel.TabIndex = 2;
            this.beschriftungslabel.Text = "Reserve\r\n\r\n";
            this.beschriftungslabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Bedienelement
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.Eigenschaften;
            this.Controls.Add(this.beschriftungslabel);
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Bedienelement";
            this.Size = new System.Drawing.Size(53, 78);
            this.toolTip1.SetToolTip(this, "Bedienelement");
            this.MouseEnter += new System.EventHandler(this.Bedienelement_MouseEnter);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.Eigenschaften.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ContextMenuStrip Eigenschaften;
        private System.Windows.Forms.ToolStripMenuItem eigenschaftenToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label beschriftungslabel;

    }
}
