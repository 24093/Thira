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
    }
}
