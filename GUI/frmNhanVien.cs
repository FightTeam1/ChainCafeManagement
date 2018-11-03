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
using BLL.serviceNhanVien;

namespace GUI
{
    public partial class frmNhanVien : XtraForm
    {
        bllNhanVien bllNhanVien = new bllNhanVien();
        frmMain formMainn;

        public frmNhanVien(frmMain formMain)
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
            BindingList<NHANVIEN> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
            gridView.Columns.Remove(gridView.Columns[gridView.Columns.Count - 1]);
            gridView.Columns.Remove(gridView.Columns[gridView.Columns.Count - 1]);
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
                    frmThemNhanVien frm = new frmThemNhanVien();
                    hideControls();
                    frm.MdiParent = this;
                    frm.Show();
                    break;
                case "Edit":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    NHANVIEN nvv = (NHANVIEN)gridView.GetRow(gridView.GetSelectedRows()[0]);
                    hideControls();
                    frmCapNhatNhanVien frm1 = new frmCapNhatNhanVien(nvv.MANV, nvv.MALOAINV, nvv.MACS, nvv.HOTENNV, nvv.SDT_NV,nvv.CMND,nvv.EMAIL,nvv.DIACHI_NV,nvv.MATKHAU);
                    frm1.MdiParent = this;
                    frm1.Show();
                    break;
                case "Delete":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    NHANVIEN nvvv = (NHANVIEN)gridView.GetRow(gridView.GetSelectedRows()[0]);

                    if (bllNhanVien.deleteNhanVien(nvvv.MANV))
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

        public BindingList<NHANVIEN> GetDataSource()
        {
            BindingList<NHANVIEN> result = new BindingList<NHANVIEN>();
            foreach (NHANVIEN nv in bllNhanVien.getAll())
            {
                NHANVIEN NhanVien = new NHANVIEN();
                NhanVien.MANV = nv.MANV;
                NhanVien.HOTENNV = nv.HOTENNV;
                NhanVien.MALOAINV = nv.MALOAINV;
                NhanVien.MATKHAU = nv.MATKHAU;
                NhanVien.SDT_NV = nv.SDT_NV;
                NhanVien.CMND = nv.CMND;
                NhanVien.MACS = nv.MACS;
                NhanVien.DIACHI_NV = nv.DIACHI_NV;
                NhanVien.EMAIL = nv.EMAIL;
                result.Add(NhanVien);
            }
            return result;
        }
    }
}
