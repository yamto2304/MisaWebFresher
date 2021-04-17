﻿using System;
using Microsoft.AspNetCore.Mvc;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Service;
using MISA.eShop.WebApp.Result;

namespace MISA.eShop.WebApp.Controllers
{
    public class DistrictController : BaseEntityController<District>
    {
        IDistrictService _districtService;
        public DistrictController(IDistrictService districtService) : base(districtService)
        {
            _districtService = districtService;

        }
        [HttpGet("WithParent/{entityId}")]
        public IActionResult GetWithParent(Guid entityId)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _districtService.GetDistrictWithProvince(entityId);
            // Kiểm tra dữ liệu trả về
            if (entitie == null)
            {
                res.OnBadRequest(res);
                res.DevMsg = "Không có data !";
                res.UserMsg = "Không tìm thấy quận huyện !";
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
