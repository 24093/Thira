using System;
using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    public class Player : IDeepCloneable<Player>
    {
        public readonly IMovementConstraints MovementConstraints;
        public readonly string Name;

        public Player(string name, IMovementConstraints movementConstraints)
        {
            Name = name ?? Guid.NewGuid().ToString();
            MovementConstraints = movementConstraints;
        }

        public Player DeepClone()
        {
            return new Player(Name, MovementConstraints.DeepClone());
        }

        protected bool Equals(Player other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Player) obj);
        }

        public override int GetHashCode()
        {
            return Name != null ? Name.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}