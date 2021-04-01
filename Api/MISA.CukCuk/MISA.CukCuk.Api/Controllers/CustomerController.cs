using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.Api.Model;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{

    /// <summary>
    /// Api cho dữ liệu khách hàng
    /// CreatedBy:Tuanhd(01/04/2021)
    /// </summary>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
//=============================================================
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu trong DataBase
        /// Có dữ liệu : HttpCode 200
        /// KHông có dữ liệu : HttpCode 204
        /// </returns>
        /// CreatedBy:Tuanhd(01/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            //Khởi tạo kết nối tới Database
            string connectionString = "";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Thực hiện lấy dữ liệu từ Database
            var customers = dbConnection.Query<Customer>("SELECT * FROM Customer");
            //Kiểm tra kết quả và trả về cho Client
            if(customers.Count() == 0)
            {
                return NoContent();
            } else
            {
            return StatusCode(200, customers);

            }
        }
//=============================================================
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="customerId">Id của khách hàng</param>
        /// <returns>Thông tin của đối tượng tìm được</returns>
        /// CreatedBy:Tuanhd(01/04/2021)
        [HttpGet("{customerId}")]
        public IActionResult Get(Guid customerId)
        {
            return StatusCode(200, 1);
        }
//=============================================================
        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="customer">Dữ liệu khách hàng</param>
        /// <returns>
        /// - HttpCode: 200 nếu thêm được dữ liệu
        /// - Lỗi dữ liệu không hợp lệ : HttpCode 400 (Bad request)
        /// - HttpCode 500 : nếu có lỗi hoặc exception xảy ra trên Server
        /// </returns>
        /// CreatedBy:Tuanhd(01/04/2021)
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            return StatusCode(200);
        }
//=============================================================
        /// <summary>
        /// Sửa thông tin khách hàngThêm mới đối tượng
        /// </summary>
        /// <param name="customer">Dữ liệu khách hàng cần sửa</param>
        /// <returns>
        /// - HttpCode: 200 nếu thêm được dữ liệu
        /// - Lỗi dữ liệu không hợp lệ : HttpCode 400 (Bad request)
        /// - HttpCode 500 : nếu có lỗi hoặc exception xảy ra trên Server
        /// </returns>
        /// CreatedBy:Tuanhd(01/04/2021)
        [HttpPut("{customerId}")]
        public IActionResult Put(Customer customer, Guid customerId)
        {
            return StatusCode(200);
        }
        //=============================================================
        /// <summary>
        /// Xoá khách hàng
        /// </summary>
        /// <param name="customerId">Id khách hàng</param>
        /// <returns>
        /// - HttpCode: 200 nếu xóa thành công
        /// - Lỗi dữ liệu không hợp lệ : HttpCode 400 (Bad request)
        /// - HttpCode 500 : nếu có lỗi hoặc exception xảy ra trên Server
        /// </returns>
        /// CreatedBy:Tuanhd(01/04/2021)
        [HttpDelete("{customerId}")]
        public IActionResult Delete(Guid customerId)
        {
            return StatusCode(200);
        }
    }
}
