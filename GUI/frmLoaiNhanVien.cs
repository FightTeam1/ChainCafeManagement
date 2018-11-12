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
    public partial class frmLoaiNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiNhanVien()
        {
            InitializeComponent();
            Load += formLoad;
        }

        private void formLoad(object ob, EventArgs e)
        {

            List<string[]> lst = new List<string[]>();
            lst.Add(new string[] { "ma1", "ten1" });
            lst.Add(new string[] { "ma2", "ten2" });
            lst.Add(new string[] { "ma3", "ten3" });
            lst.Add(new string[] { "ma4", "ten4" });
            lst.Add(new string[] { "ma5", "ten5" });


            DataTable tbl = new DataTable();
            tbl.Columns.Add();
            tbl.Columns.Add();
            foreach (string[] a in lst)
            {
                
                tbl.Rows.Add(a);

            }
            listBox1.DataSource = tbl;
            listBox1.DisplayMember = tbl.Columns[1].Caption;
            listBox1.ValueMember = tbl.Columns[0].Caption;

            listBox1.SelectedIndexChanged += selectionChanged;
        }

        private void selectionChanged(object ob, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedValue.ToString();
        }
    }
}