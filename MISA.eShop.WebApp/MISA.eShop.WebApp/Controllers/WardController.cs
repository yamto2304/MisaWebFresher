using System;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using MISA.eShop.WebApp.Result;

namespace MISA.eShop.WebApp.Controllers
{
    public class WardController : BaseEntityController<Ward>
    {
        IWardService _wardService;
        public WardController(IWardService wardService) : base(wardService)
        {
            _wardService = wardService;

        }

        [HttpGet("WithParent/{entityId}")]
        public IActionResult GetWithParent(Guid entityId)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _wardService.GetWardWithDistrict(entityId);
            // Kiểm tra dữ liệu trả về
            if (entitie == null)
            {
                res.OnBadRequest(res);
                res.DevMsg = "Không có data !";
                res.UserMsg = "Không tìm thấy tỉnh !";
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
