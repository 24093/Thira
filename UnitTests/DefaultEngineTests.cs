using System;
using System.Linq;
using Alkl.Thira.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class DefaultEngineTests
    {
        private Board _board;
        private Guid _player1Id;
        private Guid _player2Id;

        [TestInitialize]
        public void Initialize()
        {
            _board = new Board();
            _player1Id = _board.AddPlayer("Alice");
            _player2Id = _board.AddPlayer("Bob");

            _board.PlaceInitialBuilders(_player1Id, (1, 1), (3, 3));
            _board.PlaceInitialBuilders(_player2Id, (4, 1), (4, 4));
        }

        [TestMethod]
        public void Test1()
        {
            var engine = new DefaultEngine();
            engine.Play(_board, _player1Id, _player2Id);
        }
    }
}
