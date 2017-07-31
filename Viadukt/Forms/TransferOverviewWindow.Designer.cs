namespace Unfrosted.Forms
{
    partial class TransferOverviewWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.lblBytes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbProgress
            // 
            this.pgbProgress.Location = new System.Drawing.Point(12, 12);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(432, 23);
            this.pgbProgress.Step = 1;
            this.pgbProgress.TabIndex = 0;
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPercentage.Location = new System.Drawing.Point(8, 40);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(45, 19);
            this.lblPercentage.TabIndex = 1;
            this.lblPercentage.Text = "label1";
            // 
            // lblBytes
            // 
            this.lblBytes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBytes.Location = new System.Drawing.Point(322, 40);
            this.lblBytes.Name = "lblBytes";
            this.lblBytes.Size = new System.Drawing.Size(128, 19);
            this.lblBytes.TabIndex = 2;
            this.lblBytes.Text = "KB";
            this.lblBytes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TransferOverviewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(455, 68);
            this.Controls.Add(this.lblBytes);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.pgbProgress);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TransferOverviewWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Label lblBytes;
    }
}