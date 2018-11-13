using BLL.serviceHoaDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bllHoaDon
    {
        WS_HoaDon dal = new WS_HoaDon();

        public List<HOADON> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<HOADON>();
            }
        }

        //public string[] getFilterByDay(string maCS, DateTime date)
        //{
        //    long tong = 0;
        //    List<HOADON> lst = new List<HOADON>();
        //    lst = dal.FilterByDateAndCoSo(maCS, date, date).ToList();
        //    foreach (HOADON hd in lst)
        //    {
        //        tong += (long)hd.THANHTIEN;
        //    }
        //    string ngay = "";
        //    ngay += date.Day + "/" + date.Month;
        //    return new string[] { ngay, tong.ToString() };
        //}

        //public List<string[]> getFilterByDays(string maCS, DateTime start, DateTime end)
        //{
        //    List<string[]> lst = new List<string[]>();
        //    DateTime dt = start;
        //    bool stop = false;
        //    while (!stop)
        //    {
        //        lst.Add(getFilterByDay(maCS, dt));
        //        dt = dt.AddDays(1);
        //        if (dt == end)
        //        {
        //            stop = true;
        //        }
        //    }
        //    return lst;
        //}

        public string[] getFilterByMonth(string maCS, int month, int year)
        {
            try
            {
                List<HOADON> lst = new List<HOADON>();
                DateStart_End startend = new DateStart_End(month, year);
                lst = dal.FilterByDateAndCoSo(maCS, startend.Start, startend.End).ToList();
                long tong = 0;
                foreach (HOADON hd in lst)
                {
                    tong += (long)hd.THANHTIEN;
                }
                return new string[] { month.ToString(), tong.ToString() };
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new string[] { };
            }
        }

        public List<string[]> getFilterMonthly(string maCS, int year)
        {
            try
            {
                List<string[]> lst = new List<string[]>();
                for (int i = 1; i < 13; i++)
                {
                    lst.Add(getFilterByMonth(maCS, i, year));
                }
                return lst;
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<string[]>();
            }
        }

        public List<string[]> getFilterQuarterly(string maCS, int year)
        {
            try
            {
                List<string[]> lst = new List<string[]>();
                int x = 0;
                for (int i = 1; i < 5; i++)
                {
                    long tong = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        tong += long.Parse(getFilterByMonth(maCS, i + j + x, year)[1]);
                    }
                    string ten = "Quý " + i.ToString();
                    lst.Add(new string[] { ten, tong.ToString() });
                    x += 3;
                }
                return lst;
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<string[]>();
            }
        }

        public HOADON getByMaHD(string MaHD)
        {
            try
            {
                return dal.Find(MaHD);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new HOADON();
            }
        }

        public string addHoaDon(string MaNV, string Sdt, string DiaChi)
        {
            try
            {
                return dal.Add(MaNV, Sdt, DiaChi);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return "";
            }
        }

        public bool deleteHoaDon(string MaHoaDon)
        {
            try
            {
                return dal.Delete(MaHoaDon);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool updateHoaDon(string MaHD, string MaNV, string Sdt, DateTime NgayGioLap, int ThanhTien, string TrangThai, string DiaChi, string LoaiHD)
        {
            try
            {
                return dal.Update(MaHD, MaNV, Sdt, NgayGioLap, ThanhTien, TrangThai, DiaChi, LoaiHD);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool IsStringsEmpty(string MaNV, string Sdt, string DiaChi)
        {
            try
            {
                return (string.Equals(MaNV, string.Empty) || string.Equals(Sdt, string.Empty) || string.Equals(DiaChi, string.Empty));
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }
    }

    public class DateStart_End
    {
        private DateTime start, end;

        public DateStart_End(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Start = new DateTime(year, month, 1);
                    End = new DateTime(year, month, 31);
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Start = new DateTime(year, month, 1);
                    End = new DateTime(year, month, 30);
                    break;
                case 2:
                    if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
                    {
                        Start = new DateTime(year, month, 1);
                        End = new DateTime(year, month, 29);
                    }
                    else
                    {
                        Start = new DateTime(year, month, 1);
                        End = new DateTime(year, month, 28);
                    }
                    break;
            }
        }

        public DateTime Start { get => start; set => start = value; }
        public DateTime End { get => end; set => end = value; }


    }
}
