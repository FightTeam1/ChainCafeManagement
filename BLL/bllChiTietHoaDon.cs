using BLL.serviceChiTietHoaDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllChiTietHoaDon
    {
        WS_ChiTietHoaDon dal = new WS_ChiTietHoaDon();

        public List<CHITIETHOADON> getAll()
        {
            return dal.FindAll().ToList();
        }

        public List<CHITIETHOADON> getChiTietHDByMaHD(string MaHoaDon)
        {
            return dal.FindByMaHD(MaHoaDon).ToList();
        }

        public int addChiTietHoaDon(string MaHoaDon, string MaSP, int SoLuong)
        {
            if (IsStringsEmpty(MaHoaDon, MaSP, SoLuong))
            {
                return 1;
            }
            if (ktraTrungKhoaChinh(MaHoaDon, MaSP))
            {
                return 2;
            }
            if (!dal.Add(MaHoaDon, MaSP, SoLuong))
            {
                return 3;
            }
            return 0;
        }

        public bool deleteChiTietHoaDon(string MaHoaDon, string MaSP)
        {
            return dal.Delete(MaHoaDon, MaSP);
        }

        public bool updateChiTietHoaDon(string MaHoaDon, string MaSP, int SoLuong)
        {
            return dal.Update(MaHoaDon, MaSP, SoLuong);
        }

        public bool IsStringsEmpty(string MaHoaDon, string MaSP, int SoLuong)
        {
            return (string.Equals(MaHoaDon, string.Empty) || string.Equals(MaSP, string.Empty));
        }

        public bool ktraTrungKhoaChinh(string MaHD, string MaSP)
        {
            foreach (CHITIETHOADON ct in getAll())
            {
                if (string.Equals(ct.MAHOADON, MaHD) && string.Equals(ct.MASP, MaSP))
                {
                    return true; ;
                }
            }
            return false;
        }
    }
}
