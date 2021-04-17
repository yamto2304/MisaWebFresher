using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Thực thể chung
    /// </summary>
    /// Created by HuongDoll 05/04/2021
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
