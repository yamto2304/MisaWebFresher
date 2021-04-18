using System;
using System.Collections.Generic;

namespace MISA.eShop.Core.Interfaces.Repository
{
    /// <summary>
    /// Base repository / thao tác với database
    /// </summary>
    /// <typeparam name="MISAEntity">kieur của thực thể truyền vào</typeparam>
    /// CreatedBy:Tuanhd (05/04/2021)
    public interface IBaseRepository<MISAEntity>
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
