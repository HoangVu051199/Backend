using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IMonanBusiness
    {
        bool Create(MonanModel model);
        bool Update(MonanModel model);
        bool Delete(string id);
        MonanModel GetDatabyID(string id);
        List<MonanModel> GetDatabyIDloai(string id);
        List<MonanModel> GetDataAll();
        List<MonanModel> Search(int pageIndex, int pageSize, out long total, string ten_mon);
    }
}
