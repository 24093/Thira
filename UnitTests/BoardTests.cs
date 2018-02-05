using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        private Fields _fields;
        private Player _player1;
        private Player _player2;

        [TestInitialize]
        public void Initialize()
        {
            _fields = new Fields(5, 5);
            _player1 = new Player(null, new DefaultMovementConstraints());
            _player2 = new Player(null, new DefaultMovementConstraints());

            _fields[0, 0].Builder = new Builder(_player1);
            _fields[3, 3].Builder = new Builder(_player2);
        }

        [TestMethod]
        public void TestInitialPlacement()
        {
            var board = new Board();
            
            board.PlaceInitialBuilders(_player1, (1, 2), (3, 3));
            board.PlaceInitialBuilders(_player2, (1, 3), (4, 4));

            Assert.AreEqual(_player1.Name, board.Fields[1, 2].Builder.Owner.Name);
            Assert.AreEqual(_player1.Name, board.Fields[3, 3].Builder.Owner.Name);
            Assert.AreEqual(_player2.Name, board.Fields[1, 3].Builder.Owner.Name);
            Assert.AreEqual(_player2.Name, board.Fields[4, 4].Builder.Owner.Name);
        }

        [TestMethod]
        public void TestMovement()
        {
            var board = new Board();

            board.PlaceInitialBuilders(_player1, (1, 2), (3, 3));
            board.PlaceInitialBuilders(_player2, (1, 3), (4, 4));

            var builder = board.Fields[1, 2].Builder;
            board.MoveBuilder(_player1, (1, 2), (2, 2));

            Assert.IsNull(board.Fields[1, 2].Builder);
            Assert.AreEqual(builder, board.Fields[2, 2].Builder);

        }
    }
}
