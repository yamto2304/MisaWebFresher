using Dapper;
using MySqlConnector;
using System.Data;
using System.Linq;

namespace MISA.eShop.Core.Exceptions
{
    /// <summary>
    /// Validate sever side
    /// </summary>
    /// CreatedBy : Tuanhd(18/4/2021)
    public class Validate
    {
        /// <summary>
        /// Validate mã cửa hàng không được trống
        /// </summary>
        /// <param name="code">Mã cửa hàng</param>
        /// CreatedBy : Tuanhd(18/4/2021)
        public static void CheckCodeEmpty(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ValidateExceptions("Mã cửa hàng không được phép để trống!");
            }
        }

        /// <summary>
        /// Validate địa chỉ cửa hàng không được trống
        /// </summary>
        /// <param name="address">Địa chỉ cửa hàng</param>
        /// CreatedBy : Tuanhd(18/4/2021)
        public static void CheckAddressEmpty(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ValidateExceptions("Tên cửa hàng không được phép để trống!");
            }
        }

        /// <summary>
        /// Validate tên cửa hàng không được trống
        /// </summary>
        /// <param name="storeName">Tên cửa hàng</param>
        /// CreatedBy : Tuanhd(18/4/2021)
        public static void CheckNameEmpty(string storeName)
        {
            if (string.IsNullOrEmpty(storeName))
            {
                throw new ValidateExceptions("Tên cửa hàng không được phép để trống!");
            }
        }

        public static void CheckDuplicateCodeInsert(string storeCode)
        {
            string _connectionString = "" +
                   "Host=47.241.69.179; " +
                   "Port=3306;" +
                   "User Id= dev; " +
                   "Password=12345678;" +
                   "Database= MF772_HUONGHTT_ESHOP;" +
                   "convert zero datetime=True";

            //"Database= MF772_HUONGHTT_ESHOP;" +
           //string _connectionString = "" +
           //        "Host=47.241.69.179; " +
           //        "Port=3306;" +
           //        "User Id= dev; " +
           //        "Password=12345678;" +
           //        "Database= TEST.MISA.eShop";

           IDbConnection _dbConnection = new MySqlConnection(_connectionString);
            //Validate dữ liệu:
            //-check trùng mã:
            // Kiểm tra xem có khách hàng nào có mã tương tự hay không ?:
            var sqlCheckExitCode = "Select StoreCode from Store Where StoreCode = @StoreCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@StoreCode", storeCode);
            var storeExitsCode = _dbConnection.Query<string>(sqlCheckExitCode, dynamicParameters);
            if (storeExitsCode.Count() > 0)
            {
                var erroInfo = new
                {
                    devMsg = "StoreCode duplucate!",
                    userMsg = "Thông tin mã cửa hàng bị trùng",
                    errorCode = "misa-001",
                    moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
                    traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
                };

                throw new ValidateExceptions("Mã cửa hàng không được để trùng");
            }
        }
    }
}
