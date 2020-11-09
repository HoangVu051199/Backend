using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonanController : ControllerBase
    {
        private IMonanBusiness _itemBusiness;
        public MonanController(IMonanBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-monan")]
        [HttpPost]
        public MonanModel CreateMonan([FromBody] MonanModel model)
        {
            /*if (model.hinh_anh != null)
            {
                var arrData = model.hinh_anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinh_anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.ma_mon = Guid.NewGuid().ToString();*/
            _itemBusiness.Create(model);
            return model;
        }

        [Route("update-monan")]
        [HttpPost]
        public MonanModel UpdateMonan([FromBody] MonanModel model)
        {
            /*if (model.hinh_anh != null)
            {
                var arrData = model.hinh_anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinh_anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }*/
            _itemBusiness.Create(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public MonanModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<MonanModel> GetDatabAll()
        {
            return _itemBusiness.GetDataAll();
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_mon = "";
                if (formData.Keys.Contains("ten_mon") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_mon"]))) { ten_mon = Convert.ToString(formData["ten_mon"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, ten_mon);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }

    }
}
