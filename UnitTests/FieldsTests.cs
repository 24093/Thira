using Alkl.Thira.DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class FieldsTests
    {
        [TestMethod]
        public void TestFieldCreation()
        {
            const uint rows = 5;
            const uint columns = 5;

            var fields = new Fields(rows, columns);

            for (uint row = 0; row < rows; ++row)
            {
                for (uint column = 0; column < columns; ++column)
                {
                    Assert.IsNotNull(fields[row, column]);
                }
            }

            Assert.IsNull(fields[rows, columns]);
        }

        [TestMethod]
        public void TestFieldsCloning()
        {
            const uint rows = 3;
            const uint columns = 7;

            var fields = new Fields(rows, columns);
            var copy = fields.DeepClone();

            for (uint row = 0; row < rows; ++row)
            {
                for (uint column = 0; column < columns; ++column)
                {
                    Assert.AreNotEqual(fields[row, column], copy[row, column]);
                    Assert.AreEqual(fields[row, column].Position, copy[row, column].Position);
                }
            }
        }
    }
}
