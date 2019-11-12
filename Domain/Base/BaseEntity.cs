using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public T id { get; set; }
    }
}
