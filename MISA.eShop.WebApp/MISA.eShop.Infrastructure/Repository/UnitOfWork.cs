using MISA.eShop.Core.Interfaces;
using MISA.eShop.Core.Interfaces.Repository;

namespace MISA.eShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Nơi nhận "công nhân" và phân phối đến từng nơi cần để làm việc
        /// </summary>
        /// <param name="countryRepository">Chuyển đến "kho" country</param>
        /// <param name="districtRepository">Chuyển đến "kho" district</param>
        /// <param name="provinceRepository">Chuyển đến "kho" province</param>
        /// <param name="storeRepository">Chuyển đến "kho" store</param>
        /// <param name="wardRepository">Chuyển đến "kho" ward</param>
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
