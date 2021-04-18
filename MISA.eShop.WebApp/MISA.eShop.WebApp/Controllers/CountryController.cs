using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Service;

namespace MISA.eShop.WebApp.Controllers
{
    /// <summary>
    /// Controller yêu cầu nghiệp vụ đến dữ liệu Country
    /// </summary>
    /// CreatedBy: Tuanhd (18/04/2021)
    public class CountryController : BaseEntityController<Country>
    {
        ICountryService _countryService;
        public CountryController(ICountryService countryService) : base(countryService)
        {
            _countryService = countryService;

        }


    }
}
