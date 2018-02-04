using Alkl.Thira.DomainObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alkl.Thira.UnitTests
{
    [TestClass]
    public class StoriesTests
    {
        [TestMethod]
        public void TestStoriesCreation()
        {
            var stories = new Stories();

            stories.AddStories(0, 22);
            stories.AddStories(1, 18);
            stories.AddStories(2, 14);
            stories.AddStories(3, 18);

            Assert.AreEqual(22U, stories[0]);
            Assert.AreEqual(18U, stories[1]);
            Assert.AreEqual(14U, stories[2]);
            Assert.AreEqual(18U, stories[3]);
        }
    }
}
