using System;
using System.Collections.Generic;

namespace MISA.eShop.Core.Interfaces.Service
{
    /// <summary>
    /// Base service/ Tuong tac voi controller
    /// </summary>
    /// <typeparam name="MISAEntity"> kiểu của thực thể</typeparam>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy:Tuanhd (05/04/2021)
        IEnumerable<MISAEntity> GetEntities();

        /// <summary>
        /// Lấy dữ liệu dựa theo id
        /// </summary>
        /// <param name="entityId">id cua dữ liệu cần lấy</param>
        /// <returns>đối tượng</returns>
        /// CreatedBy:Tuanhd (05/04/2021)
        MISAEntity GetById(Guid entityId);

    }
}
