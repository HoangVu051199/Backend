using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class DatbanBusiness : IDatbanBusiness
    {
        private IDatbanRepository _res;
        public DatbanBusiness(IDatbanRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(DatbanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DatbanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public DatbanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<DatbanModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<DatbanModel> Search(int pageIndex, int pageSize, out long total, string ten_ban)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_ban);
        }
    }

}
