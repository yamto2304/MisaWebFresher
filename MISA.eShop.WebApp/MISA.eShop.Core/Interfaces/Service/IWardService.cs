using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Interfaces.Service
{
    /// <summary>
    /// Interface cho dữ liệu Ward kết nối với Controller
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IWardService : IBaseService<Ward>
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
