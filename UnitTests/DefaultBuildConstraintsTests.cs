﻿using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class DefaultBuildConstraintsTests
    {
        private Fields _fields;
        private Player _player1;
        private Player _player2;

        [TestInitialize]
        public void Initialize()
        {
            _fields = new Fields(5, 5);
            _player1 = new Player("Alice", new DefaultMovementConstraints(), new DefaultBuildConstraints());
            _player2 = new Player("Bob", new DefaultMovementConstraints(), new DefaultBuildConstraints());

            _fields[0, 0].Builder = new Builder(_player1);
            _fields[1, 0].Builder = new Builder(_player1);
            _fields[3, 3].Builder = new Builder(_player2);
            _fields[2, 0].Builder = new Builder(_player2);
        }

        [TestMethod]
        public void TestCheckArguments()
        {
            Assert.ThrowsException<BuilderFieldDoesNotExistException>(() =>
                _player1.BuildConstraints.CheckBuild(null, _fields[1, 0]));

            Assert.ThrowsException<TargetFieldDoesNotExistException>(() =>
                _player1.BuildConstraints.CheckBuild(_fields[0, 0], null));

            Assert.ThrowsException<NoBuilderOnBuilderFieldException>(() =>
                _player1.BuildConstraints.CheckBuild(_fields[1, 1], _fields[1, 2]));
        }
    }
}