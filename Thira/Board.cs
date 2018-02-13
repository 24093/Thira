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
        private List<Player> _players = new List<Player>();
        private Fields _fields;
        private List<uint> _levels;
        private uint _maxLevel;
        
        public Board()
        {
            Reset(5, 5, new List<uint> {0, 22, 18, 14, 18});
        }

        public Board(uint rows, uint columns, List<uint> levels)
        {
            Reset(rows, columns, levels);
        }
        
        private void Reset(uint rows, uint columns, List<uint> levels)
        {
            _players = new List<Player>();
            _fields = new Fields(rows, columns);
            _levels = levels;
            _maxLevel = (uint)_levels.Count - 1;
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

            var checkMoveResult = builder.Owner.MovementConstraints.CheckMove(fieldFrom, fieldTo);

            if (!checkMoveResult.Success)
            {
                throw new InvalidMoveException(checkMoveResult.Error);
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

            var checkBuildResult = builderField.Builder.Owner.BuildConstraints.CheckBuild(builderField, targetField);

            if (!checkBuildResult.Success)
            {
                throw new InvalidBuildException(checkBuildResult.Error);
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

        public IEnumerable<Guid> GetPlayerIds()
        {
            return _players.Select(p => p.Id);
        }

        public uint? GetLevel(Position position)
        {
            return _fields[position]?.Level;
        }

        public IEnumerable<Guid> GetBuilderIds(Guid playerId)
        {
            return _fields.Where(f => f.Builder?.Owner.Id == playerId).Select(f => f.Builder.Id);
        }
        
        public IEnumerable<Position> GetPossibleMoves(Guid builderId)
        {
            var position = GetBuilderPosition(builderId);
            return _fields.GetNeighbors(position);
        }

        public Position GetBuilderPosition(Guid builderId)
        {
            return _fields.SingleOrDefault(f => f.Builder?.Id == builderId)?.Position;
        }

        private Builder GetBuilder(Guid builderId)
        {
            return _fields.Where(f => f.Builder?.Id == builderId).Select(f => f.Builder).SingleOrDefault();
        }

        private Player GetPlayer(Guid playerId)
        {
            return _players.SingleOrDefault(p => p.Id == playerId);
        }
    }
}