using MISA.eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Interfaces.Service
{
    /// <summary>
    /// Interface cho dữ liệu Province kết nối với Controller
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public interface IProvinceService : IBaseService<Province>
    {
        IEnumerable<Province> GetProvinceWithCountry(Guid entityId);
    }
}
