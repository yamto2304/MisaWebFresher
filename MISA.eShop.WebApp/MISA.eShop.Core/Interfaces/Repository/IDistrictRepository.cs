using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.eShop.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface cho dữ liệu Quận/Huyện kết nối với repository
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IDistrictRepository : IBaseRepository<District>
    {
        /// <summary>
        /// Lấy tất cả quận huyện có trong tỉnh
        /// </summary>
        /// <param name="entityId">Id của tỉnh</param>
        /// <returns>Tất cả quận/huyện có trong tỉnh</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        IEnumerable<District> GetDistrictWithProvince(Guid entityId);
    }
}
