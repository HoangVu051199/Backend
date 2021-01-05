using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachhangController : ControllerBase
    {
        private IKhachhangBusiness _itemBusiness;
        public KhachhangController(IKhachhangBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-khachhang")]
        [HttpPost]
        public KhachhangModel CreateKhachhang([FromBody] KhachhangModel model)
        {
            model.ma_kh = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-khachhang")]
        [HttpPost]
        public IActionResult DeleteKhachhang([FromBody] Dictionary<string, object> formData)
        {
            string ma_kh = "";
            if (formData.Keys.Contains("ma_kh") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_kh"]))) { ma_kh = Convert.ToString(formData["ma_kh"]); }
            _itemBusiness.Delete(ma_kh);
            return Ok();
        }

        [Route("update-khachhang")]
        [HttpPost]
        public KhachhangModel UpdateKhachhang([FromBody] KhachhangModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhachhangModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<KhachhangModel> GetDatabAll()
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
                string ten_kh = "";
                if (formData.Keys.Contains("ten_kh") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_kh"]))) { ten_kh = Convert.ToString(formData["ten_kh"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, ten_kh);
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
