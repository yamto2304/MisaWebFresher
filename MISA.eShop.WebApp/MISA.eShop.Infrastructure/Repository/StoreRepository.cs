using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public int Delete(Guid storeId)
        {
            string storeName = $"Proc_Delete{_tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramName = $"@{_tableName}Id";
            dynamicParameters.Add(paramName, storeId);
            var entity = _dbConnection.Execute(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

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

        public int GetCountStore()
        {
            string storeName = "Proc_GetCountStores";
            var entity = _dbConnection.Execute(storeName, commandType: CommandType.StoredProcedure);
            return entity;
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

        public int Insert(Store entity)
        {
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }

        public int Update(Store entity, Guid storeId)
        {
            entity.StoreId = storeId;
            var storeName = $"Proc_Update{_tableName}";
            var rowAffects = _dbConnection.Execute(storeName, param: entity, commandType: CommandType.StoredProcedure);
            return rowAffects;
        }
    }
}
