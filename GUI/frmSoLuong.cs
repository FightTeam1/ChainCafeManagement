using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class frmSoLuong : DevExpress.XtraEditors.XtraUserControl
    {
        frmGoiMon frm;

        public frmSoLuong(frmGoiMon frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private bool ktra(string str)
        {
            try
            {
                int.Parse(str);

                return true;
            }
            catch
            {
                MessageBox.Show("Số lượng phải là số");
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ktra(textBox1.Text))
            {
                frm.kq = true;
                frm.sl = int.Parse(textBox1.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm.kq = false;
            this.Parent.Controls.Remove(this);
        }
    }
}
