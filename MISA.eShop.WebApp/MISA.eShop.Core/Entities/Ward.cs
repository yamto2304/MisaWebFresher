using System;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng phường/xã
    /// </summary>
    /// CreatedBy : Tuanhd (13/04/2021)
    public class Ward : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid WardId { get; set; }

        /// <summary>
        /// Tên phường/xã
        /// </summary>
        public string WardName { get; set; }

        /// <summary>
        /// khóa chính với bảng quận/huyện
        /// </summary>
        public Guid DistrictId { get; set; }

    }
}
