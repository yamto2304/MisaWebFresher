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
    public class CountryService : BaseService<Country>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository) : base(countryRepository) { }
    }
}
