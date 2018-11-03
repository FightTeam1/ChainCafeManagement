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

namespace GUI
{
    public partial class frmThemLoaiSanPham : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bllLoaiSanPham bllLoaiSanPham = new bllLoaiSanPham();

        public frmThemLoaiSanPham()
        {
            InitializeComponent();

            bbiSave.ItemClick += clickSave;
            bbiReset.ItemClick += clickReset;
            bbiClose.ItemClick += clickClose;
            button1.Click += btnUpload_Click;
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
            switch (bllLoaiSanPham.addLoaiSP(txtMaLoai.Text, txtTenLoai.Text, txtHinhAnh.Text))
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

        

        /// <summary>

        /// Allow the user to browse for a file

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

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
                txtFileName.Text = openFileDialog1.FileName;
        }


        /// <summary>

        /// If the user has selected a file, send it to the upload method,

        /// the upload method will convert the file to a byte array and

        /// send it through the web service

        /// </summary>

        /// <param name="sender"></param>

        /// <param name="e"></param>

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text != string.Empty)
                txtHinhAnh.Text = bllLoaiSanPham.UploadFile(txtFileName.Text);
            else
                MessageBox.Show("You must select a file first.", "No File Selected");
        }
    }
}