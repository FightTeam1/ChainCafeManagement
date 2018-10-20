using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_CoSo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_CoSo : System.Web.Services.WebService
    {
        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Add CoSo")]
        public bool Add(string MaCS, string TenCS, string DiaChi, string Sdt)
        {
            try
            {
                COSO coSo = new COSO();
                coSo.MACS = MaCS;
                coSo.TENCS = TenCS;
                coSo.DIACHI = DiaChi;
                coSo.SDT = Sdt;

                dc.COSOs.InsertOnSubmit(coSo);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Find all CoSo")]
        public List<COSO> FindAll()
        {
            try
            {
                return dc.COSOs.ToList();
            }
            catch
            {
                return new List<COSO>();
            }
        }

        [WebMethod(Description = "Find CoSo by MaCS")]
        public COSO Find(string MaCS)
        {
            try
            {
                return dc.COSOs.Single(coSo => coSo.MACS == MaCS);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Delete CoSo by MaCS")]
        public bool Delete(string MaCS)
        {
            try
            {
                COSO coSo = dc.COSOs.Single(t => t.MACS == MaCS);
                dc.COSOs.DeleteOnSubmit(coSo);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update CoSo by MaCS")]
        public bool Update(string MaCS, string TenCS, string DiaChi, string Sdt)
        {
            try
            {
                COSO coSo = dc.COSOs.Single(t => t.MACS == MaCS);
                coSo.TENCS = TenCS;
                coSo.DIACHI = DiaChi;
                coSo.SDT = Sdt;
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
