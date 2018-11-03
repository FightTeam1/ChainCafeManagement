namespace GUI
{
    partial class frmMain
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tileItem4 = new DevExpress.XtraEditors.TileItem();
            this.tileControl1 = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem2 = new DevExpress.XtraEditors.TileItem();
            this.tileItem1 = new DevExpress.XtraEditors.TileItem();
            this.tileItem3 = new DevExpress.XtraEditors.TileItem();
            this.tileItem5 = new DevExpress.XtraEditors.TileItem();
            this.tileItem6 = new DevExpress.XtraEditors.TileItem();
            this.tileItem7 = new DevExpress.XtraEditors.TileItem();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Coffee";
            // 
            // tileItem4
            // 
            this.tileItem4.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileItem4.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement1.Text = "Gọi món";
            tileItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem4.Elements.Add(tileItemElement1);
            this.tileItem4.Id = 1;
            this.tileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem4.Name = "tileItem4";
            // 
            // tileControl1
            // 
            this.tileControl1.AllowDisabledStateIndication = false;
            this.tileControl1.AllowDrag = false;
            this.tileControl1.AllowDragTilesBetweenGroups = false;
            this.tileControl1.AllowSelectedItemBorder = false;
            this.tileControl1.AllowSmoothScrolling = false;
            this.tileControl1.AppearanceGroupText.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileControl1.AppearanceGroupText.Options.UseFont = true;
            this.tileControl1.AppearanceItem.Normal.BackColor = System.Drawing.Color.Tan;
            this.tileControl1.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileControl1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileControl1.AppearanceItem.Normal.Options.UseFont = true;
            this.tileControl1.AppearanceText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileControl1.AppearanceText.Options.UseFont = true;
            this.tileControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tileControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl1.Groups.Add(this.tileGroup2);
            this.tileControl1.Location = new System.Drawing.Point(0, 0);
            this.tileControl1.MaxId = 10;
            this.tileControl1.Name = "tileControl1";
            this.tileControl1.ShowGroupText = true;
            this.tileControl1.ShowText = true;
            this.tileControl1.Size = new System.Drawing.Size(893, 638);
            this.tileControl1.TabIndex = 0;
            this.tileControl1.Text = "Cafe Chain";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItem2);
            this.tileGroup2.Items.Add(this.tileItem1);
            this.tileGroup2.Items.Add(this.tileItem3);
            this.tileGroup2.Items.Add(this.tileItem5);
            this.tileGroup2.Items.Add(this.tileItem6);
            this.tileGroup2.Items.Add(this.tileItem7);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileItem2
            // 
            this.tileItem2.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileItem2.AppearanceItem.Normal.Options.UseFont = true;
            tileItemElement2.Text = "Gọi món";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem2.Elements.Add(tileItemElement2);
            this.tileItem2.Id = 1;
            this.tileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem2.Name = "tileItem2";
            this.tileItem2.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem2_ItemClick);
            // 
            // tileItem1
            // 
            tileItemElement3.Text = "Loại sản phẩm";
            tileItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem1.Elements.Add(tileItemElement3);
            this.tileItem1.Id = 4;
            this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem1.Name = "tileItem1";
            this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem1_ItemClick);
            // 
            // tileItem3
            // 
            tileItemElement4.Text = "Nhân viên";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem3.Elements.Add(tileItemElement4);
            this.tileItem3.Id = 5;
            this.tileItem3.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem3.Name = "tileItem3";
            this.tileItem3.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem3_ItemClick);
            // 
            // tileItem5
            // 
            tileItemElement5.Text = "Sản phẩm";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem5.Elements.Add(tileItemElement5);
            this.tileItem5.Id = 6;
            this.tileItem5.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem5.Name = "tileItem5";
            this.tileItem5.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem5_ItemClick);
            // 
            // tileItem6
            // 
            tileItemElement6.Text = "Cơ sở";
            tileItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem6.Elements.Add(tileItemElement6);
            this.tileItem6.Id = 7;
            this.tileItem6.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem6.Name = "tileItem6";
            this.tileItem6.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem6_ItemClick);
            // 
            // tileItem7
            // 
            tileItemElement7.Text = "Đăng xuất";
            tileItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem7.Elements.Add(tileItemElement7);
            this.tileItem7.Id = 9;
            this.tileItem7.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem7.Name = "tileItem7";
            this.tileItem7.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem7_ItemClick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 638);
            this.Controls.Add(this.tileControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.TileControl tileControl1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileItem2;
        private DevExpress.XtraEditors.TileItem tileItem1;
        private DevExpress.XtraEditors.TileItem tileItem3;
        private DevExpress.XtraEditors.TileItem tileItem4;
        private DevExpress.XtraEditors.TileItem tileItem5;
        private DevExpress.XtraEditors.TileItem tileItem6;
        private DevExpress.XtraEditors.TileItem tileItem7;
    }
}