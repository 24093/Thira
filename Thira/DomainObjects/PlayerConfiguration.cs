using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    internal class PlayerConfiguration
    {
        public IBuildConstraints BuildConstraints = new DefaultBuildConstraints();
        public IMovementConstraints MovementConstraints = new DefaultMovementConstraints();
        public string Name;
    }
}