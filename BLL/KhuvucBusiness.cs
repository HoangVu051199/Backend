using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class KhuvucBusiness : IKhuvucBusiness
    {
        private IKhuvucRepository _res;
        public KhuvucBusiness(IKhuvucRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(KhuvucModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhuvucModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public KhuvucModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<KhuvucModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<KhuvucModel> Search(int pageIndex, int pageSize, out long total, string ten_kv)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_kv);
        }
    }

}
