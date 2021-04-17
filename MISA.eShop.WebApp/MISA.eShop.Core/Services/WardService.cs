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
    public class WardService : BaseService<Ward>, IWardService
    {
        IWardRepository _wardRepository;
        public WardService(IWardRepository wardRepository) : base(wardRepository)
        {
            _wardRepository = wardRepository;
        }
        public IEnumerable<Ward> GetWardWithDistrict(Guid entityId)
        {
            var entities = _wardRepository.GetWardWithDistrict(entityId);
            return entities;
        }
    }
}
