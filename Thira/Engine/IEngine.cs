using System;
using System.Collections.Generic;

namespace Alkl.Thira.Engine
{
    internal interface IEngine
    {
        IEnumerable<Move> RateMoves(Board board, Guid playerId);
    }
}