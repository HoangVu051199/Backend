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
    public class NhanvienController : ControllerBase
    {
        private INhanvienBusiness _itemBusiness;
        public NhanvienController(INhanvienBusiness itemBusiness)
        {
            _itemBusiness = itemBusiness;
        }

        [Route("create-nhanvien")]
        [HttpPost]
        public NhanvienModel CreateNhanvien([FromBody] NhanvienModel model)
        {
            _itemBusiness.Create(model);
            return model;
        }

        [Route("delete-nhanvien")]
        [HttpPost]
        public IActionResult DeleteNhanvien([FromBody] Dictionary<string, object> formData)
        {
            string ma_nv = "";
            if (formData.Keys.Contains("ma_nv") && !string.IsNullOrEmpty(Convert.ToString(formData["ma_nv"]))) { ma_nv = Convert.ToString(formData["ma_nv"]); }
            _itemBusiness.Delete(ma_nv);
            return Ok();
        }

        [Route("update-nhanvien")]
        [HttpPost]
        public NhanvienModel UpdateNhanvien([FromBody] NhanvienModel model)
        {
            _itemBusiness.Update(model);
            return model;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public NhanvienModel GetDatabyID(string id)
        {
            return _itemBusiness.GetDatabyID(id);
        }

        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NhanvienModel> GetDatabAll()
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
                string ten_nv = "";
                if (formData.Keys.Contains("ten_nv") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_nv"]))) { ten_nv = Convert.ToString(formData["ten_nv"]); }
                long total = 0;
                var data = _itemBusiness.Search(page, pageSize, out total, ten_nv);
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
