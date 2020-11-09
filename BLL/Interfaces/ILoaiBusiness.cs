using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ILoaiBusiness
    {
        bool Create(LoaiModel model);
        bool Update(LoaiModel model);
        bool Delete(string id);
        LoaiModel GetDatabyID(string id);
        List<LoaiModel> GetDataAll();
        List<LoaiModel> Search(int pageIndex, int pageSize, out long total, string ten_loai);
    }
}
