namespace GUI
{
    partial class frmCapNhatNhanVien
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.mainRibbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
			this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
			this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
			this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
			this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
			this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
			this.mainRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.mainRibbonPageGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.cboCoSo = new System.Windows.Forms.ComboBox();
			this.cboLoai = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMatKhau = new System.Windows.Forms.TextBox();
			this.txtDiaChi = new System.Windows.Forms.TextBox();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtCMND = new System.Windows.Forms.TextBox();
			this.txtSdt = new System.Windows.Forms.TextBox();
			this.txtHoten = new System.Windows.Forms.TextBox();
			this.txtMaNV = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).BeginInit();
			this.SuspendLayout();
			// 
			// mainRibbonControl
			// 
			this.mainRibbonControl.ExpandCollapseItem.Id = 0;
			this.mainRibbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mainRibbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiDelete,
            this.bbiClose});
			this.mainRibbonControl.Location = new System.Drawing.Point(0, 0);
			this.mainRibbonControl.MaxItemId = 10;
			this.mainRibbonControl.Name = "mainRibbonControl";
			this.mainRibbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.mainRibbonPage});
			this.mainRibbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
			this.mainRibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
			this.mainRibbonControl.Size = new System.Drawing.Size(725, 146);
			this.mainRibbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
			// 
			// bbiSave
			// 
			this.bbiSave.Caption = "Save";
			this.bbiSave.Id = 2;
			this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
			this.bbiSave.Name = "bbiSave";
			// 
			// bbiSaveAndClose
			// 
			this.bbiSaveAndClose.Caption = "Save And Close";
			this.bbiSaveAndClose.Id = 3;
			this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
			this.bbiSaveAndClose.Name = "bbiSaveAndClose";
			// 
			// bbiSaveAndNew
			// 
			this.bbiSaveAndNew.Caption = "Save And New";
			this.bbiSaveAndNew.Id = 4;
			this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
			this.bbiSaveAndNew.Name = "bbiSaveAndNew";
			// 
			// bbiReset
			// 
			this.bbiReset.Caption = "Reset Changes";
			this.bbiReset.Id = 5;
			this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
			this.bbiReset.Name = "bbiReset";
			// 
			// bbiDelete
			// 
			this.bbiDelete.Caption = "Delete";
			this.bbiDelete.Id = 6;
			this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
			this.bbiDelete.Name = "bbiDelete";
			// 
			// bbiClose
			// 
			this.bbiClose.Caption = "Close";
			this.bbiClose.Id = 7;
			this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
			this.bbiClose.Name = "bbiClose";
			// 
			// mainRibbonPage
			// 
			this.mainRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.mainRibbonPageGroup});
			this.mainRibbonPage.MergeOrder = 0;
			this.mainRibbonPage.Name = "mainRibbonPage";
			this.mainRibbonPage.Text = "Home";
			// 
			// mainRibbonPageGroup
			// 
			this.mainRibbonPageGroup.AllowTextClipping = false;
			this.mainRibbonPageGroup.ItemLinks.Add(this.bbiSave);
			this.mainRibbonPageGroup.ItemLinks.Add(this.bbiReset);
			this.mainRibbonPageGroup.ItemLinks.Add(this.bbiClose);
			this.mainRibbonPageGroup.Name = "mainRibbonPageGroup";
			this.mainRibbonPageGroup.ShowCaptionButton = false;
			this.mainRibbonPageGroup.Text = "Tasks";
			// 
			// cboCoSo
			// 
			this.cboCoSo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboCoSo.FormattingEnabled = true;
			this.cboCoSo.Location = new System.Drawing.Point(351, 240);
			this.cboCoSo.Name = "cboCoSo";
			this.cboCoSo.Size = new System.Drawing.Size(121, 29);
			this.cboCoSo.TabIndex = 2;
			// 
			// cboLoai
			// 
			this.cboLoai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboLoai.FormattingEnabled = true;
			this.cboLoai.Location = new System.Drawing.Point(351, 203);
			this.cboLoai.Name = "cboLoai";
			this.cboLoai.Size = new System.Drawing.Size(179, 29);
			this.cboLoai.TabIndex = 1;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(175, 461);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(83, 21);
			this.label9.TabIndex = 19;
			this.label9.Text = "Mật khẩu:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(175, 422);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(69, 21);
			this.label8.TabIndex = 18;
			this.label8.Text = "Địa chỉ:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(175, 382);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(55, 21);
			this.label7.TabIndex = 17;
			this.label7.Text = "Email:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(175, 350);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 21);
			this.label6.TabIndex = 16;
			this.label6.Text = "Số CMND:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(175, 318);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 21);
			this.label5.TabIndex = 15;
			this.label5.Text = "Số điện thoại:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(175, 281);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 21);
			this.label4.TabIndex = 20;
			this.label4.Text = "Họ tên:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(175, 243);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(85, 21);
			this.label3.TabIndex = 14;
			this.label3.Text = "Mã cơ sở:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(175, 206);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 21);
			this.label2.TabIndex = 13;
			this.label2.Text = "Mã loại nhân viên:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(175, 171);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 21);
			this.label1.TabIndex = 12;
			this.label1.Text = "Mã nhân viên:";
			// 
			// txtMatKhau
			// 
			this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMatKhau.Location = new System.Drawing.Point(351, 458);
			this.txtMatKhau.Name = "txtMatKhau";
			this.txtMatKhau.Size = new System.Drawing.Size(179, 29);
			this.txtMatKhau.TabIndex = 8;
			// 
			// txtDiaChi
			// 
			this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDiaChi.Location = new System.Drawing.Point(351, 419);
			this.txtDiaChi.Name = "txtDiaChi";
			this.txtDiaChi.Size = new System.Drawing.Size(179, 29);
			this.txtDiaChi.TabIndex = 7;
			// 
			// txtEmail
			// 
			this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEmail.Location = new System.Drawing.Point(351, 379);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(179, 29);
			this.txtEmail.TabIndex = 6;
			// 
			// txtCMND
			// 
			this.txtCMND.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCMND.Location = new System.Drawing.Point(351, 347);
			this.txtCMND.Name = "txtCMND";
			this.txtCMND.Size = new System.Drawing.Size(179, 29);
			this.txtCMND.TabIndex = 5;
			// 
			// txtSdt
			// 
			this.txtSdt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSdt.Location = new System.Drawing.Point(351, 315);
			this.txtSdt.Name = "txtSdt";
			this.txtSdt.Size = new System.Drawing.Size(179, 29);
			this.txtSdt.TabIndex = 4;
			// 
			// txtHoten
			// 
			this.txtHoten.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHoten.Location = new System.Drawing.Point(351, 278);
			this.txtHoten.Name = "txtHoten";
			this.txtHoten.Size = new System.Drawing.Size(179, 29);
			this.txtHoten.TabIndex = 3;
			// 
			// txtMaNV
			// 
			this.txtMaNV.Enabled = false;
			this.txtMaNV.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMaNV.Location = new System.Drawing.Point(351, 168);
			this.txtMaNV.Name = "txtMaNV";
			this.txtMaNV.Size = new System.Drawing.Size(179, 29);
			this.txtMaNV.TabIndex = 0;
			// 
			// frmCapNhatNhanVien
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ClientSize = new System.Drawing.Size(725, 518);
			this.Controls.Add(this.cboCoSo);
			this.Controls.Add(this.cboLoai);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtMatKhau);
			this.Controls.Add(this.txtDiaChi);
			this.Controls.Add(this.txtEmail);
			this.Controls.Add(this.txtCMND);
			this.Controls.Add(this.txtSdt);
			this.Controls.Add(this.txtHoten);
			this.Controls.Add(this.txtMaNV);
			this.Controls.Add(this.mainRibbonControl);
			this.Name = "frmCapNhatNhanVien";
			this.Ribbon = this.mainRibbonControl;
			((System.ComponentModel.ISupportInitialize)(this.mainRibbonControl)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonControl mainRibbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage mainRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup mainRibbonPageGroup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private System.Windows.Forms.ComboBox cboCoSo;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.TextBox txtSdt;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.TextBox txtMaNV;
    }
}