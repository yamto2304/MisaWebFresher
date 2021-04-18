using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    /// <summary>
    /// Class lấy dữ liệu từ bảng Province
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        /// <summary>
        /// Lấy tất cả tỉnh có trong nước
        /// </summary>
        /// <param name="entityId">Id của nước</param>
        /// <returns>Toàn bộ tỉnh trong nước</returns>
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
