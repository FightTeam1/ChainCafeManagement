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
using DevExpress.XtraCharts;

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
            List<string[]> lst = new List<string[]>();
            lst = bllHoaDon.getFilterQuarterly("CS001", 2018);
            for(int i = 0; i < lst.Count; i++)
            {
                chartControl1.Series["Thu"].Points.Add(new SeriesPoint(lst[i][0], lst[i][1]));
            }
        }
    }
}