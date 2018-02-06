using System;
using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    public class Player : UniqueObject, IDeepCloneable<Player>
    {
        public readonly IMovementConstraints MovementConstraints;
        public readonly string Name;
        
        public Player(string name, IMovementConstraints movementConstraints)
        {
            Name = name ?? Id.ToString();
            MovementConstraints = movementConstraints;
        }

        private Player(string name, IMovementConstraints movementConstraints, Guid id)
            : base(id)
        {
            Name = name ?? Id.ToString();
            MovementConstraints = movementConstraints;
        }

        public Player DeepClone()
        {
            return new Player(Name, MovementConstraints.DeepClone(), Id);
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