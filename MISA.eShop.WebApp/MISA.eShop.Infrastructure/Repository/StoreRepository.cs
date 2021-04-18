using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;
using MySqlConnector;

namespace MISA.eShop.Infrastructure.Repository
{
    /// <summary>
    /// Class lấy dữ liệu từ bảng Store
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        /// <summary>
        /// Xóa store 
        /// </summary>
        /// <param name="storeId">d của store cần xóa</param>
        /// <returns>store đã xóa</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public int Delete(Guid storeId)
        {
            string storeName = $"Proc_Delete{_tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramName = $"@{_tableName}Id";
            dynamicParameters.Add(paramName, storeId);
            var entity = _dbConnection.Execute(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        /// <summary>
        /// Lấy ra store với code đã có 
        /// </summary>
        /// <param name="storeCode">Mã code của store cần tìm</param>
        /// <returns>Đưa ra store có code đã nhập</returns>
        /// CreatedBy: Tuanhd(18/4/2021)

        public Store GetByStoreCode(string storeCode)
        {
            string storeName = $"Proc_Get{_tableName}ByStoreCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramName = $"@{_tableName}Code";
            dynamicParameters.Add(paramName, storeCode);
            var entity = _dbConnection.Query<Store>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            if (entity != null) return entity;
            else return null;
        }

        /// <summary>
        /// Đếm tất cả store có trong bảng
        /// </summary>
        /// <returns>Số lượng store</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public int GetCountStore()
        {
            string storeName = "Proc_GetCountStores";
            var count = _dbConnection.Execute(storeName, commandType: CommandType.StoredProcedure);
            return count;
        }

        public IEnumerable<Store> GetIndexOffset(int position, int offset)
        {
            string storeName = "Proc_GetStoreByIndexOffset";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("positionStart", position);
            dynamicParameters.Add("offset", offset);
            var entities = _dbConnection.Query<Store>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
        }

        public IEnumerable<Store> GetStoreFilter(string storeCode, string storeNamee, string address, string phoneNumber, int? status)
        {
            string storeName = "Proc_GetStoreFilter";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("storeCode", storeCode);
            dynamicParameters.Add("storeName", storeNamee);
            dynamicParameters.Add("address", address);
            dynamicParameters.Add("phoneNumber", phoneNumber);
            dynamicParameters.Add("status", status);
            var entities = _dbConnection.Query<Store>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entities;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Thêm mới store
        /// </summary>
        /// <param name="entity">Dữ liệu store nhập vào</param>
        /// <returns>Số bản ghi được thêm vào</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public int Insert(Store entity)
        {
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        /// <summary>
        /// Cập nhật dữ liệu store
        /// </summary>
        /// <param name="entity">dữ liệu store nhập vào</param>
        /// <param name="storeId">Id của store cần cập nhật</param>
        /// <returns>Số bản ghi được thay đổi</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public int Update(Store entity, Guid storeId)
        {
            entity.StoreId = storeId;
            var storeName = $"Proc_Update{_tableName}";
            var rowAffects = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }
    }
}
