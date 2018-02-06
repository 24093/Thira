using System;

namespace Alkl.Thira.DomainObjects
{
    internal class Builder : UniqueObject, IDeepCloneable<Builder>
    {
        public readonly Player Owner;

        public Builder(Player owner)
        {
            Owner = owner;
        }

        private Builder(Player owner, Guid id)
            : base(id)
        {
            Owner = owner;
        }

        public Builder DeepClone()
        {
            return new Builder(Owner.DeepClone(), Id);
        }
    }
}