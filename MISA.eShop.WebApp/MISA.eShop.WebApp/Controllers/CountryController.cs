using MISA.eShop.Core.Entities;
using MISA.eShop.Core.Interfaces.Service;

namespace MISA.eShop.WebApp.Controllers
{
    public class CountryController : BaseEntityController<Country>
    {
        ICountryService _countryService;
        public CountryController(ICountryService countryService) : base(countryService)
        {
            _countryService = countryService;

        }


    }
}
