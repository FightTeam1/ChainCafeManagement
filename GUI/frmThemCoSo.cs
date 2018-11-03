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
using DevExpress.XtraBars;
using BLL;
using BLL.serviceCoSo;

namespace GUI
{
    public partial class frmThemCoSo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllCoSo bllCoso = new bllCoSo();

        public frmThemCoSo()
        {
            InitializeComponent();

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
            switch (bllCoso.addCoSo(txtMaCoSo.Text, txtTenCoSo.Text, txtDiaChi.Text, txtSdt.Text, txtHinhAnh.Text))
            {
                case 0:
                    MessageBox.Show("Thêm thành công");
                    Close();
                    break;
                case 1:
                    MessageBox.Show("Dữ liệu không được trống");
                    return;
                case 2:
                    MessageBox.Show("Mã loại sản phẩm bị trùng");
                    return;
                case 3:
                    MessageBox.Show("Thêm không thành công");
                    return;
            }
        }

        private void clickReset(object ob, ItemClickEventArgs e)
        {
            txtMaCoSo.Text = "";
            txtTenCoSo.Text = "";
            txtDiaChi.Text = "";
            txtSdt.Text = "";
            txtHinhAnh.Text = "";
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