using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MISA.eShop.Core.Services
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository) : base(districtRepository)
        {
            _districtRepository = districtRepository;
        }
        public IEnumerable<District> GetDistrictWithProvince(Guid entityId)
        {
            var entities = _districtRepository.GetDistrictWithProvince(entityId);
            return entities;
        }
    }
}
