using System;
using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    public class Player : IDeepCloneable<Player>
    {
        public readonly string Name;

        public readonly IMovementConstraints MovementConstraints;

        public Player(string name, IMovementConstraints movementConstraints)
        {
            Name = name ?? Guid.NewGuid().ToString();
            MovementConstraints = movementConstraints;
        }
        
        protected bool Equals(Player other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
        
        public Player DeepClone()
        {
            return new Player(Name, MovementConstraints.DeepClone());
        }

        public override string ToString()
        {
            return Name;
        }
        
    }
}