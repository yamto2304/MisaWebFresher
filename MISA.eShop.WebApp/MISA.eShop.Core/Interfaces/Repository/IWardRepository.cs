using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.eShop.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface cho dữ liệu Xã/Phường kết nối với repository
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IWardRepository : IBaseRepository<Ward>
    {
        /// <summary>
        /// Lấy tất cả Xã/Phường phố có trong huyện
        /// </summary>
        /// <param name="entityId">Id của huyện</param>
        /// <returns>Tất cả Xã/Phường có trong huyện</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        IEnumerable<Ward> GetWardWithDistrict(Guid entityId);
    }
}
