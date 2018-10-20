using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_NhanVien
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_NhanVien : System.Web.Services.WebService
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Add NhanVien")]
        public bool Add(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt_NV, string Cmnd, string Email, string DiaChi_NV, string MatKhau)
        {
            try
            {
                NHANVIEN nhanVien = new NHANVIEN();
                nhanVien.MANV = MaNV;
                nhanVien.MALOAINV = MaLoaiNV;
                nhanVien.MACS = MaCS;
                nhanVien.HOTENNV = HoTenNV;
                nhanVien.SDT_NV = Sdt_NV;
                nhanVien.CMND = Cmnd;
                nhanVien.EMAIL = Email;
                nhanVien.DIACHI_NV = DiaChi_NV;
                nhanVien.MATKHAU = MatKhau;
                dc.NHANVIENs.InsertOnSubmit(nhanVien);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Find all NhanVien")]
        public List<NHANVIEN> FindAll()
        {
            try
            {
                return dc.NHANVIENs.ToList();
            }
            catch
            {
                return new List<NHANVIEN>();
            }
        }

        [WebMethod(Description = "Find NHANVIEN by MaNV")]
        public NHANVIEN Find(string MaNV)
        {
            try
            {
                return dc.NHANVIENs.Single(nhanVien => nhanVien.MANV == MaNV);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Delete NhanVien by MaNV")]
        public bool Delete(string MaNV)
        {
            try
            {
                NHANVIEN nhanVien = dc.NHANVIENs.Single(t => t.MANV == MaNV);
                dc.NHANVIENs.DeleteOnSubmit(nhanVien);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update NhanVien by MaNV")]
        public bool Update(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt_NV, string Cmnd, string Email, string DiaChi_NV, string MatKhau)
        {
            try
            {
                NHANVIEN nhanVien = dc.NHANVIENs.Single(t => t.MANV == MaNV);
                nhanVien.MALOAINV = MaLoaiNV;
                nhanVien.MACS = MaCS;
                nhanVien.HOTENNV = HoTenNV;
                nhanVien.SDT_NV = Sdt_NV;
                nhanVien.CMND = Cmnd;
                nhanVien.EMAIL = Email;
                nhanVien.DIACHI_NV = DiaChi_NV;
                nhanVien.MATKHAU = MatKhau;
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
