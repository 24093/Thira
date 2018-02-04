﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Alkl.Thira.DomainObjects
{
    public class Fields : IEnumerable<Field>
    {
        private readonly List<Field> _fields = new List<Field>();

        public Field this[uint row, uint column] =>_fields.FirstOrDefault(f => f.Position.Row == row && f.Position.Column == column);

        public Field this[Position position] => this[position.Row, position.Column];
        
        public Fields(uint rows, uint columns)
        {
            for (uint row = 0; row < rows; ++row)
            {
                for (uint column = 0; column < columns; ++column)
                {
                    _fields.Add(new Field(row, column));
                }
            }
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
