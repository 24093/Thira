namespace Alkl.Thira.DomainObjects
{
    public class Position
    {
        public readonly uint Row;

        public readonly uint Column;

        public Position(uint row, uint column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", Row, Column);
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