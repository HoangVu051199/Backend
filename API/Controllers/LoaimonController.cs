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
    public class LoaimonController : ControllerBase
    {
        private ILoaimonBusiness _itemBusiness;
        public LoaimonController(ILoaimonBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-loai")]
        [HttpPost]
        public LoaimonModel CreateLoai([FromBody] LoaimonModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-loai")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string Ma_loai = "";
            if (formData.Keys.Contains("Ma_loai") && !string.IsNullOrEmpty(Convert.ToString(formData["Ma_loai"]))) { Ma_loai = Convert.ToString(formData["Ma_loai"]); }
            _itemBusiness.Delete(Ma_loai);
            return Ok();
        }



        [Route("get-by-id/{id}")]
        [HttpGet]
        public LoaimonModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<LoaimonModel> GetDatabAll()
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
                string Ma_loai = "";
                if (formData.Keys.Contains("Ma_loai") && !string.IsNullOrEmpty(Convert.ToString(formData["Ma_loai"]))) { Ma_loai = Convert.ToString(formData["Ma_loai"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, Ma_loai);
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
