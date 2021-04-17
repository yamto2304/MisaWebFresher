using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Entities
{
    /// <summary>
    /// Bảng cửa hàng
    /// </summary>
    /// Created bu HuongDoll 13/04/2021
    public class Store : BaseEntity
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid StoreId { get; set; }
        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        public string StoreCode { get; set; }
        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string StoreTaxCode { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng quốc gia
        /// </summary>
        public Guid? CountryId { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng tỉnh/thành phố
        /// </summary>
        public Guid? ProvinceId { get; set; }
        /// <summary>
        /// Khóa ngoại với bảng quận/huyện
        /// </summary>
        public Guid? DistrictId { get; set; }
        /// <summary>
        /// KHóa ngoại với bảng phường/ xã
        /// </summary>
        public Guid? WardId { get; set; }
        /// <summary>
        /// Đường phố
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Trạng thái hoạt động 
        /// ( 0 - Đang hoạt động, 1 - Đang đóng cửa )
        /// </summary>
        public int? Status { get; set; }
    }
}
