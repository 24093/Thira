using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    internal class PlayerConfiguration
    {
        public string Name;
        public IMovementConstraints MovementConstraints = new DefaultMovementConstraints();
        public IBuildConstraints BuildConstraints = new DefaultBuildConstraints();
    }
}