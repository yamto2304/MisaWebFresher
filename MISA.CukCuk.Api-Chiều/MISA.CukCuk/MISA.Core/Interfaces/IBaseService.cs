using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// Base service
    /// </summary>
    /// <typeparam name="MISAEntity">Kiểu của thực thể</typeparam>
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của bảng trong database
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        IReadOnlyList<MISAEntity> GetEntities();

        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <returns>1 thực thể duy nhất có ID tương ứng</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        MISAEntity GetById();

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Số bản ghi thêm mới vào DB</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        int Insert(MISAEntity entity);

        /// <summary>
        /// Sửa thông tin của đối tượng
        /// </summary>
        /// <param name="entity">Thực thể đã được chỉnh sửa</param>
        /// <param name="entityId">ID</param>
        /// <returns>Số bản ghi đã update được vào DB</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa thông tin đối tượng
        /// </summary>
        /// <param name="entityId">ID</param>
        /// <returns>Số bản ghi đã xóa trong DB</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        int Delete(Guid entityId);
    }
}
