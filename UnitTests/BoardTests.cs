using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        private Player _player1;
        private Player _player2;

        [TestInitialize]
        public void Initialize()
        {
            _player1 = new Player("Alice", new DefaultMovementConstraints(), new DefaultBuildConstraints());
            _player2 = new Player("Bob", new DefaultMovementConstraints(), new DefaultBuildConstraints());
        }

        [TestMethod]
        public void TestInitialPlacement()
        {
            var board = new Board();
            
            board.PlaceInitialBuilders(_player1, (1, 2), (3, 3));
            board.PlaceInitialBuilders(_player2, (1, 3), (4, 4));

            Assert.AreEqual(_player1.Id, board.GetPlayerId((1, 2)));
            Assert.AreEqual(_player1.Id, board.GetPlayerId((3, 3)));
            Assert.AreEqual(_player2.Id, board.GetPlayerId((1, 3)));
            Assert.AreEqual(_player2.Id, board.GetPlayerId((4, 4)));
        }

        [TestMethod]
        public void TestMovement()
        {
            var board = new Board();

            board.PlaceInitialBuilders(_player1, (1, 2), (3, 3));
            board.PlaceInitialBuilders(_player2, (1, 3), (4, 4));
            
            board.MoveBuilder((1, 2), (2, 2));

            Assert.IsNull(board.GetBuilderId((1, 2)));
            Assert.IsNotNull(board.GetBuilderId((2, 2)));

        }
    }
}
