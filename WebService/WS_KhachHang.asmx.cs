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

        [WebMethod(Description = "Find KhachHang by TenDangNhap")]
        public KHACHHANG Find(string TenDangNhap)
        {
            try
            {
                return dc.KHACHHANGs.Single(kh => kh.TENDANGNHAP == TenDangNhap);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Add KHACHHANG")]
        public bool Add(string TenDangNhap, string HoTenKH, string Sdt, string Email, int DiemTich, string MatKhau, string HinhAnh)
        {
            try
            {
                KHACHHANG khachHang = new KHACHHANG();
                khachHang.TENDANGNHAP = TenDangNhap;
                khachHang.HOTENKH = HoTenKH;
                khachHang.SDT = Sdt;
                khachHang.EMAIL = Email;
                khachHang.DIEMTICH = DiemTich;
                khachHang.MATKHAU = MatKhau;
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

        [WebMethod(Description = "Delete KHACHHANG by TenDangNhap")]
        public bool Delete(string TenDangNhap)
        {
            try
            {
                KHACHHANG khachHang = dc.KHACHHANGs.Single(kh => kh.TENDANGNHAP == TenDangNhap);
                dc.KHACHHANGs.DeleteOnSubmit(khachHang);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update KHACHHANG by TenDangNhap")]
        public bool Update(string TenDangNhap, string HoTenKH, string Sdt, string Email, int DiemTich, string MatKhau, string HinhAnh)
        {
            try
            {
                KHACHHANG khachHang = dc.KHACHHANGs.Single(kh => kh.TENDANGNHAP == TenDangNhap);
                khachHang.HOTENKH = HoTenKH;
                khachHang.SDT = Sdt;
                khachHang.EMAIL = Email;
                khachHang.DIEMTICH = DiemTich;
                khachHang.MATKHAU = MatKhau;
                khachHang.HinhAnh = HinhAnh;
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
