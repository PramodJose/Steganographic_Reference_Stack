using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using FrontEnd;
using EnDecode;
using Constants;

namespace Steg_Ref_Stack
{
    public partial class frm_decode : Form
    {
        Validation validate = new Validation();
        public frm_decode()
        {
            InitializeComponent();
        }

        private void picIcon_Click(object sender, EventArgs e)
        {
            //Clicking on the Application Icon will take the user to the Home Screen.
            Program.nextFormId = FormId.frm_main;
            Close();
        }

        private void chkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPwd.Checked)
                txtPwd.PasswordChar = '\0';                 //user can see the original characters instead of password character
            else
                txtPwd.PasswordChar = '●';
        }

        private unsafe void btnDecode_Click(object sender, EventArgs e)
        {
            Decode dec = new Decode();                      //Creates an object of Decode class.
            Program.decodecover = dlg_cover.FileName;       
            if (validate.isImage)                           //Checks if the Stego medium selected is an Image.
                Program.decOutput = dec.DecodeImage(dlg_cover.FileName, txtPwd.Text, ref Program.msgPath, ref Program.msgExt);
            else
                Program.decOutput = dec.DecodeAudio(dlg_cover.FileName, txtPwd.Text, ref Program.msgPath, ref Program.msgExt);
            if (Program.decOutput)                          //Checks if decoding is successful.
            {
                #region SaveFileDialogAs
                //Create a new object of SaveFileDialog.
                SaveFileDialog sfdSave = new SaveFileDialog();

                //Create the filter, initial directory and default filename of the newly created instance of SaveFileDialog.
                sfdSave.Filter = Program.msgExt + " Files|*." + Program.msgExt;
                sfdSave.InitialDirectory = Path.GetDirectoryName(dlg_cover.FileName);
                sfdSave.FileName = Path.GetFileNameWithoutExtension(dlg_cover.FileName) + "Decoded." + Program.msgExt;

                //If a file with the same name as the default filename exists, then keep searching for other possible file names.
                for (ulong i = 0; File.Exists(sfdSave.InitialDirectory + "\\" + sfdSave.FileName); ++i)
                    sfdSave.FileName = Path.GetFileNameWithoutExtension(dlg_cover.FileName) + "Decoded" + i.ToString() + "." + Program.msgExt;
                #endregion

                if (sfdSave.ShowDialog() == DialogResult.OK)
                {
                    File.Move(Program.msgPath, sfdSave.FileName);
                    MessageBox.Show("Decoded message file is saved as " + sfdSave.FileName);
                }
                else
                    File.Delete(Program.msgPath);
                Program.nextFormId = FormId.frm_main;
                Close();
            }
            else
                MessageBox.Show("Incorrect File or Password", "Error");
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();                    //terminates the application.
        }

        private void picEditCover_Click(object sender, EventArgs e)
        {
            //Checks if the Stego medium is selected.
            if (dlg_cover.ShowDialog() == DialogResult.OK)
            {
                FormManager formManager = new FormManager();                //Creates an object of User defined FormManager class.
                txtName.Text = Path.GetFileNameWithoutExtension(dlg_cover.FileName);
                txtPath.Text = dlg_cover.FileName;
                txtSize.Text = formManager.FileSize(dlg_cover.FileName).ToString() + " MB";
                txtExt.Text = Path.GetExtension(dlg_cover.FileName).ToString();
                Icon fileicon = Icon.ExtractAssociatedIcon(dlg_cover.FileName.ToString());
                if (validate.CheckFile(dlg_cover.FileName) == true)
                {
                    if (txtExt.Text == ".png" || txtExt.Text == ".gif" || txtExt.Text == ".bmp")
                    {
                        picCover.Load(dlg_cover.FileName);
                    }
                    else
                        picCover.Image = fileicon.ToBitmap();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Program.nextFormId = FormId.frm_main;           //Takes the user to home screen.
            Close();
        }
    }
}
