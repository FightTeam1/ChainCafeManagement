using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_ChiTietHoaDon
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_ChiTietHoaDon : System.Web.Services.WebService
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Add ChiTietHoaDon")]
        public bool Add(string MaHoaDon, string MaSP, int SL_SP)
        {
            try
            {
                CHITIETHOADON ctHD = new CHITIETHOADON();
                ctHD.MAHOADON = MaHoaDon;
                ctHD.MASP = MaSP;
                ctHD.SL_SP = SL_SP;

                dc.CHITIETHOADONs.InsertOnSubmit(ctHD);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Find all ChiTietHoaDon")]
        public List<CHITIETHOADON> FindAll()
        {
            try
            {
                return dc.CHITIETHOADONs.ToList();
            }
            catch
            {
                return new List<CHITIETHOADON>();
            }
        }

        [WebMethod(Description = "Find CHITIETHOADON by MaHoaDon and MaSP")]
        public CHITIETHOADON Find(string MaHoaDon, string MaSP)
        {
            try
            {
                return dc.CHITIETHOADONs.Single(ct => ct.MAHOADON == MaHoaDon && ct.MASP == MaSP);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Delete CHITIETHOADON by MaHoaDon and MaSP")]
        public bool Delete(string MaHoaDon, string MaSP)
        {
            try
            {
                CHITIETHOADON ctHD = dc.CHITIETHOADONs.Single(t => t.MAHOADON == MaHoaDon && t.MASP == MaSP);
                dc.CHITIETHOADONs.DeleteOnSubmit(ctHD);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update CHITIETHOADON by MaHoaDon and MaSP")]
        public bool Update(string MaHoaDon, string MaSP, int SL_SP)
        {
            try
            {
                CHITIETHOADON ctHD = dc.CHITIETHOADONs.Single(t => t.MAHOADON == MaHoaDon && t.MASP == MaSP);
                ctHD.SL_SP = SL_SP;
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
