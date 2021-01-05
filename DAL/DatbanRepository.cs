using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DatbanRepository : IDatbanRepository
    {
        private IDatabaseHelper _dbHelper;
        public DatbanRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool Create(DatbanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dat_ban_create",
                "@madat", model.ma_dat,
                "@makh", model.ma_kh,
                "@maban", model.ma_ban,
                "@tenban", model.ten_ban,
                "@tenkh", model.ten_kh,
                "@sdt", model.sdt,
                "@gio", model.gio,
                "@ngaydat", model.ngay_dat);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dat_ban_delete",
                "@madat", id);
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
        public bool Update(DatbanModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_dat_ban_update",
                "@madat", model.ma_dat,
                "@makh", model.ma_kh,
                "@maban", model.ma_ban,
                "@tenban", model.ten_ban,
                "@tenkh", model.ten_kh,
                "@sdt", model.sdt,
                "@gio", model.gio,
                "@ngaydat", model.ngay_dat);
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
        public DatbanModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dat_ban_get_by_id",
                     "@madat", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DatbanModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DatbanModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dat_ban_all");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DatbanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DatbanModel> Search(int pageIndex, int pageSize, out long total, string ten_ban)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_dat_ban_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tenban", ten_ban);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DatbanModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
