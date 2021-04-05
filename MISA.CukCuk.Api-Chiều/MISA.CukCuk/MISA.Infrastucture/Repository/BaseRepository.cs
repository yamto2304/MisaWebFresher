using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastucture.Repository
{
    class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public MISAEntity GetById()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<MISAEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public int Insert(MISAEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(MISAEntity entity, Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
