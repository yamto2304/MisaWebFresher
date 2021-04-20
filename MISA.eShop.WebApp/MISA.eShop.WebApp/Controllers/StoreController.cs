using Microsoft.AspNetCore.Mvc;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Service;
using MISA.eShop.WebApp.Result;
using System;


namespace MISA.eShop.WebApp.Controllers
{
    /// <summary>
    /// Controller yêu cầu nghiệp vụ đến dữ liệu Store
    /// </summary>
    /// CreatedBy: Tuanhd (18/04/2021)
    public class StoreController : BaseEntityController<Store>
    {
        IStoreService _storeService;
        public StoreController(IStoreService storeService) : base(storeService)
        {
            _storeService = storeService;

        }
        /// <summary>
        /// Xóa cửa hàng
        /// </summary>
        /// <param name="entityId"> id của cửa hàng cần xóa</param>
        /// <returns>số bản ghi bị ảnh hưởng</returns>
        /// CreatedBy: Tuanhd (18/04/2021)
        [HttpDelete("{entityId}")]

        public IActionResult Delete(Guid entityId)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _storeService.Delete(entityId);
            // Kiểm tra dữ liệu trả về
            if (entitie == 0)
            {
                res.OnBadRequest(res);
                res.DevMsg = "Có lỗi xảy ra !";
                res.UserMsg = "Có lỗi xảy ra !";
                res.Data = entitie;
                return BadRequest(res);
            }
            else
            {
                res.OnSuccess(res);
                res.DevMsg = "Xóa cửa hàng thành công!";
                res.UserMsg = "Xóa cửa hàng thành công!";
                res.Data = entitie;
                return Ok(res);
            }
        }
        /// <summary>
        /// Thêm mới cửa hàng
        /// </summary>
        /// <param name="store">thông tin cửa hàng</param>
        /// <returns>số bản ghi bị ảnh hường</returns>
        /// CreatedBy: Tuanhd (18/04/2021)
        [HttpPost]
        public IActionResult Post(Store store)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            store.StoreId = new Guid();
            var entitie = _storeService.Insert(store);
            // Kiểm tra dữ liệu trả về
            if (entitie == 0)
            {
                res.OnBadRequest(res);
                res.DevMsg = "Có lỗi xảy ra !";
                res.UserMsg = "Thêm mới cửa hàng thất bại!";
                res.Data = entitie;
                return BadRequest(res);
            }
            else
            {
                res.OnSuccess(res);
                res.DevMsg = "Thêm cửa hàng thành công!";
                res.UserMsg = "Thêm mới cửa hàng thành công!";
                res.Data = entitie;
                return Ok(res);
            }
        }
        /// <summary>
        /// chỉnh sửa thông tin cửa hàng
        /// </summary>
        /// <param name="entityId">id cửa hàng </param>
        /// <param name="store"> thông tin cửa hàng</param>
        /// <returns>Thông báo</returns>
        /// CreatedBy: Tuanhd (18/04/2021)
        [HttpPut("{entityId}")]
        public IActionResult Put(Guid entityId, Store store)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _storeService.Update(store, entityId);
            // Kiểm tra dữ liệu trả về
            if (entitie == 0)
            {
                res.OnBadRequest(res);
                res.DevMsg = "Có lỗi xảy ra !";
                res.UserMsg = "Thay đổi thông tin cửa hàng thất bại!";
                res.Data = entitie;
                return BadRequest(res);
            }
            else
            {
                res.OnSuccess(res);
                res.DevMsg = "Thay đổi thông tin thành công!";
                res.UserMsg = "Thay đổi thông tin cửa hàng thành công!";
                res.Data = entitie;
                return Ok(res);
            }
        }

        /// <summary>
        /// Unuse
        /// </summary>
        /// <param name="position"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        [HttpGet("{position}/{offset}")]
        public IActionResult GetIndexOffset(int position, int offset)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _storeService.GetIndexOffset(position, offset);
            // Kiểm tra dữ liệu trả về

            res.OnSuccess(res);
            res.DevMsg = "Lấy thông tin thành công!";
            res.UserMsg = "Lấy thông tin cửa hàng thành công!";
            res.Data = entitie;
            return Ok(res);

        }
        // "{storeCode}/{storeName}/{address}/{phoneNumber}/{status}"
        /// <summary>
        /// Unuse
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public IActionResult GetStoreFilter([FromQuery] PagingParameter parameter)
        {
            // string storeCode, string storeName, string address, string phoneNumber, int? status
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _storeService.GetStoreFilter(
                parameter.storeCode, parameter.storeName, parameter.address, parameter.phoneNumber, parameter.status);
            // Kiểm tra dữ liệu trả về

            res.OnSuccess(res);
            res.DevMsg = "Lấy thông tin thành công!";
            res.UserMsg = "Lấy thông tin cửa hàng thành công!";
            res.Data = entitie;
            return Ok(res);

        }

        /// <summary>
        /// Unuse
        /// </summary>
        /// <returns></returns>
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _storeService.GetCountStore();
            // Kiểm tra dữ liệu trả về

            res.OnSuccess(res);
            res.DevMsg = "Lấy thông tin thành công!";
            res.UserMsg = "Lấy thông tin cửa hàng thành công!";
            res.Data = entitie;
            return Ok(res);
        }

        [HttpGet("byCode/{storeCode}")]
        public IActionResult GetStoreByCode(string storeCode)
        {
            var res = new DataRespone();
            // lấy dữ liệu từ database
            var entitie = _storeService.GetByStoreCode(storeCode);

            res.OnSuccess(res);
            res.DevMsg = "Lấy thông tin thành công!";
            res.UserMsg = "Lấy thông tin cửa hàng thành công!";
            res.Data = entitie;
            return Ok(res);
        }
    }

    public class PagingParameter
    {
        public string storeCode { get; set; }

        public string storeName { get; set; }

        public string address { get; set; }

        public string phoneNumber { get; set; }

        public int? status { get; set; }
    }
}
