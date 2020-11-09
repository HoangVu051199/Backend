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
    public class BanController : ControllerBase
    {
        private IBanBusiness _itemBusiness;
        public BanController(IBanBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-ban")]
        [HttpPost]
        public BanModel CreateBan([FromBody] BanModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-ban")]
        [HttpPost]
        public IActionResult DeleteBan([FromBody] Dictionary<string, object> formData)
        {
            string ma_ban = "";
            if (formData.Keys.Contains("ma_ban") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_ban"]))) { ma_ban = Convert.ToString(formData["ma_ban"]); }
            _itemBusiness.Delete(ma_ban);
            return Ok();
        }

        [Route("update-ban")]
        [HttpPost]
        public BanModel UpdateBan([FromBody] BanModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public BanModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<BanModel> GetDatabAll()
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
                string ten_ban = "";
                if (formData.Keys.Contains("ten_ban") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_ban"]))) { ten_ban = Convert.ToString(formData["ten_ban"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, ten_ban);
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
