using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface INhanvienRepository
    {
        bool Create(NhanvienModel model);
        bool Delete(string id);
        NhanvienModel GetDatabyID(string id);
        List<NhanvienModel> GetDataAll();
        List<NhanvienModel> Search(int pageIndex, int pageSize, out long total, string Ma_nv);
    }
}
