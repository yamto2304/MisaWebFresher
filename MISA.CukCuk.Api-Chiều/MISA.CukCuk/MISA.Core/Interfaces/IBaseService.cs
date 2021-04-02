using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    /// <summary>
    /// Base service
    /// Interface for Core ?
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ data
        /// </summary>
        /// <returns></returns>
        /// CreatedBy: Tuanhd (02/04/21)
        IEnumerable<MISAEntity> GetEntities();

        /// <summary>
        /// Lấy data theo ID
        /// </summary>
        /// <returns>ID</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        MISAEntity GetById();

        /// <summary>
        /// THêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// CreatedBy: Tuanhd (02/04/21)
        int Insert(MISAEntity entity);

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns>Số bản ghi sửa được</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        int Update(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns>Số bản ghi xóa được</returns>
        /// CreatedBy: Tuanhd (02/04/21)
        int Delete(Guid entityId);
    }
}
