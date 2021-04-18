using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.eShop.Core.Interfaces.Repository
{
    /// <summary>
    /// Interface cho dữ liệu Tỉnh/Thành phố kết nối với repository
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IProvinceRepository : IBaseRepository<Province>
    {
        /// <summary>
        /// Lấy tất cả Tỉnh/Thành phố có trong nước
        /// </summary>
        /// <param name="entityId">Id của nước</param>
        /// <returns>Tất cả Tỉnh/Thành có trong nước</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        IEnumerable<Province> GetProvinceWithCountry(Guid entityId);
    }
}
