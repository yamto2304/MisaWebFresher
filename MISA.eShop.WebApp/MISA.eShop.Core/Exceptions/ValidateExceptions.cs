using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.eShop.Core.Exceptions
{
    class ValidateExceptions : Exception
    {
        public ValidateExceptions(string msg) : base(msg)
        {

        }
    }
}
