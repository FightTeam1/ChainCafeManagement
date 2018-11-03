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
using BLL.serviceLoaiSanPham;

namespace GUI
{
    public partial class frmLoaiSanPham : XtraForm
    {
        public bllLoaiSanPham bllLoaiSanPham = new bllLoaiSanPham();
        private frmMain formMainn;

        public frmLoaiSanPham(frmMain formMain)
        {
            InitializeComponent();

            gridControl.DataSource = GetDataSource();

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
            BindingList<LOAISP> dataSource = GetDataSource();
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
                    frmThemLoaiSanPham frm = new frmThemLoaiSanPham();
                    hideControls();
                    frm.MdiParent = this;
                    frm.Show();
                    break;
                case "Edit":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    LOAISP spp = (LOAISP)gridView.GetRow(gridView.GetSelectedRows()[0]);
                    hideControls();
                    frmCapNhatLoaiSanPham frm1 = new frmCapNhatLoaiSanPham(spp.MALOAISP, spp.TENLOAISP, spp.HinhAnh);
                    frm1.MdiParent = this;
                    frm1.Show();
                    break;
                case "Delete":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    LOAISP sppp = (LOAISP)gridView.GetRow(gridView.GetSelectedRows()[0]);

                    if (bllLoaiSanPham.deleteLoaiSP(sppp.MALOAISP))
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

        public BindingList<LOAISP> GetDataSource()
        {
            BindingList<LOAISP> result = new BindingList<LOAISP>();
            foreach (LOAISP loai in bllLoaiSanPham.getAll())
            {
                LOAISP loaiSP = new LOAISP();
                loaiSP.MALOAISP = loai.MALOAISP;
                loaiSP.TENLOAISP = loai.TENLOAISP;
                loaiSP.HinhAnh = loai.HinhAnh;
                result.Add(loaiSP);
            }
            return result;
        }
    }
}
