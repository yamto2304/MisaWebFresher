using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ICustomerRepository customerRepository,
            ICustomerGroupRepository customerGroupRepository)
        {
            Customer = customerRepository;
            CustomerGroup = customerGroupRepository;
        }
        public ICustomerRepository Customer { get; }

        public ICustomerGroupRepository CustomerGroup { get; }
    }
}
