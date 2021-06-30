using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;
using Constants;
using Steg_Ref_Stack;

namespace EnDecode
{
    /// <summary>
    /// Provides methods to encode messages in any type of cover medium - image or audio.
    /// </summary>
    public class Encode
    {
        /// <summary>
        /// Encodes a message into an audio file.
        /// </summary>
        /// <param name="msgPath">Path of the unencrypted message file. In case of textbox input, send the path of the temporary file in which the contents of the textbox are stored in UTF-8 Encoding.</param>
        /// <param name="msgExt">Extension of the file to be encoded. In case of textbox input, send ".txt". The result of Path.Extension(FILE) has to be sent in case of file input. Will be converted to compatible form.</param>
        /// <param name="coverPath">Path of the cover audio file into which the message has to be encoded.</param>
        /// <param name="password">String containing the password as entered by the user. Will be converted to compatible form.</param>
        /// <param name="saveFileAs">Path where the stego-audio-file has to be stored; alongwith the filename.</param>
        /// <returns>true in case of successful encoding, false in case of unsuccessful encoding.</returns>
        public bool EncodeAudio(string msgPath, string msgExt, string coverPath, string password, string saveFileAs)
        {
            Program.cryptID = Program.hashID = 0;
            //Make new instance of Metadata and initialise the members of the class with required metadata.
            Metadata metadata = new Metadata();
            metadata.FillData(password, msgPath, msgExt);   //Encrypt the message file and collect salt, hash, etc which are required for encoding.

            /* Copy the source cover-audio file to another file; open the newly created file and the encrypted message file.
             * Changes are made to the copied file because there maybe a case where the whole encrypted message cannot be hidden in the cover audio file.
             */
            File.Copy(coverPath, saveFileAs, true);
            FileStream cover = new FileStream(saveFileAs, FileMode.Open);
            FileStream msg = new FileStream(metadata.encDataPath, FileMode.Open);

             /*
             * coverBuf is the buffer for the cover file. Will mainly be used by helper function.
             * msgBuf is the buffer for the encrypted message file. Will mainly be used by helper function.
             * masks contains the masks of all the regions. Will mainly be used by helper function.
            */
            byte[] coverBuf = new byte[FileBufs.COVER_BUF_SIZE], msgBuf = new byte[FileBufs.MSG_BUF_SIZE];
            Masks masks = new Masks();

            /*
             * coverOff denotes the offset in the data part of the cover file. Will mainly be used by helper function.
             * coverAbsOff specifies the absolute offset position in the cover file, i.e.;
             * coverAbsOff + coverOff + coverIndex will give us the exact byte position in the file,
             * coverOff + coverIndex will give us the exact byte position in the data part of the file,
             * and coverIndex will give us the byte position in the buffer.
             * coverOff will mainly be used by the helper function.
             * coverAbsOff will mainly be used by this function.
            */
            long coverOff = 0, coverAbsOff = 0;
            
            /*
             * msgOff denotes the offset in the encrypted message file. Will mainly be used by this function.
             * coverSize denotes the size of the data part of the cover file.
            */
            long msgOff = 0, coverSize = 0;

            /*
             * coverCount denotes the number of valid bytes in the cover buffer. Will mainly be used by helper function.
             * msgCount denotes the number of valid bytes in the cover buffer. Will mainly be used by helper function.
             * coverIndex denotes the byte position in the buffer of the cover file. Will mainly be used by helper function.
             * msgIndex denotes the byte position in the buffer of the encrypted message file. Will mainly be used by helper function.
             * maskIndex denotes the index of the boolean value in the masks. The region number will be decided at run time by looking at the current value of coverOff + coverIndex. Will mainly be used by helper function.
             * msgShift denotes the shift value for the byte being encoded into the cover file. Will mainly be used by helper function.
             * coverStep is the step size for the cover file. Will mainly be used by helper function.
            */
            short coverCount = 0, msgCount = 0, coverIndex = 0, msgIndex = 0, maskIndex = 0, msgShift = 7;
            byte coverStep = 0, coverShift = 7;
            Audio.Detect(ref coverPath, ref coverAbsOff, ref coverSize, ref coverStep);
            
            //Read contents from file into respective buffers.
            cover.Seek(coverAbsOff, SeekOrigin.Begin);  //Placing file pointers..
            msg.Seek(0, SeekOrigin.Begin);              //..to proper places.
            //If the size of the data part of the cover audio file is lesser than the size of the cover buffer, then read as much as data is present; else read as much as the buffer can accomodate.
            coverCount = FileBufs.COVER_BUF_SIZE > coverSize ? (short)coverSize : FileBufs.COVER_BUF_SIZE; 
            cover.Read(coverBuf, 0, coverCount);
            msgCount = (short) msg.Read(msgBuf, 0, FileBufs.MSG_BUF_SIZE);
            
            //Encoding salt...
            masks.CreateFirstRegion(metadata.password); //Create mask for first region.
            short len = (short) metadata.salt.Length;
            masks.reg[0].limit *= coverStep;    //Actual limit would be; the limit of the first region multiplied by the step size of the cover audio file.
            EncodeHelper(coverBuf, ref coverCount, ref coverIndex, ref coverStep, ref coverOff, ref coverShift, metadata.salt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
            
            //Encoding hash, length and extension.
            masks.CreateRegion(metadata.salt, 2);   //Create masks for the first and second regions. (Actually, the pseudo mask for the first region and mask for the second region.)
            len = (short) metadata.hashLenExt.Length;
            coverIndex= msgIndex= maskIndex= 0; //Resetting the variables..
            msgShift = 7;                       //...which got altered when the salt was encoded.
            coverShift = 7;
            EncodeHelper(coverBuf, ref coverCount, ref coverIndex, ref coverStep, ref coverOff, ref coverShift, metadata.hashLenExt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
            masks.reg[1].limit = (int) (coverOff + coverIndex);
            //Once the hash, length of the encrypted message and extension get encoded depending on the salt, we get to know the limit of the second region which is assigned to the second region's "limit" variable.
            
            //Encoding encrypted data.
            masks.CreateRegion(metadata.hash, 3, true); //Create masks for the first, second and third regions. (Actually, the pseudo mask for the first and second regions and mask for the third region.)
            coverIndex = msgIndex = maskIndex = 0;  //Resetting the varibles...
            msgShift = 7;                           //..which got altered when the hash, length and extension was encoded.
            coverShift = 7;
            while ((msgOff + msgIndex < msg.Length) && (coverOff + coverIndex < coverSize)) //Stop if message gets sucessfully encoded or the cover audio file gets finished.
            {
                EncodeHelper(coverBuf, ref coverCount, ref coverIndex, ref coverStep, ref coverOff, ref coverShift, msgBuf, ref msgCount, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
                if (msgIndex == msgCount)   //If the message buffer has been encoded completely, then read new data from the encrypted message file.
                {
                    msgOff += msgCount; //Advance the offset by the number of bytes in the buffer -that would be the offset of the newly to-be-read data.
                    msgIndex = 0;
                    msgCount = (short) msg.Read(msgBuf, 0, FileBufs.MSG_BUF_SIZE);
                }
                if (coverIndex >= coverCount)   //If the cover buffer has completely been utilised, then write changed bytes and read new data into buffer.
                {
                    cover.Seek(-coverCount, SeekOrigin.Current);    //Move the file pointer back as much as the number of bytes in the buffer.
                    cover.Write(coverBuf, 0, coverCount);   //Write buffer to file.
                    coverOff += coverCount; //Advance the offset by the number of bytes in the buffer.
                    coverIndex = 0;

                    /* If FileBufs.COVER_BUF_SIZE number of bytes is read, then, (coverOff + FileBufs.COVER_BUF_SIZE) would be the total number of bytes read.
                     * Now, if that is greater than the size of the data part of the cover audio file, then read only as much as data is left in the data part; which would be (coverSize - coverOff).
                     * Else, read FileBufs.COVER_BUF_SIZE number of bytes from the audio file.
                     */
                    coverCount = (coverOff + FileBufs.COVER_BUF_SIZE > coverSize) ? (short)(coverSize - coverOff) : FileBufs.COVER_BUF_SIZE;
                    cover.Read(coverBuf, 0, coverCount);
                }
            }

            //Write the remaining changed bytes back to the audio file.
            cover.Seek(-coverCount, SeekOrigin.Current);
            cover.Write(coverBuf, 0, coverCount);
            cover.Close();  //Close the files...
            msg.Close();
            cover.Dispose();    //And also dispose them...
            msg.Dispose();
            File.Delete(metadata.encDataPath);  //Delete the encrypted temporary file as it is not required anymore.
            if (coverOff + coverIndex >= coverSize) //If the message is too long to be encoded into the image...
            {
                File.Delete(saveFileAs);    //...then delete the new stego file.
                return false;
            }
            return true;
        }

        /// <summary>
        /// Encodes a message into a bitmap image.
        /// </summary>
        /// <param name="msgPath">Path of the unencrypted message file. In case of textbox input, send the path of the temporary file in which the contents of the textbox are stored in UTF-8 Encoding.</param>
        /// <param name="msgExt">Extension of the file to be encoded. In case of textbox input, send ".txt". The result of Path.Extension(FILE) has to be sent in case of file input. Will be converted to compatible form.</param>
        /// <param name="coverPath">Path of the cover medium into which the message has to be encoded.</param>
        /// <param name="password">String containing the password as entered by the user. Will be converted to compatible form.</param>
        /// <param name="saveFileAs">Path where the stego-medium has to be stored; alongwith the filename.</param>
        /// <returns>true in case of successful encoding, false in case of unsuccessful encoding.</returns>
        public unsafe bool EncodeImage(string msgPath, string msgExt, string coverPath, string password, string saveFileAs)
        {
            Program.cryptID = Program.hashID = 0;
            //Make new instance of Metadata and initialise the members of the class with required metadata.
            Metadata metadata = new Metadata();
            metadata.FillData(password, msgPath, msgExt);   //Encrypt the message file and collect salt, hash, etc which are required for encoding.

            //Lock the source cover-image and open the encrypted message file.
            Bitmap image = new Bitmap(coverPath);
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            FileStream msg = new FileStream(metadata.encDataPath, FileMode.Open);

            //Variable initialisations.
            byte[] coverBuf = new byte[FileBufs.COVER_BUF_SIZE], msgBuf = new byte[FileBufs.MSG_BUF_SIZE];
            Masks masks = new Masks();
            long coverOff = 0, msgOff = 0, coverEnd = 0, coverLineEnd = 0, coverCur = 0, coverWriteOff = 0, coverWriteLineEnd = 0;
            short coverCount = 0, msgCount = 0, coverIndex = 0, msgIndex = 0, maskIndex = 0, msgShift = 7;
            //coverStep is used as a temporary variable for some time and stores the number of bytes per pixel.
            byte coverStep = (byte)(Bitmap.GetPixelFormatSize(image.PixelFormat) / 8), coverPadding = 0, coverShift = 7;
            byte* scan0 = (byte*)imageData.Scan0.ToPointer();

            //Read into cover buffer.
            coverLineEnd = image.Width * coverStep;
            coverWriteLineEnd = coverLineEnd;
            coverPadding = (byte)(imageData.Stride - coverLineEnd);
            coverEnd = image.Height * imageData.Stride - coverPadding;
            coverStep = Bitmap.IsExtendedPixelFormat(image.PixelFormat) ? (byte)2 : (byte)1;
            ImageRW.Read(ref scan0, ref coverCur, ref coverEnd, ref coverLineEnd, ref coverPadding, imageData.Stride, coverBuf, ref coverCount);

            //Read into the message buffer.
            msg.Seek(0, SeekOrigin.Begin);
            msgCount = (short)msg.Read(msgBuf, 0, FileBufs.MSG_BUF_SIZE);

            //Encoding salt...
            masks.CreateFirstRegion(metadata.password);
            short len = (short)metadata.salt.Length;
            masks.reg[0].limit *= coverStep;
            EncodeHelper(coverBuf, ref coverCount, ref coverIndex, ref coverStep, ref coverOff, ref coverShift, metadata.salt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);

            //Encoding hash, length and extension...
            masks.CreateRegion(metadata.salt, 2);
            len = (short)metadata.hashLenExt.Length;
            coverIndex = msgIndex = maskIndex = 0;
            msgShift = 7;
            coverShift = 7;
            EncodeHelper(coverBuf, ref coverCount, ref coverIndex, ref coverStep, ref coverOff, ref coverShift, metadata.hashLenExt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
            masks.reg[1].limit = (int)(coverOff + coverIndex);

            //Encoding encrypted data.
            masks.CreateRegion(metadata.hash, 3, true);
            coverIndex = msgIndex = maskIndex = 0;
            msgShift = 7;
            coverShift = 7;
            while ((msgOff + msgIndex < msg.Length) && coverCur < coverEnd)
            {
                EncodeHelper(coverBuf, ref coverCount, ref coverIndex, ref coverStep, ref coverOff, ref coverShift, msgBuf, ref msgCount, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
                if (msgIndex == msgCount)   //If the message buffer has been encoded completely, then read new data from the encrypted message file.
                {
                    msgOff += msgCount; //Advance the offset by the number of bytes in the buffer.
                    msgIndex = 0;
                    msgCount = (short)msg.Read(msgBuf, 0, FileBufs.MSG_BUF_SIZE);
                }
                if (coverIndex >= coverCount)   //If the cover buffer has completely been utilised, then write changed bytes and read new data into buffer.
                {
                    ImageRW.Write(ref scan0, ref coverWriteOff, ref coverCur, ref coverWriteLineEnd, imageData.Stride, ref coverPadding, coverBuf, ref coverIndex);
                    coverOff += coverCount; //Advance the offset by the number of bytes in the buffer.
                    coverIndex = 0;
                    ImageRW.Read(ref scan0, ref coverCur, ref coverEnd, ref coverLineEnd, ref coverPadding, imageData.Stride, coverBuf, ref coverCount);
                }
            }

            //Write the remaining changed bytes back to the image.
            ImageRW.Write(ref scan0, ref coverWriteOff, ref coverCur, ref coverWriteLineEnd, imageData.Stride, ref coverPadding, coverBuf, ref coverIndex);
            msg.Close();
            msg.Dispose();
            File.Delete(metadata.encDataPath);  //Delete the encrypted temporary file.
            image.UnlockBits(imageData);
            if (coverCur >= coverEnd)   //If the message is too long to be encoded into the image.
            {
                image.Dispose();
                return false;
            }
            image.Save(saveFileAs); //If the message has successfully been encoded into the image, then save it.
            image.Dispose();
            return true;
        }

        /// <summary>
        /// Helps in encoding the message into the cover medium. Takes a cover buffer, a message buffer and masks and hides the message in that cover buffer depending on the masks.
        /// Provides a common way to encode messages into any cover medium- image or audio.
        /// Relevant cover medium and message bytes are sent as argument along with the masks and other necessary information like buffer indices, offsets, etc.
        /// </summary>
        /// <param name="coverBuf">Cover Buffer - Byte array containing relevant bytes (excluding padding, header chunks, etc.) of the cover medium.</param>
        /// <param name="coverCount">Cover Count - Denotes the number of valid bytes in the cover buffer.</param>
        /// <param name="coverIndex">Cover Index - Specifies the index (in the cover buffer) of the byte of the cover medium under consideration.</param>
        /// <param name="coverStep">Cover Step - Denotes the length of each sample of the cover medium. If each sample in the cover medium is of 2 bytes, then changes would be made to every second byte, i.e., the least significant bytes only. In such a case, the value of coverStep would be 2.</param>
        /// <param name="coverOff">Cover Offset - Specifies the offset of the cover buffer in the data part of the cover medium.</param>
        /// <param name="msgBuf">Message Buffer - Byte array containing the bytes of the message to be encoded in the cover medium.</param>
        /// <param name="msgCount">Message Count - Specifies the number of valid bytes in the message buffer.</param>
        /// <param name="msgIndex">Message Index- Specifies the index (in the message buffer) of the byte of the message under consideration.</param>
        /// <param name="msgShift">Message Shift - Represents the shift value used in the left shift operation to be performed to extract a particular bit from the message.</param>
        /// <param name="masks">Masks - Contains the mask, cumulative mask and limit of the three regions.</param>
        /// <param name="maskIndex">Mask Index - Represents the index in the mask array.</param>
        private void EncodeHelper(byte[] coverBuf, ref short coverCount, ref short coverIndex, ref byte coverStep, ref long coverOff, ref byte coverShift, byte[] msgBuf, ref short msgCount, ref short msgIndex, ref short msgShift, ref Masks masks, ref short maskIndex)
        {
            long curByte = coverOff + coverIndex;   //Calculate the current byte number in the data part of the cover medium.
            byte curReg = 0, mask = 0, cover = 0, msgBit = 0;
            byte[] byteMasks = { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };  //Storing all possible mask values for faster code execution.

            while (msgIndex < msgCount && coverIndex < coverCount)  //Continue until the message or cover buffer get exhausted.
            {
                //Detect the current region number.
                if (curByte < masks.reg[0].limit)
                    curReg = 0;
                else if (curByte < masks.reg[1].limit || masks.reg[1].limit < 0)
                    curReg = 1;
                else
                    curReg = 2;

                if (masks.reg[curReg].mask[maskIndex])  //If the current cover byte can be used for hiding a message bit, then...
                {
                    //..determine whether the message bit to be hidden is 0 or 1; then...
                    msgBit = (msgBuf[msgIndex] & byteMasks[msgShift]) > 0 ? (byte)1 : (byte)0;
                    //..determine whether the least significant bit or the second least significant bit of the cover byte is used for storing the message bit.
                    //If the least significant bit is used, then the new mask would be 1, and in case of the second least significant bit being used, the new mask would be 2.
                    mask = (coverBuf[coverIndex] & byteMasks[coverShift]) > 0 ? (byte)2 : (byte)1;
                    //Determine the bit value of the cover byte.
                    cover = (coverBuf[coverIndex] & mask) > 0 ? (byte)1 : (byte)0;

                    //The cover bit has to be flipped only when the message bit and the cover bit are unequal.
                    if (cover != msgBit)
                        coverBuf[coverIndex] ^= mask;
                    if (--coverShift == 3)  //The mask value used for determining the LSB has to be changed every four bytes of the cover medium.
                        coverShift = 7;
                    if (--msgShift < 0) //If the new shift value is -1, then it means that one full byte of the message has been encoded.
                    {
                        ++msgIndex; //So, move on to the next byte of the message...
                        msgShift = 7;   //..and update the shift value.
                    }
                }

                //If the mask of the current region has been completely traversed, then loop back to the beginning of the mask array.
                if (++maskIndex == masks.reg[curReg].mask.Length)
                    maskIndex = 0;

                coverIndex += coverStep;    //Advance the index of the cover buffer by the step size of the cover medium.
                curByte = coverOff + coverIndex;    //Also advance the current byte value by the step size of the cover medium.
                //If the new maskIndex value results a cross over to a new region, then reset the value of maskIndex to 0.
                if (masks.reg[curReg].limit > 0 && curByte >= masks.reg[curReg].limit)
                    maskIndex = 0;
            }
        }
    }

    /// <summary>
    /// Provides methods to decode messages from any type of stego medium - image or audio.
    /// </summary>
    public class Decode
    {
        /// <summary>
        /// Decodes a message from an audio file.
        /// </summary>
        /// <param name="stegoPath">Path of the stego medium from which the message has to be decoded.</param>
        /// <param name="password">String containing the password as entered by the user. Will be converted to compatible form.</param>
        /// <param name="msgPath">String where the path to the temporary file containing the decrypted message would be stored.</param>
        /// <param name="msgExt">String where the extension of the decoded message file would be stored.</param>
        /// <returns>true in case of successful decoding, false in case of unsuccessful decoding.</returns>
        public bool DecodeAudio(string stegoPath, string password, ref string msgPath, ref string msgExt)
        {
            //Create objects for storing the to-be-extracted metadata and masks.
            Metadata metadata = new Metadata();
            Masks masks = new Masks();

            //Initialisation.
            byte[] stegoBuf = new byte[FileBufs.COVER_BUF_SIZE], msgBuf;
            long stegoOff = 0, stegoAbsOff = 0, stegoSize = 0;
            short stegoCount = 0, msgCount = 0, stegoIndex = 0, msgIndex = 0, maskIndex = 0, msgShift = 7;
            byte stegoStep = 0, stegoShift = 7;
            Audio.Detect(ref stegoPath, ref stegoAbsOff, ref stegoSize, ref stegoStep);

            //Open the stego-medium.
            FileStream stego = new FileStream(stegoPath, FileMode.Open);
            //Make a temporary file for storing the to-be-extracted encrypted data.
            string tmpEncPath = Path.GetTempFileName();
            FileStream msg = new FileStream(tmpEncPath, FileMode.Open);

            //Read contents from file into respective buffers.
            stego.Seek(stegoAbsOff, SeekOrigin.Begin);
            msg.Seek(0, SeekOrigin.Begin);
            stegoCount = FileBufs.COVER_BUF_SIZE > stegoSize ? (short) stegoSize : FileBufs.COVER_BUF_SIZE;
            stego.Read(stegoBuf, 0, stegoCount);

            //Extracting salt.
            metadata.password = Encoding.UTF8.GetBytes(password);
            masks.CreateFirstRegion(metadata.password);
            short len = (short) metadata.salt.Length;
            DecodeHelper(stegoBuf, ref stegoCount, ref stegoIndex, ref stegoStep, ref stegoOff, ref stegoShift, metadata.salt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);

            //Extracting hash, length and extension.
            masks.CreateRegion(metadata.salt, 2);
            len = (short) metadata.hashLenExt.Length;
            stegoIndex = msgIndex = maskIndex = 0;
            msgShift = 7;
            stegoShift = 7;
            DecodeHelper(stegoBuf, ref stegoCount, ref stegoIndex, ref stegoStep, ref stegoOff, ref stegoShift, metadata.hashLenExt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
            masks.reg[1].limit = (int)((stegoOff + stegoIndex) / stegoStep);
            Buffer.BlockCopy(metadata.hashLenExt, 0, metadata.hash, 0, metadata.hash.Length);

            //Concatenate password and salt in a byte array.
            byte[] passAndSalt = new byte[metadata.password.Length + metadata.salt.Length];
            Buffer.BlockCopy(metadata.password, 0, passAndSalt, 0, metadata.password.Length);
            Buffer.BlockCopy(metadata.salt, 0, passAndSalt, metadata.password.Length, metadata.salt.Length);

            //Calculate hash.
            SHA256Managed shaHash = new SHA256Managed();
            byte[] computedHash = shaHash.ComputeHash(passAndSalt);

            
            if (computedHash.SequenceEqual(metadata.hash))
            {
                //Extract length...
                byte[] tmp = new byte[4];
                Buffer.BlockCopy(metadata.hashLenExt, metadata.hash.Length, tmp, 0, tmp.Length);
                int msgLen = BitConverter.ToInt32(tmp, 0);

                //Extract extension of the encoded file.
                Buffer.BlockCopy(metadata.hashLenExt, metadata.hash.Length + tmp.Length, tmp, 0, tmp.Length);
                for (len = 0; len < tmp.Length && tmp[len] != 0; ++len) ;
                msgExt = Encoding.UTF8.GetString(tmp, 0, len);
                
                //Extracting encrypted data.
                masks.CreateRegion(metadata.hash, 3, true);
                stegoIndex = msgIndex = maskIndex = 0;
                msgShift = 7;
                stegoShift = 7;
                msgCount = msgLen > FileBufs.MSG_BUF_SIZE ? FileBufs.MSG_BUF_SIZE : (short)msgLen;
                msgBuf = new byte[msgCount];
                while (msgLen > 0)
                {
                    DecodeHelper(stegoBuf, ref stegoCount, ref stegoIndex, ref stegoStep, ref stegoOff, ref stegoShift, msgBuf, ref msgCount, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
                    if (msgIndex == msgCount)
                    {
                        msg.Write(msgBuf, 0, msgCount);
                        msgLen -= msgCount;
                        msgCount = msgLen > FileBufs.MSG_BUF_SIZE ? FileBufs.MSG_BUF_SIZE : (short) msgLen;
                        msgBuf = new byte[msgCount];
                        msgIndex = 0;
                    }
                    if (stegoIndex >= stegoCount)
                    {
                        stegoOff += stegoCount;
                        stegoIndex = 0;
                        stegoCount = (stegoOff + FileBufs.COVER_BUF_SIZE > stegoSize) ? (short)(stegoSize - stegoOff) : FileBufs.COVER_BUF_SIZE;
                        stego.Read(stegoBuf, 0, stegoCount);
                    }
                }

                stego.Close();
                stego.Dispose();
                msg.Close();
                msg.Dispose();

                byte[] IV = new byte[16];
                Buffer.BlockCopy(shaHash.ComputeHash(metadata.salt), 0, IV, 0, IV.Length);
                shaHash.Dispose();
                metadata.EnDeCrypt(tmpEncPath, metadata.hash, IV, false);
                msgPath = metadata.encDataPath;
                File.Delete(tmpEncPath);
                return true;
            }
            else
            {
                shaHash.Dispose();
                stego.Close();
                stego.Dispose();
                msg.Close();
                msg.Dispose();
                File.Delete(tmpEncPath);
                return false;
            }
        }

        /// <summary>
        /// Decodes a message from a bitmap image.
        /// </summary>
        /// <param name="stegoPath">Path of the stego medium from which the message has to be decoded.</param>
        /// <param name="password">String containing the password as entered by the user. Will be converted to compatible form.</param>
        /// <param name="msgPath">String where the path to the temporary file containing the decrypted message would be stored.</param>
        /// <param name="msgExt">String where the extension of the decoded message file would be stored.</param>
        /// <returns>true in case of successful decoding, false in case of unsuccessful decoding.</returns>
        public unsafe bool DecodeImage(string stegoPath, string password, ref string msgPath, ref string msgExt)
        {
            //Create objects for storing the to-be-extracted metadata and masks.
            Metadata metadata = new Metadata();
            Masks masks = new Masks();

            //Lock the stego-image.
            Bitmap image = new Bitmap(stegoPath);
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
            //Make a temporary file for storing the to-be-extracted encrypted data.
            string tmpEncPath = Path.GetTempFileName();
            FileStream msg = new FileStream(tmpEncPath, FileMode.Open);

            //Initialisation.
            byte[] stegoBuf = new byte[FileBufs.COVER_BUF_SIZE], msgBuf;
            long stegoOff = 0, stegoEnd = 0, stegoLineEnd = 0, stegoCur = 0;
            short stegoCount = 0, msgCount = 0, stegoIndex = 0, msgIndex = 0, maskIndex = 0, msgShift = 7;
            //stegoStep is used as a temporary variable for some time and stores the number of bytes per pixel.
            byte stegoStep = (byte)(Bitmap.GetPixelFormatSize(image.PixelFormat) / 8), stegoPadding = 0, stegoShift = 7;
            byte* scan0 = (byte*)imageData.Scan0.ToPointer();

            //Read into cover buffer.
            stegoLineEnd = image.Width * stegoStep;
            stegoPadding = (byte)(imageData.Stride - stegoLineEnd);
            stegoEnd = image.Height * imageData.Stride - stegoPadding;
            stegoStep = Bitmap.IsExtendedPixelFormat(image.PixelFormat) ? (byte)2 : (byte)1;
            ImageRW.Read(ref scan0, ref stegoCur, ref stegoEnd, ref stegoLineEnd, ref stegoPadding, imageData.Stride, stegoBuf, ref stegoCount);
            msg.Seek(0, SeekOrigin.Begin);

            //Extracting salt.
            metadata.password = Encoding.UTF8.GetBytes(password);
            masks.CreateFirstRegion(metadata.password);
            short len = (short)metadata.salt.Length;
            DecodeHelper(stegoBuf, ref stegoCount, ref stegoIndex, ref stegoStep, ref stegoOff, ref stegoShift, metadata.salt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);

            //Extracting hash, length and extension.
            masks.CreateRegion(metadata.salt, 2);
            len = (short)metadata.hashLenExt.Length;
            stegoIndex = msgIndex = maskIndex = 0;
            msgShift = 7;
            stegoShift = 7;
            DecodeHelper(stegoBuf, ref stegoCount, ref stegoIndex, ref stegoStep, ref stegoOff, ref stegoShift, metadata.hashLenExt, ref len, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
            masks.reg[1].limit = (int)((stegoOff + stegoIndex) / stegoStep);
            Buffer.BlockCopy(metadata.hashLenExt, 0, metadata.hash, 0, metadata.hash.Length);

            //Concatenate password and salt in a byte array.
            byte[] passAndSalt = new byte[metadata.password.Length + metadata.salt.Length];
            Buffer.BlockCopy(metadata.password, 0, passAndSalt, 0, metadata.password.Length);
            Buffer.BlockCopy(metadata.salt, 0, passAndSalt, metadata.password.Length, metadata.salt.Length);

            //Calculate hash.
            SHA256Managed shaHash = new SHA256Managed();
            byte[] computedHash = shaHash.ComputeHash(passAndSalt);

            if (computedHash.SequenceEqual(metadata.hash))
            {
                //Extract length...
                byte[] tmp = new byte[4];
                Buffer.BlockCopy(metadata.hashLenExt, metadata.hash.Length, tmp, 0, tmp.Length);
                int msgLen = BitConverter.ToInt32(tmp, 0);

                //Extract extension of the encoded file.
                Buffer.BlockCopy(metadata.hashLenExt, metadata.hash.Length + tmp.Length, tmp, 0, tmp.Length);
                for (len = 0; len < tmp.Length && tmp[len] != 0; ++len) ;
                msgExt = Encoding.UTF8.GetString(tmp, 0, len);  //Set the extension of the decrypted message file for future use.

                //Extracting encrypted data.
                masks.CreateRegion(metadata.hash, 3, true);
                stegoIndex = msgIndex = maskIndex = 0;
                msgShift = 7;
                stegoShift = 7;
                msgCount = msgLen > FileBufs.MSG_BUF_SIZE ? FileBufs.MSG_BUF_SIZE : (short)msgLen;
                msgBuf = new byte[msgCount];
                while (msgLen > 0)
                {
                    DecodeHelper(stegoBuf, ref stegoCount, ref stegoIndex, ref stegoStep, ref stegoOff, ref stegoShift, msgBuf, ref msgCount, ref msgIndex, ref msgShift, ref masks, ref maskIndex);
                    if (msgIndex == msgCount)   //If the message buffer has been filled completely, then write it to message file.
                    {
                        msg.Write(msgBuf, 0, msgCount);
                        msgLen -= msgCount; //Calculate the remaining number of bytes in the message to be extracted.
                        msgCount = msgLen > FileBufs.MSG_BUF_SIZE ? FileBufs.MSG_BUF_SIZE : (short)msgLen;
                        msgBuf = new byte[msgCount];
                        msgIndex = 0;
                    }
                    if (stegoIndex >= stegoCount)   //If the stego buffer has completely been utilised, then read new data into buffer.
                    {
                        stegoOff += stegoCount; //Advance the offset by the number of bytes in the buffer.
                        stegoIndex = 0;
                        ImageRW.Read(ref scan0, ref stegoCur, ref stegoEnd, ref stegoLineEnd, ref stegoPadding, imageData.Stride, stegoBuf, ref stegoCount);
                    }
                }

                //Dispose image and close the encrypted message file.
                image.UnlockBits(imageData);
                image.Dispose();
                msg.Close();
                msg.Dispose();

                //Decrypted the encrypted message file.
                byte[] IV = new byte[16];
                Buffer.BlockCopy(shaHash.ComputeHash(metadata.salt), 0, IV, 0, IV.Length);
                shaHash.Dispose();
                metadata.EnDeCrypt(tmpEncPath, metadata.hash, IV, false);
                msgPath = metadata.encDataPath; //Set the path of the decrypted message file for future use.
                File.Delete(tmpEncPath);    //Delete the extracted encrypted message file.
                return true;
            }
            else
            {
                shaHash.Dispose();
                image.UnlockBits(imageData);
                image.Dispose();
                msg.Close();
                msg.Dispose();
                File.Delete(tmpEncPath);
                return false;
            }
        }

        /// <summary>
        /// Helps in decoding the message from the stego-medium. Takes a stego-buffer, an empty message buffer and masks and extracts the message into the message buffer from the stego-medium depending on the masks.
        /// Provides a common way to decode messages from any type of stego-medium- image, audio or video.
        /// Relevant stego-medium bytes, an empty message buffer (containing null values), masks and other necessary information like buffer indices, offsets, etc. have to be sent.
        /// </summary>
        /// <param name="stegoBuf">Stego Buffer - Byte array containing relevant bytes (excluding padding, header chunks, etc) of the stego medium.</param>
        /// <param name="stegoCount">Stego Count - Denotes the number of valid bytes in the stego buffer.</param>
        /// <param name="stegoIndex">Stego Index - Specifies the index (in the stego buffer) of the byte of the stego medium under consideration.</param>
        /// <param name="stegoStep">Stego Step - Denotes the length of each sample of the stego medium. If each sample in the stego medium is of 2 bytes, then changes would be made to every second byte, i.e., the least significant bytes only. In such a case, the value of stegoStep would be 2.</param>
        /// <param name="stegoOff">Stego Offset - Specifies the offset of the stego buffer in the data part of the stego medium.</param>
        /// <param name="msgBuf">Message Buffer - Byte array containing null values. Extracted data bits from the stego medium would be placed here.</param>
        /// <param name="msgCount">Message Count - Specifies the number of bytes to be extracted from the stego medium.</param>
        /// <param name="msgIndex">Message Index- Specifies the index (in the message buffer) of the byte of the message under consideration.</param>
        /// <param name="msgShift">Message Shift - Represents the shift value used in the left shift operation to be performed to turn on a particular bit in the message.</param>
        /// <param name="masks">Masks - Contains the mask, cumulative mask and limit of the three regions.</param>
        /// <param name="maskIndex">Mask Index - Represents the index in the mask array.</param>
        private void DecodeHelper(byte[] stegoBuf, ref short stegoCount, ref short stegoIndex, ref byte stegoStep, ref long stegoOff, ref byte stegoShift, byte[] msgBuf, ref short msgCount, ref short msgIndex, ref short msgShift, ref Masks masks, ref short maskIndex)
        {
            int[] actualLimits = { masks.reg[0].limit * stegoStep, masks.reg[1].limit * stegoStep, masks.reg[2].limit };
            long curByte = stegoOff + stegoIndex;
            byte curReg = 0, mask = 0;
            byte[] byteMasks = { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };

            while (msgIndex < msgCount && stegoIndex < stegoCount)
            {
                //First calculate the current position in the data part of the cover medium. Then, accordingly, detect the region number.
                if (curByte < actualLimits[0])
                    curReg = 0;
                else if (curByte < actualLimits[1] || actualLimits[1] < 0)
                    curReg = 1;
                else
                    curReg = 2;

                if (masks.reg[curReg].mask[maskIndex])
                {
                    mask = (stegoBuf[stegoIndex] & byteMasks[stegoShift]) > 0 ? (byte)2 : (byte)1;
                    if ((stegoBuf[stegoIndex] & mask) != 0)
                        msgBuf[msgIndex] = (byte)(msgBuf[msgIndex] | byteMasks[msgShift]);
                    if (--stegoShift == 3)
                        stegoShift = 7;
                    if (--msgShift < 0)
                    {
                        ++msgIndex;
                        msgShift = 7;
                    }
                }

                if (++maskIndex == masks.reg[curReg].mask.Length)
                    maskIndex = 0;

                stegoIndex += stegoStep;
                curByte = stegoOff + stegoIndex;
                if (actualLimits[curReg] > 0 && curByte >= actualLimits[curReg])
                    maskIndex = 0;
            }
        }
    }

    /// <summary>
    /// Provides methods to create masks for the three regions in the data part of the cover/stego medium using which the salt, hash, length (of encrypted data),
    /// extension (of the file to be encoded) and encrypted data are encoded into the cover medium or decoded from the stego medium.
    /// </summary>
    internal class Masks
    {
        public struct Region
        {
            public bool[] mask;
            public bool[] cumMask;
            public int limit;
        };
        public Region[] reg = new Region[3];

        /// <summary>
        /// Default constructor initialises the limits of the three regions to -1 which denote uninitialised region masks.
        /// </summary>
        public Masks()
        {
            reg[0].limit = reg[1].limit = reg[2].limit = -1;
        }
        
        /// <summary>
        /// Creates the mask for the first region in the data part of the cover/stego medium; and depending on the generated mask, the salt bits are encoded/decoded.
        /// Only the first 32 ones in the bit pattern of the password are considered since the salt bits are stored in the bytes (of the cover medium) which
        /// correspond to a one in the bit sequence of the password. Also, the salt is of 32 bits (4 bytes); hence, only 32 bytes of the cover medium have to be used to hide the salt bits.
        /// </summary>
        /// <param name="password">Byte array which contains bytes of the password. Should be in UTF-8 Encoding.</param>
        public void CreateFirstRegion(byte[] password)
        {
            /*
             * count is for couting number of ones.
             * length is for storing length of password.
             * index keeps track of index in password.
             * buf is the boolean buffer.
             * i denotes current index of buffer.
             * shift keeps track of the shift value.
             */
            byte count = 0, length = (byte)password.Length, index = 0; //length is a byte variable as no password would be longer than 32 characters (or bytes - UTF8 Encoding).
            bool[] buf = new bool[256];
            short i = -1, shift= 7;

            while (count < 32)  //Continue loop until the first 32 bits are found.
            {
                for (shift = 7; shift >= 0 && count < 32; --shift)  //Process a single byte from the password.
                {
                    buf[++i] = (password[index] & (1 << shift)) > 0;
                    if (buf[i])
                        ++count;
                }
                if (++index == length)  //If the whole password has been traversed and 32 ones have not been found, then go back to the first byte of password.
                    index = 0;
            }

            reg[0].limit = ++i;     //The last bit of the salt will be stored at the iTH byte in the data part of the cover medium. i+1 is taken as the limit.
            reg[0].mask = new bool[i];      //Assign empty byte arrays...
            reg[0].cumMask = new bool[i];
            Buffer.BlockCopy(buf, 0, reg[0].mask, 0, i);    //Copy only the used part of the buffer.
            Buffer.BlockCopy(buf, 0, reg[0].cumMask, 0, i);
        }

        /// <summary>
        /// Creates the masks for the second and third region in the data part of the cover medium; depending on the region id. Also updates the cumulative and pseudo-mask of the previous regions.
        /// </summary>
        /// <param name="mask">Byte array which contains the bit pattern required to generate masks.</param>
        /// <param name="regId">The region id is 2 for region#2 and 3 for region#3. These are the only valid regions accepted.</param>
        /// <param name="invert">true if the bit pattern has to be inverted, otherwise false. The bit pattern may need
        /// to be inverted if the number of ones are lesser than the number of zeros in the bit pattern.</param>
        public void CreateRegion(byte[] mask, byte regId, bool invert = false)
        {
            byte cur = (byte)(regId - 1);   //Get position in masks array. Reg#2 corresponds to position 1 in the masks array.
            reg[cur].mask = new bool[mask.Length * 8];  //Allocate memory.
            short shift, i = -1, count = 0; //shift denotes the shift value, i denotes index position in the boolean mask, count keeps track of the number of ones in the bit pattern.

            //Construct mask for region denoted by regId.
            foreach (byte b in mask)
                for (shift = 7; shift >= 0; --shift)
                {
                    reg[cur].mask[++i] = (b & (1 << shift)) > 0;
                    if (reg[cur].mask[i])
                        ++count;
                }

            //Invert mask sequence if number of ones is lesser than half the mask length.
            if (invert && count < reg[cur].mask.Length / 2)
                for (; i >= 0; --i)
                    reg[cur].mask[i] = !reg[cur].mask[i];

            //Construct cumMask (cumulative mask) only if it is the second region; it is of no use in the third region as it is the last region.
            if (regId == 2)
            {
                reg[1].cumMask = new bool[mask.Length * 8];
                Buffer.BlockCopy(reg[1].mask, 0, reg[1].cumMask, 0, reg[1].cumMask.Length);
            }

            //Reconstruct pseudo-mask and cumMask for previous regions.
            for (short j = (byte)(cur - 1), k = 0; j >= 0; --j)
            {
                short len = (short)reg[j].mask.Length, limLen = (byte)reg[cur].mask.Length;
                for (i = 0; i < len; ++i, ++k)
                {
                    if (limLen == k)
                        k = 0;
                    reg[j].mask[i] = !reg[j].cumMask[i] && reg[cur].mask[k];
                    reg[j].cumMask[i] = reg[j].cumMask[i] || reg[cur].mask[k];
                }
            }
        }
    }

    /// <summary>
    /// Contains  member variables that are used to store essential metadata required for encoding the message. Also provides methods which initialise those member variables to proper values.
    /// </summary>
    internal class Metadata
    {
        public byte[] password, salt = new byte[4], hash = new byte[32], hashLenExt = new byte[40];
        public string encDataPath;

        /// <summary>
        /// Initialises required metadata like the password, salt, hash, length, extension (of the file to be encoded) and encrypts the message file and stores the path of the encrypted file for later use.
        /// Note: Password and extension can be sent as is - those will be converted to compatible forms. Ensure that the message is in a file. If the input is from a textbox, write the 
        /// contents to a temporary file and send the path of that temporary file. Save the contents of the textbox in UTF-8 encoding to save the unused upper byte in case of Unicode encoding.
        /// </summary>
        /// <param name="passwd">Password as entered by the user. Will be converted into a byte array of the UTF-8 representation of the string sent.</param>
        /// <param name="inputMsgPath">Path to the unencrypted, input message file. If input is from a textbox, save the contents to a temporary file and send the path of that temporary file.</param>
        /// <param name="extension">Extension of the input message file. If input is from a textbox, send extension as ".TXT". If input is from a file, send result of Path.GetExtension(FILE). Will be converted to a compatible 4 bytes long extension.</param>
        public void FillData(string passwd, string inputMsgPath, string extension)
        {
            //Initialise password array.
            password = Encoding.UTF8.GetBytes(passwd);

            //Get a salt...
            if (Program.saltID == SaltID.CSRNG)
            {
                RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
                csprng.GetBytes(salt);
                csprng.Dispose();
            }
            else
            {
                RandomNumberGenerator prng = RandomNumberGenerator.Create();
                prng.GetBytes(salt);
                prng.Dispose();
            }

            //Concatenate password and salt in a byte array.
            byte[] passAndSalt = new byte[password.Length + salt.Length];
            Buffer.BlockCopy(password, 0, passAndSalt, 0, password.Length);
            Buffer.BlockCopy(salt, 0, passAndSalt, password.Length, salt.Length);

            //Calculate hash.
            byte[] IV = new byte[16];
            if (Program.hashID == HashID.SHA256)
            {
                SHA256Managed shaHash = new SHA256Managed();
                hash = shaHash.ComputeHash(passAndSalt);
                Buffer.BlockCopy(shaHash.ComputeHash(salt), 0, IV, 0, IV.Length);
                shaHash.Dispose();
            }
            else if(Program.hashID == HashID.MD5)
            {
                MD5 md5Hash = MD5.Create();
                hash = md5Hash.ComputeHash(passAndSalt);
                Buffer.BlockCopy(md5Hash.ComputeHash(salt), 0, IV, 0, IV.Length);
                md5Hash.Dispose();
            }
            else
            {
                SHA384Managed sha384Hash = new SHA384Managed();
                byte[] hashInter = sha384Hash.ComputeHash(passAndSalt);
                Buffer.BlockCopy(hashInter, 0, hash, 0, hash.Length);
                Buffer.BlockCopy(hashInter, hash.Length, IV, 0, IV.Length);
                sha384Hash.Dispose();
            }
            int len = EnDeCrypt(inputMsgPath, hash, IV);
            
            //Convert extension to a compatible form.
            byte[] ext = new byte[4];
            if (extension.Length > 5)       //If extension has more than 4 characters.
                ext = Encoding.UTF8.GetBytes(extension.Substring(1, 4));
            else if (extension.Length > 0)  //If extension has 1 to 4 characters.
            {
                extension = extension.Substring(1);
                Buffer.BlockCopy(Encoding.UTF8.GetBytes(extension), 0, ext, 0, extension.Length);
            }
            Buffer.BlockCopy(hash, 0, hashLenExt, 0, hash.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(len), 0, hashLenExt, hash.Length, sizeof(int));
            Buffer.BlockCopy(ext, 0, hashLenExt, hash.Length + sizeof(int), ext.Length);
        }

        /// <summary>
        /// Encrypts the input message file using the key and initialisation vector passed to it and saves the encrypted data in a string variable passed to it.
        /// </summary>
        /// <param name="inMsgPath">Path of the input message file.</param>
        /// <param name="key">The 256 bit key used for encryption.</param>
        /// <param name="IV">The 128 bit Initialisation Vector used for encryption.</param>
        /// <param name="encrypt">True if encryption has to be performed, false if decryption has to be performed.</param>
        /// <returns>Length (number of bytes) of the generated encrypted message file.</returns>
        public int EnDeCrypt(string inMsgPath, byte[] key, byte[] IV, bool encrypt= true)
        {
            encDataPath = Path.GetTempFileName();

            int blockSize;
            RijndaelManaged rjndl;
            TripleDESCryptoServiceProvider tdes;

            FileStream fin = new FileStream(inMsgPath, FileMode.Open);
            FileStream fout = new FileStream(encDataPath, FileMode.Open);
            fout.SetLength(0);
            CryptoStream cStream;

            if (Program.cryptID == CryptID.TDES)
            {
                tdes = new TripleDESCryptoServiceProvider();
                tdes.KeySize = 128;
                tdes.BlockSize = 64;
                tdes.Mode = CipherMode.CBC;
                Buffer.BlockCopy(key, 0, tdes.Key, 0, tdes.KeySize / 8);
                Buffer.BlockCopy(IV, 0, tdes.IV, 0, tdes.BlockSize / 8);
                blockSize = tdes.BlockSize / 8;

                if (encrypt)
                    cStream = new CryptoStream(fout, tdes.CreateEncryptor(), CryptoStreamMode.Write);
                else
                    cStream = new CryptoStream(fout, tdes.CreateDecryptor(), CryptoStreamMode.Write);
            }
            else;
            {
                rjndl = new RijndaelManaged();
                rjndl.KeySize = 256;
                rjndl.BlockSize = 128;
                rjndl.Mode = CipherMode.CBC; //Use Cipher Block Chaining Technique for file encryption.
                rjndl.Key = key;
                rjndl.IV = IV;
                blockSize = rjndl.BlockSize / 8;

                if (encrypt)
                    cStream = new CryptoStream(fout, rjndl.CreateEncryptor(), CryptoStreamMode.Write);
                else
                    cStream = new CryptoStream(fout, rjndl.CreateDecryptor(), CryptoStreamMode.Write);
            }

            int count = 0;
            byte[] data = new byte[blockSize];

            while ((count = fin.Read(data, 0, blockSize)) > 0)
                cStream.Write(data, 0, count);

            fin.Close();
            cStream.FlushFinalBlock();
            int len = (int)fout.Length;
            cStream.Close();
            fout.Close();
            return len;
        }

        /*public int EnDeCrypt(string inMsgPath, byte[] key, byte[] IV, bool encrypt= true)
        {
            encDataPath = Path.GetTempFileName();
            RijndaelManaged rjndl = new RijndaelManaged();
            rjndl.KeySize = 256;
            rjndl.BlockSize = 128;
            rjndl.Mode = CipherMode.CBC; //Use Cipher Block Chaining Technique for file encryption.
            rjndl.Key = key;
            rjndl.IV = IV;

            FileStream fin = new FileStream(inMsgPath, FileMode.Open);
            FileStream fout = new FileStream(encDataPath, FileMode.Open);
            CryptoStream encrypted;
            if(encrypt)
                encrypted= new CryptoStream(fout, rjndl.CreateEncryptor(), CryptoStreamMode.Write);
            else
                encrypted = new CryptoStream(fout, rjndl.CreateDecryptor(), CryptoStreamMode.Write);

            int count = 0, blockSize= rjndl.BlockSize/8;
            byte[] data = new byte[blockSize];

            while ((count = fin.Read(data, 0, blockSize)) > 0)
                encrypted.Write(data, 0, count);

            fin.Close();
            encrypted.FlushFinalBlock();
            int len = (int)fout.Length;
            encrypted.Close();
            fout.Close();
            return len;
        }*/
    }

    /// <summary>
    /// Provides methods to read from and write to the locked bytes of an image into/from a buffer.
    /// </summary>
    internal class ImageRW
    {
        /// <summary>
        /// Reads from the locked bytes of the image into a buffer.
        /// </summary>
        /// <param name="scan0">Byte pointer which points to the first scan line of the image.</param>
        /// <param name="cur">Current byte index in the locked bytes to be copied.</param>
        /// <param name="end"></param>
        /// <param name="lineEnd"></param>
        /// <param name="padding"></param>
        /// <param name="stride"></param>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        public unsafe static void Read(ref byte* scan0, ref long cur, ref long end, ref long lineEnd, ref byte padding, int stride, byte[] buffer, ref short count)
        {
            long stop = 0;
            for (count = 0; count < buffer.Length && cur < end; )
            {
                //If remaining bytes in buffer greater than the number of bytes in a line, then read till end of line. Else, read as many bytes as left.
                stop = (buffer.Length - count) > (lineEnd - cur) ? lineEnd : (cur + buffer.Length - count);
                for (; cur < stop; ++cur, ++count)
                    buffer[count] = scan0[cur];
                if (cur == lineEnd)
                {
                    lineEnd += stride;
                    cur += padding;
                }
            }
        }

        /// <summary>
        /// Writes to the locked bytes of the image from the buffer.
        /// </summary>
        /// <param name="scan0"></param>
        /// <param name="pos"></param>
        /// <param name="end"></param>
        /// <param name="lineEnd"></param>
        /// <param name="stride"></param>
        /// <param name="padding"></param>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        public unsafe static void Write(ref byte* scan0, ref long pos, ref long end, ref long lineEnd, int stride, ref byte padding, byte[] buffer, ref short index)
        {
            long stop = 0;
            for (short i = 0; pos < end && i < index; )
            {
                stop = lineEnd < end ? lineEnd : end;
                for (; pos < stop; ++pos, ++i)
                    scan0[pos] = buffer[i];
                if (pos == lineEnd)
                {
                    lineEnd += stride;
                    pos += padding;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class Audio
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="absOff"></param>
        /// <param name="dataSize"></param>
        /// <param name="step"></param>
        public static void Detect(ref string path, ref long absOff, ref long dataSize, ref byte step)
        {
            FileStream audFile = new FileStream(path, FileMode.Open);
            byte[] buf = new byte[4];
            uint chunkID = 0, chunkSize = 0;

            if (string.Compare(Path.GetExtension(path).Substring(1, 3), "WAV", true) == 0)    //WAVE file.
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
                    if (chunkID != ChunkIDs.WAVE_fmt)
                        audFile.Seek(chunkSize, SeekOrigin.Current);
                } while (chunkID != ChunkIDs.WAVE_fmt);
                audFile.Seek(14, SeekOrigin.Current);   //Skip over unnecessary details to the BitsPerSample property.

                ushort bitsPerSample = 0;
                audFile.Read(buf, 0, 2);
                bitsPerSample = BitConverter.ToUInt16(buf, 0);
                step = (byte)(bitsPerSample >> 3);
                if ((bitsPerSample & 7) > 0)
                    ++step;

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
                } while (chunkID != ChunkIDs.WAVE_data);
                dataSize = chunkSize;
                absOff = audFile.Position;
            }
            else    //AIFF File.
            {
                audFile.Seek(8, SeekOrigin.Begin);
                audFile.Read(buf, 0, 4);
                uint type = BitConverter.ToUInt32(buf, 0);
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
                } while (chunkID != ChunkIDs.AIFF_COMM);
                audFile.Seek(6, SeekOrigin.Current);

                ushort bitsPerSample = 0;
                audFile.Read(buf, 0, 2);
                Array.Reverse(buf);
                bitsPerSample = BitConverter.ToUInt16(buf, 2);
                step = (byte)(bitsPerSample >> 3);
                if ((bitsPerSample & 7) > 0)
                    ++step;

                if (type == ChunkIDs.AIFF_AIFC)
                {
                    audFile.Seek(10, SeekOrigin.Current);
                    audFile.Read(buf, 0, 4);
                    type = BitConverter.ToUInt32(buf, 0);
                }

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
                } while (chunkID != ChunkIDs.AIFF_SSND);
                dataSize = chunkSize;
                if (type == ChunkIDs.AIFF_AIFF || type == ChunkIDs.AIFF_NONE)
                    absOff = audFile.Position + step - 1;
                else
                    absOff = audFile.Position;
            }
            audFile.Close();
            audFile.Dispose();
        }
    }
}