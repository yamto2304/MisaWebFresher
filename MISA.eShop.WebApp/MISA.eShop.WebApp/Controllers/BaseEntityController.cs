using System;
using Microsoft.AspNetCore.Mvc;
using MISA.eShop.Core.Interfaces.Service;
//using MISA.eShop.WebApp.Result;

namespace MISA.eShop.WebApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseEntityController<MISAEntity> : ControllerBase
    {
        IBaseService<MISAEntity> _baseService;
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }


        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Nếu có dữ liệu: trả vễ HttpCode 200; 204 nếu không có dữ liệu</returns>
        /// CreatedBy: huongdoll (01/04/2021)
        [HttpGet]

        public IActionResult Get()
        {
            // lấy dữ liệu từ database
            var res = new DataRespone();
            var entities = _baseService.GetEntities();
            // Kiểm tra dữ liệu trả về
            if (entities == null)
            {
                res.OnBadRequest(res);
                res.DevMsg = "Không có data !";
                res.UserMsg = "Không có dữ liệu !";
                res.Data = entities;
                return Ok(res);
            }
            else
            {
                res.OnSuccess(res);
                res.DevMsg = "Lấy dữ liệu thành công!";
                res.UserMsg = "Lấy dữ liệu thành công!";
                res.Data = entities;
                return Ok(res);
            }
        }

        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _baseService.GetById(entityId);
            // Kiểm tra dữ liệu trả về
            if (entitie == null)
            {
                res.OnBadRequest(res);
                res.DevMsg = "Không có data !";
                res.UserMsg = "Không tìm thấy khách hàng !";
                res.Data = entitie;
                return Ok(res);
            }
            else
            {
                res.OnSuccess(res);
                res.DevMsg = "Lấy dữ liệu thành công!";
                res.UserMsg = "Lấy dữ liệu thành công!";
                res.Data = entitie;
                return Ok(res);
            }
        }

    }
}
