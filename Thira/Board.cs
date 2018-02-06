using System;
using System.Collections.Generic;
using System.Linq;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;

namespace Alkl.Thira
{
    public class Board
    {
        private Fields _fields;

        public Board()
        {
            Reset();
        }
        
        public void Reset()
        {
            _fields = new Fields(5, 5);
        }

        public IEnumerable<Guid> PlaceInitialBuilders(Player player, Position builder1Position, Position builder2Position)
        {
            return new[]
            {
                PlaceInitialBuilder(player, builder1Position),
                PlaceInitialBuilder(player, builder2Position)
            };
        }

        private Guid PlaceInitialBuilder(Player player, Position builderPosition)
        {
            var fieldsContainingPlayerBuilder = _fields.Where(f => f.Builder?.Owner.Id == player.Id);

            if (fieldsContainingPlayerBuilder.Count() == 2) throw new MaximumNumberOfBuildersExceededException();

            var field = _fields[builderPosition];

            if (field.Builder != null) throw new FieldContainsBuilderException();

            field.Builder = new Builder(player);

            return field.Builder.Id;
        }

        public Guid MoveBuilder(Position from, Position to)
        {
            var fieldFrom = _fields[from];
            var fieldTo = _fields[to];
            var builder = _fields[from].Builder;

            try
            {
                builder.Owner.MovementConstraints.CheckMove(fieldFrom, fieldTo);
            }
            catch (InvalidMoveException ex)
            {
                throw new Exception($"Invalid move from {from} to {to} for player {builder.Owner}: {ex.GetType().Name}", ex);
            }

            fieldTo.Builder = fieldFrom.Builder;
            fieldFrom.Builder = null;

            return fieldTo.Builder.Id;
        }

        public Guid? GetBuilderId(Position position)
        {
            return _fields[position]?.Builder?.Id;
        }

        public Guid? GetPlayerId(Position position)
        {
            return _fields[position]?.Builder?.Owner.Id;
        }
    }
}