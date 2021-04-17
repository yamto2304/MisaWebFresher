using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Exceptions
{
    class Validate
    {
        public static void CheckCodeEmpty(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ValidateExceptions("Mã khách hàng không được phép để trống!");
            }
        }

        public static void CheckDuplicateCodeInsert(string code)
        {
            //string _connectionString = "" +
            //   "Host=47.241.69.179; " +
            //   "Port=3306;" +
            //   "User Id= dev; " +
            //   "Password=12345678;" +
            //   "Database= MF0_NVManh_CukCuk02";
            //IDbConnection _dbConnection = new MySqlConnection(_connectionString);
            //Validate dữ liệu:
            //-check trùng mã:
            // Kiểm tra xem có khách hàng nào có mã tương tự hay không ?:
            //var sqlCheckExitCode = "Select CustomerCode from Customer Where CustomerCode = @CustomerCode";
            //DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@CustomerCode", customerCode);
            //var customerExitsCode = _dbConnection.Query<string>(sqlCheckExitCode, dynamicParameters);
            //if (customerExitsCode.Count() > 0)
            //{
            //    var erroInfo = new
            //    {
            //        devMsg = "CustomerCode duplucate!",
            //        userMsg = "Thông tin mã khách hàng không được phép để trống",
            //        errorCode = "misa-001",
            //        moreInfo = "https://openapi.misa.com.vn/errorcode/misa-001",
            //        traceId = "ba9587fd-1a79-4ac5-a0ca-2c9f74dfd3fb"
            //    };

            //    throw new ValidateExceptions("Mã khách hàng không được để trùng");
            //}
        }
    }
}
