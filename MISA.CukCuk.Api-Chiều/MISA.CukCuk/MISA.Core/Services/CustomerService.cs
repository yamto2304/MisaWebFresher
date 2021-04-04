using MISA.Core.Entities;
<<<<<<< HEAD
=======
using MISA.Core.Interfaces;
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
<<<<<<< HEAD
    public class CustomerService:BaseService<Customer>
    {

=======
    public class CustomerService: BaseServiceFake<Customer>, ICustomerService
    {
        //public CustomerService(IBaseRepository<Customer> baseRepository):base(baseRepository)
        //{
        //}

        IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork, IBaseRepository<Customer> baseRepository) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void Validate()
        {
            base.Validate();
        }
        public IEnumerable<Customer> GetAllCustomer()
        {
            return _unitOfWork.Customer.GetEntities();
        }
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
    }
}
