using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    /// <summary>
    /// Class lấy dừ liệu từ bảng District
    /// </summary>
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        /// <summary>
        /// Lấy tất cả huyện có trong tỉnh
        /// </summary>
        /// <param name="entityId">Id của tỉnh</param>
        /// <returns>Toàn bộ huyện trong tỉnh</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
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
