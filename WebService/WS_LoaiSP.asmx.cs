using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_LoaiSP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_LoaiSP : System.Web.Services.WebService
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod (Description = "Add LoaiSP")]
        public bool Add(string MaLoaiSP, string TenLoaiSP)
        {
            try
            {
                LOAISP loaiSP = new LOAISP();
                loaiSP.MALOAISP = MaLoaiSP;
                loaiSP.TENLOAISP = TenLoaiSP;
                dc.LOAISPs.InsertOnSubmit(loaiSP);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Find all LoaiSP")]
        public List<LOAISP> FindAll()
        {
            try
            {
                return dc.LOAISPs.ToList();
            }
            catch
            {
                return new List<LOAISP>();
            }
        }

        [WebMethod(Description = "Find LoaiSP by MaLoaiSP")]
        public LOAISP Find(string MaLoaiSP)
        {
            try
            {
                return dc.LOAISPs.Single(loaiSP => loaiSP.MALOAISP == MaLoaiSP);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod (Description = "Delete LoaiSP by MaLoaiSP")]
        public bool Delete(string MaLoaiSP)
        {
            try
            {
                LOAISP loaiSP = dc.LOAISPs.Single(t => t.MALOAISP == MaLoaiSP);
                dc.LOAISPs.DeleteOnSubmit(loaiSP);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod (Description = "Update LoaiSP by MaLoaiSP")]
        public bool Update(string MaLoaiSP, string TenLoaiSP)
        {
            try
            {
                LOAISP loaiSP = dc.LOAISPs.Single(t => t.MALOAISP == MaLoaiSP);
                loaiSP.TENLOAISP = TenLoaiSP;
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
