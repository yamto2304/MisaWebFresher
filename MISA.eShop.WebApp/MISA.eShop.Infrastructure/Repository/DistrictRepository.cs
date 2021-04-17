using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        public IEnumerable<District> GetDistrictWithProvince(Guid entityId)
        {
            string storeName = "Proc_GetDistrictWithProvince";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("ProvinceId", entityId);
            var entity = _dbConnection.Query<District>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        
    }
}
