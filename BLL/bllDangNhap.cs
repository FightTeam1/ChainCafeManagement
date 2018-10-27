using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceNhanVien;

namespace BLL
{
    public class bllDangNhap
    {
        WS_NhanVien dal = new WS_NhanVien();

        public int ketquaDangNhap(string tendangnhap, string matkhau) //Hàm kiểm tra tên đăng nhập và mật khẩu
        {
            foreach(NHANVIEN nv in dal.FindAll())
            {
                if (string.Equals(nv.MANV, tendangnhap))
                {
                    if (string.Equals(nv.MATKHAU, matkhau))
                    {
                        return 0; //Kết quả đăng nhập thành công
                    }
                    else
                    {
                        return 2; // Nhập sai mật khẩu
                    }
                }
            }
            return 1; // Tên đăng nhập không tồn tại
        }
    }
}
