using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
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
        public void TestDestinationFieldDoesNotExistError()
        {
            var result = _player1.MovementConstraints.CheckMove(_fields[0, 0], null);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(CheckMoveError.DestinationFieldDoesNotExist, result.Error);
        }

        [TestMethod]
        public void TestDestinationFieldIsNotEmptyError()
        {
            var result = _player1.MovementConstraints.CheckMove(_fields[1, 0], _fields[2, 0]);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(CheckMoveError.DestinationFieldIsNotEmpty, result.Error);
        }

        [TestMethod]
        public void TestDestinationFieldIsNotNeighborOfSourceFieldError()
        {
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[3, 4]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[4, 4]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[4, 3]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[4, 2]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[3, 2]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[2, 2]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[2, 3]);
            _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[2, 4]);

            var result1 = _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[1, 1]);
            Assert.IsFalse(result1.Success);
            Assert.AreEqual(CheckMoveError.DestinationFieldIsNotNeighborOfSourceField, result1.Error);

            var result2 = _player2.MovementConstraints.CheckMove(_fields[3, 3], _fields[0, 1]);
            Assert.IsFalse(result2.Success);
            Assert.AreEqual(CheckMoveError.DestinationFieldIsNotNeighborOfSourceField, result2.Error);
        }

        [TestMethod]
        public void TestNoBuilderOnSourceFieldError()
        {
            var result = _player1.MovementConstraints.CheckMove(_fields[2, 2], _fields[0, 1]);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(CheckMoveError.NoBuilderOnSourceField, result.Error);
        }

        [TestMethod]
        public void TestSourceFieldDoesNotExistError()
        {
            var result = _player1.MovementConstraints.CheckMove(null, _fields[0, 1]);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(CheckMoveError.SourceFieldDoesNotExist, result.Error);
        }
    }
}
