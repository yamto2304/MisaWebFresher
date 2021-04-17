using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng thông tin tỉnh/thành phố
    /// </summary>
    /// Created bu HuongDoll 13/04/2021
    public class Province : BaseEntity
    {
        /// <summary>
        /// Khóa chính
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
