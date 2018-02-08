using System;
using System.Collections.Generic;
using System.Linq;
using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions.BoardExceptions;
using Alkl.Thira.Exceptions.BuildExceptions;
using Alkl.Thira.Exceptions.MoveExceptions;

namespace Alkl.Thira
{
    public class Board
    {
        private List<Player> _players = new List<Player>();
        private Fields _fields;
        private List<uint> _levels;
        private uint _maxLevel;
        
        public Board()
        {
            Reset();
        }

        public void Reset()
        {
            _players = new List<Player>();
            _fields = new Fields(5, 5);
            _levels = new List<uint> {0, 22, 18, 14, 18};
            _maxLevel = 4;
        }

        public Guid AddPlayer(string name)
        {
            var player = new Player(name, new DefaultMovementConstraints(), new DefaultBuildConstraints());
            _players.Add(player);
            return player.Id;
        }

        public IEnumerable<Guid> PlaceInitialBuilders(Guid playerId, Position builder1Position,
            Position builder2Position)
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

        public void Move(Position from, Position to)
        {
            var fieldFrom = _fields[from];
            var fieldTo = _fields[to];
            var builder = _fields[from].Builder;

            try
            {
                builder.Owner.MovementConstraints.CheckMove(fieldFrom, fieldTo);
            }
            catch (MoveException ex)
            {
                throw new InvalidMoveException(null, ex);
            }

            fieldTo.Builder = fieldFrom.Builder;
            fieldFrom.Builder = null;
        }

        public void Build(Position builderPosition, Position position)
        {
            var builderField = _fields[builderPosition];
            var targetField = _fields[position];
            var level = (int)targetField.Level;

            if (targetField.Level.Equals(_maxLevel))
            {
                throw new MaximumLevelReachedException();
            }

            if (_levels[level + 1] == 0)
            {
                throw new LevelNotAvailableException();
            }

            try
            {
                builderField.Builder.Owner.BuildConstraints.CheckBuild(builderField, targetField);
            }
            catch (BuildException ex)
            {
                throw new InvalidBuildException(null, ex);
            }

            _levels[level + 1]--;
            targetField.Level++;
        }

        public Guid? GetBuilderId(Position position)
        {
            return _fields[position]?.Builder?.Id;
        }

        public Guid? GetPlayerId(Position position)
        {
            return _fields[position]?.Builder?.Owner.Id;
        }

        public uint? GetLevel(Position position)
        {
            return _fields[position]?.Level;
        }

        private Player GetPlayer(Guid id)
        {
            return _players.SingleOrDefault(p => p.Id == id);
        }
    }
}