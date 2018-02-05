namespace Alkl.Thira.DomainObjects
{

    public class Field : IDeepCloneable<Field>
    {
        public readonly Position Position;

        public Builder Builder;

        public uint StoryLevel;

        public Field(Position position)
        {
            Position = position;
        }
        
        public Field DeepClone()
        {
            return new Field(Position.DeepClone())
            {
                Builder = Builder?.DeepClone(),
                StoryLevel = StoryLevel
            };
        }
    }
}
