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
    public class ChucvuController : ControllerBase
    {
        private IChucvuBusiness _itemBusiness;
        public ChucvuController(IChucvuBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-item")]
        [HttpPost]
        public ChucvuModel CreateItem([FromBody] ChucvuModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-cv")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string Ma_cv = "";
            if (formData.Keys.Contains("Ma_cv") && !string.IsNullOrEmpty(Convert.ToString(formData["Ma_cv"]))) { Ma_cv = Convert.ToString(formData["Ma_cv"]); }
            _itemBusiness.Delete(Ma_cv);
            return Ok();
        }



        [Route("get-by-id/{id}")]
        [HttpGet]
        public ChucvuModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ChucvuModel> GetDatabAll()
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
                string Ma_cv = "";
                if (formData.Keys.Contains("Ma_cv") && !string.IsNullOrEmpty(Convert.ToString(formData["Ma_cv"]))) { Ma_cv = Convert.ToString(formData["Ma_cv"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, Ma_cv);
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
