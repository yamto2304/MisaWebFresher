using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace MISA.eShop.Core.Interfaces.Service
{
    /// <summary>
    /// Interface cho dữ liệu Store kết nối với Controller
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IStoreService : IBaseService<Store>
    {
        /// <summary>
        /// Xóa cửa hàng theo ID
        /// </summary>
        /// <param name="storeId">Id cửa hàng</param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        int Delete(Guid storeId);

        /// <summary>
        /// Đếm có tất cả bao nhiêu cửa hàng
        /// </summary>
        /// <returns>Tổng số cửa hàng trong bảng Store</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        int GetCountStore();
        IEnumerable<Store> GetIndexOffset(int position, int offset);
        /// <summary>
        /// Lấy dữ liệu dựa theo code
        /// </summary>
        /// <param name="storeCode">mã code của cửa hàng cần lấy</param>
        /// <returns>cửa hàng</returns>
        /// CreatedBy:Tuanhd (05/04/2021)
        Store GetByStoreCode(string storeCode);
        IEnumerable<Store> GetStoreFilter(string storeCode, string storeName, string address, string phoneNumber, int? status);

        /// <summary>
        /// Thêm cửa hàng
        /// </summary>
        /// <param name="entity">Đối tượng cửa hàng </param>
        /// <returns>Số bản ghi được thêm vào</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        int Insert(Store entity);

        /// <summary>
        /// Sửa thông tin cửa hàng
        /// </summary>
        /// <param name="entity">Đối tượng cửa hàng</param>
        /// <param name="storeId">Id cửa hàng cần sửa</param>
        /// <returns>Số bản ghi được cập nhật</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        int Update(Store entity, Guid storeId);

        /// <summary>
        /// Validate sever side
        /// </summary>
        /// <param name="store">Dữ liệu cửa hàng</param>
        /// <returns>Dữ liệu hợp lệ hay không</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        bool ValidateStore(Store store);
    }
}
