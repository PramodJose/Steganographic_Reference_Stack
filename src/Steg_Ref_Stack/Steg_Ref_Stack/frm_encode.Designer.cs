namespace Steg_Ref_Stack
{
    partial class frm_encode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_encode));
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.grpCover = new System.Windows.Forms.GroupBox();
            this.picEditCover = new System.Windows.Forms.PictureBox();
            this.picCover = new System.Windows.Forms.PictureBox();
            this.grpMsg = new System.Windows.Forms.GroupBox();
            this.lblMsgFileName = new System.Windows.Forms.TextBox();
            this.picEditMsg = new System.Windows.Forms.PictureBox();
            this.picMsgFileIcon = new System.Windows.Forms.PictureBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.grpPasswd = new System.Windows.Forms.GroupBox();
            this.lblPwd = new System.Windows.Forms.Label();
            this.chkPwd = new System.Windows.Forms.CheckBox();
            this.lblRePwd = new System.Windows.Forms.Label();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.tipEncode = new System.Windows.Forms.ToolTip(this.components);
            this.dlgCover = new System.Windows.Forms.OpenFileDialog();
            this.dlgMsg = new System.Windows.Forms.OpenFileDialog();
            this.TitleBar = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.grpMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditMsg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMsgFileIcon)).BeginInit();
            this.grpPasswd.SuspendLayout();
            this.TitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(823, 661);
            this.btnBack.Margin = new System.Windows.Forms.Padding(10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(198, 46);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEncode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEncode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEncode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncode.Location = new System.Drawing.Point(1062, 661);
            this.btnEncode.Margin = new System.Windows.Forms.Padding(10);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(181, 46);
            this.btnEncode.TabIndex = 9;
            this.btnEncode.Text = "ENCODE";
            this.btnEncode.UseVisualStyleBackColor = false;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // grpCover
            // 
            this.grpCover.BackColor = System.Drawing.Color.Transparent;
            this.grpCover.Controls.Add(this.picEditCover);
            this.grpCover.Controls.Add(this.picCover);
            this.grpCover.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCover.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpCover.Location = new System.Drawing.Point(71, 76);
            this.grpCover.Margin = new System.Windows.Forms.Padding(10);
            this.grpCover.Name = "grpCover";
            this.grpCover.Padding = new System.Windows.Forms.Padding(10);
            this.grpCover.Size = new System.Drawing.Size(482, 350);
            this.grpCover.TabIndex = 14;
            this.grpCover.TabStop = false;
            this.grpCover.Text = "COVER MEDIUM";
            this.tipEncode.SetToolTip(this.grpCover, "Double Click to Select A File");
            // 
            // picEditCover
            // 
            this.picEditCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picEditCover.BackColor = System.Drawing.SystemColors.Control;
            this.picEditCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEditCover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEditCover.Image = ((System.Drawing.Image)(resources.GetObject("picEditCover.Image")));
            this.picEditCover.Location = new System.Drawing.Point(465, 330);
            this.picEditCover.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.picEditCover.Name = "picEditCover";
            this.picEditCover.Size = new System.Drawing.Size(17, 20);
            this.picEditCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEditCover.TabIndex = 2;
            this.picEditCover.TabStop = false;
            this.picEditCover.Click += new System.EventHandler(this.picEditCover_Click);
            // 
            // picCover
            // 
            this.picCover.BackColor = System.Drawing.Color.Transparent;
            this.picCover.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCover.InitialImage = null;
            this.picCover.Location = new System.Drawing.Point(10, 48);
            this.picCover.Margin = new System.Windows.Forms.Padding(10);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(462, 292);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCover.TabIndex = 0;
            this.picCover.TabStop = false;
            this.picCover.DoubleClick += new System.EventHandler(this.picEditCover_Click);
            // 
            // grpMsg
            // 
            this.grpMsg.BackColor = System.Drawing.Color.Transparent;
            this.grpMsg.Controls.Add(this.lblMsgFileName);
            this.grpMsg.Controls.Add(this.picEditMsg);
            this.grpMsg.Controls.Add(this.picMsgFileIcon);
            this.grpMsg.Controls.Add(this.txtMsg);
            this.grpMsg.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMsg.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpMsg.Location = new System.Drawing.Point(633, 76);
            this.grpMsg.Margin = new System.Windows.Forms.Padding(10);
            this.grpMsg.Name = "grpMsg";
            this.grpMsg.Padding = new System.Windows.Forms.Padding(10);
            this.grpMsg.Size = new System.Drawing.Size(609, 350);
            this.grpMsg.TabIndex = 15;
            this.grpMsg.TabStop = false;
            this.grpMsg.Text = "MESSAGE";
            this.tipEncode.SetToolTip(this.grpMsg, "Double Click to Select A File");
            // 
            // lblMsgFileName
            // 
            this.lblMsgFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMsgFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.lblMsgFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMsgFileName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMsgFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsgFileName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMsgFileName.Location = new System.Drawing.Point(195, 137);
            this.lblMsgFileName.Multiline = true;
            this.lblMsgFileName.Name = "lblMsgFileName";
            this.lblMsgFileName.ReadOnly = true;
            this.lblMsgFileName.Size = new System.Drawing.Size(386, 86);
            this.lblMsgFileName.TabIndex = 6;
            this.lblMsgFileName.Visible = false;
            // 
            // picEditMsg
            // 
            this.picEditMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picEditMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picEditMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEditMsg.Image = ((System.Drawing.Image)(resources.GetObject("picEditMsg.Image")));
            this.picEditMsg.Location = new System.Drawing.Point(580, 323);
            this.picEditMsg.Margin = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.picEditMsg.Name = "picEditMsg";
            this.picEditMsg.Size = new System.Drawing.Size(19, 17);
            this.picEditMsg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picEditMsg.TabIndex = 3;
            this.picEditMsg.TabStop = false;
            this.picEditMsg.Click += new System.EventHandler(this.picEditMsg_Click);
            // 
            // picMsgFileIcon
            // 
            this.picMsgFileIcon.BackColor = System.Drawing.Color.Transparent;
            this.picMsgFileIcon.Location = new System.Drawing.Point(29, 106);
            this.picMsgFileIcon.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.picMsgFileIcon.Name = "picMsgFileIcon";
            this.picMsgFileIcon.Size = new System.Drawing.Size(158, 161);
            this.picMsgFileIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMsgFileIcon.TabIndex = 5;
            this.picMsgFileIcon.TabStop = false;
            this.picMsgFileIcon.Visible = false;
            // 
            // txtMsg
            // 
            this.txtMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMsg.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(10, 48);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(10);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(589, 292);
            this.txtMsg.TabIndex = 4;
            this.txtMsg.DoubleClick += new System.EventHandler(this.picEditMsg_Click);
            // 
            // grpPasswd
            // 
            this.grpPasswd.BackColor = System.Drawing.Color.Transparent;
            this.grpPasswd.Controls.Add(this.lblPwd);
            this.grpPasswd.Controls.Add(this.chkPwd);
            this.grpPasswd.Controls.Add(this.lblRePwd);
            this.grpPasswd.Controls.Add(this.txtConfirmPwd);
            this.grpPasswd.Controls.Add(this.txtPwd);
            this.grpPasswd.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPasswd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.grpPasswd.Location = new System.Drawing.Point(71, 446);
            this.grpPasswd.Name = "grpPasswd";
            this.grpPasswd.Size = new System.Drawing.Size(1171, 184);
            this.grpPasswd.TabIndex = 16;
            this.grpPasswd.TabStop = false;
            this.grpPasswd.Text = "PASSWORD";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPwd.Location = new System.Drawing.Point(58, 57);
            this.lblPwd.Margin = new System.Windows.Forms.Padding(10);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(121, 20);
            this.lblPwd.TabIndex = 10;
            this.lblPwd.Text = "Enter Password";
            this.lblPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPwd
            // 
            this.chkPwd.AutoSize = true;
            this.chkPwd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkPwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPwd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.chkPwd.Location = new System.Drawing.Point(834, 52);
            this.chkPwd.Margin = new System.Windows.Forms.Padding(10);
            this.chkPwd.Name = "chkPwd";
            this.chkPwd.Size = new System.Drawing.Size(141, 24);
            this.chkPwd.TabIndex = 13;
            this.chkPwd.Text = "Show Password";
            this.chkPwd.UseVisualStyleBackColor = true;
            this.chkPwd.CheckedChanged += new System.EventHandler(this.chkPwd_CheckedChanged);
            // 
            // lblRePwd
            // 
            this.lblRePwd.AutoSize = true;
            this.lblRePwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRePwd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblRePwd.Location = new System.Drawing.Point(36, 128);
            this.lblRePwd.Margin = new System.Windows.Forms.Padding(10);
            this.lblRePwd.Name = "lblRePwd";
            this.lblRePwd.Size = new System.Drawing.Size(147, 20);
            this.lblRePwd.TabIndex = 11;
            this.lblRePwd.Text = "Re-Enter Password";
            this.lblRePwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPwd.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPwd.Location = new System.Drawing.Point(185, 120);
            this.txtConfirmPwd.Margin = new System.Windows.Forms.Padding(10);
            this.txtConfirmPwd.MaxLength = 32;
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.PasswordChar = '●';
            this.txtConfirmPwd.Size = new System.Drawing.Size(582, 34);
            this.txtConfirmPwd.TabIndex = 1;
            this.tipEncode.SetToolTip(this.txtConfirmPwd, "Use AlphaNumeri Characters");
            // 
            // txtPwd
            // 
            this.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPwd.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPwd.Location = new System.Drawing.Point(185, 46);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(10);
            this.txtPwd.MaxLength = 32;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(582, 34);
            this.txtPwd.TabIndex = 0;
            this.tipEncode.SetToolTip(this.txtPwd, "Use AlphaNumeric Characters");
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // dlgCover
            // 
            this.dlgCover.Filter = "Image Files (BMP, GIF, PNG)|*.bmp;*.gif;*.png|Audio Files (AIFF, WAV)|*.aif;*.aif" +
    "f;*.wav;*.wave";
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
            this.TitleBar.Size = new System.Drawing.Size(1320, 46);
            this.TitleBar.TabIndex = 17;
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
            this.lblTitle.Text = "Steganographic Reference Stack - Encode";
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
            this.btnClose.Location = new System.Drawing.Point(1279, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(41, 46);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frm_encode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1320, 730);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.grpCover);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpMsg);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.grpPasswd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frm_encode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpCover.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEditCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.grpMsg.ResumeLayout(false);
            this.grpMsg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEditMsg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMsgFileIcon)).EndInit();
            this.grpPasswd.ResumeLayout(false);
            this.grpPasswd.PerformLayout();
            this.TitleBar.ResumeLayout(false);
            this.TitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipEncode;
        private System.Windows.Forms.PictureBox picEditCover;
        private System.Windows.Forms.PictureBox picEditMsg;
        protected System.Windows.Forms.TextBox txtMsg;
        protected System.Windows.Forms.OpenFileDialog dlgCover;
        private System.Windows.Forms.OpenFileDialog dlgMsg;
        private System.Windows.Forms.PictureBox picMsgFileIcon;
        private System.Windows.Forms.Label lblRePwd;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.CheckBox chkPwd;
        private System.Windows.Forms.GroupBox grpCover;
        private System.Windows.Forms.GroupBox grpMsg;
        private System.Windows.Forms.GroupBox grpPasswd;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox lblMsgFileName;
        private System.Windows.Forms.Panel TitleBar;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
    }
}