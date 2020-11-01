using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ChucvuRepository : IChucvuRepository
    {
        private IDatabaseHelper _dbHelper;
        public ChucvuRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(ChucvuModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_chuc_vu_create",
                "@Macv", model.Ma_cv,
                "@Tencv", model.Ten_cv);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_chuc_vu_delete",
                "@Macv", id);
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
        public ChucvuModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_chuc_vu_get_by_id",
                     "@Macv", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChucvuModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChucvuModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_chuc_vu_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChucvuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChucvuModel> Search(int pageIndex, int pageSize, out long total, string Ma_cv)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_chuc_vu_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@Macv", Ma_cv);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ChucvuModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
