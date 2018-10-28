using System;
using System.Collections.Generic;
using System.IO;
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


        [WebMethod(Description = "Find SanPham by MaLoaiSP")]
        public List<SANPHAM> FindByMaLoaiSP(string MaLoaiSP)
        {
            try
            {
                return (from sp in dc.SANPHAMs where sp.MALOAISP == MaLoaiSP select sp).ToList();
            }
            catch
            {
                return new List<SANPHAM>();
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

        [WebMethod(Description = "Upload")]
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

                FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/resources/images/san_pham/") + timeNow + "_" + fileName, FileMode.Create);

                // write the memory stream containing the original
                // file as a byte array to the filestream
                ms.WriteTo(fs);
                // clean up

                ms.Close();
                fs.Close();
                fs.Dispose();

                // return OK if we made it this far
                return "resources/images/san_pham/" + timeNow + "_" + fileName;
            }
            catch (Exception ex)
            {
                // return the error message if the operation fails
                return ex.Message.ToString();
            }
        }
    }
}
