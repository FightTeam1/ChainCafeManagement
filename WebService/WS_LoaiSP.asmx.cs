using System;
using System.Collections.Generic;
using System.IO;
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
        public bool Add(string MaLoaiSP, string TenLoaiSP, string HinhAnh)
        {
            try
            {
                LOAISP loaiSP = new LOAISP();
                loaiSP.MALOAISP = MaLoaiSP;
                loaiSP.TENLOAISP = TenLoaiSP;
                loaiSP.HinhAnh = HinhAnh;
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
        public bool Update(string MaLoaiSP, string TenLoaiSP, string HinhAnh)
        {
            try
            {
                LOAISP loaiSP = dc.LOAISPs.Single(t => t.MALOAISP == MaLoaiSP);
                loaiSP.TENLOAISP = TenLoaiSP;
                loaiSP.HinhAnh = HinhAnh;
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod (Description = "Upload")]
        public string UploadFile(byte[] f, string fileName)
        {
            // the byte array argument contains the content of the file
            // the string argument contains the name and extension
            // of the file passed in the byte array
            try
            {
                // instance a memory stream and pass the
                // byte array to its constructor
                MemoryStream ms = new MemoryStream(f);

                // instance a filestream pointing to the
                // storage folder, use the original file name
                // to name the resulting file
                string timeNow = (DateTime.Now.ToFileTime()).ToString();
                FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/resources/images/loai_san_pham/") + timeNow + "_" + fileName, FileMode.Create);

                // write the memory stream containing the original
                // file as a byte array to the filestream
                ms.WriteTo(fs);
                // clean up

                ms.Close();
                fs.Close();
                fs.Dispose();

                // return OK if we made it this far
                return "resources/images/loai_san_pham/" + timeNow + "_" + fileName;
            }
            catch (Exception ex)
            {
                // return the error message if the operation fails
                return ex.Message.ToString();
            }
        }
    }
}
