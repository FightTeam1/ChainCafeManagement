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
using BLL.serviceHoaDon;

namespace GUI
{
    public partial class frmThongKe : DevExpress.XtraEditors.XtraForm
    {
        bllHoaDon bllHoaDon = new bllHoaDon();

        public frmThongKe()
        {
            InitializeComponent();
            Load += frmLoad;
        }

        private void frmLoad(object ob, EventArgs e)
        {
            List<string[]> lst = bllHoaDon.getFilterQuarterly("CS001", 2018);
            for(int i = 0; i < 4; i++)
            {
                chart1.Series["Khoản thu"].Points.AddXY(lst[i][0], lst[i][1]);
                //chart1.Series["Khoản thu"].Points.AddY(lst[i][1]);
            }
        }
    }
}