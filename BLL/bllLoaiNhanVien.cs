using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceLoaiNhanVien;
using System.Windows.Forms;

namespace BLL
{
    public class bllLoaiNhanVien
    {
        WS_LoaiNhanVien dal = new WS_LoaiNhanVien();

        public List<LOAINHANVIEN> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<LOAINHANVIEN>();
            }
        }

        //public NHANVIEN getNhanVienByMaNV

        public int addLoaiNhanVien(string MaLoaiNV, string TenLoaiNV)
        {
            try
            {
                if (IsStringsEmpty(MaLoaiNV, TenLoaiNV))
                {
                    return 1;
                }
                if (ktraTrungMaLoaiNhanVien(MaLoaiNV))
                {
                    return 2;
                }
                if (!dal.Add(MaLoaiNV, TenLoaiNV))
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

        public bool updateLoaiNhanVien(string MaLoaiNV, string TenLoaiNV)
        {
            try
            {
                return dal.Update(MaLoaiNV, TenLoaiNV);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool deleteLoaiNhanVien(string maLoai)
        {
            try
            {
                return dal.Delete(maLoai);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool IsStringsEmpty(string MaLoaiNV, string TenLoaiNV)
        {
            try
            {
                return (string.Equals(MaLoaiNV, string.Empty) || string.Equals(TenLoaiNV, string.Empty));
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool ktraTrungMaLoaiNhanVien(string maLoai)
        {
            try
            {
                foreach (LOAINHANVIEN loai in getAll())
                {
                    if (string.Equals(loai.MALOAINV, maLoai))
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
