using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira
{
    public class Game
    {
        private readonly Stories _stories;
        private Player _player1;

        private Player _player2;

        public Game(IMovementConstraints player1MovementConstraints, IMovementConstraints player2MovementConstraints)
        {
            Board = new Board();
            _player1 = new Player(null, player1MovementConstraints);
            _player2 = new Player(null, player2MovementConstraints);

            _stories = new Stories();
            _stories.AddStories(0, 22);
            _stories.AddStories(0, 18);
            _stories.AddStories(0, 14);
            _stories.AddStories(0, 18);
        }

        public Board Board { get; }
    }
}