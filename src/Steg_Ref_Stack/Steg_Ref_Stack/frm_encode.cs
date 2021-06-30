using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using FrontEnd;
using Constants;
using EnDecode;

namespace Steg_Ref_Stack
{
    public partial class frm_encode : Form
    {
        Validation validate = new Validation();
        public frm_encode()
        {
            InitializeComponent();
        }

        private void picIcon_Click(object sender, EventArgs e)
        {
            //Click the Application Icon will take the user to home screen.
            Program.nextFormId = FormId.frm_main;
            Close();
        }
        
        private void picEditCover_Click(object sender, EventArgs e)
        {
            if (dlgCover.ShowDialog() == DialogResult.OK)
            {
                Icon fileicon = Icon.ExtractAssociatedIcon(dlgCover.FileName);
                string extension = Path.GetExtension(dlgCover.FileName);
                if (validate.CheckFile(dlgCover.FileName) == true)
                {
                    picCover.Image = null;
                    if (extension == ".png" || extension == ".gif" || extension == ".bmp")
                    {
                        using (FileStream fs = new FileStream(dlgCover.FileName, FileMode.Open))
                            picCover.Image = Image.FromStream(fs);
                    }
                    else
                        picCover.Image = fileicon.ToBitmap();
                }
}                          //UDF to manage the form after cover file selection.
        }

        private void picEditMsg_Click(object sender, EventArgs e)
        {
            if (dlgMsg.ShowDialog() == DialogResult.OK)
            {
                //Checks if the message file seected is a text file.
                if (Path.GetExtension(dlgMsg.FileName) == ".txt")
                {
                    txtMsg.Visible = true;
                    //Adds the content of the text file selected to the TextBox.
                    txtMsg.Text = File.ReadAllText(dlgMsg.FileName);
                    picMsgFileIcon.Visible = false;
                    lblMsgFileName.Visible = false;
                }
                else
                {
                    FormManager formManager = new FormManager();
                    txtMsg.Text = string.Empty;
                    txtMsg.Visible = false;
                    picMsgFileIcon.Visible = true;
                    lblMsgFileName.Visible = true;
                    //Gets the icon of the selected message file.
                    Program.msgIcon = Icon.ExtractAssociatedIcon(dlgMsg.FileName);
                    //Displays the icon of the message file in the PictureBox.
                    picMsgFileIcon.Image = Program.msgIcon.ToBitmap();
                    //Displays the message file name with extension in the label   
                    lblMsgFileName.Text = Path.GetFileNameWithoutExtension(dlgMsg.FileName);
                    //Creates an object of FileInfo Class to get the size of the message file.
                    lblMsgFileName.Text += "\r\n" + formManager.FileSize(dlgMsg.FileName).ToString() + "MB";
                }
            }
        }

        private void chkPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPwd.Checked == true)                                 //if user has checked the Show password checkBox.
            {
                txtPwd.UseSystemPasswordChar = false;                   //User will be able to see the original characters.
                txtConfirmPwd.Enabled = false;                          //User can not type in the confirm password field. 
                txtConfirmPwd.Text = String.Empty;
            }
            else
            {
                txtPwd.UseSystemPasswordChar = true;
                txtConfirmPwd.Enabled = true;
            }
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            string pass = txtPwd.Text;
            if (validate.CheckForm(txtPwd.Text, txtConfirmPwd.Text, dlgCover.FileName, dlgMsg.FileName, txtMsg.Text, chkPwd.Checked) == true)
            {
                Program.image = new Bitmap(picCover.Image);
                Program.message = txtMsg.Text;
                string messagepath = string.Empty;
                string extension = string.Empty;

                #region SaveFileDialogAs
                //Create a new object of SaveFileDialog.
                SaveFileDialog sfdSave = new SaveFileDialog();

                //Get extension without the period.
                string ext = Path.GetExtension(dlgCover.FileName).Substring(1);
                //Create the filter, initial directory and default filename of the newly created instance of SaveFileDialog.
                sfdSave.Filter = ext.ToUpper() + " Files|*." + ext;
                sfdSave.InitialDirectory = Path.GetDirectoryName(dlgCover.FileName);
                sfdSave.FileName = Path.GetFileNameWithoutExtension(dlgCover.FileName) + "Encoded." + ext;

                //If a file with the same name as the default filename exists, then keep searching for other possible file names.
                for (ulong i = 0; File.Exists(sfdSave.InitialDirectory + "\\" + sfdSave.FileName); ++i)
                    sfdSave.FileName = Path.GetFileNameWithoutExtension(dlgCover.FileName) + "Encoded" + i.ToString() + "." + ext;
                #endregion
                if (txtMsg.Text.Length > 0)
                {
                    string temppath = Path.GetTempFileName();
                    File.WriteAllBytes(temppath, Encoding.UTF8.GetBytes(txtMsg.Text));
                    messagepath = temppath;
                    extension = ".txt";
                    Program.msgIcon = Steg_Ref_Stack.Properties.Resources.Iconica_Pastel_Text_file;
                }
                else
                {
                    messagepath = dlgMsg.FileName;
                    extension = Path.GetExtension(dlgMsg.FileName);
                }
                Encode enc = new Encode();
                if (sfdSave.ShowDialog() == DialogResult.OK)
                {
                    if (validate.isImage)                   //Checks if the cover medium is an Image or Audio.
                        Program.encOutput = enc.EncodeImage(messagepath, extension, dlgCover.FileName, txtPwd.Text, sfdSave.FileName);
                    else
                        Program.encOutput = enc.EncodeAudio(messagepath, extension, dlgCover.FileName, txtPwd.Text, sfdSave.FileName);

                    if (Program.encOutput)
                        MessageBox.Show("Stego medium saved at " + sfdSave.FileName);
                    else
                        MessageBox.Show("Unable to encode secret message into Cover Medium.\nTry using a shorter message or a larger cover medium.", "Low Carrier Medium capacity", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.nextFormId = FormId.frm_main;
                    Close();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.nextFormId = FormId.frm_main;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


