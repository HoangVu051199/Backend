using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class NhacungcapBusiness : INhacungcapBusiness
    {
        private INhacungcapRepository _res;
        public NhacungcapBusiness(INhacungcapRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(NhacungcapModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhacungcapModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public NhacungcapModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<NhacungcapModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<NhacungcapModel> Search(int pageIndex, int pageSize, out long total, string ten_ncc)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_ncc);
        }
    }

}
