using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin cửa hàng
    /// CreatedBy : Tuanhd (14/4/2021)
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        public Guid StoreId { get; set; }

        /// <summary>
        /// Mã cửa hàng
        /// </summary>
        public String StoreCode { get; set; }

        /// <summary>
        /// Tên cửa hàng
        /// </summary>
        public String StoreName { get; set; }

        /// <summary>
        /// Địa chỉ cửa hàng
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public String PhoneNumber { get; set; }

        /// <summary>
        /// Mã số thuế của cửa hàng
        /// </summary>
        public String StoreTaxCode { get; set; }

        /// <summary>
        /// Mã quốc gia
        /// </summary>
        public Guid CountryId { get; set; }

        /// <summary>
        /// Mã tỉnh/Thành phố
        /// </summary>
        public Guid ProvinceId { get; set; }

        /// <summary>
        /// Mã Quận/Huyện
        /// </summary>
        public Guid DistrictId { get; set; }

        /// <summary>
        /// Mã Xã/Phường
        /// </summary>
        public Guid WardId { get; set; }

        /// <summary>
        /// Tên đường
        /// </summary>
        public String Street { get; set; }

        /// <summary>
        /// Trạng thái theo dõi
        /// </summary>
        public int Status { get; set; }

        //===================
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
