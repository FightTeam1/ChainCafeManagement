using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using BLL;
using BLL.serviceChiTietHoaDon;
using System.Collections.Generic;
using DevExpress.XtraPrinting;


namespace GUI
{
    public partial class rpHoaDon : DevExpress.XtraReports.UI.XtraReport
    {
        string hd = "";
        bllChiTietHoaDon bllChiTietHoaDon = new bllChiTietHoaDon();
        bllNhanVien bllNhanVien = new bllNhanVien();
        bllKhachHang bllKhachHang = new bllKhachHang();

        public rpHoaDon(string hd)
        {
            InitializeComponent();
            this.hd = hd;
            gido();
        }
        
        void gido()
        {
            //XRTableRow row = new XRTableRow();
            //XRTableCell cell = new XRTableCell();
            //cell.Text = "một con vịt";
            //row.Cells.Add(cell);
            //row.Cells.Add(cell);
            //xrTable1.Rows.Add(row);
            //xrTableRow1.Cells.Add(cell);
            xrTableRow1.Cells[0].Text = "Tên sản phẩm";
            xrTableRow1.Cells[0].TextAlignment = TextAlignment.MiddleLeft;
            xrTableRow1.Cells[1].Text = "SL";
            xrTableRow1.Cells[1].TextAlignment = TextAlignment.MiddleRight;
            xrTableRow1.Cells[2].Text = "Đơn giá(VND)";
            xrTableRow1.Cells[2].TextAlignment = TextAlignment.MiddleRight;
            xrTableRow1.Cells[3].Text = "Thành tiền(VND)";
            xrTableRow1.Cells[3].TextAlignment = TextAlignment.MiddleRight;

            List<CHITIETHOADON> lst = new List<CHITIETHOADON>();
            lst = bllChiTietHoaDon.getChiTietHDByMaHD(hd);
            string ten = bllNhanVien.getNhanVienByMaNV(lst[0].HOADON.MANV).HOTENNV;
            this.txtMaHD.Text = lst[0].MAHOADON;
            this.txtMaKH.Text = bllKhachHang.getBySdt(lst[0].HOADON.SDT_KH).HOTENKH;
            this.txtNV.Text = ten;
            string ngay = lst[0].HOADON.NGAYGIOLAP.Value.Day.ToString() + "/" + lst[0].HOADON.NGAYGIOLAP.Value.Month.ToString()+ "/" + lst[0].HOADON.NGAYGIOLAP.Value.Year.ToString();
            this.txtNgayLap.Text = ngay;
            int tong = 0;
            
            foreach(CHITIETHOADON ct in lst)
            {
                XRTableRow row = new XRTableRow();
                XRTableCell sp = new XRTableCell();
                sp.Padding = new PaddingInfo(5, 5, 10, 10);
                sp.TextAlignment = TextAlignment.MiddleLeft;
                sp.WidthF = xrTableRow1.Cells[0].WidthF;
                XRTableCell sl = new XRTableCell();
                sl.Padding = new PaddingInfo(5, 5, 10, 10);
                sl.TextAlignment = TextAlignment.MiddleRight;
                sl.WidthF = xrTableRow1.Cells[1].WidthF;
                XRTableCell dg = new XRTableCell();
                dg.Padding = new PaddingInfo(5, 5, 10, 10);
                dg.TextAlignment = TextAlignment.MiddleRight;
                dg.WidthF = xrTableRow1.Cells[2].WidthF;
                XRTableCell tt = new XRTableCell();
                tt.TextAlignment = TextAlignment.MiddleRight;
                tt.Padding = new PaddingInfo(5, 5, 10, 10);
                tt.WidthF = xrTableRow1.Cells[3].WidthF;
                sp.Text = ct.SANPHAM.TENSP;
                sl.Text = ct.SL_SP.ToString();
                dg.Text = ct.SANPHAM.DONGIA.ToString();
                tt.Text = (ct.SL_SP * ct.SANPHAM.DONGIA).ToString();
                tong += int.Parse(tt.Text);
                row.Cells.Add(sp);
                row.Cells.Add(sl);
                row.Cells.Add(dg);
                row.Cells.Add(tt);
                row.Font = new Font("Times New Roman", 14);
                table.Rows.Add(row);
            }
            XRTableRow roww = new XRTableRow();
            XRTableCell cell = new XRTableCell();
            cell.Padding = new PaddingInfo(5, 5, 10, 10);
            cell.Text = "Tổng tiền: " + tong.ToString() + " VND";
            roww.TextAlignment = TextAlignment.MiddleRight;
            roww.Cells.Add(cell);
            table.Rows.Add(roww);
        }
    }
}

//10, 143,75
//580, 25