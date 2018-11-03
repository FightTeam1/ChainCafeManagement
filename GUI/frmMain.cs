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
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
            //frmDangNhap frm = new frmDangNhap(Controls.IndexOf(tileControl1));

            //tileControl1.Hide();
            //frm.MdiParent = this;
            //frm.Location = new Point(300, 300);
            //frm.Show();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            frmGoiMon frm = new frmGoiMon(this);
            frm.Show();
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            frmLoaiSanPham frm = new frmLoaiSanPham(this);
            frm.Show();
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            frmNhanVien frm = new frmNhanVien(this);
            frm.Show();
        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            frmSanPham frm = new frmSanPham(this);
            frm.Show();
        }

        private void tileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            frmCoSo frm = new frmCoSo(this);
            frm.Show();
        }

        private void tileItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            frmReport frm = new frmReport();
            frm.Show();
        }
    }
}