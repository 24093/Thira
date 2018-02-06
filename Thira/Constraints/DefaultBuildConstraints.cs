using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;

namespace Alkl.Thira.Constraints
{
    public class DefaultBuildConstraints : IBuildConstraints
    {
        public void CheckBuild(Field builderField, Field targetGield)
        {
            if (!builderField.Position.IsNeighbor(targetGield.Position))
            {
                throw new TargetFieldIsNotNeighborOfBuilderFieldException(builderField, targetGield);
            }
        }

        public IBuildConstraints DeepClone()
        {
            return new DefaultBuildConstraints();
        }
    }
}