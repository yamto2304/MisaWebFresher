using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    public class WardRepository : BaseRepository<Ward>, IWardRepository
    {
        public IEnumerable<Ward> GetWardWithDistrict(Guid entityId)
        {
            string storeName = "Proc_GetWardWithDistrict";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("DistrictId", entityId);
            var entity = _dbConnection.Query<Ward>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}
