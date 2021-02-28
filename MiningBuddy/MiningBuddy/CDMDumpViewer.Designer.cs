
namespace MiningBuddy
{
    partial class CDMDumpViewer
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
            this.HtmlBrowser = new System.Windows.Forms.WebBrowser();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // HtmlBrowser
            // 
            this.HtmlBrowser.Location = new System.Drawing.Point(1, -1);
            this.HtmlBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.HtmlBrowser.Name = "HtmlBrowser";
            this.HtmlBrowser.Size = new System.Drawing.Size(619, 707);
            this.HtmlBrowser.TabIndex = 0;
            this.HtmlBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.HtmlBrowser_DocumentCompleted);
            // 
            // CloseButton
            // 
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Image = global::MiningBuddy.Properties.Resources.close_button;
            this.CloseButton.Location = new System.Drawing.Point(555, 10);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(31, 31);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 1;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CDMDumpViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(598, 707);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.HtmlBrowser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CDMDumpViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CDMDumpViewer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CDMDumpViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser HtmlBrowser;
        private System.Windows.Forms.PictureBox CloseButton;
    }
}