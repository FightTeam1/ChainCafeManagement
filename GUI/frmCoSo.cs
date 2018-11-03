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
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraBars;
using BLL;
using BLL.serviceCoSo;

namespace GUI
{
    public partial class frmCoSo : XtraForm
    {
        bllCoSo bllCoSo = new bllCoSo();
        private frmMain formMainn;

        public frmCoSo(frmMain formMain)
        {
            InitializeComponent();

            gridControl.DataSource = GetDataSource();
            this.formMainn = formMain;
            formMainn.Hide();

            FormClosing += frmClosing;
        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {
            formMainn.Show();
        }
        public void capnhat()
        {
            BindingList<COSO> dataSource = GetDataSource();
            gridControl.DataSource = dataSource;
        }

        public void hideControls()
        {
            layoutControl.Hide();
            windowsUIButtonPanel.Hide();
        }

        public void showControls()
        {
            layoutControl.Show();
            windowsUIButtonPanel.Show();
        }

        void windowsUIButtonPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Print":
                    gridControl.ShowRibbonPrintPreview();
                    break;
                case "New":
                    frmThemCoSo frm = new frmThemCoSo();
                    hideControls();
                    frm.MdiParent = this;
                    frm.Show();
                    break;
                case "Edit":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    COSO coso = (COSO)gridView.GetRow(gridView.GetSelectedRows()[0]);
                    hideControls();
                    frmCapNhatCoSo frm1 = new frmCapNhatCoSo(coso.MACS,coso.TENCS,coso.DIACHI,coso.SDT,coso.HinhAnh);
                    frm1.MdiParent = this;
                    frm1.Show();
                    break;
                case "Delete":
                    gridView.SelectRow(gridView.GetSelectedRows()[0]);
                    COSO cosoo = (COSO)gridView.GetRow(gridView.GetSelectedRows()[0]);

                    if (bllCoSo.deleteCoSo(cosoo.MACS))
                    {
                        MessageBox.Show("Xóa thành công");
                        capnhat();
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công");
                    }
                    break;
                case "Refresh":
                    capnhat();
                    break;
            }
        }

        public BindingList<COSO> GetDataSource()
        {
            BindingList<COSO> result = new BindingList<COSO>();
            foreach (COSO coSo in bllCoSo.getAll())
            {
                COSO coso = new COSO();
                coso.MACS = coSo.MACS;
                coso.TENCS = coSo.TENCS;
                coso.DIACHI = coSo.DIACHI;
                coso.SDT = coSo.SDT;
                coso.HinhAnh = coSo.HinhAnh;
                result.Add(coso);
            }
            return result;
        }
    }
}
