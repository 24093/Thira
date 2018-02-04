namespace Alkl.Thira.DomainObjects
{
    public class Field
    {
        public readonly Position Position;

        public Builder Builder;

        public uint StoryLevel;

        public Field(Position position)
        {
            Position = position;
        }

        public Field(uint row, uint column)
            : this(new Position(row, column))
        {
        }
    }
}
