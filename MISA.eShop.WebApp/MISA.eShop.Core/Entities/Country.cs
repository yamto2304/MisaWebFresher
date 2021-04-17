using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng thông tin quốc gia
    /// </summary>
    /// Created bu HuongDoll 13/04/2021
    public class Country : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CountryId { get; set; }
        /// <summary>
        /// Tên quốc gia
        /// </summary>

        public string CountryName { get; set; }

    }
}
