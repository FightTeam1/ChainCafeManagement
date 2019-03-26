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
using BLL.serviceLoaiSanPham;
using BLL;
using DevExpress.XtraBars;

namespace GUI
{
    public partial class frmCapNhatLoaiSanPham : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllLoaiSanPham bllLoaiSanPham = new bllLoaiSanPham();
        LOAISP sp = new LOAISP();

        public frmCapNhatLoaiSanPham(string maLoaiSP, string tenLoaiSP, string hinhAnh)
        {
            InitializeComponent();

            //Khởi tạo giá trị cho sp
            sp.MALOAISP = maLoaiSP;
            sp.TENLOAISP = tenLoaiSP;
            sp.HinhAnh = hinhAnh;

            //gán giá trị cho controls
            txtMaLoai.Text = maLoaiSP;
            txtTenLoai.Text = tenLoaiSP;
            txtHinhAnh.Text = hinhAnh;

            //gán sự kiện
            bbiSave.ItemClick += clickSave;
            bbiReset.ItemClick += clickReset;
            bbiClose.ItemClick += clickClose;
            FormClosing += frmCloing;
        }

        private void frmCloing(object sender, FormClosingEventArgs e)
        {

            ((frmLoaiSanPham)MdiParent).capnhat();
            ((frmLoaiSanPham)MdiParent).showControls();
        }

        private void clickSave(object ob, ItemClickEventArgs e)
        {
            if (bllLoaiSanPham.updateLoaiSP(txtMaLoai.Text, txtTenLoai.Text, txtHinhAnh.Text))
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
            txtMaLoai.Text = sp.MALOAISP;
            txtTenLoai.Text = sp.TENLOAISP;
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