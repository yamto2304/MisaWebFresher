using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    /// <summary>
    /// Class lấy dữ liệu từ bảng Ward
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class WardRepository : BaseRepository<Ward>, IWardRepository
    {
        /// <summary>
        /// Lấy tất cả xã có trong huyện
        /// </summary>
        /// <param name="entityId">Id của huyện</param>
        /// <returns>Tất cả xã trong huyện</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
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
