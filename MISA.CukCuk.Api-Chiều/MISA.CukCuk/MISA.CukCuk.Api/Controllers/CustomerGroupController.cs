using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using MISA.Core.Interfaces;
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
using MISA.CukCuk.Api.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
<<<<<<< HEAD
    public class CustomerGroupController : BaseEntityController<CustomerGroup>
    {
=======
    public class CustomerGroupController : BaseEntityController<CustomerGroupND>
    {
        public CustomerGroupController(IBaseService<CustomerGroupND> baseService):base(baseService)
        {
        }


>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="customer">Thông tin khách hàng cần chỉnh sửa</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpPut("{customerId}")]
<<<<<<< HEAD
        public IActionResult Put(CustomerGroup customer, Guid customerId)
=======
        public IActionResult Put(CustomerGroupND customer, Guid customerId)
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
        {
                return Ok(customer);
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerId">Khóa chính bảng thông tin khách hàng</param>
        /// <returns>
        ///  - HttpCode: 200 nếu xóa thành công
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
                return Ok();
        }
    }
}
