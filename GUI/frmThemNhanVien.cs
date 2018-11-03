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
using BLL.serviceNhanVien;
using DevExpress.XtraBars;

namespace GUI
{
    public partial class frmThemNhanVien : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllNhanVien bllNhanVien = new bllNhanVien();
        bllCoSo bllCoso = new bllCoSo();
        bllLoaiNhanVien bllLoaiNhanVien = new bllLoaiNhanVien();

        public frmThemNhanVien()
        {
            InitializeComponent();

            bbiSave.ItemClick += clickSave;
            bbiReset.ItemClick += clickReset;
            bbiClose.ItemClick += clickClose;
            FormClosing += frmCloing;
            cboLoai.DataSource = bllLoaiNhanVien.getAll();
            cboLoai.ValueMember = "MALOAINV";
            cboLoai.DisplayMember = "TENLOAINV";
            cboCoSo.DataSource = bllCoso.getAll();
            cboCoSo.ValueMember = "MACS";
            cboCoSo.DisplayMember = "TENCS";
        }

        private void frmCloing(object sender, FormClosingEventArgs e)
        {

            ((frmNhanVien)MdiParent).capnhat();
            ((frmNhanVien)MdiParent).showControls();
        }

        private void clickSave(object ob, ItemClickEventArgs e)
        {
            MessageBox.Show(cboLoai.SelectedValue.ToString() + " " + cboCoSo.SelectedValue.ToString());
            switch (bllNhanVien.addNhanVien(txtMaNV.Text, cboLoai.SelectedValue.ToString(), cboCoSo.SelectedValue.ToString(), txtHoten.Text, txtSdt.Text, txtCMND.Text, txtEmail.Text, txtDiaChi.Text, txtMatKhau.Text))
            {
                case 0:
                    MessageBox.Show("Thêm thành công");
                    Close();
                    break;
                case 1:
                    MessageBox.Show("Dữ liệu không được trống");
                    return;
                case 2:
                    MessageBox.Show("Nhân viên đã có trong danh sách");
                    return;
                case 3:
                    MessageBox.Show("Thêm không thành công");
                    return;
            }
        }

        private void clickReset(object ob, ItemClickEventArgs e)
        {
            txtMaNV.Text = "";
            txtHoten.Text = "";
            txtCMND.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtMatKhau.Text = "";
            txtSdt.Text = "";
            cboCoSo.Text = "";
            cboLoai.Text = "";
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