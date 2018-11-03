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
using System.Net;

namespace GUI
{
    public partial class frmGoiMon : DevExpress.XtraEditors.XtraForm
    {
        public frmMain formMainn;

        bllLoaiSanPham bllLoaiSanPham = new bllLoaiSanPham();
        bllSanPham bllSanPham = new bllSanPham();
        bllHoaDon bllHoaDon = new bllHoaDon();
        bllChiTietHoaDon bllChiTietHoaDon = new bllChiTietHoaDon();
        bllKhachHang bllKhachHang = new bllKhachHang();

        bllDieuPhoi bllDieuPhoi = new bllDieuPhoi();
        bllNhanVien bllNhanVien = new bllNhanVien();

        List<BLL.serviceDieuPhoi.DIEUPHOI> listDieuPhoi = new List<BLL.serviceDieuPhoi.DIEUPHOI>();
        List<BLL.serviceChiTietHoaDon.CHITIETHOADON> listChiTietHD = new List<BLL.serviceChiTietHoaDon.CHITIETHOADON>();
        public string MaNV = "NV001";
        string _MaCS = "";
        string MaHDSelected = "";
        string maNhanVien = "NV002";
        bool order = false;
        public string nameMa;

        public int sl = 0;
        public bool kq = false;

        public BLL.serviceHoaDon.HOADON hd = new BLL.serviceHoaDon.HOADON();

        public frmGoiMon(frmMain formMain)
        {
            InitializeComponent();
            Load += frmLoad;
            dataGridViewDonDatHang.SelectionChanged += dataGridViewDonDatHang_SelectionChanged;
            btnDuyet.Click += btnDuyet_Click;
            timer1.Tick += timer1_Tick;
            btnXacNhanThanhToan.Click += btnXacNhanThanhToan_Click;
            btnThemHoaDon.Click += clickThemHoaDon;

            checkBox.CheckedChanged += checkedChanged;

            _MaCS = bllNhanVien.getNhanVienByMaNV(MaNV).MACS;
            timer1.Enabled = true;



            this.formMainn = formMain;
            formMainn.Hide();

            FormClosing += frmClosing;
        }

        private void clickXacNhan(object ob, EventArgs e)
        {
            bllHoaDon.updateHoaDon(hd.MAHOADON, hd.MANV, txtDienThoai.Text, (DateTime)hd.NGAYGIOLAP, (int)hd.THANHTIEN, hd.TRANGTHAI, hd.DIACHI, hd.LOAIHD);
            hd = bllHoaDon.getByMaHD(hd.MAHOADON);
            ganGiaTri(hd);
        }

        private void checkedChanged(object sender, EventArgs e)
        {
            if (txtDienThoai.ReadOnly)
            {
                txtDienThoai.ReadOnly = false;
            }
            else
            {
                txtDienThoai.ReadOnly = true;
            }
        }

        private void frmClosing(object sender, FormClosingEventArgs e)
        {
            formMainn.Show();
        }

        private void frmLoad(object ob, EventArgs e)
        {
            taoGiaoDien();

            listDieuPhoi = bllDieuPhoi.getDieuPhoiOfCoSo(_MaCS);
            updateGridViewHoaDon();
        }


        private void clickThemHoaDon(object ob, EventArgs e)
        {
            order = true;
            string str = bllHoaDon.addHoaDon(maNhanVien, "0000000000", "");
            checkBox.Enabled = true;
            btnKiemKH.Enabled = true;
            hd = bllHoaDon.getByMaHD(str);
            txtDienThoai.ReadOnly = false;
            if ( ktra(str))
            {
                MessageBox.Show("Thêm thành công");
                bllHoaDon.updateHoaDon(hd.MAHOADON, hd.MANV, hd.SDT_KH, (DateTime)hd.NGAYGIOLAP, (int)hd.THANHTIEN, "Chưa thanh toán", hd.DIACHI, hd.LOAIHD);
                hd = bllHoaDon.getByMaHD(hd.MAHOADON);
                gridControl1.DataSource = bllChiTietHoaDon.getChiTietHDByMaHD(str);
                ganGiaTri(hd);
                gridView1.Columns.Remove(gridView1.Columns[gridView1.Columns.Count - 1]);
                gridView1.Columns.Remove(gridView1.Columns[gridView1.Columns.Count - 1]);
                return;
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
                return;
            }
        }

        private bool ktra(string ma)
        {
            string str = "";
            for(int i = 0; i < 2; i++)
            {
                str += ma[i];
            }

            if (string.Equals(str, "HD"))
            {
                return true;
            }
            return false;
        }

        private void ganGiaTri(BLL.serviceHoaDon.HOADON hd)
        {
            txtMaHoaDon.Text = hd.MAHOADON;
            txtDienThoai.Text = hd.SDT_KH;
            txtNgayLap.Text = hd.NGAYGIOLAP.Value.Date.ToString();
            txtNhanVienLap.Text = hd.MANV;
            txtThanhTien.Text = hd.THANHTIEN.ToString();
            txtTrangThai.Text = hd.TRANGTHAI;
        }

        private void ganGiaTriRong()
        {
            txtMaHoaDon.Text = "";
            txtDienThoai.Text = "";
            txtNgayLap.Text = "";
            txtNhanVienLap.Text = "";
            txtThanhTien.Text = "";
            txtTrangThai.Text = "";
        }

        private void taoGiaoDien()
        {
            TileGroup gr = new TileGroup();
            gr.Name = "loaiSP";
            gr.Text = "Loại sản phẩm";

            foreach (BLL.serviceLoaiSanPham.LOAISP loai in bllLoaiSanPham.getAll())
            {
                gr.Items.Add(taoItemLoaiSP(loai.MALOAISP, loai.TENLOAISP, loai.HinhAnh));
            }

            tileControl1.Groups.Add(gr);

            foreach(TileItem i in tileControl1.Groups[0].Items)
            {
                TileGroup grr = new TileGroup();
                grr.Name = i.Name;

                grr.Items.Add(taoItemReturn("btnReturn", "", "resources/images/loai_san_pham/131852199406646391_arrow.png"));

                foreach (BLL.serviceSanPham.SANPHAM sp in bllSanPham.getBy(((TileItem)i).Name))
                {
                    grr.Items.Add(taoItemSP(sp.MASP, sp.TENSP, sp.HinhAnh));
                }

                tileControl1.Groups.Add(grr);
            }

            for(int i = 1; i < tileControl1.Groups.Count; i++)
            {
                tileControl1.Groups[i].Visible = false;
            }
        }

        private void clickItemSP(object ob, TileItemEventArgs e)
        {
            if (string.Equals(((TileItem)ob).Name, "btnReturn"))
            {
                tileControl1.Groups[0].Visible = true;
                ((TileItem)ob).Group.Visible = false;
            }
            else
            {
                nameMa = ((TileItem)ob).Name;
                if (order)
                {
                    frmSoLuong1 frmmm = new frmSoLuong1(this);
                    frmmm.Show();
                }
                
            }
        }

        public void ChiTietHoadDon(string maHD, string maSP, int sl)
        {
            bllChiTietHoaDon.addChiTietHoaDon(maHD,maSP,sl);
            MessageBox.Show(maSP);
            hd = bllHoaDon.getByMaHD(hd.MAHOADON);
            gridControl1.DataSource = bllChiTietHoaDon.getChiTietHDByMaHD(hd.MAHOADON);
            
            ganGiaTri(hd);
        }



        private void clickItemLoaiSP(object ob, TileItemEventArgs e)
        {
            tileControl1.Groups[0].Visible = false;
            foreach (TileGroup gr in tileControl1.Groups)
            {
                if (string.Equals(gr.Name, ((TileItem)ob).Name)) {
                    gr.Visible = true;
                }
            }

        }

        private TileItem taoItemSP(string maSP, string tenSP, string hinhanh)
        {
            TileItem item = new TileItem();
            item.ItemSize = TileItemSize.Large;
            item.Name = maSP;
            item.Text = tenSP;
            item.AppearanceItem.Normal.Font = new Font("Tahoma", (float)14.25, FontStyle.Bold);


            var request = WebRequest.Create("http://35.185.83.140/ChainCafeManagerment/" + hinhanh);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                item.Image = resizeImage(Bitmap.FromStream(stream), new Size(330, 230));
            }

            item.ItemClick += clickItemSP;
            item.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            return item;
        }

        private TileItem taoItemLoaiSP(string maloai, string tenloai, string hinhanh)
        {
            TileItem item = new TileItem();
            item.ItemSize = TileItemSize.Large;
            item.Name = maloai;
            item.AppearanceItem.Normal.Font = new Font("Tahoma", (float)14.25, FontStyle.Bold);


            var request = WebRequest.Create("http://35.185.83.140/ChainCafeManagerment/" + hinhanh);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                item.Image = resizeImage(Bitmap.FromStream(stream),new Size(330,230));
            }

            item.ItemClick += clickItemLoaiSP;
            item.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            return item;
        }

        private TileItem taoItemReturn(string maloai, string tenloai, string hinhanh)
        {
            TileItem item = new TileItem();
            item.ItemSize = TileItemSize.Large;
            item.Name = maloai;
            item.AppearanceItem.Normal.Font = new Font("Tahoma", (float)14.25, FontStyle.Bold);
            var request = WebRequest.Create("http://35.185.83.140/ChainCafeManagerment/" + hinhanh);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream()) { item.Image = resizeImage(Bitmap.FromStream(stream), new Size(170, 170)); }

            item.ItemClick += clickItemSP;
            item.ImageAlignment = TileItemContentAlignment.MiddleCenter;
            return item;
        }

        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }









        public void updateGridViewHoaDon()
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
                        }
                        break;
                    case "Đã duyệt":
                        {
                            dataGridViewDonDatHang.Rows[rowIndex].Cells[2].Style.BackColor = Color.Green;
                        }
                        break;
                    case "Đã thanh toán":
                        {
                            dataGridViewDonDatHang.Rows[rowIndex].Cells[2].Style.BackColor = Color.LightBlue;
                        }
                        break;
                    default:
                        {
                            dataGridViewDonDatHang.Rows[rowIndex].Cells[2].Style.BackColor = Color.Red;
                        }
                        break;
                }
            }

            // hide Chi tiet hoa don
            panel3.Visible = listDieuPhoi.Count != 0;
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
                this.MaHDSelected = MaHD;

                lblMaHD.Text = MaHD;
                var hoaDon = bllHoaDon.getByMaHD(MaHD);
                lblTenKH.Text = hoaDon.KHACHHANG.HOTENKH;
                lblSDT.Text = hoaDon.KHACHHANG.SDT;
                lblDiaChi.Text = hoaDon.DIACHI;
                lblTrangThai.Text = hoaDon.TRANGTHAI;
                lblThanhTien.Text = hoaDon.THANHTIEN.ToString();

                listChiTietHD = bllChiTietHoaDon.getChiTietHDByMaHD(MaHD);
                updateGridViewChiTietHD();

                // hide button
                btnDuyet.Enabled = hoaDon.TRANGTHAI == "Đang chờ duyệt";
                btnXacNhanThanhToan.Enabled = hoaDon.TRANGTHAI == "Đã duyệt";
            }
            catch
            {
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            string MaHD = dataGridViewDonDatHang.SelectedRows[0].Cells[1].Value.ToString();
            var hoaDon = bllHoaDon.getByMaHD(MaHD);
            bllHoaDon.updateHoaDon(hoaDon.MAHOADON, this.MaNV, hoaDon.SDT_KH, (DateTime)hoaDon.NGAYGIOLAP, (int)hoaDon.THANHTIEN, "Đã duyệt", hoaDon.DIACHI, hoaDon.LOAIHD);
            lblTrangThai.Text = "Đã duyệt";

            dataGridViewDonDatHang.SelectedRows[0].Cells[2].Value = "Đã duyệt";
            dataGridViewDonDatHang.SelectedRows[0].Cells[2].Style.BackColor = Color.Green;
            btnDuyet.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listDieuPhoi = bllDieuPhoi.getDieuPhoiOfCoSo(_MaCS);
            dataGridViewDonDatHang.SelectionChanged -= dataGridViewDonDatHang_SelectionChanged;
            updateGridViewHoaDon();
            dataGridViewDonDatHang.SelectionChanged += dataGridViewDonDatHang_SelectionChanged;
            int selectedIndex = findRowIndexByMaHD(this.MaHDSelected);
            if (selectedIndex >= 0)
            {
                dataGridViewDonDatHang.Rows[selectedIndex].Selected = true;
            }
        }

        public int findRowIndexByMaHD(string MaHD)
        {
            if (MaHD == "")
            {
                return -1;
            }

            for (int i = 0; i < dataGridViewDonDatHang.Rows.Count; i++)
            {
                if (dataGridViewDonDatHang.Rows[i].Cells[1].Value.ToString() == MaHD)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            string MaHD = dataGridViewDonDatHang.SelectedRows[0].Cells[1].Value.ToString();
            var hoaDon = bllHoaDon.getByMaHD(MaHD);
            bllHoaDon.updateHoaDon(hoaDon.MAHOADON, this.MaNV, hoaDon.SDT_KH, (DateTime)hoaDon.NGAYGIOLAP, (int)hoaDon.THANHTIEN, "Đã thanh toán", hoaDon.DIACHI, hoaDon.LOAIHD);
            lblTrangThai.Text = "Đã thanh toán";

            dataGridViewDonDatHang.SelectedRows[0].Cells[2].Value = "Đã thanh toán";
            dataGridViewDonDatHang.SelectedRows[0].Cells[2].Style.BackColor = Color.LightBlue;
            btnXacNhanThanhToan.Enabled = false;
        }

        private void btnInTamTinh_Click(object sender, EventArgs e)
        {
            order = false;
            checkBox.Enabled = false;
            btnKiemKH.Enabled = false;
            txtDienThoai.ReadOnly = true;
            bllHoaDon.updateHoaDon(hd.MAHOADON, hd.MANV, hd.SDT_KH, (DateTime)hd.NGAYGIOLAP, (int)hd.THANHTIEN, "In tạm tính", hd.DIACHI, hd.LOAIHD);
            gridControl1.DataSource = bllChiTietHoaDon.getChiTietHDByMaHD(hd.MAHOADON);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            bllHoaDon.updateHoaDon(hd.MAHOADON, hd.MANV, hd.SDT_KH, (DateTime)hd.NGAYGIOLAP, (int)hd.THANHTIEN, "Đã thanh toán", hd.DIACHI, hd.LOAIHD);
            gridControl1.DataSource = new List<BLL.serviceChiTietHoaDon.CHITIETHOADON>();
            ganGiaTriRong();
        }

        private void btnKiemKH_Click(object sender, EventArgs e)
        {
            List<BLL.serviceKhachHang.KHACHHANG> lst = bllKhachHang.getAll();
            MessageBox.Show(txtDienThoai.Text);
            foreach(BLL.serviceKhachHang.KHACHHANG kh in lst)
            {  
                if (string.Equals(kh.SDT, txtDienThoai.Text))
                {
                    MessageBox.Show("Khách hàng hợp lệ");
                    btnXacNhanKH.Enabled = true;
                    return;
                }
            }

            MessageBox.Show("Khách hàng không tồn tại");
        }
    }
}