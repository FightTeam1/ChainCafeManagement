using BLL.serviceHoaDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllHoaDon
    {
        WS_HoaDon dal = new WS_HoaDon();

        public List<HOADON> getAll()
        {
            return dal.FindAll().ToList();
        }

        public List<HOADON> filterByDate(DateTime start, DateTime end)
        {
            return dal.FilterByDate(start,end).ToList();

        }

        public List<HOADON> filterByDateAndCoSo(string maCS, DateTime start, DateTime end)
        {
            return dal.FilterByDateAndCoSo(maCS, start, end).ToList();
        }

        public HOADON getByMaHD(string MaHD)
        {
            return dal.Find(MaHD);
        }

        public string addHoaDon(string MaNV, string Sdt, string DiaChi)
        {
            return dal.Add(MaNV, Sdt, DiaChi);
        }

        public bool deleteHoaDon(string MaHoaDon)
        {
            return dal.Delete(MaHoaDon);
        }

        public bool updateHoaDon(string MaHD, string MaNV, string Sdt, DateTime NgayGioLap, int ThanhTien, string TrangThai, string DiaChi, string LoaiHD)
        {
            return dal.Update(MaHD, MaNV, Sdt, NgayGioLap, ThanhTien, TrangThai, DiaChi, LoaiHD);
        }

        public bool IsStringsEmpty(string MaNV, string Sdt, string DiaChi)
        {
            return (string.Equals(MaNV, string.Empty) || string.Equals(Sdt, string.Empty) || string.Equals(DiaChi, string.Empty));
        }
    }
}
