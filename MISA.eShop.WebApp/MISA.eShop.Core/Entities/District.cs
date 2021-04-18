using System;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng quận/ huyện
    /// </summary>
    /// CreatedBy : Tuanhd 13/04/2021
    public class District : BaseEntity
    {
        /// <summary>
        /// Khóa chính/ Mã huyện
        /// </summary>
        public Guid DistrictId { get; set; }

        /// <summary>
        /// Tên quận/huyện
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// Khóa ngoại với bảng tỉnh/thành phố
        /// </summary>
        public Guid ProvinceId { get; set; }
    }
}
