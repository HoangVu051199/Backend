using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class BanBusiness : IBanBusiness
    {
        private IBanRepository _res;
        public BanBusiness(IBanRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(BanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(BanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public BanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<BanModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<BanModel> Search(int pageIndex, int pageSize, out long total, string ten_ban)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_ban);
        }
    }

}
