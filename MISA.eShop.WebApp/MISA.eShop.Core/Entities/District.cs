using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng quận/ huyện
    /// </summary>
    /// Created bu HuongDoll 13/04/2021
    public class District : BaseEntity
    {
        /// <summary>
        /// Khóa chính
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
