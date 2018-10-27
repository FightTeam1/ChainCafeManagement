using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceLoaiSanPham;

namespace BLL
{
    public class bllLoaiSanPham
    {
        WS_LoaiSP dal = new WS_LoaiSP();

        public List<LOAISP> getAll()
        {
            return dal.FindAll().ToList();
        }
        
        public int addLoaiSP(string maLoaiSP, string tenLoaiSP, string hinhAnh)
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

        public bool deleteLoaiSP(string maLoaiSP)
        {
            return dal.Delete(maLoaiSP);
        }

        public bool updateLoaiSP(string maLoaiSP, string tenLoaiSP, string hinhAnh)
        {
            return dal.Update(maLoaiSP, tenLoaiSP, hinhAnh);
        }

        public bool IsStringsEmpty(string maLoaiSP, string tenLoaiSP, string hinhAnh)
        {
            return (string.Equals(maLoaiSP, string.Empty) || string.Equals(tenLoaiSP, string.Empty) || string.Equals(hinhAnh, string.Empty));
        }

        public bool ktraTrungMaLoai(string maLoaiSP)
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
    }
}
