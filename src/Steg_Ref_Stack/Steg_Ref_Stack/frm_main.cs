using System;
using System.Windows.Forms;
using Constants;

namespace Steg_Ref_Stack
{
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
        }

        private void btnEncode_Click(object sender, EventArgs e)
        {
            Program.nextFormId = FormId.frm_encode;
            Close();
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            Program.nextFormId = FormId.frm_decode;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
