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
using BLL;

namespace GUI
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        bllDangNhap bllDangNhap = new bllDangNhap();
        int index;

        public frmDangNhap(int index)
        {
            InitializeComponent();
            txtTenDangNhap.Click += clickTextBox;
            txtTenDangNhap.Leave += leaveTenDangNhap;
            txtMatKhau.Click += clickTextBox;
            txtMatKhau.Leave += leaveMatKhau;
            checkPasswordShow.CheckedChanged += changeCheck;
            btnDangNhap.Click += clickDangNhap;
            this.index = index;
            FormClosing += formClosing;
        }

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void reset()
        {
            txtMatKhau.Text = "Mật khẩu";
            txtTenDangNhap.Text = "Tên đăng nhập";
        }


        #region Sự kiện của Controls

        private void clickTextBox(object sender, EventArgs e) //Sự kiện click của TextBox
        {
            ((TextBox)sender).Text = "";
        }

        private void leaveTenDangNhap(object sender, EventArgs e) //Sự kiện bỏ focus TextBox tên đăng nhập
        {
            if (((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).Text = "Tên đăng nhập";
            }
        }

        private void leaveMatKhau(object sender, EventArgs e) //Sự kiện bỏ focus TextBox mật khẩu
        {
            if (((TextBox)sender).Text == string.Empty)
            {
                ((TextBox)sender).Text = "Mật khẩu";
            }
        }

        private void changeCheck(object sender, EventArgs e) //Sự kiện thay đổi check
        {
            if (((CheckBox)sender).Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void clickDangNhap(object sender, EventArgs e) //Sự kiện click của btn đăng nhập
        {
            switch (bllDangNhap.ketquaDangNhap(txtTenDangNhap.Text, txtMatKhau.Text))
            {
                case 0:
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                    this.MdiParent.Controls[index].Show();
                    this.Hide();
                    return;
                case 1:
                    MessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo");
                    return;
                case 2:
                    MessageBox.Show("Sai mật khẩu", "Thông báo");
                    return;
            }
        }

        #endregion

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}