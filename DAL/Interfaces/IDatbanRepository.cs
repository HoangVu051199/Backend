using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IDatbanRepository
    {
        bool Create(DatbanModel model);
        bool Update(DatbanModel model);
        bool Delete(string id);
        DatbanModel GetDatabyID(string id);
        List<DatbanModel> GetDataAll();
        List<DatbanModel> Search(int pageIndex, int pageSize, out long total, string ten_ban);
    }
}
