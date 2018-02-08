using System;
using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions.BoardExceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class BoardTests
    {
        private Board _board;
        private Guid _player1Id;
        private Guid _player2Id;

        [TestInitialize]
        public void TestInitialize()
        {
            _board = new Board();
            _player1Id = _board.AddPlayer("Alice");
            _player2Id = _board.AddPlayer("Bob");

            _board.PlaceInitialBuilders(_player1Id, (1, 2), (3, 3));
            _board.PlaceInitialBuilders(_player2Id, (1, 3), (4, 4));
        }

        [TestMethod]
        public void TestInitialPlacement()
        {
            Assert.AreEqual(_player1Id, _board.GetPlayerId((1, 2)));
            Assert.AreEqual(_player1Id, _board.GetPlayerId((3, 3)));
            Assert.AreEqual(_player2Id, _board.GetPlayerId((1, 3)));
            Assert.AreEqual(_player2Id, _board.GetPlayerId((4, 4)));
        }

        [TestMethod]
        public void TestMovement()
        {
            _board.Move((1, 2), (2, 2));

            Assert.IsNull(_board.GetBuilderId((1, 2)));
            Assert.IsNotNull(_board.GetBuilderId((2, 2)));
        }

        #region Exceptions

        [TestMethod]
        public void TestFieldContainsBuilderException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestInvalidBuildException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestInvalidMoveException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestLevelNotAvailableException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestMaximumLevelReachedException()
        {
            _board.Build((1, 2), (1, 1));
            Assert.AreEqual(1U, _board.GetLevel((1, 1)));

            _board.Build((1, 2), (1, 1));
            Assert.AreEqual(2U, _board.GetLevel((1, 1)));

            _board.Build((1, 2), (1, 1));
            Assert.AreEqual(3U, _board.GetLevel((1, 1)));

            _board.Build((1, 2), (1, 1));
            Assert.AreEqual(4U, _board.GetLevel((1, 1)));

            Assert.ThrowsException<MaximumLevelReachedException>(() =>
                _board.Build((1, 2), (1, 1)));
            Assert.AreEqual(4U, _board.GetLevel((1, 1)));
        }

        [TestMethod]
        public void TestNumberOfBuilderExceededException()
        {
            Assert.Fail();
        }

        #endregion
    }
}
