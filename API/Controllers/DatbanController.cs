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
    public class DatbanController : ControllerBase
    {
        private IDatbanBusiness _itemBusiness;
        public DatbanController(IDatbanBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-datban")]
        [HttpPost]
        public DatbanModel CreateDatban([FromBody] DatbanModel model)
        {
            model.ma_dat = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-datban")]
        [HttpPost]
        public IActionResult DeleteDatban([FromBody] Dictionary<string, object> formData)
        {
            string ma_dat = "";
            if (formData.Keys.Contains("ma_dat") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_dat"]))) { ma_dat = Convert.ToString(formData["ma_dat"]); }
            _itemBusiness.Delete(ma_dat);
            return Ok();
        }

        [Route("update-datban")]
        [HttpPost]
        public DatbanModel UpdateDatban([FromBody] DatbanModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public DatbanModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DatbanModel> GetDatabAll()
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
