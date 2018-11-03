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
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraBars;
using BLL;
using BLL.serviceSanPham;

namespace GUI
{
    public partial class frmSanPham : XtraForm
    {
        public bllSanPham bllSanPham = new bllSanPham();
        private frmMain formMainn;

        public frmSanPham(frmMain formMain)
        {
            InitializeComponent();

            capnhat();
            this.formMainn = formMain;
            formMainn.Hide();

            FormClosing += frmClosing;
        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {
            formMainn.Show();
        }
        public void capnhat()
        {
            BindingList<SANPHAM> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
        }

        public void hideControls()
        {
            layoutControl.Hide();
            windowsUIButtonPanel.Hide();
        }

        public void showControls()
        {
            layoutControl.Show();
            windowsUIButtonPanel.Show();
        }

        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Print":
                    gridControl.ShowRibbonPrintPreview();
                    break;
                case "New":
                    frmThemSanPham frm = new frmThemSanPham();
                    hideControls();
                    frm.MdiParent = this;
                    frm.Show();
                    break;
                case "Edit":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    SANPHAM spp = (SANPHAM)gridView.GetRow(gridView.GetSelectedRows()[0]);
                    hideControls();
                    frmCapNhatSanPham frm1 = new frmCapNhatSanPham(spp.MASP,spp.MALOAISP,spp.TENSP,(int)spp.DONGIA,spp.HinhAnh);
                    frm1.MdiParent = this;
                    frm1.Show();
                    break;
                case "Delete":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    SANPHAM sppp = (SANPHAM)gridView.GetRow(gridView.GetSelectedRows()[0]);

                    if (bllSanPham.deleteSanPham(sppp.MASP))
                    {
                        MessageBox.Show("Xóa thành công");
                        capnhat();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                    break;
                case "Refresh":
                    capnhat();
                    break;
            }
        }

        public BindingList<SANPHAM> GetDataSource()
        {
            BindingList<SANPHAM> result = new BindingList<SANPHAM>();
            foreach (SANPHAM sp in bllSanPham.getAll())
            {
                SANPHAM SanPham = new SANPHAM();
                SanPham.MASP = sp.MASP;
                SanPham.TENSP = sp.TENSP;
                SanPham.MALOAISP = sp.MALOAISP;
                SanPham.DONGIA = sp.DONGIA;
                SanPham.HinhAnh = sp.HinhAnh;
                result.Add(SanPham);
            }
            return result;
        }
    }
}
