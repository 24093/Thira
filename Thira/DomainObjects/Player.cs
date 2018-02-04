using System;
using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    public class Player
    {
        public string Name = Guid.NewGuid().ToString();

        public readonly IMovementConstraints MovementConstraints;

        public Player(IMovementConstraints movementConstraints)
        {
            MovementConstraints = movementConstraints;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}