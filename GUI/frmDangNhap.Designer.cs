namespace GUI
{
    partial class frmDangNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.checkPasswordShow = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.SuspendLayout();
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.Location = new System.Drawing.Point(17, 100);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(292, 35);
            this.txtTenDangNhap.TabIndex = 0;
            this.txtTenDangNhap.Text = "Tên đăng nhập";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(17, 147);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(292, 35);
            this.txtMatKhau.TabIndex = 1;
            this.txtMatKhau.Text = "Mật khẩu";
            this.txtMatKhau.UseSystemPasswordChar = true;
            // 
            // checkPasswordShow
            // 
            this.checkPasswordShow.AutoSize = true;
            this.checkPasswordShow.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkPasswordShow.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPasswordShow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkPasswordShow.Location = new System.Drawing.Point(166, 197);
            this.checkPasswordShow.Name = "checkPasswordShow";
            this.checkPasswordShow.Size = new System.Drawing.Size(143, 25);
            this.checkPasswordShow.TabIndex = 3;
            this.checkPasswordShow.Text = "Hiện mật khẩu";
            this.checkPasswordShow.UseVisualStyleBackColor = true;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.Bisque;
            this.btnDangNhap.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.Location = new System.Drawing.Point(12, 246);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(297, 53);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 76);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Tan;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 336);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(331, 80);
            this.panel2.TabIndex = 5;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Coffee";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 416);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.checkPasswordShow);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.CheckBox checkPasswordShow;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}