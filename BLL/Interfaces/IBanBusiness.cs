﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IBanBusiness
    {
        bool Create(BanModel model);
        bool Update(BanModel model);
        bool Delete(string id);
        BanModel GetDatabyID(string id);
        List<BanModel> GetDataAll();
        List<BanModel> Search(int pageIndex, int pageSize, out long total, string ten_ban);
    }
}
