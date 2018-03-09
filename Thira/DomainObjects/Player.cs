using System;
using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    internal class Player : UniqueObject, IDeepCloneable<Player>
    {
        public readonly IBuildConstraints BuildConstraints;
        public readonly IMovementConstraints MovementConstraints;
        public readonly string Name;

        public Player(string name, IMovementConstraints movementConstraints, IBuildConstraints buildConstraints)
        {
            Name = name ?? Id.ToString();
            MovementConstraints = movementConstraints;
            BuildConstraints = buildConstraints;
        }

        private Player(string name, IMovementConstraints movementConstraints, IBuildConstraints buildConstraints,
            Guid id)
            : base(id)
        {
            Name = name ?? Id.ToString();
            MovementConstraints = movementConstraints;
            BuildConstraints = buildConstraints;
        }

        public Player DeepClone()
        {
            return new Player(Name, MovementConstraints.DeepClone(), BuildConstraints.DeepClone(), Guid.Parse(Id.ToString()));
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