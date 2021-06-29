namespace Stegotron
{
    partial class frm_decode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_decode));
            this.dlg_cover = new System.Windows.Forms.OpenFileDialog();
            this.tip_cover = new System.Windows.Forms.ToolTip(this.components);
            this.picCover = new System.Windows.Forms.PictureBox();
            this.picEditCover = new System.Windows.Forms.PictureBox();
            this.grpPasswd = new System.Windows.Forms.GroupBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.chkShowPwd = new System.Windows.Forms.CheckBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.grpCover = new System.Windows.Forms.GroupBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.lblExt = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEditCover)).BeginInit();
            this.grpPasswd.SuspendLayout();
            this.grpCover.SuspendLayout();
            this.panel1.SuspendLayout();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // dlg_cover
            // 
            this.dlg_cover.Filter = "Image Files (BMP, GIF, PNG)|*.bmp;*.gif;*.png|Audio Files (AIFF, WAV)|*.aif;*.aif" +
    "f;*.wav;*.wave";
            // 
            // picCover
            // 
            this.picCover.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCover.InitialImage = ((System.Drawing.Image)(resources.GetObject("picCover.InitialImage")));
            this.picCover.Location = new System.Drawing.Point(3, 41);
            this.picCover.Margin = new System.Windows.Forms.Padding(0);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(416, 267);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCover.TabIndex = 0;
            this.picCover.TabStop = false;
            this.tip_cover.SetToolTip(this.picCover, "Double Click to Select A File");
            this.picCover.DoubleClick += new System.EventHandler(this.picEditCover_Click);
            // 
            // picEditCover
            // 
            this.picEditCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picEditCover.BackColor = System.Drawing.SystemColors.Control;
            this.picEditCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEditCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEditCover.Image = ((System.Drawing.Image)(resources.GetObject("picEditCover.Image")));
            this.picEditCover.Location = new System.Drawing.Point(401, 292);
            this.picEditCover.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.picEditCover.Name = "picEditCover";
            this.picEditCover.Size = new System.Drawing.Size(21, 19);
            this.picEditCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEditCover.TabIndex = 2;
            this.picEditCover.TabStop = false;
            this.picEditCover.Click += new System.EventHandler(this.picEditCover_Click);
            // 
            // grpPasswd
            // 
            this.grpPasswd.Controls.Add(this.lblPwd);
            this.grpPasswd.Controls.Add(this.chkShowPwd);
            this.grpPasswd.Controls.Add(this.txtPwd);
            this.grpPasswd.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPasswd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpPasswd.Location = new System.Drawing.Point(45, 428);
            this.grpPasswd.Margin = new System.Windows.Forms.Padding(10);
            this.grpPasswd.Name = "grpPasswd";
            this.grpPasswd.Size = new System.Drawing.Size(1239, 200);
            this.grpPasswd.TabIndex = 17;
            this.grpPasswd.TabStop = false;
            this.grpPasswd.Text = "PASSWORD";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPwd.Location = new System.Drawing.Point(63, 74);
            this.lblPwd.Margin = new System.Windows.Forms.Padding(10);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(121, 20);
            this.lblPwd.TabIndex = 10;
            this.lblPwd.Text = "Enter Password";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShowPwd
            // 
            this.chkShowPwd.AutoSize = true;
            this.chkShowPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowPwd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkShowPwd.Location = new System.Drawing.Point(225, 132);
            this.chkShowPwd.Margin = new System.Windows.Forms.Padding(10);
            this.chkShowPwd.Name = "chkShowPwd";
            this.chkShowPwd.Size = new System.Drawing.Size(141, 24);
            this.chkShowPwd.TabIndex = 13;
            this.chkShowPwd.Text = "Show Password";
            this.chkShowPwd.UseVisualStyleBackColor = true;
            this.chkShowPwd.CheckedChanged += new System.EventHandler(this.chkShowPwd_CheckedChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPwd.Location = new System.Drawing.Point(225, 67);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(10);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '●';
            this.txtPwd.Size = new System.Drawing.Size(644, 30);
            this.txtPwd.TabIndex = 0;
            // 
            // grpCover
            // 
            this.grpCover.Controls.Add(this.picEditCover);
            this.grpCover.Controls.Add(this.picCover);
            this.grpCover.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCover.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpCover.Location = new System.Drawing.Point(45, 70);
            this.grpCover.Margin = new System.Windows.Forms.Padding(10);
            this.grpCover.Name = "grpCover";
            this.grpCover.Size = new System.Drawing.Size(422, 311);
            this.grpCover.TabIndex = 16;
            this.grpCover.TabStop = false;
            this.grpCover.Text = "STEGO MEDIUM";
            // 
            // btnDecode
            // 
            this.btnDecode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDecode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.btnDecode.Location = new System.Drawing.Point(1086, 666);
            this.btnDecode.Margin = new System.Windows.Forms.Padding(10);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(198, 49);
            this.btnDecode.TabIndex = 9;
            this.btnDecode.Text = "DECODE";
            this.btnDecode.UseVisualStyleBackColor = false;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.btnBack.Location = new System.Drawing.Point(847, 666);
            this.btnBack.Margin = new System.Windows.Forms.Padding(10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(188, 49);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Enabled = false;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(701, 111);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(583, 22);
            this.txtName.TabIndex = 3;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPath.Location = new System.Drawing.Point(600, 342);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(50, 20);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "Path :";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExt
            // 
            this.lblExt.AutoSize = true;
            this.lblExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExt.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblExt.Location = new System.Drawing.Point(600, 264);
            this.lblExt.Name = "lblExt";
            this.lblExt.Size = new System.Drawing.Size(87, 20);
            this.lblExt.TabIndex = 2;
            this.lblExt.Text = "Extension :";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSize.Location = new System.Drawing.Point(598, 185);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(48, 20);
            this.lblSize.TabIndex = 1;
            this.lblSize.Text = "Size :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblName.Location = new System.Drawing.Point(598, 111);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 20);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name :";
            // 
            // txtSize
            // 
            this.txtSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSize.Enabled = false;
            this.txtSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSize.Location = new System.Drawing.Point(701, 185);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(583, 22);
            this.txtSize.TabIndex = 8;
            // 
            // txtExt
            // 
            this.txtExt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExt.Enabled = false;
            this.txtExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExt.Location = new System.Drawing.Point(703, 264);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(581, 22);
            this.txtExt.TabIndex = 9;
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath.Enabled = false;
            this.txtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPath.Location = new System.Drawing.Point(703, 342);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(581, 22);
            this.txtPath.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.panel1.Controls.Add(this.TitleBar);
            this.panel1.Controls.Add(this.btnDecode);
            this.panel1.Controls.Add(this.lblPath);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.grpPasswd);
            this.panel1.Controls.Add(this.lblExt);
            this.panel1.Controls.Add(this.grpCover);
            this.panel1.Controls.Add(this.txtExt);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.txtPath);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.lblSize);
            this.panel1.Controls.Add(this.txtSize);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1336, 768);
            this.panel1.TabIndex = 19;
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
            this.TitleBar.Size = new System.Drawing.Size(1336, 46);
            this.TitleBar.TabIndex = 18;
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.Color.Transparent;
            this.picIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picIcon.Image = global::Steg_Ref_Stack.Properties.Resources.Logo;
            this.picIcon.Location = new System.Drawing.Point(0, -1);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(60, 47);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 2;
            this.picIcon.TabStop = false;
            this.picIcon.Click += new System.EventHandler(this.picIcon_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(71)))), ((int)(((byte)(71)))));
            this.lblTitle.Location = new System.Drawing.Point(66, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(174, 24);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Steganographic Reference Stack - Decode";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnClose.Location = new System.Drawing.Point(1295, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(41, 46);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frm_decode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1336, 768);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_decode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DECODE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEditCover)).EndInit();
            this.grpPasswd.ResumeLayout(false);
            this.grpPasswd.PerformLayout();
            this.grpCover.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog dlg_cover;
        private System.Windows.Forms.ToolTip tip_cover;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.PictureBox picEditCover;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.GroupBox grpCover;
        private System.Windows.Forms.GroupBox grpPasswd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.CheckBox chkShowPwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label lblExt;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtExt;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
    }
}