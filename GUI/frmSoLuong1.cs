using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class frmSoLuong1 : DevExpress.XtraEditors.XtraForm
    {
        frmGoiMon frmmon;

        public frmSoLuong1(frmGoiMon frm)
        {
            InitializeComponent();
            frmmon = frm;
        }

        private bool ktra(string str)
        {
            try
            {
                if(int.Parse(str) == 0)
                {
                    MessageBox.Show("Số lượng không được bằng 0");
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ktra(textBox1.Text))
            {
                frmmon.ChiTietHoadDon(frmmon.hd.MAHOADON, frmmon.nameMa, int.Parse(textBox1.Text));
                Close();
            }
            else
            {
                MessageBox.Show("Số lượng phải là số");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}