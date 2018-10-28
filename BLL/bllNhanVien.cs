using BLL.serviceNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllNhanVien
    {
        WS_NhanVien dal = new WS_NhanVien();

        public List<NHANVIEN> getAll()
        {
            return dal.FindAll().ToList();
        }

        //public NHANVIEN getNhanVienByMaNV

        public int addNhanVien(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt, string Cmnd, string Email, string Diachi, string MatKhau)
        {
            if (IsStringsEmpty(MaNV, MaLoaiNV, MaCS, HoTenNV, Sdt, Cmnd, Email, Diachi, MatKhau))
            {
                return 1;
            }
            if (ktraTrungMaNhanVien(MaNV))
            {
                return 2;
            }
            if (!dal.Add(MaNV, MaLoaiNV, MaCS, HoTenNV, Sdt, Cmnd, Email, Diachi, MatKhau))
            {
                return 3;
            }
            return 0;
        }

        public bool updateNhanVien(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt, string Cmnd, string Email, string Diachi, string MatKhau)
        {
            return dal.Update(MaNV, MaLoaiNV, MaCS, HoTenNV, Sdt, Cmnd, Email, Diachi, MatKhau);
        }

        public bool deleteNhanVien(string MaNV)
        {
            return dal.Delete(MaNV);
        }

        public bool IsStringsEmpty(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt, string Cmnd, string Email, string Diachi, string MatKhau)
        {
            return (string.Equals(MaNV, string.Empty) || string.Equals(MaLoaiNV, string.Empty) || string.Equals(MaCS, string.Empty) || string.Equals(HoTenNV, string.Empty) || string.Equals(Sdt, string.Empty)
                || string.Equals(Cmnd, string.Empty) || string.Equals(Email, string.Empty) || string.Equals(Diachi, string.Empty) || string.Equals(MatKhau, string.Empty));
        }

        public bool ktraTrungMaNhanVien(string MaNV)
        {
            foreach (NHANVIEN nhanVien in getAll())
            {
                if (string.Equals(nhanVien.MANV, MaNV))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
