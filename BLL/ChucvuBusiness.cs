using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ChucvuBusiness : IChucvuBusiness
    {
        private IChucvuRepository _res;
        public ChucvuBusiness(IChucvuRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(ChucvuModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public ChucvuModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ChucvuModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ChucvuModel> Search(int pageIndex, int pageSize, out long total, string Ma_cv)
        {
            return _res.Search(pageIndex, pageSize, out total, Ma_cv);
        }
    }

}
