using BLL.serviceChiTietHoaDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bllChiTietHoaDon
    {
        WS_ChiTietHoaDon dal = new WS_ChiTietHoaDon();

        public List<CHITIETHOADON> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<CHITIETHOADON>();
            }
        }

        public List<CHITIETHOADON> getChiTietHDByMaHD(string MaHoaDon)
        {
            try
            {
                return dal.FindByMaHD(MaHoaDon).ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<CHITIETHOADON>();

            }
        }

        public int addChiTietHoaDon(string MaHoaDon, string MaSP, int SoLuong)
        {
            try
            {
                if (IsStringsEmpty(MaHoaDon, MaSP, SoLuong))
                {
                    return 1;
                }
                if (ktraTrungKhoaChinh(MaHoaDon, MaSP))
                {
                    updateChiTietHoaDon(MaHoaDon, MaSP, (int)getChiTietHDByMaHD(MaHoaDon)[0].SL_SP + SoLuong);
                    return 2;
                }
                if (!dal.Add(MaHoaDon, MaSP, SoLuong))
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

        public bool deleteChiTietHoaDon(string MaHoaDon, string MaSP)
        {
            try
            {
                return dal.Delete(MaHoaDon, MaSP);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool updateChiTietHoaDon(string MaHoaDon, string MaSP, int SoLuong)
        {
            try
            {
                return dal.Update(MaHoaDon, MaSP, SoLuong);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool IsStringsEmpty(string MaHoaDon, string MaSP, int SoLuong)
        {
            return (string.Equals(MaHoaDon, string.Empty) || string.Equals(MaSP, string.Empty));
        }

        public bool ktraTrungKhoaChinh(string MaHD, string MaSP)
        {
            try
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
            catch
            {
                MessageBox.Show("Kiểm tra kết nối mạng");
                return false;
            }
        }
    }
}
