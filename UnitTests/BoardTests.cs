using System;
using System.Collections.Generic;
using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;
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
        
        [TestMethod]
        public void TestFieldContainsBuilderException()
        {
            // create a local board
            var board = new Board();
            var player1Id = board.AddPlayer("Alice");
            var player2Id = board.AddPlayer("Bob");

            board.PlaceInitialBuilders(player1Id, (1, 2), (3, 3));

            Assert.ThrowsException<FieldContainsBuilderException>(() =>
                board.PlaceInitialBuilders(player2Id, (1, 3), (3, 3)));
        }

        [TestMethod]
        public void TestInvalidBuildException()
        {
            var exception = Assert.ThrowsException<InvalidBuildException>(() => _board.Build((1, 2), (3, 2)));
            Assert.AreEqual(CheckBuildError.TargetFieldIsNotNeighborOfBuilderField, exception.Error);
        }

        [TestMethod]
        public void TestInvalidMoveException()
        {
            var exception = Assert.ThrowsException<InvalidMoveException>(() => _board.Move((1, 2), (4, 2)));
            Assert.AreEqual(CheckMoveError.DestinationFieldIsNotNeighborOfSourceField, exception.Error);
        }

        [TestMethod]
        public void TestLevelNotAvailableException()
        {
            // create a local board
            var board = new Board(5, 5, new List<uint> {0, 2, 2, 2, 2});
            var player1Id = board.AddPlayer("Alice");
            var player2Id = board.AddPlayer("Bob");

            board.PlaceInitialBuilders(player1Id, (0, 0), (4, 4));

            board.Build((0, 0), (0, 1));
            board.Build((0, 0), (1, 0));

            Assert.ThrowsException<LevelNotAvailableException>(() =>
                board.Build((0, 0), (1, 1)));
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

            Assert.ThrowsException<MaximumLevelReachedException>(() => _board.Build((1, 2), (1, 1)));
            Assert.AreEqual(4U, _board.GetLevel((1, 1)));
        }

        [TestMethod]
        public void TestMaximumNumberOfBuildersExceededException()
        {
            Assert.ThrowsException<MaximumNumberOfBuildersExceededException>(() =>
                _board.PlaceInitialBuilders(_player2Id, (0, 0), (2, 4)));
        }
    }
}
