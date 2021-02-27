
namespace MiningBuddy
{
    partial class MiningBuddy
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
            this.EthAddressLabel = new System.Windows.Forms.Label();
            this.BitvavoStatusLabel = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // EthAddressLabel
            // 
            this.EthAddressLabel.AutoSize = true;
            this.EthAddressLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EthAddressLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.EthAddressLabel.Location = new System.Drawing.Point(12, 489);
            this.EthAddressLabel.Name = "EthAddressLabel";
            this.EthAddressLabel.Size = new System.Drawing.Size(104, 21);
            this.EthAddressLabel.TabIndex = 0;
            this.EthAddressLabel.Text = "ETH Address: ";
            // 
            // BitvavoStatusLabel
            // 
            this.BitvavoStatusLabel.AutoSize = true;
            this.BitvavoStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BitvavoStatusLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.BitvavoStatusLabel.Location = new System.Drawing.Point(13, 518);
            this.BitvavoStatusLabel.Name = "BitvavoStatusLabel";
            this.BitvavoStatusLabel.Size = new System.Drawing.Size(135, 15);
            this.BitvavoStatusLabel.TabIndex = 1;
            this.BitvavoStatusLabel.Text = "Bitvavo DISCONNECTED";
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeButton.Image = global::MiningBuddy.Properties.Resources.minimize_button;
            this.MinimizeButton.Location = new System.Drawing.Point(787, 24);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(32, 34);
            this.MinimizeButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MinimizeButton.TabIndex = 3;
            this.MinimizeButton.TabStop = false;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Image = global::MiningBuddy.Properties.Resources.close_button;
            this.CloseButton.Location = new System.Drawing.Point(836, 24);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(27, 24);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 2;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MiningBuddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(13)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(900, 548);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.BitvavoStatusLabel);
            this.Controls.Add(this.EthAddressLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiningBuddy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiningBuddy";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MiningBuddy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EthAddressLabel;
        private System.Windows.Forms.Label BitvavoStatusLabel;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox MinimizeButton;
    }
}

