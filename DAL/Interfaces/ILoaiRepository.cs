using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ILoaiRepository
    {
        bool Create(LoaiModel model);
        bool Update(LoaiModel model);
        bool Delete(string id);
        LoaiModel GetDatabyID(string id);
        List<LoaiModel> GetDataAll();
        List<LoaiModel> Search(int pageIndex, int pageSize, out long total, string ten_loai);
    }
}
