using BLL.serviceDieuPhoi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class bllDieuPhoi
    {
        WS_DieuPhoi dal = new WS_DieuPhoi();

        public List<DIEUPHOI> getDieuPhoiOfCoSo(string MaCS)
        {
            return dal.Find(MaCS).ToList();
        }

        public List<DIEUPHOI> getAll()
        {
            return dal.FindAll().ToList();
        }
        
        public bool deleteDieuPhoi(string MaCS, string MaHoaDon)
        {
            return dal.Delete(MaCS, MaHoaDon);
        }
    }
}
