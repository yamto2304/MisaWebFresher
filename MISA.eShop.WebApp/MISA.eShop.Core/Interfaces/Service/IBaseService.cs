using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Interfaces.Service
{
    /// <summary>
    /// Base service/ Tuong tac voi controller
    /// </summary>
    /// <typeparam name="MISAEntity"> kiểu của thực thể</typeparam>
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        /// CreatedBy:HuongDoll 05/04/2021
        IEnumerable<MISAEntity> GetEntities();
        /// <summary>
        /// Lấy dữ liệu dựa theo id
        /// </summary>
        /// <param name="entityId">id cua dữ liệu cần lấy</param>
        /// <returns>đối tượng</returns>
        /// CreatedBy:HuongDoll 05/04/2021
        MISAEntity GetById(Guid entityId);

    }
}
