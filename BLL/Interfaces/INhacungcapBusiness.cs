using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface INhacungcapBusiness
    {
        bool Create(NhacungcapModel model);
        bool Update(NhacungcapModel model);
        bool Delete(string id);
        NhacungcapModel GetDatabyID(string id);
        List<NhacungcapModel> GetDataAll();
        List<NhacungcapModel> Search(int pageIndex, int pageSize, out long total, string ten_ncc);
    }
}
