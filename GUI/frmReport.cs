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

namespace GUI
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        public frmReport(string hd)
        {
            InitializeComponent();
            rpHoaDon report = new rpHoaDon(hd);
            viewer.DocumentSource = report;
        }
    }
}

