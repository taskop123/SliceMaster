namespace SliceMaster
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelPoints = new System.Windows.Forms.ToolStripLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripLabelMisses = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelPoints,
            this.toolStripLabelMisses});
            this.toolStrip1.Location = new System.Drawing.Point(0, 436);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(884, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelPoints
            // 
            this.toolStripLabelPoints.Name = "toolStripLabelPoints";
            this.toolStripLabelPoints.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabelPoints.Text = "Points: 0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.BackgroundImage = global::SliceMaster.Properties.Resources.background;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(62, 25);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripLabelMisses
            // 
            this.toolStripLabelMisses.Name = "toolStripLabelMisses";
            this.toolStripLabelMisses.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripLabelMisses.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabelMisses.Text = "Misses: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SliceMaster.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "SliceMaster";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelPoints;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelMisses;
        //       private System.Windows.Forms.Timer timer1;
    }
}

