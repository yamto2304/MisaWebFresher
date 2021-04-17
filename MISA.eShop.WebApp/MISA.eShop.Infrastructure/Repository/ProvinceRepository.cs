using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public IEnumerable<Province> GetProvinceWithCountry(Guid entityId)
        {
            string storeName = "Proc_GetProvinceWithCountry";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("CountryId", entityId);
            var entity = _dbConnection.Query<Province>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
    }
}
