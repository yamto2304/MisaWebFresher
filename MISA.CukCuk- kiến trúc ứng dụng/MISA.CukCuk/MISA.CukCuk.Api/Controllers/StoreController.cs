using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Api cho đối tượng cửa hàng
    /// </summary>
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        //===========================================================
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>
        ///  - Nếu có dữ liệu: trả về HttpCode 200
        ///  - Nếu không có dữ liệu : trả về HttpCode 204
        /// </returns>
        /// CreatedBy: Tuanhd (14/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
            //Khởi tạo kết nối tới database
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.eShop";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Thực hiện lấy dữ liệu từ Db
            var stores = dbConnection.Query<Store>("Proc_GetStores", commandType: CommandType.StoredProcedure);

            //Kiểm tra kết quả và return 
            if (stores.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(stores);
            }
        }
        //=======================================
        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="storeId">Id của bảng dữ liệu</param>
        /// <returns>Thông tin của 1 đối tượng</returns>
        /// CreatedBy: Tuanhd (14/04/2021)
        [HttpGet("{storeId}")]
        public IActionResult Get(Guid storeId)
        {
            //Khởi tạo kết nối tới database
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.eShop";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Thực hiện lấy dữ liệu từ Db
            var storeName = "Proc_GetStoreById";
            var storeParam = new
            {
                StoreId = storeId
            };
            var store = dbConnection.Query<Store>(storeName, param: storeParam, commandType: CommandType.StoredProcedure).FirstOrDefault();

            //Kiểm tra kết quả và return 
            if (store == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(store);
            }
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="store">Cửa hàng muốn thêm mới</param>
        /// <returns>
        ///  - Nếu thêm được dữ liệu    : 200 
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - Nếu có lỗi hoặc Exceotion xảy ra trên Server : 500 
        /// </returns>
        /// CreatedBy: Tuanhd (14/04/2021)
        [HttpPost]
        public IActionResult Post(Store store)
        {
            //Validate dữ liệu

            //- Check trùng mã
            //Khởi tạo kết nối tới database
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.eShop";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            //Kiểm tra xem có Object nào có cùng mã hay không
            var sqlCheckExitsCode = "Select StoreCode from Store Where StoreCode = @StoreCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@StoreCode", store.StoreCode);
            var storeExitsCode = dbConnection.Query<string>(sqlCheckExitsCode, dynamicParameters);
           
            if(storeExitsCode.Count() > 0)
            {
                var erroInfo = new
                {
                    devMsg = "CustomerCode duplicate",
                    userMsg = "Thông tin mã khách hàng không được phép trùng",
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };
                return BadRequest(erroInfo);
            }

            //Thực hiện lấy dữ liệu từ Db
            var storeName = "Proc_InsertStore";
            var storeParam = store;
            var rowAffects = dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);

            //Kiểm tra kết quả và return 
            if (rowAffects == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(store);
            }
        }

        /// <summary>
        /// Sửa thông tin cửa hàng
        /// </summary>
        /// <param name="store">Cửa hàng muốn sửa thông tin</param>
        /// <returns>
        ///  - Nếu thêm được dữ liệu    : 200 
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - Nếu có lỗi hoặc Exceotion xảy ra trên Server : 500 
        /// </returns>
        /// CreatedBy: Tuanhd (14/04/2021)
        [HttpPut("{storeId}")]
        public IActionResult Put(Store store, Guid storeId)
        {
            //Validate dữ liệu

            //- Check trùng mã
            //Khởi tạo kết nối tới database
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.eShop";
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            //Kiểm tra xem có Object nào có cùng mã hay không
            store.StoreId = storeId;
            //Check store trùng code (trừ chính mình)
            var sqlCheckExitsCode = "Select StoreCode from Store Where StoreCode = @StoreCode AND StoreId <> @StoreId";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@StoreCode", store.StoreCode);
            dynamicParameters.Add("@StoreId", store.StoreId);

            var storeExitscode = dbConnection.Query<string>(sqlCheckExitsCode, dynamicParameters);
            if (storeExitscode.Count() > 0)
            {
                var erroInfo = new
                {
                    devMsg = "CustomerCode duplicate",
                    userMsg = "Thông tin mã khách hàng không được phép trùng",
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };
                return Ok(erroInfo);
            }
            //Thực hiện lấy dữ liệu từ Db
            var storeName = "Proc_UpdateStore";
            var storeParam = store;
            var rowAffects = dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);

            //Kiểm tra kết quả và return 
            if (rowAffects == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(store);
            }
        }

        /// <summary>
        /// Xóa cửa hàng
        /// </summary>
        /// <param name="storeId">Khóa chính</param>
        /// <returns>
        ///  - Nếu thêm được dữ liệu    : 200 
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - Nếu có lỗi hoặc Exceotion xảy ra trên Server : 500 
        /// </returns>
        /// CreatedBy: Tuanhd (14/04/2021)
        /// ModifiedBy : Tuanhd (15/04/2021)
        [HttpDelete("{storeId}")]
        public IActionResult Delete(Guid storeId)
        {
            //Khởi tạo kết nối tới database
            string connectionString = "" +
                "Host=47.241.69.179; " +
                "Port=3306;" +
                "User Id= dev; " +
                "Password=12345678;" +
                "Database= TEST.MISA.eShop";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            //Thực hiện xoá dữ liệu từ Db
            var storeParam = new
            {
                StoreId = storeId
            };
            var rowAffect = dbConnection.Execute("Proc_DeleteStore",param: storeParam, commandType: CommandType.StoredProcedure);

            //Kiểm tra kết quả và return 
            if (rowAffect == 0)
            {
                var erroInfo = new
                {
                    devMsg = "No record deleted !",
                    userMsg = "Không thể xóa, vui lòng kiểm tra lại",
                    errorCode = "misa-002",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };
                return BadRequest(erroInfo);
            }
                else
            {
                return Ok(rowAffect + " bản ghi đã được xóa thành công !");
            }           
        }
    }
}
