using System;

namespace Alkl.Thira.DomainObjects
{
    public abstract class UniqueObject
    {
        public readonly Guid Id;

        protected UniqueObject(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }
    }
}