using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Engine
{
    internal class Move
    {
        public Position From;

        public Position To;

        public int Rating;

        public override string ToString()
        {
            return $"{From} -> {To} [{Rating}]";
        }
    }
}