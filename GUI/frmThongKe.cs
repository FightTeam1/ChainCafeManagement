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
        string coso;
        string[] lstThang = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"};
        string[] lstNam = new string[] {"-Năm-", (DateTime.Now.Year - 2).ToString(), (DateTime.Now.Year - 1).ToString(), DateTime.Now.Year.ToString(), (DateTime.Now.Year + 1).ToString(), (DateTime.Now.Year + 2).ToString()};
        frmMain frmMainn;

        public frmThongKe(string cs, frmMain frm)
        {
            InitializeComponent();
            coso = cs;
            cboNam.Items.AddRange(lstNam);
            cboNam.SelectedIndexChanged += indexChanged;
            frmMainn = frm;
            frmMainn.Hide();
            FormClosing += frmClosing;
        }

        private void frmClosing(object ob, EventArgs e)
        {
            frmMainn.Show();
        }

        private void indexChanged(object ob, EventArgs e)
        {
            if(cboNam.SelectedIndex != 0)
            {
                thongke(int.Parse(cboNam.Text));
            }
        }

        void thongke(int nam)
        {
            chartControl1.Series["Thu"].Points.Clear();
            List<string[]> lst = new List<string[]>();
            lst = bllHoaDon.getFilterMonthly(coso, nam);
            for (int i = 0; i < lst.Count; i++)
            {
                chartControl1.Series["Thu"].Points.Add(new SeriesPoint(lst[i][0], lst[i][1]));
            }
        }
    }
}