using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class DefaultMovementConstraintsTests
    {
        private Fields _fields;
        private Player _player1;
        private Player _player2;

        [TestInitialize]
        public void Initialize()
        {
            _fields = new Fields(5, 5);
            _player1 = new Player("Alice", new DefaultMovementConstraints(), new DefaultBuildConstraints());
            _player2 = new Player("Bob", new DefaultMovementConstraints(), new DefaultBuildConstraints());

            _fields[0, 0].Builder = new Builder(_player1);
            _fields[1, 0].Builder = new Builder(_player1);
            _fields[3, 3].Builder = new Builder(_player2);
            _fields[2, 0].Builder = new Builder(_player2);
        }

        [TestMethod]
        public void TestCheckArguments()
        {
            Assert.ThrowsException<SourceFieldDoesNotExistException>(() =>
                _player1.MovementConstraints.CheckMove(null, _fields[0, 1]));

            Assert.ThrowsException<DestinationFieldDoesNotExistException>(() =>
                _player1.MovementConstraints.CheckMove(_fields[0, 0], null));

            Assert.ThrowsException<NoBuilderOnSourceFieldException>(() =>
                _player1.MovementConstraints.CheckMove(_fields[2, 2], _fields[0, 1]));
        }

        [TestMethod]
        public void TestCheckMoveNeighbor()
        {
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[3, 4]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[4, 4]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[4, 3]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[4, 2]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[3, 2]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[2, 2]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[2, 3]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[2, 4]);

            Assert.ThrowsException<DestinationFieldIsNotNeighborOfSourceFieldException>(() =>
                _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[1, 1]));

            Assert.ThrowsException<DestinationFieldIsNotNeighborOfSourceFieldException>(() =>
                _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[0, 1]));
        }

        [TestMethod]
        public void TestCheckMoveBusy()
        {
            Assert.ThrowsException<DestinationFieldIsNotEmptyException>(() =>
                _player1.MovementConstraints.CheckMove(_fields[1, 0], _fields[2, 0]));
        }
    }
}
