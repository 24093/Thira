namespace Alkl.Thira.DomainObjects
{
    internal class Field : IDeepCloneable<Field>
    {
        public readonly Position Position;

        public Builder Builder;

        public uint StoryLevel { get; private set; }

        public Field(Position position)
        {
            Position = position;
        }

        public void IncreaseStoryLevel()
        {
            StoryLevel++;
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