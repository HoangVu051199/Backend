using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IKhachhangBusiness
    {
        bool Create(KhachhangModel model);
        bool Update(KhachhangModel model);
        bool Delete(string id);
        KhachhangModel GetDatabyID(string id);
        List<KhachhangModel> GetDataAll();
        List<KhachhangModel> Search(int pageIndex, int pageSize, out long total, string ten_kh);
    }
}
