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
using BLL.serviceSanPham;
using BLL;
using DevExpress.XtraBars;

namespace GUI
{
    public partial class frmCapNhatSanPham : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllSanPham bllSanPham = new bllSanPham();
        bllLoaiSanPham bllLoaiSanPham = new bllLoaiSanPham();
        SANPHAM sp = new SANPHAM();

        public frmCapNhatSanPham(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            InitializeComponent();

			cboMaLoai.DataSource = bllLoaiSanPham.getAll();
			cboMaLoai.ValueMember = "MALOAISP";
			cboMaLoai.DisplayMember = "TENLOAISP";


			//Khởi tạo giá trị cho sp
			sp.MASP = MaSP;
            sp.TENSP = TenSP;
            sp.MALOAISP = MaLoaiSP;
            sp.DONGIA = DonGia;
            sp.HinhAnh = HinhAnh;

            //gán giá trị cho controls
            txtTenSP.Text = TenSP;
            txtMaSP.Text = MaSP;
            txtDonGia.Text = DonGia.ToString();
            txtHinhAnh.Text = HinhAnh;

            //gán sự kiện
            bbiSave.ItemClick += clickSave;
            bbiReset.ItemClick += clickReset;
            bbiClose.ItemClick += clickClose;
			Load += load;

            FormClosing += frmCloing;
        }

		private void load(object ob, EventArgs e)
		{
			cboMaLoai.SelectedValue = sp.MALOAISP;
		}

        private void frmCloing(object sender, FormClosingEventArgs e)
        {

            ((frmSanPham)MdiParent).capnhat();
            ((frmSanPham)MdiParent).showControls();
        }

        private void clickSave(object ob, ItemClickEventArgs e)
        {
            if (bllSanPham.updateSanPham(txtMaSP.Text, cboMaLoai.SelectedValue.ToString(), txtTenSP.Text,int.Parse(txtDonGia.Text), txtHinhAnh.Text))
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
            txtMaSP.Text = sp.MASP;
			cboMaLoai.SelectedValue = sp.MALOAISP;
			txtTenSP.Text = sp.TENSP;
            txtDonGia.Text = sp.DONGIA.ToString();
            txtHinhAnh.Text = sp.HinhAnh;
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