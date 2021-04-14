using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Core.Services
{
    public class CustomerService : BaseServiceFake<Customer>, ICustomerService
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
            // check trùng mã:
            var isDuplicate = _unitOfWork.Customer.CheckCustomerCode("KH0001");

            //TODO
            if (true)
            {
            }
            base.Validate();

        }
        public IEnumerable<Customer> GetAllCustomer()
        {
           return _unitOfWork.Customer.GetEntities();
        }
        
    }
}
