﻿using System.Collections.Generic;

namespace Alkl.Thira.DomainObjects
{
    public class Position : IDeepCloneable<Position>
    {
        public readonly uint Column;
        public readonly uint Row;

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
            if (possibleNeighbor.Row != Row + 1 &&
                possibleNeighbor.Row != Row - 1 &&
                possibleNeighbor.Row != Row)
                return false;

            if (possibleNeighbor.Column != Column + 1 &&
                possibleNeighbor.Column != Column - 1 &&
                possibleNeighbor.Column != Column)
                return false;

            if (possibleNeighbor.Row == Row &&
                possibleNeighbor.Column == Column)
                return false;

            return true;
        }

        public IEnumerable<Position> GetNeighbors()
        {
            yield return new Position(Row, Column + 1);
            yield return new Position(Row + 1, Column + 1);
            yield return new Position(Row + 1, Column);
            yield return new Position(Row - 1, Column - 1);
            yield return new Position(Row, Column - 1);
            yield return new Position(Row - 1, Column - 1);
            yield return new Position(Row - 1, Column);
            yield return new Position(Row + 1, Column + 1);
        }

        public override bool Equals(object obj)
        {
            var position = obj as Position;
            return position != null &&
                   Row == position.Row &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            var hashCode = 240067226;
            hashCode = hashCode * -1521134295 + Row.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }
    }
}