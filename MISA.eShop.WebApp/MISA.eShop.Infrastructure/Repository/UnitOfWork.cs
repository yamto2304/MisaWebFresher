using MISA.eShop.Core.Interfaces;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICountryRepository countryRepository, IDistrictRepository districtRepository, IProvinceRepository provinceRepository, IStoreRepository storeRepository, IWardRepository wardRepository)
        {
            CountryRepository = countryRepository;
            DistrictRepository = districtRepository;
            ProvinceRepository = provinceRepository;
            StoreRepository = storeRepository;
            WardRepository = wardRepository;
        }

        public ICountryRepository CountryRepository { get; }

        public IDistrictRepository DistrictRepository { get; }

        public IProvinceRepository ProvinceRepository { get; }

        public IStoreRepository StoreRepository { get; }

        public IWardRepository WardRepository { get; }
    }
}
