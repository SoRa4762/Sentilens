using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Core.Entities.Base
{
    interface IEntityBase<TId>
    {
        TId Id { get; }
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; }
        bool IsDeleted { get; }
    }
}
