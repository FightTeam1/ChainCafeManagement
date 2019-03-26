using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceKhachHang;
using System.Windows.Forms;

namespace BLL
{
    public class bllKhachHang
    {
        WS_KhachHang dal = new WS_KhachHang();

        public List<KHACHHANG> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<KHACHHANG>();
            }
        }

        public int addKhachHang(string HoTen, string Sdt, string Email, string DiemTich, string HinhAnh)
        {
            try
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
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return 3;
            }
        }

        public bool deleteKhachHang(string sdt)
        {
            try
            {
                return dal.Delete(sdt);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool updateKhachHang(string HoTen, string Sdt, string Email, string DiemTich, string HinhAnh)
        {
            try
            {
                return dal.Update(HoTen, Sdt, Email, int.Parse(DiemTich), HinhAnh);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool IsStringsEmpty(string HoTen, string Sdt, string Email, string DiemTich, string HinhAnh)
        {
            return (string.Equals(HoTen, string.Empty) || string.Equals(Sdt, string.Empty) || string.Equals(Email, string.Empty) || string.Equals(HinhAnh, string.Empty));
        }

        public bool ktraTrungMaLoai(string sdt)
        {
            try
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
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public KHACHHANG getBySdt(string sdt)
        {
            try
            {
                return dal.Find(sdt);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new KHACHHANG();
            }
        }
    }
}
