namespace Unfrosted.Forms
{
    partial class MainWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.mstMain = new System.Windows.Forms.MenuStrip();
            this.tsmiMain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewTransfer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReloadPool = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransfers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnectionDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.lsbPoolMembers = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mstMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mstMain
            // 
            this.mstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMain,
            this.tsmiReloadPool,
            this.tsmiTransfers,
            this.tsmiInfo});
            this.mstMain.Location = new System.Drawing.Point(0, 0);
            this.mstMain.Name = "mstMain";
            this.mstMain.Padding = new System.Windows.Forms.Padding(6);
            this.mstMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mstMain.Size = new System.Drawing.Size(784, 31);
            this.mstMain.TabIndex = 0;
            this.mstMain.Text = "menuStrip1";
            // 
            // tsmiMain
            // 
            this.tsmiMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewTransfer,
            this.toolStripSeparator2,
            this.tsmiSettings,
            this.toolStripSeparator1,
            this.tsmiClose});
            this.tsmiMain.Name = "tsmiMain";
            this.tsmiMain.Size = new System.Drawing.Size(70, 19);
            this.tsmiMain.Text = "unfrosted";
            // 
            // tsmiNewTransfer
            // 
            this.tsmiNewTransfer.Name = "tsmiNewTransfer";
            this.tsmiNewTransfer.Size = new System.Drawing.Size(143, 22);
            this.tsmiNewTransfer.Text = "New Transfer";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(143, 22);
            this.tsmiSettings.Text = "Settings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.Size = new System.Drawing.Size(143, 22);
            this.tsmiClose.Text = "Close";
            // 
            // tsmiReloadPool
            // 
            this.tsmiReloadPool.Name = "tsmiReloadPool";
            this.tsmiReloadPool.Size = new System.Drawing.Size(82, 19);
            this.tsmiReloadPool.Text = "Reload Pool";
            // 
            // tsmiTransfers
            // 
            this.tsmiTransfers.Name = "tsmiTransfers";
            this.tsmiTransfers.Size = new System.Drawing.Size(66, 19);
            this.tsmiTransfers.Text = "Transfers";
            // 
            // tsmiInfo
            // 
            this.tsmiInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnectionDetails,
            this.tsmiAbout});
            this.tsmiInfo.Name = "tsmiInfo";
            this.tsmiInfo.Size = new System.Drawing.Size(40, 19);
            this.tsmiInfo.Text = "Info";
            // 
            // tsmiConnectionDetails
            // 
            this.tsmiConnectionDetails.Name = "tsmiConnectionDetails";
            this.tsmiConnectionDetails.Size = new System.Drawing.Size(161, 22);
            this.tsmiConnectionDetails.Text = "Connection";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(161, 22);
            this.tsmiAbout.Text = "About unfrosted";
            // 
            // lsbPoolMembers
            // 
            this.lsbPoolMembers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lsbPoolMembers.FormattingEnabled = true;
            this.lsbPoolMembers.ItemHeight = 17;
            this.lsbPoolMembers.Location = new System.Drawing.Point(12, 102);
            this.lsbPoolMembers.Name = "lsbPoolMembers";
            this.lsbPoolMembers.Size = new System.Drawing.Size(240, 259);
            this.lsbPoolMembers.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lsbPoolMembers);
            this.Controls.Add(this.mstMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mstMain;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "unfrosted";
            this.mstMain.ResumeLayout(false);
            this.mstMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mstMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnectionDetails;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransfers;
        private System.Windows.Forms.ToolStripMenuItem tsmiReloadPool;
        private System.Windows.Forms.ListBox lsbPoolMembers;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewTransfer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button button1;
    }
}

