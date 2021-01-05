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
        private string _path;
        public MonanController(IMonanBusiness itemBusiness, IConfiguration configuration)
        {
            _itemBusiness = itemBusiness;
            _path = configuration["AppSettings:PATH"];
        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("create-monan")]
        [HttpPost]
        public MonanModel CreateMonan([FromBody] MonanModel model)
        {
            if (model.hinh_anh != null)
            {
                var arrData = model.hinh_anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinh_anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            model.ma_mon = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("update-monan")]
        [HttpPost]
        public MonanModel UpdateMonan([FromBody] MonanModel model)
        {
            if (model.hinh_anh != null)
            {
                var arrData = model.hinh_anh.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/{arrData[0]}";
                    model.hinh_anh = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _itemBusiness.Update(model);
            return model;
        }

        [Route("delete-monan")]
        [HttpPost]
        public IActionResult DeleteMon([FromBody] Dictionary<string, object> formData)
        {
            string ma_mon = "";
            if (formData.Keys.Contains("ma_mon") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_mon"]))) { ma_mon = Convert.ToString(formData["ma_mon"]); }
            _itemBusiness.Delete(ma_mon);
            return Ok();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public MonanModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }
        [Route("get-by-loai/{id}")]
        [HttpGet]
        public List<MonanModel> GetDatabyIDloai(string id)
        {
            return _itemBusiness.GetDatabyIDloai(id);
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
