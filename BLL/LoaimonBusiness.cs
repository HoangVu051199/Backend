using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class LoaimonBusiness : ILoaimonBusiness
    {
        private ILoaimonRepository _res;
        public LoaimonBusiness(ILoaimonRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(LoaimonModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public LoaimonModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<LoaimonModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<LoaimonModel> Search(int pageIndex, int pageSize, out long total, string Ma_loai)
        {
            return _res.Search(pageIndex, pageSize, out total, Ma_loai);
        }
    }

}
