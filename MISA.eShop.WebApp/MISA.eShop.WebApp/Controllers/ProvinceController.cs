using System;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using MISA.eShop.WebApp.Result;

namespace MISA.eShop.WebApp.Controllers
{
    /// <summary>
    /// Controller yêu cầu nghiệp vụ đến dữ liệu Province
    /// </summary>
    /// CreatedBy: Tuanhd (18/04/2021)
    public class ProvinceController : BaseEntityController<Province>
    {
        IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService) : base(provinceService)
        {
            _provinceService = provinceService;

        }

        /// <summary>
        /// Lấy tất cả tỉnh có trong quốc gia
        /// </summary>
        /// <param name="entityId">Id quốc gia</param>
        /// <returns>Toàn bộ tỉnh</returns>
        /// CreatedBy: Tuanhd (18/04/2021)
        [HttpGet("WithParent/{entityId}")]
        public IActionResult GetWithParent(Guid entityId)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _provinceService.GetProvinceWithCountry(entityId);
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
