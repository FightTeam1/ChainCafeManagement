using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceLoaiSanPham;
using System.Windows.Forms;

namespace BLL
{
    public class bllLoaiSanPham
    {
        WS_LoaiSP dal = new WS_LoaiSP();

        public List<LOAISP> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<LOAISP>();
            }
        }
        
        public int addLoaiSP(string maLoaiSP, string tenLoaiSP, string hinhAnh)
        {
            try
            {
                if (IsStringsEmpty(maLoaiSP, tenLoaiSP, hinhAnh))
                {
                    return 1;
                }
                if (ktraTrungMaLoai(maLoaiSP))
                {
                    return 2;
                }
                if (!dal.Add(maLoaiSP, tenLoaiSP, hinhAnh))
                {
                    return 3;
                }
                return 0;
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return 3;
            }
        }

        public bool deleteLoaiSP(string maLoaiSP)
        {
            try
            {
                return dal.Delete(maLoaiSP);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool updateLoaiSP(string maLoaiSP, string tenLoaiSP, string hinhAnh)
        {
            try
            {
                return dal.Update(maLoaiSP, tenLoaiSP, hinhAnh);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public bool IsStringsEmpty(string maLoaiSP, string tenLoaiSP, string hinhAnh)
        {
            return (string.Equals(maLoaiSP, string.Empty) || string.Equals(tenLoaiSP, string.Empty) || string.Equals(hinhAnh, string.Empty));
        }

        public bool ktraTrungMaLoai(string maLoaiSP)
        {
            try
            {
                foreach (LOAISP loai in getAll())
                {
                    if (string.Equals(loai.MALOAISP, maLoaiSP))
                    {
                        return true; ;
                    }
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }

        public string UploadFile(string filename)
        {
            try
            {
                // get the exact file name from the path
                String strFile = System.IO.Path.GetFileName(filename);

                // get the file information form the selected file
                FileInfo fInfo = new FileInfo(filename);

                // get the length of the file to see if it is possible
                // to upload it (with the standard 4 MB limit)

                long numBytes = fInfo.Length;
                double dLen = Convert.ToDouble(fInfo.Length / 1000000);


                // Default limit of 4 MB on web server
                // have to change the web.config to if
                // you want to allow larger uploads

                if (dLen < 4)
                {
                    // set up a file stream and binary reader for the
                    // selected file

                    FileStream fStream = new FileStream(filename,
                    FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    // convert the file to a byte array
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();

                    // pass the byte array (file) and file name to the web service
                    string url = dal.UploadFile(data, strFile);

                    fStream.Close();
                    fStream.Dispose();

                    // this will always say OK unless an error occurs,
                    // if an error occurs, the service returns the error message

                    return url;
                }
                else
                {
                    // Display message if the file was too large to upload
                    //MessageBox.Show("The file selected exceeds the size limit for uploads.", "File Size");
                    return "";
                }
            }
            catch (Exception ex)
            {
                // display an error message to the user
                MessageBox.Show(ex.Message.ToString(), "Upload Error");
                return "";
            }
        }
    }
}
