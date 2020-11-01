﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface ILoaimonBusiness
    {
        bool Create(LoaimonModel model);
        bool Delete(string id);
        LoaimonModel GetDatabyID(string id);
        List<LoaimonModel> GetDataAll();
        List<LoaimonModel> Search(int pageIndex, int pageSize, out long total, string Ma_loai);
    }
}
