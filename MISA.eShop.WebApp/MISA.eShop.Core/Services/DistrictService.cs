using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;


namespace MISA.eShop.Core.Services
{
    /// <summary>
    /// Chi nhánh của tổng cty BaseService, thực thi công việc của interface IDistrictService
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class DistrictService : BaseService<District>, IDistrictService
    {
        IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository) : base(districtRepository)
        {
            _districtRepository = districtRepository;
        }

        /// <summary>
        /// Lấy tất cả quận huyện có trong tỉnh
        /// </summary>
        /// <param name="entityId">Id của tỉnh</param>
        /// <returns>Tất cả quận/huyện có trong tỉnh</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public IEnumerable<District> GetDistrictWithProvince(Guid entityId)
        {
            var entities = _districtRepository.GetDistrictWithProvince(entityId);
            return entities;
        }
    }
}
