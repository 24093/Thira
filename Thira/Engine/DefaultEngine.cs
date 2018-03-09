using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;

namespace Alkl.Thira.Engine
{
    internal class DefaultEngine : IEngine
    {
        public void Play(Board board, Guid player1Id, Guid player2Id)
        {
            while (true)
            {
                var player1Move = RateMoves(board, player1Id).FirstOrDefault();
                if (player1Move == null) continue;

                board.Move(player1Move.From, player1Move.To);
                if (HasPlayerWon(board, player1Id)) return;

                board.Build(player1Move.To, player1Move.Build);

                var player2Move = RateMoves(board, player2Id).FirstOrDefault();
                if (player2Move == null) continue;
                
                board.Move(player2Move.From, player2Move.To);
                if (HasPlayerWon(board, player2Id)) return;

                board.Build(player2Move.To, player2Move.Build);
            }
        }

        private bool HasPlayerWon(Board board, Guid playerId)
        {
            return board.GetBuilderIds(playerId).Any(builderId => board.GetLevel(board.GetBuilderPosition(builderId)) == board.GetMaxLevel());
        }

        public IEnumerable<Move> RateMoves(Board board, Guid playerId)
        {
            var currentBoard = board.DeepClone();
            
            // random builder
            var builderId = currentBoard.GetBuilderIds(playerId).Random();
            var builderPosition = currentBoard.GetBuilderPosition(builderId);

            // random move
            var destinationPosition = currentBoard.GetPossibleMoves(builderId).Random();

            try
            {
                currentBoard.Move(builderPosition, destinationPosition);
            }
            catch (BoardException)
            {
                return new Move[] { };
            }

            // random build
            var buildPosition = currentBoard.GetPossibleBuilds(builderId).Random();

            try
            {
                currentBoard.Build(destinationPosition, buildPosition);
            }
            catch (BoardException)
            {
                return new Move[] { };
            }
            
            return new []
            {
                new Move
                {
                    From = builderPosition,
                    To = destinationPosition,
                    Build = buildPosition,
                    Rating = int.MaxValue
                }
            };
        }
    }
}
