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
    public class KhuvucController : ControllerBase
    {
        private IKhuvucBusiness _itemBusiness;
        public KhuvucController(IKhuvucBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-khuvuc")]
        [HttpPost]
        public KhuvucModel CreateKhuvuc([FromBody] KhuvucModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-Khuvuc")]
        [HttpPost]
        public IActionResult DeleteKhuvuc([FromBody] Dictionary<string, object> formData)
        {
            string ma_kv = "";
            if (formData.Keys.Contains("ma_kv") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_kv"]))) { ma_kv = Convert.ToString(formData["ma_kv"]); }
            _itemBusiness.Delete(ma_kv);
            return Ok();
        }

        [Route("update-khuvuc")]
        [HttpPost]
        public KhuvucModel UpdateKhuvuc([FromBody] KhuvucModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public KhuvucModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<KhuvucModel> GetDatabAll()
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
                string ten_kv = "";
                if (formData.Keys.Contains("ten_kv") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_kv"]))) { ten_kv = Convert.ToString(formData["ten_kv"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, ten_kv);
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
