using System;
using System.Collections.Generic;
using Alkl.Thira;

namespace ConsoleApp1
{
    internal class Game
    {
        private Board _board;
        private Guid _aliceId;
        private Guid _bobId;
        private IEnumerable<Guid> _aliceBuilderIds;
        private IEnumerable<Guid> _bobBuilderIds;

        public Game()
        {
            try
            {
                _board = new Board();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Init()
        {
            try
            {
                _aliceId = _board.AddPlayer("Alice");
                _bobId = _board.AddPlayer("Bob");

                _aliceBuilderIds = _board.PlaceInitialBuilders(_aliceId, (2, 2), (2, 4));
                _bobBuilderIds = _board.PlaceInitialBuilders(_bobId, (4, 2), (4, 4));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void Test()
        {
            try
            {
                _board.Move((2, 2), (2, 3));
                _board.Build((2, 3), (1, 3));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void WriteCurrentBoard()
        {
        }
    }
}