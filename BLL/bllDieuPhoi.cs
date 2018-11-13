using BLL.serviceDieuPhoi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BLL
{
    public class bllDieuPhoi
    {
        WS_DieuPhoi dal = new WS_DieuPhoi();

        public List<DIEUPHOI> getDieuPhoiOfCoSo(string MaCS)
        {
            try
            {
                return dal.Find(MaCS).ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<DIEUPHOI>();
            }
        }

        public List<DIEUPHOI> getAll()
        {
            try
            {
                return dal.FindAll().ToList();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return new List<DIEUPHOI>();
            }

        }
        
        public bool deleteDieuPhoi(string MaCS, string MaHoaDon)
        {
            try
            {
                return dal.Delete(MaCS, MaHoaDon);
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại kết nối mạng");
                return false;
            }
        }
    }
}
