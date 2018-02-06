using System;
using System.Collections.Generic;
using System.Linq;
using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;

namespace Alkl.Thira
{
    public class Board
    {
        private Fields _fields;
        private List<Player> _players = new List<Player>();

        public Board()
        {
            Reset();
        }
        
        public void Reset()
        {
            _fields = new Fields(5, 5);
        }

        public Guid AddPlayer(string name)
        {
            var player = new Player(name, new DefaultMovementConstraints(), new DefaultBuildConstraints());
            _players.Add(player);
            return player.Id;
        }

        public IEnumerable<Guid> PlaceInitialBuilders(Guid playerId, Position builder1Position, Position builder2Position)
        {
            return new[]
            {
                PlaceInitialBuilder(GetPlayer(playerId), builder1Position),
                PlaceInitialBuilder(GetPlayer(playerId), builder2Position)
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

        public void MoveBuilder(Position from, Position to)
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
        }

        public void Build(Position builderPosition, Position position)
        {
            var builderField = _fields[builderPosition];
            var targetField = _fields[position];

            try
            {
                builderField.Builder.Owner.BuildConstraints.CheckBuild(builderField, targetField);
            }
            catch (BuildException ex)
            {
                throw new Exception($"Invalid build on {position} for player {builderField.Builder.Owner}: {ex.GetType().Name}", ex);
            }

            targetField.IncreaseStoryLevel();
        }

        public Guid? GetBuilderId(Position position)
        {
            return _fields[position]?.Builder?.Id;
        }

        public Guid? GetPlayerId(Position position)
        {
            return _fields[position]?.Builder?.Owner.Id;
        }

        private Player GetPlayer(Guid id)
        {
            return _players.SingleOrDefault(p => p.Id == id);
        }
    }
}