namespace Constants
{
    /// <summary>
    /// Defines constants related to size of buffers used during file read/write operations.
    /// </summary>
    public class FileBufs
    {
        /// <summary>
        /// Specifies a standard buffer size. It is set to 4096 bytes as that is the default allocation unit (cluster) 
        /// size for the NTFS file system. Since this application is for Windows-based systems and since most
        /// Windows-based systems use NTFS; reading in unit clusters would be faster and more efficient.
        /// </summary>
        public const short BUF_SIZE = 4096;
        /// <summary>
        /// Specifies the buffer size to be used when reading from, or writing to, the encrypted data (or message) file.
        /// </summary>
        public const short MSG_BUF_SIZE = 4096;
        /// <summary>
        /// Specifies the buffer size to be used when reading from, or writing to, the cover (audio or image) file.
        /// </summary>
        public const short COVER_BUF_SIZE = 8192;
    }

    public class FormId
    {
        public const byte frm_main = 1;
        public const byte frm_encode = 2;
        public const byte frm_decode = 3;
    }

    public class SaltID
    {
        public const int CSRNG = 0;
        public const int PRNG = 1;
    }

    public class HashID
    {
        public const int SHA256 = 0;
        public const int MD5 = 1;
        public const int SHA384 = 2;
    }

    public class CryptID
    {
        public const int AES = 0;
        public const int TDES = 1;
    }

    public class ChunkIDs
    {
        public const uint WAVE_RIFF = 1179011410;
        public const uint WAVE_WAVE = 1163280727;
        public const uint WAVE_fmt = 544501094;
        public const uint WAVE_data = 1635017060;
        public const uint WAVE_LPCM = 1;

        public const uint AIFF_FORM = 1297239878;
        public const uint AIFF_AIFF = 1179011393;
        public const uint AIFF_AIFC = 1128679745;
        public const uint AIFF_COMM = 1296912195;
        public const uint AIFF_SOWT = 1953984371;
        public const uint AIFF_NONE = 1162760014;
        public const uint AIFF_SSND = 1145983827;
    }
}