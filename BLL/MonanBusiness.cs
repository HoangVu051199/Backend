using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class MonanBusiness : IMonanBusiness
    {
        private IMonanRepository _res;
        public MonanBusiness(IMonanRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(MonanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(MonanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public MonanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<MonanModel> GetDatabyIDloai(string id)
        {
            return _res.GetDatabyIDloai(id);
        }
        public List<MonanModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<MonanModel> Search(int pageIndex, int pageSize, out long total, string ten_mon)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_mon);
        }
    }

}
