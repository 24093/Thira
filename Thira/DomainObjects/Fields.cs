using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Alkl.Thira.DomainObjects
{
    internal class Fields : IEnumerable<Field>, IDeepCloneable<Fields>
    {
        private readonly List<Field> _fields = new List<Field>();

        public Fields(uint rows, uint columns)
        {
            for (uint row = 0; row < rows; ++row)
            for (uint column = 0; column < columns; ++column)
                _fields.Add(new Field((row, column)));
        }

        private Fields(IEnumerable<Field> fields)
        {
            _fields = new List<Field>(fields);
        }

        public Field this[uint row, uint column] =>
            _fields.FirstOrDefault(f => f.Position.Row == row && f.Position.Column == column);

        public Field this[Position position] => this[position.Row, position.Column];

        public IEnumerable<Position> GetNeighbors(Position position)
        {
            return position.GetNeighbors().Where(p => this[p] != null);
        }

        public IEnumerable<Field> GetFields(IEnumerable<Position> positions)
        {
            return positions.Select(p => this[p]).Where(f => f != null);
        }

        public Fields DeepClone()
        {
            return new Fields(_fields.Select(f => f.DeepClone()));
        }

        public IEnumerator<Field> GetEnumerator()
        {
            return _fields.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}