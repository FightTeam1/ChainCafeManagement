using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI
{
    public partial class frmDatHang : Form
    {
        bllDieuPhoi bllDieuPhoi = new bllDieuPhoi();
        bllChiTietHoaDon bllChiTietHD = new bllChiTietHoaDon();
        bllHoaDon bllHD = new bllHoaDon();
        bllNhanVien bllNV = new bllNhanVien();
        

        List<BLL.serviceDieuPhoi.DIEUPHOI> listDieuPhoi = new List<BLL.serviceDieuPhoi.DIEUPHOI>();
        List<BLL.serviceChiTietHoaDon.CHITIETHOADON> listChiTietHD = new List<BLL.serviceChiTietHoaDon.CHITIETHOADON>();
        public string MaNV = "";
        string _MaCS = "CS001";

        public frmDatHang()
        {
            InitializeComponent();

            //_MaCS = bllNV
        }

        private void frmDatHang_Load(object sender, EventArgs e)
        {
            listDieuPhoi = bllDieuPhoi.getDieuPhoiOfCoSo(_MaCS);
            updateGridViewHoaDon();
        }

        public void updateGridViewHoaDon ()
        {
            dataGridViewDonDatHang.Rows.Clear();
            foreach (var dp in listDieuPhoi)
            {
                int rowIndex = dataGridViewDonDatHang.Rows.Add(dp.MACS, dp.MAHOADON, dp.HOADON.TRANGTHAI);
                switch (dp.HOADON.TRANGTHAI)
                {
                    case "Đang chờ duyệt":
                        {
                            dataGridViewDonDatHang.Rows[rowIndex].Cells[2].Style.BackColor = Color.Yellow;
                        } break;
                    case "Đã duyệt":
                        {
                            dataGridViewDonDatHang.Rows[rowIndex].Cells[2].Style.BackColor = Color.Green;
                        } break;
                    default:
                        {
                            dataGridViewDonDatHang.Rows[rowIndex].Cells[2].Style.BackColor = Color.Red;
                        } break;
                }
            }
        }

        public void updateGridViewChiTietHD()
        {
            dataGridViewChiTietHD.Rows.Clear();
            foreach (var ct in listChiTietHD)
            {
                dataGridViewChiTietHD.Rows.Add(ct.SANPHAM.TENSP, ct.SL_SP, ct.SANPHAM.DONGIA);
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewDonDatHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string MaHD = dataGridViewDonDatHang.SelectedRows[0].Cells[1].Value.ToString();
                listChiTietHD = bllChiTietHD.getChiTietHDByMaHD(MaHD);
                updateGridViewChiTietHD();

                lblMaHD.Text = MaHD;
                var hoaDon = bllHD.getByMaHD(MaHD);
                lblTenKH.Text = hoaDon.KHACHHANG.HOTENKH;
                lblSDT.Text = hoaDon.KHACHHANG.SDT;
                lblDiaChi.Text = hoaDon.DIACHI;
                lblTrangThai.Text = hoaDon.TRANGTHAI;
                lblThanhTien.Text = hoaDon.THANHTIEN.ToString();
            }
            catch
            {

            }
            
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            string MaHD = dataGridViewDonDatHang.SelectedRows[0].Cells[1].Value.ToString();
            var hoaDon = bllHD.getByMaHD(MaHD);
            bllHD.updateHoaDon(hoaDon.MAHOADON, hoaDon.MANV, hoaDon.SDT_KH, (DateTime)hoaDon.NGAYGIOLAP, (int)hoaDon.THANHTIEN, "Đã duyệt", hoaDon.DIACHI, hoaDon.LOAIHD);
            lblTrangThai.Text = "Đã duyệt";

            dataGridViewDonDatHang.SelectedRows[0].Cells[2].Value = "Đã duyệt";
            dataGridViewDonDatHang.SelectedRows[0].Cells[2].Style.BackColor = Color.Green;
        }
    }
}
