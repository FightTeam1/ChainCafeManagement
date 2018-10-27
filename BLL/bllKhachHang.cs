using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceKhachHang;

namespace BLL
{
    public class bllKhachHang
    {
        WS_KhachHang dal = new WS_KhachHang();

        public List<KHACHHANG> getAll()
        {
            return dal.FindAll().ToList();
        }

        public int addKhachHang(string HoTen, string Sdt, string Email, string DiemTich, string HinhAnh)
        {
            if (IsStringsEmpty(HoTen, Sdt, Email, DiemTich, HinhAnh))
            {
                return 1;
            }
            if (ktraTrungMaLoai(Sdt))
            {
                return 2;
            }
            if (!dal.Add(HoTen, Sdt, Email, int.Parse(DiemTich), HinhAnh))
            {
                return 3;
            }
            return 0;
        }

        public bool deleteKhachHang(string sdt)
        {
            return dal.Delete(sdt);
        }

        public bool updateKhachHang(string HoTen, string Sdt, string Email, string DiemTich, string HinhAnh)
        {
            return dal.Update(HoTen, Sdt, Email, int.Parse(DiemTich), HinhAnh);
        }

        public bool IsStringsEmpty(string HoTen, string Sdt, string Email, string DiemTich, string HinhAnh)
        {
            return (string.Equals(HoTen, string.Empty) || string.Equals(Sdt, string.Empty) || string.Equals(Email, string.Empty) || string.Equals(HinhAnh, string.Empty));
        }

        public bool ktraTrungMaLoai(string sdt)
        {
            foreach (KHACHHANG kh in getAll())
            {
                if (string.Equals(kh.SDT, sdt))
                {
                    return true; ;
                }
            }
            return false;
        }
    }
}
