using BLL.serviceNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bllNhanVien
    {
        WS_NhanVien dal = new WS_NhanVien();

        public List<NHANVIEN> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<NHANVIEN>();
            }
        }

        public NHANVIEN getNhanVienByMaNV(string MaNV)
        {
            try
            {
                return dal.Find(MaNV);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new NHANVIEN();
            }
        }

        public int addNhanVien(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt, string Cmnd, string Email, string Diachi, string MatKhau)
        {
            try
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
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return 3;
            }
        }

        public bool updateNhanVien(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt, string Cmnd, string Email, string Diachi, string MatKhau)
        {
            try
            {
                return dal.Update(MaNV, MaLoaiNV, MaCS, HoTenNV, Sdt, Cmnd, Email, Diachi, MatKhau);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool deleteNhanVien(string MaNV)
        {
            try
            {
                return dal.Delete(MaNV);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool IsStringsEmpty(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt, string Cmnd, string Email, string Diachi, string MatKhau)
        {
            return (string.Equals(MaNV, string.Empty) || string.Equals(MaLoaiNV, string.Empty) || string.Equals(MaCS, string.Empty) || string.Equals(HoTenNV, string.Empty) || string.Equals(Sdt, string.Empty)
                || string.Equals(Cmnd, string.Empty) || string.Equals(Email, string.Empty) || string.Equals(Diachi, string.Empty) || string.Equals(MatKhau, string.Empty));
        }

        public bool ktraTrungMaNhanVien(string MaNV)
        {
            try
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
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }
    }
}
