using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class NhanvienRepository : INhanvienRepository
    {
        private IDatabaseHelper _dbHelper;
        public NhanvienRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(NhanvienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhan_vien_create",
                "@Manv", model.Ma_nv,
                "@Macv", model.Ma_cv,
                "@Tennv", model.Ten_nv,
                "@Gioitinh", model.Gioi_tinh,
                "@Ngaysinh", model.Ngay_sinh,
                "@Diachi", model.Dia_chi,
                "@Sodienthoai", model.So_dien_thoai,
                "@Chucvu", model.Chuc_vu);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_nhan_vien_delete",
                "@Manv", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public NhanvienModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhan_vien_get_by_id",
                     "@Manv", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanvienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NhanvienModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhan_vien_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhanvienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhanvienModel> Search(int pageIndex, int pageSize, out long total, string Ma_nv)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_nhan_vien_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Manv", Ma_nv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhanvienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
