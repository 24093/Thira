using System;

namespace Alkl.Thira.DomainObjects
{
    public class Position : IDeepCloneable<Position>
    {
        public readonly uint Row;

        public readonly uint Column;

        public Position(uint row, uint column)
        {
            Row = row;
            Column = column;
        }

        public Position DeepClone()
        {
            return new Position(Row, Column);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", Row, Column);
        }

        public static implicit operator Position((uint, uint) rowColumnTuple)
        {
            return new Position(rowColumnTuple.Item1, rowColumnTuple.Item2);
        }
        
        public bool IsNeighbor(Position possibleNeighbor)
        {
            if (possibleNeighbor.Row != Row + 1 && possibleNeighbor.Row != Row - 1 && possibleNeighbor.Row != Row)
            {
                return false;
            }

            if (possibleNeighbor.Column != Column + 1 && possibleNeighbor.Column != Column - 1 && possibleNeighbor.Column != Column)
            {
                return false;
            }

            if (possibleNeighbor.Row == Row && possibleNeighbor.Column == Column)
            {
                return false;
            }

            return true;
        }
    }
}