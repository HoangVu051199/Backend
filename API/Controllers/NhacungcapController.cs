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
    public class NhacungcapController : ControllerBase
    {
        private INhacungcapBusiness _itemBusiness;
        public NhacungcapController(INhacungcapBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-ncc")]
        [HttpPost]
        public NhacungcapModel CreateNhacc([FromBody] NhacungcapModel model)
        {
            model.ma_ncc = Guid.NewGuid().ToString();
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-ncc")]
        [HttpPost]
        public IActionResult DeleteNhacc([FromBody] Dictionary<string, object> formData)
        {
            string ma_ncc = "";
            if (formData.Keys.Contains("ma_ncc") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_ncc"]))) { ma_ncc = Convert.ToString(formData["ma_ncc"]); }
            _itemBusiness.Delete(ma_ncc);
            return Ok();
        }

        [Route("update-ncc")]
        [HttpPost]
        public NhacungcapModel UpdateNhacungcap([FromBody] NhacungcapModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public NhacungcapModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NhacungcapModel> GetDatabAll()
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
                string ten_ncc = "";
                if (formData.Keys.Contains("ten_ncc") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_ncc"]))) { ten_ncc = Convert.ToString(formData["ten_ncc"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, ten_ncc);
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
