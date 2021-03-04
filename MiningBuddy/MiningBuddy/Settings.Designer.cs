namespace MiningBuddy
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.HeadingBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TopMostCheckbox = new System.Windows.Forms.CheckBox();
            this.AddressTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PoolComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EmailTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SmtpTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SmtpPortTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BitvavoApiTextbox = new System.Windows.Forms.TextBox();
            this.BitvavoSecretTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.HeadingBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).BeginInit();
            this.SuspendLayout();
            // 
            // HeadingBar
            // 
            this.HeadingBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HeadingBar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.HeadingBar.Controls.Add(this.CloseButton);
            this.HeadingBar.Controls.Add(this.label1);
            this.HeadingBar.Location = new System.Drawing.Point(0, 0);
            this.HeadingBar.Name = "HeadingBar";
            this.HeadingBar.Size = new System.Drawing.Size(387, 53);
            this.HeadingBar.TabIndex = 0;
            this.HeadingBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HeadingBar_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Settings";
            // 
            // TopMostCheckbox
            // 
            this.TopMostCheckbox.AutoSize = true;
            this.TopMostCheckbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TopMostCheckbox.ForeColor = System.Drawing.SystemColors.Control;
            this.TopMostCheckbox.Location = new System.Drawing.Point(33, 464);
            this.TopMostCheckbox.Name = "TopMostCheckbox";
            this.TopMostCheckbox.Size = new System.Drawing.Size(200, 25);
            this.TopMostCheckbox.TabIndex = 8;
            this.TopMostCheckbox.Text = "Window always topmost";
            this.TopMostCheckbox.UseVisualStyleBackColor = true;
            // 
            // AddressTextbox
            // 
            this.AddressTextbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTextbox.Location = new System.Drawing.Point(37, 218);
            this.AddressTextbox.Name = "AddressTextbox";
            this.AddressTextbox.Size = new System.Drawing.Size(306, 22);
            this.AddressTextbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(33, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address";
            // 
            // PoolComboBox
            // 
            this.PoolComboBox.BackColor = System.Drawing.SystemColors.Control;
            this.PoolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PoolComboBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PoolComboBox.FormattingEnabled = true;
            this.PoolComboBox.Location = new System.Drawing.Point(38, 271);
            this.PoolComboBox.Name = "PoolComboBox";
            this.PoolComboBox.Size = new System.Drawing.Size(200, 21);
            this.PoolComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(35, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pool";
            // 
            // EmailTextbox
            // 
            this.EmailTextbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextbox.Location = new System.Drawing.Point(37, 93);
            this.EmailTextbox.Name = "EmailTextbox";
            this.EmailTextbox.Size = new System.Drawing.Size(306, 22);
            this.EmailTextbox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(34, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "SMTP";
            // 
            // SmtpTextbox
            // 
            this.SmtpTextbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmtpTextbox.Location = new System.Drawing.Point(37, 145);
            this.SmtpTextbox.Name = "SmtpTextbox";
            this.SmtpTextbox.Size = new System.Drawing.Size(201, 22);
            this.SmtpTextbox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(255, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Port";
            // 
            // SmtpPortTextbox
            // 
            this.SmtpPortTextbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SmtpPortTextbox.Location = new System.Drawing.Point(259, 145);
            this.SmtpPortTextbox.Name = "SmtpPortTextbox";
            this.SmtpPortTextbox.Size = new System.Drawing.Size(84, 22);
            this.SmtpPortTextbox.TabIndex = 3;
            this.SmtpPortTextbox.TextChanged += new System.EventHandler(this.SmtpPortTextbox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.panel1.Location = new System.Drawing.Point(10, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 101);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.panel2.Location = new System.Drawing.Point(10, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 101);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.panel3.Location = new System.Drawing.Point(10, 323);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 101);
            this.panel3.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(35, 374);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "Secret";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(33, 321);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "API";
            // 
            // BitvavoApiTextbox
            // 
            this.BitvavoApiTextbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BitvavoApiTextbox.Location = new System.Drawing.Point(37, 345);
            this.BitvavoApiTextbox.Name = "BitvavoApiTextbox";
            this.BitvavoApiTextbox.Size = new System.Drawing.Size(306, 22);
            this.BitvavoApiTextbox.TabIndex = 6;
            // 
            // BitvavoSecretTextbox
            // 
            this.BitvavoSecretTextbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BitvavoSecretTextbox.Location = new System.Drawing.Point(37, 398);
            this.BitvavoSecretTextbox.Multiline = true;
            this.BitvavoSecretTextbox.Name = "BitvavoSecretTextbox";
            this.BitvavoSecretTextbox.PasswordChar = '•';
            this.BitvavoSecretTextbox.Size = new System.Drawing.Size(306, 20);
            this.BitvavoSecretTextbox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(33, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 21);
            this.label8.TabIndex = 20;
            this.label8.Text = "Email";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.Image = global::MiningBuddy.Properties.Resources.close_button;
            this.CloseButton.Location = new System.Drawing.Point(338, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(35, 29);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CloseButton.TabIndex = 0;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(13)))), ((int)(((byte)(21)))));
            this.ClientSize = new System.Drawing.Size(386, 608);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BitvavoSecretTextbox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BitvavoApiTextbox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SmtpPortTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SmtpTextbox);
            this.Controls.Add(this.EmailTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PoolComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddressTextbox);
            this.Controls.Add(this.TopMostCheckbox);
            this.Controls.Add(this.HeadingBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.HeadingBar.ResumeLayout(false);
            this.HeadingBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CloseButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HeadingBar;
        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox TopMostCheckbox;
        private System.Windows.Forms.TextBox AddressTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PoolComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EmailTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SmtpTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SmtpPortTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox BitvavoApiTextbox;
        private System.Windows.Forms.TextBox BitvavoSecretTextbox;
        private System.Windows.Forms.Label label8;
    }
}