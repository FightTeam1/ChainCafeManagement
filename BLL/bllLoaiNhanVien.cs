using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceLoaiNhanVien;

namespace BLL
{
    public class bllLoaiNhanVien
    {
        WS_LoaiNhanVien dal = new WS_LoaiNhanVien();

        public List<LOAINHANVIEN> getAll()
        {
            return dal.FindAll().ToList();
        }

        //public NHANVIEN getNhanVienByMaNV

        public int addLoaiNhanVien(string MaLoaiNV, string TenLoaiNV)
        {
            if (IsStringsEmpty(MaLoaiNV, TenLoaiNV))
            {
                return 1;
            }
            if (ktraTrungMaLoaiNhanVien(MaLoaiNV))
            {
                return 2;
            }
            if (!dal.Add(MaLoaiNV,TenLoaiNV))
            {
                return 3;
            }
            return 0;
        }

        public bool updateLoaiNhanVien(string MaLoaiNV, string TenLoaiNV)
        {
            return dal.Update(MaLoaiNV, TenLoaiNV);
        }

        public bool deleteLoaiNhanVien(string maLoai)
        {
            return dal.Delete(maLoai);
        }

        public bool IsStringsEmpty(string MaLoaiNV, string TenLoaiNV)
        {
            return (string.Equals(MaLoaiNV, string.Empty) || string.Equals(TenLoaiNV, string.Empty));
        }

        public bool ktraTrungMaLoaiNhanVien(string maLoai)
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
    }
}
