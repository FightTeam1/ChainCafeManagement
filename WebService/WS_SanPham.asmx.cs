using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_SanPham
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_SanPham : System.Web.Services.WebService
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod (Description = "Find all SanPham")]
        public List<SANPHAM> FindAll ()
        {
            try
            {
                return dc.SANPHAMs.ToList();
            }
            catch
            {
                return new List<SANPHAM>();
            }
        }

        [WebMethod (Description = "Find SanPham by MaSP")]
        public SANPHAM Find (string MaSP)
        {
            try
            {
                return dc.SANPHAMs.Single(sp => sp.MASP == MaSP);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod (Description = "Add SanPham")]
        public bool Add (string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            try
            {
                SANPHAM sanPham = new SANPHAM();
                sanPham.MASP = MaSP;
                sanPham.MALOAISP = MaLoaiSP;
                sanPham.TENSP = TenSP;
                sanPham.DONGIA = DonGia;
                sanPham.HinhAnh = HinhAnh;
                dc.SANPHAMs.InsertOnSubmit(sanPham);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod (Description = "Delete SanPham by MaSP")]
        public bool Delete (string MaSP)
        {
            try
            {
                SANPHAM sanPham = dc.SANPHAMs.Single(sp => sp.MASP == MaSP);
                dc.SANPHAMs.DeleteOnSubmit(sanPham);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update SanPham by MaSP")]
        public bool Update(string MaSP, string MaLoaiSP, string TenSP, int DonGia, string HinhAnh)
        {
            try
            {
                SANPHAM sanPham = dc.SANPHAMs.Single(sp => sp.MASP == MaSP);
                sanPham.MALOAISP = MaLoaiSP;
                sanPham.TENSP = TenSP;
                sanPham.DONGIA = DonGia;
                sanPham.HinhAnh = HinhAnh;
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
