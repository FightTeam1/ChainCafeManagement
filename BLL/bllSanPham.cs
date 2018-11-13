using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceSanPham;
using System.Windows.Forms;

namespace BLL
{
    public class bllSanPham
    {
        WS_SanPham dal = new WS_SanPham();

        public List<SANPHAM> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<SANPHAM>();
            }
        }

        public int addSanPham(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            try
            {
                if (IsStringsEmpty(MaSP, MaLoaiSP, TenSP, DonGia, HinhAnh))
                {
                    return 1;
                }
                if (ktraTrungMaLoai(MaSP))
                {
                    return 2;
                }
                if (!dal.Add(MaSP, MaLoaiSP, TenSP, DonGia, HinhAnh))
                {
                    return 3;
                }
                return 0;
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return 3;
            }
        }

        public bool deleteSanPham(string maSanPham)
        {
            try
            {
                return dal.Delete(maSanPham);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool updateSanPham(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            try
            {
                return dal.Update(MaSP, MaLoaiSP, TenSP, DonGia, HinhAnh);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool IsStringsEmpty(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            return (string.Equals(MaSP, string.Empty) || string.Equals(TenSP, string.Empty) || string.Equals(HinhAnh, string.Empty) || string.Equals(MaLoaiSP, string.Empty) || string.Equals(DonGia.ToString(), string.Empty));
        }

        public bool ktraTrungMaLoai(string maSanPham)
        {
            try
            {
                foreach (SANPHAM sanpham in getAll())
                {
                    if (string.Equals(sanpham.MASP, maSanPham))
                    {
                        return true; ;
                    }
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public List<SANPHAM> getBy(string maLoai)
        {
            try
            {
                return dal.FindByMaLoaiSP(maLoai).ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<SANPHAM>();
            }
        }
    }
}
