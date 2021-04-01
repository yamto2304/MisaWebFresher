using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    /// <summary>
    /// Thông tin nhóm khách hàng
    /// CreatedBy:Tuanhd(01/04/2021)
    /// </summary>
    public class CustomerGroup : BaseEntity
    {
        /// <summary>
        /// PrimaryKey of Table CustomerGroup
        /// </summary>
        public Guid CutomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm KH
        /// </summary>
        public String CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// ???
        /// </summary>
        public Guid? ParentId { get; set; }
    }
}
