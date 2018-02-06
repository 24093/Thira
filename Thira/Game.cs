using Alkl.Thira.DomainObjects;

namespace Alkl.Thira
{
    public class Game
    {
        private readonly Board _board;
        private readonly Stories _stories;
        private Player _player1;
        private Player _player2;

        public Game(GameConfiguration config)
        {
            _board = new Board();

            _player1 = new Player("Alice", config.Player1.MovementConstraints, config.Player1.BuildConstraints);
            _player2 = new Player("Bob", config.Player2.MovementConstraints, config.Player2.BuildConstraints);

            _stories = new Stories();
            _stories.AddStories(0, 22);
            _stories.AddStories(0, 18);
            _stories.AddStories(0, 14);
            _stories.AddStories(0, 18);
        }
    }
}