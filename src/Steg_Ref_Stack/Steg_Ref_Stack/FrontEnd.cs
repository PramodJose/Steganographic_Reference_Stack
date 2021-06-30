using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using Steg_Ref_Stack;
using System.Text;
using Constants;

namespace FrontEnd
{
    /// <summary>
    /// Validates the controls on the basis of file selection.
    /// </summary>
    public class Validation
    {
        public bool isImage = true;
        public bool isMsgText = true;

        /// <summary>
        /// Verifies the file selected as Cover Medium to make sure that a valid Image or Audio file is selected.  
        /// </summary>
        /// <param name="extension">extension of the file.</param>
        /// <param name="filename">full path of the file.</param>
        /// <returns>a boolean value</returns>
        public bool CheckFile(string filename)
        {
            string[,] headers = new string[6, 2] { { "89504e470d0a1a0a", ".png" }, { "474946383761", ".gif" }, 
                                                    { "424d", ".bmp" }, { "464f524d", ".aiff" }, 
                                                    { "52494646", ".wav" }, { "464f524d", ".aif" } };               //storing file extensions with headers..
            string file = string.Empty;
            string extension = Path.GetExtension(filename);
            int i = 0;
            FileStream fs = new FileStream(filename, FileMode.Open);
            for (i = 0; i < 6; i++)
                if (String.Compare(extension, headers[i, 1], true) == 0)
                {
                    BinaryReader br = new BinaryReader(fs);
                    byte[] data = br.ReadBytes(headers[i, 0].Length / 2);
                    foreach (byte b in data)
                        file += b.ToString("x2");
                    br.Close();
                    break;
                }
            if (i == 6 || file != headers[i, 0])
            {
                MessageBox.Show("Not a valid file");
                return false;
            }
            else if (i < 3)
            {
                FileStream fs1 = new FileStream(filename, FileMode.Open);
                Bitmap cover = new Bitmap(Image.FromStream(fs1));
                fs1.Close();
                isImage = true;
                if (cover.PixelFormat == PixelFormat.Format1bppIndexed || cover.PixelFormat == PixelFormat.Format4bppIndexed)
                    return false;
                else
                    return true;
            }
            else
            {
                isImage = false;
                return AudioValidate(filename);
            }
        }

        private bool AudioValidate(string path)
        {
            FileStream audFile = new FileStream(path, FileMode.Open);
            byte[] buf = new byte[4];
            uint chunkSize = 0, mediaID = 0, mediaType = 0, chunkID = 0;
            string ext = Path.GetExtension(path).Substring(1);
            bool ret = false;

            audFile.Read(buf, 0, 4);                    //Read the first four bytes (Media ID).
            mediaID = BitConverter.ToUInt32(buf, 0);    //Convert Media ID to an integer.
            audFile.Seek(4, SeekOrigin.Current);        //Skip the file size.
            audFile.Read(buf, 0, 4);                    //Read the next four bytes (Media Type).
            mediaType = BitConverter.ToUInt32(buf, 0);  //Convert Media Type to an integer.

            //If the extension is WAVE and the file signatures also belong to a WAVE file.
            if ((string.Compare(ext, "WAV", true) == 0 || string.Compare(ext, "WAVE", true) == 0) &&
                 (mediaID == ChunkIDs.WAVE_RIFF && mediaType == ChunkIDs.WAVE_WAVE))
            {
                do
                {
                    audFile.Read(buf, 0, 4);
                    chunkID = BitConverter.ToUInt32(buf, 0);
                    audFile.Read(buf, 0, 4);
                    chunkSize = BitConverter.ToUInt32(buf, 0);
                    if ((chunkSize & 1) > 0)
                        ++chunkSize;
                    if (chunkID != ChunkIDs.WAVE_fmt)
                        audFile.Seek(chunkSize, SeekOrigin.Current);
                } while (chunkID != ChunkIDs.WAVE_fmt && audFile.Position < audFile.Length);
                if (chunkID == ChunkIDs.WAVE_fmt)
                {
                    audFile.Read(buf, 0, 2);
                    if (BitConverter.ToInt16(buf, 0) == ChunkIDs.WAVE_LPCM)
                    {
                        audFile.Seek(12, SeekOrigin.Begin);
                        do
                        {
                            audFile.Read(buf, 0, 4);
                            chunkID = BitConverter.ToUInt32(buf, 0);
                            audFile.Read(buf, 0, 4);
                            chunkSize = BitConverter.ToUInt32(buf, 0);
                            if ((chunkSize & 1) > 0)
                                ++chunkSize;
                            if (chunkID != ChunkIDs.WAVE_data)
                                audFile.Seek(chunkSize, SeekOrigin.Current);
                        } while (chunkID != ChunkIDs.WAVE_data && audFile.Position < audFile.Length);
                        if (chunkID == ChunkIDs.WAVE_data)
                            ret = true;
                    }
                }
            }

            //If the extension is AIFF and the first file signature is of an AIFF file.
            else if ((string.Compare(ext, "AIFF", true) == 0 || string.Compare(ext, "AIF", true) == 0 || string.Compare(ext, "AIFC", true) == 0) &&
                    mediaID == ChunkIDs.AIFF_FORM)
            {
                //If it is a normal, uncompressed AIFF file.
                if (mediaType == ChunkIDs.AIFF_AIFF)
                    ret = true;
                //If it is a compressed AIFF file, check whether the compression type is supported or not.
                //Supported compression types are NONE and sowt.
                else if (mediaType == ChunkIDs.AIFF_AIFC)
                {
                    do
                    {
                        audFile.Read(buf, 0, 4);
                        chunkID = BitConverter.ToUInt32(buf, 0);
                        audFile.Read(buf, 0, 4);
                        Array.Reverse(buf);
                        chunkSize = BitConverter.ToUInt32(buf, 0);
                        if ((chunkSize & 1) > 0)
                            ++chunkSize;
                        if (chunkID != ChunkIDs.AIFF_COMM)
                            audFile.Seek(chunkSize, SeekOrigin.Current);
                    } while (chunkID != ChunkIDs.AIFF_COMM && audFile.Position < audFile.Length);
                    if (chunkID == ChunkIDs.AIFF_COMM && chunkSize > 18)
                    {
                        audFile.Seek(18, SeekOrigin.Current);
                        audFile.Read(buf, 0, 4);
                        mediaID = BitConverter.ToUInt32(buf, 0);
                        if (mediaID == ChunkIDs.AIFF_SOWT || mediaID == ChunkIDs.AIFF_NONE)
                            ret = true;
                    }
                }
                if (ret)
                {
                    audFile.Seek(12, SeekOrigin.Begin);
                    do
                    {
                        audFile.Read(buf, 0, 4);
                        chunkID = BitConverter.ToUInt32(buf, 0);
                        audFile.Read(buf, 0, 4);
                        Array.Reverse(buf);
                        chunkSize = BitConverter.ToUInt32(buf, 0);
                        if ((chunkSize & 1) > 0)
                            ++chunkSize;
                        if (chunkID != ChunkIDs.AIFF_SSND)
                            audFile.Seek(chunkSize, SeekOrigin.Current);
                    } while (chunkID != ChunkIDs.AIFF_SSND && audFile.Position < audFile.Length);
                    if (chunkID != ChunkIDs.AIFF_SSND)
                        ret = false;
                }
            }

            audFile.Close();
            audFile.Dispose();
            return ret;
        }

        /// <summary>
        /// verifies the password given by the user.
        /// </summary>
        /// <param name="pass">the password entered in the 'Password' field</param>
        /// <param name="confirmpass">the password entered in the 'Confirm Password' field</param>
        /// <returns>a boolean value</returns>
        public bool CheckPasswd(string pass, string confirmpass)
        {
            bool dig = false, alpha = false;
            if (pass.Length < 8)

            {
                MessageBox.Show("Minimum password length should be 8 characters", "Error");
                return false;
            }
            for (short i = 0; (!dig || !alpha) && i < pass.Length; ++i)
                if (char.IsLetter(pass, i))
                    alpha = true;
                else if (char.IsNumber(pass, i))
                    dig = true;
            if (!alpha && !dig)
                MessageBox.Show("Password must at least one Alphabet and one Numeric Value", "Error");
            else if (!dig)
                MessageBox.Show("Password must contain at least one Numeric Value", "Error");
            else if (!alpha)
                MessageBox.Show("Password must contain at least one Alphabet", "Error");
            return (dig && alpha);
        }

        /// <summary>
        /// verifies all the controls in the form.
        /// </summary>
        /// <param name="pass">the password entered in the 'Password' field</param>
        /// <param name="confirmpass">the password entered in the 'Confirm Password' field</param>
        /// <param name="cover">the file selected as Cover Medium</param>
        /// <param name="msg">the value of the message field</param>
        /// <returns></returns>
        public bool CheckForm(string pass, string confirmpass, string cover, string msgpath, string message, bool value)
        {
            
            if (!File.Exists(cover) == true)
            {
                MessageBox.Show("The file selected as Cover Medium doesn't exist", "Error");
                return false;
            }
            else if (File.Exists(msgpath) == false && message.Length < 1)
            {
                MessageBox.Show("Check Message", "Error");
                return false;
            }
            else if (CheckPasswd(pass, confirmpass) == false)
                return false;
            else if (value == false)
            {
                if (pass != confirmpass)
                {
                    MessageBox.Show("Password mismatch", "Error");
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }
    }
    
    /// <summary>
    /// Manages the controls in the form(s) and manipulates the display.
    /// </summary>
    public class FormManager
    {

        /// <summary>
        /// Calculates the specified filesize in mega bytes.
        /// </summary>
        /// <param name="filename">Full name of the file. File name should not end with the directory seperator character.</param>
        /// <returns></returns>
        public double FileSize(string fileName)
        {
            FileInfo fileinfo = new FileInfo(fileName);
            double length = fileinfo.Length;
            length = Math.Round((length / 1048576), 2);
            return length;
        }
    }
}
