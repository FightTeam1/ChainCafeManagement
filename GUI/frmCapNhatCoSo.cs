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
using BLL.serviceCoSo;
using DevExpress.XtraBars;

namespace GUI
{
    public partial class frmCapNhatCoSo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllCoSo bllCoso = new bllCoSo();
        COSO cs = new COSO();

        public frmCapNhatCoSo(string MaCS, string TenCS, string DiaChi, string Sdt, string HinhAnh)
        {
            InitializeComponent();


            //Khởi tạo giá trị cho sp
            cs.MACS = MaCS;
            cs.TENCS = TenCS;
            cs.DIACHI = DiaChi;
            cs.SDT = Sdt;
            cs.HinhAnh = HinhAnh;

            //gán giá trị cho controls
            txtMaCoSo.Text = cs.MACS;
            txtTenCoSo.Text = cs.TENCS;
            txtDiaChi.Text = cs.DIACHI;
            txtSdt.Text = cs.SDT;
            txtHinhAnh.Text = cs.HinhAnh;

            //gán sự kiện
            bbiSave.ItemClick += clickSave;
            bbiReset.ItemClick += clickReset;
            bbiClose.ItemClick += clickClose;
            FormClosing += frmCloing;
        }

        private void frmCloing(object sender, FormClosingEventArgs e)
        {

            ((frmCoSo)MdiParent).capnhat();
            ((frmCoSo)MdiParent).showControls();
        }

        private void clickSave(object ob, ItemClickEventArgs e)
        {
            if (bllCoso.updateCoSo(txtMaCoSo.Text, txtTenCoSo.Text, txtDiaChi.Text, txtSdt.Text, txtHinhAnh.Text))
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
            txtMaCoSo.Text = cs.MACS;
            txtTenCoSo.Text = cs.TENCS;
            txtDiaChi.Text = cs.DIACHI;
            txtSdt.Text = cs.SDT;
            txtHinhAnh.Text = cs.HinhAnh;
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