using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    partial class Basic2dObject
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Basic2dObject));
            this.Eigenschaften = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eigenschaftenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Eigenschaften.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Eigenschaften
            // 
            this.Eigenschaften.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eigenschaftenToolStripMenuItem});
            this.Eigenschaften.Name = "Eigenschaften";
            this.Eigenschaften.Size = new System.Drawing.Size(153, 48);
            // 
            // eigenschaftenToolStripMenuItem
            // 
            this.eigenschaftenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eigenschaftenToolStripMenuItem.Image")));
            this.eigenschaftenToolStripMenuItem.Name = "eigenschaftenToolStripMenuItem";
            this.eigenschaftenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eigenschaftenToolStripMenuItem.Text = "Eigenschaften";
            this.eigenschaftenToolStripMenuItem.Click += new System.EventHandler(this.eigenschaftenToolStripMenuItem_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.ContextMenuStrip = this.Eigenschaften;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(10, 10);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseEnter += new System.EventHandler(this.pictureBox_MouseEnter);
            // 
            // Basic2dObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Basic2dObject";
            this.Size = new System.Drawing.Size(10, 24);
            this.Eigenschaften.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ContextMenuStrip Eigenschaften;
        private System.Windows.Forms.ToolStripMenuItem eigenschaftenToolStripMenuItem;
        public System.Windows.Forms.PictureBox pictureBox;
        public ToolTip toolTip1;

        
    }
}
