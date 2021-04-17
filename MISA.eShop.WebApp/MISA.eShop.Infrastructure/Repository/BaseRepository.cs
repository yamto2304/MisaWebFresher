using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySqlConnector;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF772_HUONGHTT_ESHOP;" +
                "convert zero datetime=True";
        protected IDbConnection _dbConnection;
        public BaseRepository()
        {
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }

        public MISAEntity GetById(Guid entityId)
        {
            string storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            string paramName = $"@{_tableName}Id";
            dynamicParameters.Add(paramName, entityId);
            var entity = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return entity;
        }

        public IEnumerable<MISAEntity> GetEntities()
        {
            string storeName = $"Proc_Get{_tableName}s";
            var entities = _dbConnection.Query<MISAEntity>(storeName, commandType: CommandType.StoredProcedure);
            return entities;
        }

        
    }
}
