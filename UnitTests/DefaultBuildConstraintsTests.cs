using Alkl.Thira.Constraints;
using Alkl.Thira.DomainObjects;
using Alkl.Thira.Exceptions;
using Alkl.Thira.Exceptions.BuildExceptions;
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

        #region Exceptions

        [TestMethod]
        public void TestBuilderFieldDoesNotExistException()
        {
            Assert.ThrowsException<BuilderFieldDoesNotExistException>(() =>
                _player1.BuildConstraints.CheckBuild(null, _fields[1, 0]));
        }

        [TestMethod]
        public void TestTargetFieldDoesNotExistException()
        {
            Assert.ThrowsException<TargetFieldDoesNotExistException>(() =>
                _player1.BuildConstraints.CheckBuild(_fields[0, 0], null));
        }

        [TestMethod]
        public void TestNoBuilderOnBuilderFieldExceptionn()
        {
            Assert.ThrowsException<NoBuilderOnBuilderFieldException>(() =>
                _player1.BuildConstraints.CheckBuild(_fields[1, 1], _fields[1, 2]));
        }

        [TestMethod]
        public void TestTargetFieldIsNotNeighborOfBuilderFieldException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTargetFieldContainsBuilderException()
        {
            Assert.Fail();
        }

        #endregion
    }
}
