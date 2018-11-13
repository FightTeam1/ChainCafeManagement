using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace GUI
{
    public partial class rpHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        public rpHoaDon()
        {
            InitializeComponent();
            gido();
        }
        
        void gido()
        {
            XRTableRow row = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Text = "một con vịt";
            row.Cells.Add(cell);
            row.Cells.Add(cell);
            xrTable1.Rows.Add(row);
            //xrTableRow1.Cells.Add(cell);
        }
    }
}
