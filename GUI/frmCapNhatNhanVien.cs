using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Helpers;
using BLL;
using DevExpress.XtraBars;
using BLL.serviceNhanVien;

namespace GUI
{
    public partial class frmCapNhatNhanVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllNhanVien bllNhanVien = new bllNhanVien();
        bllCoSo bllCoso = new bllCoSo();
        bllLoaiNhanVien bllLoaiNhanVien = new bllLoaiNhanVien();
        NHANVIEN nv = new NHANVIEN();

        public frmCapNhatNhanVien(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt, string Cmnd, string Email, string Diachi, string MatKhau)
        {
            InitializeComponent();

            //Khởi tạo giá trị cho nv
            nv.MANV = MaNV;
            nv.MALOAINV = MaLoaiNV;
            nv.MACS = MaCS;
            nv.HOTENNV = HoTenNV;
            nv.SDT_NV = Sdt;
            nv.CMND = Cmnd;
            nv.EMAIL = Email;
            nv.DIACHI_NV = Diachi;
            nv.MATKHAU = MatKhau;

            //gán giá trị cho controls
            txtMaNV.Text = MaNV;
            cboLoai.SelectedValue = MaLoaiNV;
            cboCoSo.SelectedValue = MaCS;
            txtHoten.Text = HoTenNV;
            txtSdt.Text = Sdt;
            txtCMND.Text = Cmnd;
            txtEmail.Text = Email;
            txtDiaChi.Text = Diachi;
            txtMatKhau.Text = MatKhau;

            //gán sự kiện
            bbiSave.ItemClick += clickSave;
            bbiReset.ItemClick += clickReset;
            bbiClose.ItemClick += clickClose;
            cboLoai.DataSource = bllLoaiNhanVien.getAll();
            cboLoai.ValueMember = "MALOAINV";
            cboLoai.DisplayMember = "TENLOAINV";
            cboCoSo.DataSource = bllCoso.getAll();
            cboCoSo.ValueMember = "MACS";
            cboCoSo.DisplayMember = "TENCS";
            FormClosing += frmCloing;
        }

        private void frmCloing(object sender, FormClosingEventArgs e)
        {

            ((frmNhanVien)MdiParent).capnhat();
            ((frmNhanVien)MdiParent).showControls();
        }

        private void clickSave(object ob, ItemClickEventArgs e)
        {
            if (bllNhanVien.updateNhanVien(txtMaNV.Text, cboLoai.SelectedValue.ToString(), cboCoSo.SelectedValue.ToString(), txtHoten.Text, txtSdt.Text, txtCMND.Text, txtEmail.Text, txtDiaChi.Text, txtMatKhau.Text))
            {
                MessageBox.Show("Cập nhật thành công");
                Close();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công");
            }
        }

        private void clickReset(object ob, ItemClickEventArgs e)
        {
            txtMaNV.Text = nv.MANV;
            cboLoai.SelectedValue = nv.MALOAINV;
            cboCoSo.SelectedValue = nv.MACS;
            txtHoten.Text = nv.HOTENNV;
            txtSdt.Text = nv.SDT_NV;
            txtCMND.Text = nv.CMND;
            txtEmail.Text = nv.EMAIL;
            txtDiaChi.Text = nv.DIACHI_NV;
            txtMatKhau.Text = nv.MATKHAU;
        }
            

        private void clickClose(object ob, ItemClickEventArgs e)
        {
            closeForm();
        }

        void closeForm()
        {
            DialogResult h = MessageBox.Show("Các thay đổi chưa được lưu sẽ bị mất, chắc chắn thoát?", "Thông báo", MessageBoxButtons.YesNo);
            if (h == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }
    }
}