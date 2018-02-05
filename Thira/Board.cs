﻿using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;
using System;
using System.Linq;

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

        public Fields Fields => _fields.DeepClone();

        public void PlaceInitialBuilders(Player player, Position builder1Position, Position builder2Position)
        {
            PlaceInitialBuilder(player, builder1Position);
            PlaceInitialBuilder(player, builder2Position);
        }

        private void PlaceInitialBuilder(Player player, Position builderPosition)
        {
            var fieldsContainingPlayerBuilder = _fields.Where(f => f.Builder?.Owner.Name == player.Name);

            if (fieldsContainingPlayerBuilder.Count() == 2)
            {
                throw new MaximumNumberOfBuildersExceededException();
            }

            var field = _fields[builderPosition];
            
            if (field.Builder != null)
            {
                throw new FieldContainsBuilderException();
            }

            field.Builder = new Builder(player);
        }
        
        public void MoveBuilder(Player player, Position from, Position to)
        {
            var fieldFrom = _fields[from];
            var fieldTo = _fields[to];

            try
            {
                player.MovementConstraints.CheckArguments(player, fieldFrom, fieldTo);
                player.MovementConstraints.CheckMove(player, fieldFrom, fieldTo);
            }
            catch (InvalidMoveException ex)
            {
                throw new Exception($"Invalid move from {from} to {to} for player {player}: {ex.GetType().Name}", ex);
            }

            fieldTo.Builder = fieldFrom.Builder;
            fieldFrom.Builder = null;
        }
    }
}
