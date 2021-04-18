using System;
using System.Collections.Generic;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;

namespace MISA.eShop.Core.Services
{
    /// <summary>
    /// Chi nhánh của tổng cty BaseService, thực thi công việc của interface IWardService
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class WardService : BaseService<Ward>, IWardService
    {
        IWardRepository _wardRepository;
        public WardService(IWardRepository wardRepository) : base(wardRepository)
        {
            _wardRepository = wardRepository;
        }

        /// <summary>
        /// Lấy tất cả Xã/Phường phố có trong huyện
        /// </summary>
        /// <param name="entityId">Id của huyện</param>
        /// <returns>Tất cả Xã/Phường có trong huyện</returns>
        /// CreatedBy: Tuanhd(18/4/2021)
        public IEnumerable<Ward> GetWardWithDistrict(Guid entityId)
        {
            var entities = _wardRepository.GetWardWithDistrict(entityId);
            return entities;
        }
    }
}
