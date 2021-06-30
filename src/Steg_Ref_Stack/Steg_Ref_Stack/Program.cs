using System;
using System.Windows.Forms;
using Constants;
using System.Drawing;


namespace Steg_Ref_Stack
{
    static class Program
    {
        public static byte curFormId = 0, nextFormId = FormId.frm_main;
        public static Bitmap image= null;
        public static string message= null;
        public static Icon msgIcon;
        public static string msgPath;
        public static string msgExt;
        public static string decodecover;
        public static bool encOutput;
        public static bool decOutput;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       [STAThread]
        static void Main()
        {
            Form frm; 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while(curFormId!=nextFormId)
            {
                curFormId = nextFormId;
                if (curFormId == FormId.frm_main)
                    frm = new frm_main();
                else if (curFormId == FormId.frm_encode)
                    frm = new frm_encode();
                else
                    frm = new frm_decode();
                Application.Run(frm);
            }
        }

    }
}
