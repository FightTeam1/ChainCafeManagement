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
using BLL.serviceLoaiSanPham;
using System.Net;

namespace GUI
{
    public partial class frmThemLoaiSanPham : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllLoaiSanPham bllLoaiSanPham = new bllLoaiSanPham();
        string hinhanh = string.Empty;

        public frmThemLoaiSanPham()
        {
            InitializeComponent();

            bbiSave.ItemClick += clickSave;
            bbiReset.ItemClick += clickReset;
            bbiClose.ItemClick += clickClose;
            btnBrowse.Click += btnBrowse_Click;
            FormClosing += frmCloing;
        }

        private void frmCloing(object sender, FormClosingEventArgs e)
        {

            ((frmLoaiSanPham)MdiParent).capnhat();
            ((frmLoaiSanPham)MdiParent).showControls();
        }

        private void clickSave(object ob, ItemClickEventArgs e)
        {
            switch (bllLoaiSanPham.addLoaiSP(txtMaLoai.Text, txtTenLoai.Text, hinhanh))
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
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
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
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open File";
            openFileDialog1.Filter = "All Files|*.*";
            openFileDialog1.FileName = "";

            try
            {
                openFileDialog1.InitialDirectory = "C:\\Temp";
            }
            catch
            {
                // skip it
            }

            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName == "")
                return;
            else
            {
                if (openFileDialog1.FileName != string.Empty)
                {
                    hinhanh = bllLoaiSanPham.UploadFile(openFileDialog1.FileName);
                    pictureBox1.ImageLocation = openFileDialog1.FileName;

                    Image item;
                    var request = WebRequest.Create("http://35.185.83.140/ChainCafeManagerment/" + hinhanh);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream()) { item = resizeImage(Bitmap.FromStream(stream), new Size(173, 114)); }
                    pictureBox1.Image = item;
                }
            }
        }

        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}