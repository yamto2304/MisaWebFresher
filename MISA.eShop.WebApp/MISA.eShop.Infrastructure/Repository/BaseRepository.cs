using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySqlConnector;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    /// <summary>
    /// Class thực thi công việc, tiếp xúc trực tiêp với database : clas chung
    /// </summary>
    /// <typeparam name="MISAEntity">Đối tượng truyền vào</typeparam>
    /// CreatedBy : Tuanhd(18/4/2021)
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        //Connection string : chìa khóa mở kho database
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= TEST.MISA.eShop;" +
                "convert zero datetime=True";
        //string _connectionString = "" +
        //        "Host=47.241.69.179; " +
        //        "Port=3306;" +
        //        "User Id= dev; " +
        //        "Password=12345678;" +
        //        "Database= TEST.MISA.eShop";
        protected IDbConnection _dbConnection;
        public BaseRepository()
        {
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Lấy dữ liệu theo ID
        /// </summary>
        /// <param name="entityId">ID của đối tượng cần lấy</param>
        /// <returns>Đối tượng lấy được</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public MISAEntity GetById(Guid entityId)
        {
            string storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramName = $"@{_tableName}Id";
            dynamicParameters.Add(paramName, entityId);
            var entity = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        /// <summary>
        /// Lấy tất cả đối tượng trong bảng database
        /// </summary>
        /// <returns>Toàn bộ đối tượng</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public IEnumerable<MISAEntity> GetEntities()
        {
            string storeName = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<MISAEntity>(storeName, commandType: CommandType.StoredProcedure);
            return entities;
        }

        
    }
}
