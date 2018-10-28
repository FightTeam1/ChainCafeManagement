using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService.DataSet1TableAdapters;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_NhanVienDataSet : System.Web.Services.WebService
    {
        NHANVIENTableAdapter nhanVienAdapter = new NHANVIENTableAdapter();

        [WebMethod(Description = "Add NhanVien")]
        public int Add(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt_NV, string Cmnd, string Email, string DiaChi_NV, string MatKhau)
        {
            try
            {
                return nhanVienAdapter.Add(MaNV, MaLoaiNV, MaCS, HoTenNV, Sdt_NV, Cmnd, Email, DiaChi_NV, MatKhau);
            }
            catch
            {
                return -1;
            }
        }

        [WebMethod(Description = "Find all NhanVien")]
        public DataTable FindAll()
        {
            try
            {
                return nhanVienAdapter.GetData();
            }
            catch
            {
                return new DataTable();
            }
        }

        [WebMethod(Description = "Find NHANVIEN by MaNV")]
        public DataTable Find(string MaNV)
        {
            try
            {
                return nhanVienAdapter.Find(MaNV);
            }
            catch
            {
                return new DataTable();
            }
        }

        [WebMethod(Description = "Delete NhanVien by MaNV")]
        public int Delete(string MaNV)
        {
            try
            {
                return nhanVienAdapter.Delete(MaNV);
            }
            catch
            {
                return -1;
            }
        }

        [WebMethod(Description = "Update NhanVien by MaNV")]
        public int Update(string MaNV, string MaLoaiNV, string MaCS, string HoTenNV, string Sdt_NV, string Cmnd, string Email, string DiaChi_NV, string MatKhau)
        {
            try
            {
                return nhanVienAdapter.Update(MaLoaiNV, MaCS, HoTenNV, Sdt_NV, Cmnd, Email, DiaChi_NV, MatKhau, MaNV);
            }
            catch
            {
                return -1;
            }
        }
    }
}
