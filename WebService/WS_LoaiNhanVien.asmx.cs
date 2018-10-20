using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_LoaiNhanVien
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_LoaiNhanVien : System.Web.Services.WebService
    {

        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Add LoaiNhanVien")]
        public bool Add(string MaLoaiNV, string TenLoaiNV)
        {
            try
            {
                LOAINHANVIEN loaiNV = new LOAINHANVIEN();
                loaiNV.MALOAINV = MaLoaiNV;
                loaiNV.TENLOAINV = TenLoaiNV;
                dc.LOAINHANVIENs.InsertOnSubmit(loaiNV);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Find all LoaiNhanVien")]
        public List<LOAINHANVIEN> FindAll()
        {
            try
            {
                return dc.LOAINHANVIENs.ToList();
            }
            catch
            {
                return new List<LOAINHANVIEN>();
            }
        }

        [WebMethod(Description = "Find LOAINHANVIEN by MaLoaiNV")]
        public LOAINHANVIEN Find(string MaLoaiNV)
        {
            try
            {
                return dc.LOAINHANVIENs.Single(loaiNV => loaiNV.MALOAINV == MaLoaiNV);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Delete LoaiNhanVien by MaLoaiNV")]
        public bool Delete(string MaLoaiNV)
        {
            try
            {
                LOAINHANVIEN loaiNV = dc.LOAINHANVIENs.Single(t => t.MALOAINV == MaLoaiNV);
                dc.LOAINHANVIENs.DeleteOnSubmit(loaiNV);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update LoaiNV by MaLoaiNV")]
        public bool Update(string MaLoaiNV, string TenLoaiNV)
        {
            try
            {
                LOAINHANVIEN loaiNV = dc.LOAINHANVIENs.Single(t => t.MALOAINV == MaLoaiNV);
                loaiNV.TENLOAINV = TenLoaiNV;
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
