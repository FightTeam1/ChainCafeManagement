using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_KhachHang
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_KhachHang : System.Web.Services.WebService
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Find all KhachHang")]
        public List<KHACHHANG> FindAll()
        {
            try
            {
                return dc.KHACHHANGs.ToList();
            }
            catch
            {
                return new List<KHACHHANG>();
            }
        }

        [WebMethod(Description = "Find KhachHang by Sdt")]
        public KHACHHANG Find(string Sdt)
        {
            try
            {
                return dc.KHACHHANGs.Single(kh => kh.SDT == Sdt);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Add KHACHHANG")]
        public bool Add(string HoTenKH, string Sdt, string Email, int DiemTich, string HinhAnh)
        {
            try
            {
                KHACHHANG khachHang = new KHACHHANG();
                khachHang.HOTENKH = HoTenKH;
                khachHang.SDT = Sdt;
                khachHang.EMAIL = Email;
                khachHang.DIEMTICH = DiemTich;
                khachHang.HinhAnh = HinhAnh;
                dc.KHACHHANGs.InsertOnSubmit(khachHang);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Delete KHACHHANG by Sdt")]
        public bool Delete(string Sdt)
        {
            try
            {
                KHACHHANG khachHang = dc.KHACHHANGs.Single(kh => kh.SDT == Sdt);
                dc.KHACHHANGs.DeleteOnSubmit(khachHang);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update KHACHHANG by Sdt")]
        public bool Update(string HoTenKH, string Sdt, string Email, int DiemTich, string HinhAnh)
        {
            try
            {
                KHACHHANG khachHang = dc.KHACHHANGs.Single(kh => kh.SDT == Sdt);
                khachHang.HOTENKH = HoTenKH;
                khachHang.EMAIL = Email;
                khachHang.DIEMTICH = DiemTich;
                khachHang.HinhAnh = HinhAnh;
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Count all KhachHang by Sdt, return boolean")]
        public int Count(string Sdt)
        {
            try
            {
                return (dc.KHACHHANGs.Single(t => t.SDT == Sdt)) == null ? 0 : 1;
            }
            catch
            {
                return -1;
            }
        }
    }
}
