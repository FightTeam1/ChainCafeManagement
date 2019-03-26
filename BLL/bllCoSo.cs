using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.serviceCoSo;
using System.Windows.Forms;

namespace BLL
{
    public class bllCoSo
    {
        WS_CoSo dal = new WS_CoSo();

        public List<COSO> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<COSO>();
            }

        }

        public int addCoSo(string MaCS, string TenCS, string DiaChi, string Sdt, string HinhAnh)
        {
            try
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
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return 3;
            }

        }

        public bool updateCoSo(string MaCS, string TenCS, string DiaChi, string Sdt, string HinhAnh)
        {
            try
            {
                return dal.Update(MaCS, TenCS, DiaChi, Sdt, HinhAnh);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }

        }

        public bool deleteCoSo(string MaCS)
        {
            try
            {
                return dal.Delete(MaCS);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }

        }

        public bool IsStringsEmpty(string MaCS, string TenCS, string DiaChi, string Sdt, string HinhAnh)
        {
            return (string.Equals(MaCS, string.Empty) || string.Equals(TenCS, string.Empty) || string.Equals(DiaChi, string.Empty) || string.Equals(Sdt, string.Empty) || string.Equals(HinhAnh, string.Empty));
        }

        public bool ktraTrungMaCoSo(string maCS)
        {
            try
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
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }

        }

    }
}
