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
    public class LoaiController : ControllerBase
    {
        private ILoaiBusiness _itemBusiness;
        public LoaiController(ILoaiBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-loai")]
        [HttpPost]
        public LoaiModel CreateLoai([FromBody] LoaiModel model)
        {
            model.ma_loai = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-loai")]
        [HttpPost]
        public IActionResult DeleteLoai([FromBody] Dictionary<string, object> formData)
        {
            string ma_loai = "";
            if (formData.Keys.Contains("ma_loai") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_loai"]))) { ma_loai = Convert.ToString(formData["ma_loai"]); }
            _itemBusiness.Delete(ma_loai);
            return Ok();
        }

        [Route("update-loai")]
        [HttpPost]
        public LoaiModel UpdateLoai([FromBody] LoaiModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public LoaiModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<LoaiModel> GetDatabAll()
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
                string ten_loai = "";
                if (formData.Keys.Contains("ten_loai") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_loai"]))) { ten_loai = Convert.ToString(formData["ten_loai"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, ten_loai);
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
