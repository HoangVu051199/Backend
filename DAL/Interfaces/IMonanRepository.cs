﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IMonanRepository
    {
        bool Create(MonanModel model);
        bool Delete(string id);
        MonanModel GetDatabyID(string id);
        List<MonanModel> GetDataAll();
        List<MonanModel> Search(int pageIndex, int pageSize, out long total, string Ma_mon);
    }
}
