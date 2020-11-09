using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class KhachhangBusiness : IKhachhangBusiness
    {
        private IKhachhangRepository _res;
        public KhachhangBusiness(IKhachhangRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(KhachhangModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhachhangModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public KhachhangModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<KhachhangModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<KhachhangModel> Search(int pageIndex, int pageSize, out long total, string ten_kh)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_kh);
        }
    }

}
