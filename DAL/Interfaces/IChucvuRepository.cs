using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IChucvuRepository
    {
        bool Create(ChucvuModel model);
        bool Delete(string id);
        ChucvuModel GetDatabyID(string id);
        List<ChucvuModel> GetDataAll();
        List<ChucvuModel> Search(int pageIndex, int pageSize, out long total, string Ma_cv);
    }
}
