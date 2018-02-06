using Alkl.Thira.Constraints;

namespace Alkl.Thira.DomainObjects
{
    public class PlayerConfiguration
    {
        public string Name;
        public IMovementConstraints MovementConstraints = new DefaultMovementConstraints();
        public IBuildConstraints BuildConstraints = new DefaultBuildConstraints();
    }
}