using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface INhanvienBusiness
    {
        bool Create(NhanvienModel model);
        bool Delete(string id);
        NhanvienModel GetDatabyID(string id);
        List<NhanvienModel> GetDataAll();
        List<NhanvienModel> Search(int pageIndex, int pageSize, out long total, string Ma_nv);
    }
}
