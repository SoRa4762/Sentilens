using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; } = default!;
        public virtual DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public virtual DateTime? UpdatedAt { get; protected set; } = DateTime.UtcNow;
        public virtual bool IsDeleted { get; protected set; } = false;
        //public EntityBase()
        //{
        //    Id = default!;
        //}
        //public EntityBase(TId id)
        //{
        //    Id = id;
        //}
    }
}
