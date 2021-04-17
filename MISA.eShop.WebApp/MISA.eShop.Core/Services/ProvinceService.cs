using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;

namespace MISA.eShop.Core.Services
{
    public class ProvinceService : BaseService<Province>, IProvinceService
    {

        IProvinceRepository _provinceRepository;
        public ProvinceService(IProvinceRepository provinceRepository) : base(provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        public IEnumerable<Province> GetProvinceWithCountry(Guid entityId)
        {
            var entities = _provinceRepository.GetProvinceWithCountry(entityId);
            return entities;
        }
    }
}
