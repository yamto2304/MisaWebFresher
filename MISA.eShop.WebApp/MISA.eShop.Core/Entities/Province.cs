using System;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng thông tin tỉnh/thành phố
    /// </summary>
    /// CreatedBy : Tuanhd (13/04/2021)
    public class Province : BaseEntity
    {
        /// <summary>
        /// Khóa chính/ Mã tỉnh
        /// </summary>
        public Guid ProvinceId { get; set; }

        /// <summary>
        /// Tên tỉnh/thành phố
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// Khóa ngoại với bảng quốc gia
        /// </summary>
        public Guid CountryId { get; set; }

    }
}
