using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IKhuvucBusiness
    {
        bool Create(KhuvucModel model);
        bool Update(KhuvucModel model);
        bool Delete(string id);
        KhuvucModel GetDatabyID(string id);
        List<KhuvucModel> GetDataAll();
        List<KhuvucModel> Search(int pageIndex, int pageSize, out long total, string ten_kv);
    }
}
