using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Model
{
    /// <summary>
    /// Thông tin khách hàng
    /// CreatedBy: Tuanhd(01/04/2021
    /// </summary>
    public class Customer : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính ( 0 - Nữ , 1 - Nam)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Mã khách hàng (FK)
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Nhóm khách hàng
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Sđt
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Tên Cty
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Ms Thuế của cty
        /// </summary>
        public string CompanTaxCode { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        public string Note { get; set; }
    }
}
