using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_HoaDon
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_HoaDon : System.Web.Services.WebService
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Add HoaDon")]
        public string Add(string MaNV, string Sdt_KH, string DiaChi)
        {
            try
            {
                string LoaiHD = MaNV == "" ? "online" : "offline";
                HOADON hoaDon = new HOADON();
                if (dc.HOADONs.Count() == 0)
                {
                    hoaDon.MAHOADON = "HD1";
                }
                else
                {
                    var list = dc.HOADONs.ToList();
                    string MaHD = "HD1";
                    string prefix = "HD";
                    foreach (var hd in list)
                    {
                        int num = int.Parse(hd.MAHOADON.Substring(prefix.Length));
                        if (num > int.Parse(MaHD.Substring(prefix.Length)))
                        {
                            MaHD = hd.MAHOADON;
                        }
                    }
                    hoaDon.MAHOADON = Util.autoGenerationCode("HD", MaHD);
                }
                hoaDon.MANV = LoaiHD == "online" ? "NV001" : MaNV;
                hoaDon.SDT_KH = Sdt_KH;
                hoaDon.NGAYGIOLAP = DateTime.Now;
                hoaDon.THANHTIEN = 0;
                hoaDon.TRANGTHAI = LoaiHD == "online" ? "Mới" : "Đã duyệt";
                hoaDon.DIACHI = LoaiHD == "online" ? DiaChi : "Tại cửa hàng";
                hoaDon.LOAIHD = LoaiHD;
                dc.HOADONs.InsertOnSubmit(hoaDon);
                dc.SubmitChanges();
                return hoaDon.MAHOADON;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod(Description = "Find all HoaDon")]
        public List<HOADON> FindAll()
        {
            try
            {
                return dc.HOADONs.ToList();
            }
            catch
            {
                return new List<HOADON>();
            }
        }

        [WebMethod(Description = "Find HoaDon by MaHoaDon")]
        public HOADON Find(string MaHoaDon)
        {
            try
            {
                return dc.HOADONs.Single(hd => hd.MAHOADON == MaHoaDon);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Delete HoaDon by MaHoaDon")]
        public bool Delete(string MaHoaDon)
        {
            try
            {
                HOADON hoaDon = dc.HOADONs.Single(t => t.MAHOADON == MaHoaDon);
                dc.HOADONs.DeleteOnSubmit(hoaDon);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update HoaDon by MaHoaDon")]
        public bool Update(string MaHoaDon, string MaNV, string Sdt_KH, DateTime NgayGioLap, int ThanhTien, string TrangThai, string DiaChi, string LoaiHD)
        {
            try
            {
                HOADON hoaDon = dc.HOADONs.Single(t => t.MAHOADON == MaHoaDon);
                hoaDon.MANV = MaNV;
                hoaDon.SDT_KH = Sdt_KH;
                hoaDon.NGAYGIOLAP = NgayGioLap;
                hoaDon.THANHTIEN = ThanhTien;
                hoaDon.TRANGTHAI = TrangThai;
                hoaDon.DIACHI = DiaChi;
                hoaDon.LOAIHD = LoaiHD;

                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
