namespace Stegotron
{
    partial class frm_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_main));
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.tipEncodeDecode = new System.Windows.Forms.ToolTip(this.components);
            this.lblDescription = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.lblTitleMain = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.TitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEncode
            // 
            this.btnEncode.AutoSize = true;
            this.btnEncode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEncode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEncode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.btnEncode.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGray;
            this.btnEncode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnEncode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnEncode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncode.ForeColor = System.Drawing.Color.Black;
            this.btnEncode.Location = new System.Drawing.Point(760, 660);
            this.btnEncode.Margin = new System.Windows.Forms.Padding(0);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(180, 48);
            this.btnEncode.TabIndex = 1;
            this.btnEncode.Text = "Encode";
            this.tipEncodeDecode.SetToolTip(this.btnEncode, "Click to slelect cover medium, message and password for\r\n Encoding the message in" +
        "to the cover medium\r\n\r\n");
            this.btnEncode.UseVisualStyleBackColor = false;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDecode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecode.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.btnDecode.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGray;
            this.btnDecode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnDecode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnDecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.ForeColor = System.Drawing.Color.Black;
            this.btnDecode.Location = new System.Drawing.Point(1018, 660);
            this.btnDecode.Margin = new System.Windows.Forms.Padding(0);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(180, 46);
            this.btnDecode.TabIndex = 2;
            this.btnDecode.Text = "Decode";
            this.tipEncodeDecode.SetToolTip(this.btnDecode, "Click to select the cover medium and enter the\r\npassword for decoding the message" +
        " from cover medium");
            this.btnDecode.UseVisualStyleBackColor = false;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDescription.Location = new System.Drawing.Point(93, 410);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.lblDescription.Size = new System.Drawing.Size(1150, 250);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = resources.GetString("lblDescription.Text");
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Image = global::Steg_Ref_Stack.Properties.Resources.Main_Logo;
            this.picLogo.Location = new System.Drawing.Point(543, 286);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(250, 150);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 5;
            this.picLogo.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.btnClose.Location = new System.Drawing.Point(1326, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 46);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.lblTitle.Location = new System.Drawing.Point(66, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(354, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Steganographic Reference Stack - Home";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.picIcon.Image = global::Steg_Ref_Stack.Properties.Resources.Logo;
            this.picIcon.Location = new System.Drawing.Point(0, 0);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(60, 46);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 2;
            this.picIcon.TabStop = false;
            // 
            // TitleBar
            // 
            this.TitleBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TitleBar.Controls.Add(this.picIcon);
            this.TitleBar.Controls.Add(this.lblTitle);
            this.TitleBar.Controls.Add(this.btnClose);
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Location = new System.Drawing.Point(0, 0);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(1366, 46);
            this.TitleBar.TabIndex = 3;
            // 
            // lblTitleMain
            // 
            this.lblTitleMain.AutoSize = true;
            this.lblTitleMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleMain.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTitleMain.Location = new System.Drawing.Point(173, 122);
            this.lblTitleMain.Name = "lblTitleMain";
            this.lblTitleMain.Size = new System.Drawing.Size(976, 73);
            this.lblTitleMain.TabIndex = 7;
            this.lblTitleMain.Text = "Steganographic Reference Stack";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 750);
            this.Controls.Add(this.lblTitleMain);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.TitleBar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frm_main";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STEGOTRON";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.ToolTip tipEncodeDecode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.Label lblTitleMain;
    }
}

