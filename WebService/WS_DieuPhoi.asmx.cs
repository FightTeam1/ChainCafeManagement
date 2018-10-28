using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_DieuPhoi
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_DieuPhoi : System.Web.Services.WebService
    {

        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Find all DieuPhoi")]
        public List<DIEUPHOI> FindAll()
        {
            try
            {
                return dc.DIEUPHOIs.ToList();
            }
            catch
            {
                return new List<DIEUPHOI>();
            }
        }

        [WebMethod(Description = "Find DieuPhois by MaCS")]
        public List<DIEUPHOI> Find(string MaCS)
        {
            try
            {
                return (from dp in dc.DIEUPHOIs where dp.MACS == MaCS select dp).ToList();
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Add DieuPhoi")]
        public bool Add(string MaCS, string MaHoaDon)
        {
            try
            {
                DIEUPHOI dieuPhoi = new DIEUPHOI();
                dieuPhoi.MACS = MaCS;
                dieuPhoi.MAHOADON = MaHoaDon;
                dc.DIEUPHOIs.InsertOnSubmit(dieuPhoi);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Delete DieuPhoi by MaCS and MaHoaDon")]
        public bool Delete(string MaCS, string MaHoaDon)
        {
            try
            {
                DIEUPHOI dieuPhoi = dc.DIEUPHOIs.Single(dp => dp.MACS == MaCS && dp.MAHOADON == MaHoaDon);
                dc.DIEUPHOIs.DeleteOnSubmit(dieuPhoi);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //[WebMethod(Description = "Update DieuPhoi by MaHoaDon")]
        //public string Update(string MaHoaDon, string MaCS)
        //{
        //    try
        //    {
        //        DIEUPHOI dieuPhoi = dc.DIEUPHOIs.Single(dp => dp.MAHOADON == MaHoaDon);
        //        dieuPhoi.MACS = MaCS;
                
        //        dc.SubmitChanges();
        //        return "thanh cong";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        public void Distribute (string MaHoaDon)
        {
            Add("CS001", MaHoaDon);
        }
    }
}
