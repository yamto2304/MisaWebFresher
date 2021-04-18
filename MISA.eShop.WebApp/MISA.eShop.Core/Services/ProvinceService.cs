using System;
using System.Collections.Generic;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;

namespace MISA.eShop.Core.Services
{
    /// <summary>
    /// Chi nhánh của tổng cty BaseService, thực thi công việc của interface IProvinceService
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class ProvinceService : BaseService<Province>, IProvinceService
    {

        IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository) : base(provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        /// <summary>
        /// Lấy tất cả Tỉnh/Thành phố có trong nước
        /// </summary>
        /// <param name="entityId">Id của nước</param>
        /// <returns>Tất cả Tỉnh/Thành có trong nước</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public IEnumerable<Province> GetProvinceWithCountry(Guid entityId)
        {
            var entities = _provinceRepository.GetProvinceWithCountry(entityId);
            return entities;
        }
    }
}
