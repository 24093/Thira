using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Alkl.Thira.DomainObjects;

namespace Alkl.Thira.Engine
{
    internal class DefaultEngine : IEngine
    {
        private Guid _playerId;
        private Guid _enemyPlayerId;

        public IEnumerable<Move> RateMoves(Board board, Guid playerId)
        {
            _playerId = playerId;
            _enemyPlayerId = board.GetPlayerIds().SingleOrDefault(id => id != playerId);

            foreach (var builderId in board.GetBuilderIds(playerId))
            {
                var fromPosition = board.GetBuilderPosition(builderId);

                foreach (var toPosition in board.GetPossibleMoves(builderId))
                {
                    yield return new Move
                    {
                        From = fromPosition,
                        To = toPosition,
                        Rating = RateMove(board, fromPosition, toPosition)
                    };
                }
            }
        }

        protected virtual int RateMove(Board board, Position from, Position to)
        {
            try
            {
                board.Move(from, to);

                // check every enemy move
                foreach (var enemyBuilderId in board.GetBuilderIds(_enemyPlayerId))
                {
                    var enemyFromPosition = board.GetBuilderPosition(enemyBuilderId);
                    
                }
            }
            catch (Exception)
            {
                return -1;
            }
            

            return 0;
        }
    }
}
