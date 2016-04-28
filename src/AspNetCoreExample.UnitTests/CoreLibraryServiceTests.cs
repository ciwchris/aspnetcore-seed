namespace AspNetCoreExample.UnitTests
{
    using Core;
    using NUnit.Framework;

    [TestFixture]
    public class CoreLibraryServiceTests
    {
        public class CreateMessage : CoreLibraryServiceTests
        {
            [Test]
            public void DefaultMessage_SaysHello()
            {
                var sut = new CoreLibraryService();

                var result = sut.CreateMessage();

                Assert.AreEqual("Core library message", result);
            }

        }
    }
}
