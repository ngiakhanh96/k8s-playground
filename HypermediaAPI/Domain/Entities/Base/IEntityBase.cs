using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HypermediaAPI.Database.Entities.Base
{
    public interface IEntityBase<TId>
    {
        public TId Id { get; }
    }
}
