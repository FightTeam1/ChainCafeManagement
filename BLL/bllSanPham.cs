using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceSanPham;

namespace BLL
{
    public class bllSanPham
    {
        WS_SanPham dal = new WS_SanPham();

        public List<SANPHAM> getAll()
        {
            return dal.FindAll().ToList();
        }

        public int addSanPham(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
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

        public bool deleteSanPham(string maSanPham)
        {
            return dal.Delete(maSanPham);
        }

        public bool updateSanPham(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            return dal.Update(MaSP, MaLoaiSP, TenSP, DonGia, HinhAnh);
        }

        public bool IsStringsEmpty(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            return (string.Equals(MaSP, string.Empty) || string.Equals(TenSP, string.Empty) || string.Equals(HinhAnh, string.Empty) || string.Equals(MaLoaiSP, string.Empty) || string.Equals(DonGia.ToString(), string.Empty));
        }

        public bool ktraTrungMaLoai(string maSanPham)
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

        public List<SANPHAM> getBy(string maLoai)
        {
            return dal.FindByMaLoaiSP(maLoai).ToList();
        }
    }
}
