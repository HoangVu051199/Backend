using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IChucvuBusiness
    {
        bool Create(ChucvuModel model);
        bool Delete(string id);
        ChucvuModel GetDatabyID(string id);
        List<ChucvuModel> GetDataAll();
        List<ChucvuModel> Search(int pageIndex, int pageSize, out long total, string Ma_cv);
    }
}
