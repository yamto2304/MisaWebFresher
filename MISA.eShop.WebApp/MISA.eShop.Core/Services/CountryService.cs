using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Repository;
using MISA.eShop.Core.Interfaces.Service;

namespace MISA.eShop.Core.Services
{
    /// <summary>
    /// Chi nhánh của tổng cty BaseService, thực thi công việc của interface ICountryService
    /// </summary>
    /// CreatedBy: Tuanhd(18/4/2021)
    public class CountryService : BaseService<Country>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository) : base(countryRepository) { }
    }
}
