using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class NhanvienBusiness : INhanvienBusiness
    {
        private INhanvienRepository _res;
        public NhanvienBusiness(INhanvienRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(NhanvienModel model)
        {
            return _res.Create(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public NhanvienModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<NhanvienModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<NhanvienModel> Search(int pageIndex, int pageSize, out long total, string Ma_nv)
        {
            return _res.Search(pageIndex, pageSize, out total, Ma_nv);
        }
    }

}
