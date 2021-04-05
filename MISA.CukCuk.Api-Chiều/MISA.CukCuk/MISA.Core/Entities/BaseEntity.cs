using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
<<<<<<< HEAD
    public abstract class BaseEntity
=======
    public class BaseEntity
>>>>>>> c919336b1b85fad91ce6c3cf456f2becd1f90c80
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
