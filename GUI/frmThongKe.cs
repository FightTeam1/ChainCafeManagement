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

            dateTimePicker1.ValueChanged += valueChanged;
        }

        private void valueChanged(object ob, EventArgs e)
        {
            gridControl1.DataSource = bllHoaDon.filterByDate(dateTimePicker1.Value, DateTime.Now);
        }
    }
}