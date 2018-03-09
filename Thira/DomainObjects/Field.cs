namespace Alkl.Thira.DomainObjects
{
    internal class Field : IDeepCloneable<Field>
    {
        public readonly Position Position;

        public Builder Builder;

        public uint Level;

        public Field(Position position)
        {
            Position = position;
        }

        public Field DeepClone()
        {
            return new Field(Position.DeepClone())
            {
                Builder = Builder?.DeepClone(),
                Level = Level
            };
        }

        public override string ToString()
        {
            return $"{Position} - {Builder} - {Level}";
        }
    }
}