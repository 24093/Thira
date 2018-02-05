namespace Alkl.Thira.DomainObjects
{
    public class Builder : IDeepCloneable<Builder>
    {
        public readonly Player Owner;
        
        public Builder(Player owner)
        {
            Owner = owner;
        }

        public Builder DeepClone()
        {
            return new Builder(Owner.DeepClone());
        }
    }
}