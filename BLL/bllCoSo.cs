using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceCoSo;

namespace BLL
{
    public class bllCoSo
    {
        WS_CoSo dal = new WS_CoSo();

        public List<COSO> getAll()
        {
            return dal.FindAll().ToList();
        }

        public int addCoSo(string MaCS, string TenCS, string DiaChi, string Sdt, string HinhAnh)
        {
            if (IsStringsEmpty(MaCS, TenCS, DiaChi, Sdt, HinhAnh))
            {
                return 1;
            }
            if (ktraTrungMaCoSo(MaCS))
            {
                return 2;
            }
            if (!dal.Add(MaCS, TenCS, DiaChi, Sdt, HinhAnh))
            {
                return 3;
            }
            return 0;
        }

        public bool updateCoSo(string MaCS, string TenCS, string DiaChi, string Sdt, string HinhAnh)
        {
            return dal.Update(MaCS, TenCS, DiaChi, Sdt, HinhAnh);
        }

        public bool deleteCoSo(string MaCS)
        {
            return dal.Delete(MaCS);
        }

        public bool IsStringsEmpty(string MaCS, string TenCS, string DiaChi, string Sdt, string HinhAnh)
        {
            return (string.Equals(MaCS, string.Empty) || string.Equals(TenCS, string.Empty) || string.Equals(DiaChi, string.Empty) || string.Equals(Sdt, string.Empty) || string.Equals(HinhAnh, string.Empty));
        }

        public bool ktraTrungMaCoSo(string maCS)
        {
            foreach (COSO coso in getAll())
            {
                if (string.Equals(coso.MACS, maCS))
                {
                    return true; ;
                }
            }
            return false;
        }

    }
}
