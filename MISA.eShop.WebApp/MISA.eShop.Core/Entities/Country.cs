using System;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng thông tin quốc gia
    /// </summary>
    /// CreatedBy : Tuanhd (13/04/2021)
    public class Country : BaseEntity
    {
        /// <summary>
        /// Khóa chính : Id quốc gia
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Tên quốc gia
        /// </summary>
        public string CountryName { get; set; }

    }
}
