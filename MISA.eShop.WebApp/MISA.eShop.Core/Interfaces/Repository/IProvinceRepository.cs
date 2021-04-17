using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Interfaces.Repository
{
    public interface IProvinceRepository : IBaseRepository<Province>
    {
        IEnumerable<Province> GetProvinceWithCountry(Guid entityId);
    }
}
