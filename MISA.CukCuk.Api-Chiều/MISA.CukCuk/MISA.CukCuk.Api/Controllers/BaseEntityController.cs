﻿using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using MISA.Core.Interfaces;
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public abstract class BaseEntityController<MISAEntity> : ControllerBase
    {
        protected string _tableName = string.Empty;
        protected string _connectionString = "" +
               "Host=47.241.69.179; " +
               "Port=3306;" +
               "User Id= dev; " +
               "Password=12345678;" +
               "Database= MF0_NVManh_CukCuk02";
        protected IDbConnection _dbConnection;
<<<<<<< HEAD
        public BaseEntityController()
        {
=======
        IBaseService<MISAEntity> _baseService;
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
            _tableName = typeof(MISAEntity).Name;
            _dbConnection = new MySqlConnection(_connectionString);
        }


        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpGet]
        public IActionResult Get()
        {
<<<<<<< HEAD
            // Thực hiện lấy dữ liệu từ Database:
            var entities = _dbConnection.Query<MISAEntity>($"Proc_Get{_tableName}s", commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
=======
            var entities = _baseService.GetEntities();
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
            if (entities.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(entities);
            }
        }

        /// <summary>
        /// Lấy dữ liệu theo khóa chính
        /// </summary>
        /// <param name="entityId">Id của bảng dữ liệu</param>
        /// <returns>Thông tin của 1 đối tượng</returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpGet("{entityId}")]
        public IActionResult Get(string entityId)
        {
            // Thực hiện lấy dữ liệu từ Database:
            var storeName = $"Proc_Get{_tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var storeGetByIdInputParamName = $"@{_tableName}Id";
            dynamicParameters.Add(storeGetByIdInputParamName, entityId);

            var customer = _dbConnection.Query<MISAEntity>(storeName, param: dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            // Kiểm tra kết quả và trả về cho Client:
            if (customer == null)
                return NoContent();
            else
                return Ok(customer);
        }


        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Khách hàng muốn thêm mới</param>
        /// <returns>
        ///  - HttpCode: 200 nếu thêm được dữ liệu
        ///  - Lỗi dữ liệu không hợp lệ : 400 (BadRequest)
        ///  - HttpCode: 500 nếu có lỗi hoặc Exceotion xảy ra trên Server
        /// </returns>
        /// CreatedBy: NVMANH (01/04/2021)
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            // Validate dữ liệu:
            ValidateData(entity);
            // Thực hiện lấy dữ liệu từ Database:
            var storeName = $"Proc_Insert{_tableName}";
            var storeParam = entity;
            var rowAffects = _dbConnection.Execute(storeName, param: storeParam, commandType: CommandType.StoredProcedure);
            // Kiểm tra kết quả và trả về cho Client:
            if (rowAffects == 0)
                return NoContent();
            else
                return Ok(entity);
        }

        protected virtual void ValidateData(MISAEntity entity)
        {

        }
    }
}
