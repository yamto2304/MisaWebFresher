using System;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Thực thể chung
    /// </summary>
    /// CreatedBy : Tuanhd (05/04/2021)
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo bản ghi
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa đổi bản ghi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa đổi bản ghi
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
