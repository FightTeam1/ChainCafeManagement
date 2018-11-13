using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService
{
    /// <summary>
    /// Summary description for WS_TinTuc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WS_TinTuc : System.Web.Services.WebService
    {

        DataClassesDataContext dc = new DataClassesDataContext();

        [WebMethod(Description = "Add TinTuc")]
        public bool Add(string MaTin, string TieuDe, string NoiDung, string HinhAnh, string MaNV, string MoTaNgan)
        {
            try
            {
                TINTUC tinTuc = new TINTUC();
                tinTuc.MATIN = MaTin;
                tinTuc.TIEUDE = TieuDe;
                tinTuc.NOIDUNG = NoiDung;
                tinTuc.HINHANH = HinhAnh;
                tinTuc.MANV = MaNV;
                tinTuc.NGAYDANG = DateTime.Now;
                tinTuc.MOTANGAN = MoTaNgan;

                dc.TINTUCs.InsertOnSubmit(tinTuc);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        [WebMethod(Description = "Find all TinTuc")]
        public List<TINTUC> FindAll()
        {
            try
            {
                return dc.TINTUCs.ToList();
            }
            catch
            {
                return new List<TINTUC>();
            }
        }

        [WebMethod(Description = "Find TinTuc by MaTin")]
        public TINTUC Find(string MaTin)
        {
            try
            {
                return dc.TINTUCs.Single(t => t.MATIN == MaTin);
            }
            catch
            {
                return null;
            }
        }

        [WebMethod(Description = "Delete TinTuc by MaTin")]
        public bool Delete(string MaTin)
        {
            try
            {
                TINTUC tinTuc = dc.TINTUCs.Single(t => t.MATIN == MaTin);
                dc.TINTUCs.DeleteOnSubmit(tinTuc);
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Update TinTuc by MaTin")]
        public bool Update(string MaTin, string TieuDe, string NoiDung, string HinhAnh, string MaNV, string MoTaNgan)
        {
            //try
            //{
                TINTUC tinTuc = dc.TINTUCs.Single(t => t.MATIN == MaTin);
                tinTuc.TIEUDE = TieuDe;
                tinTuc.NOIDUNG = NoiDung;
                tinTuc.HINHANH = HinhAnh;
                tinTuc.MANV = MaNV;
                tinTuc.MOTANGAN = MoTaNgan;    

                dc.SubmitChanges();
                return true;
            //}
            //catch
            //{
            //    return false;
            //}

        }
    }
}
