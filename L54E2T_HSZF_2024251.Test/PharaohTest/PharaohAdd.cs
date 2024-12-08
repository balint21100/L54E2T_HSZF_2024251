using Moq;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using L54E2T_HSZF_2024251.Application;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace L54E2T_HSZF_2024251.Test.PharaohTest
{
    [TestFixture]
    internal class PharaohAdd
    {
        private Mock<IPharaohDataProvider> pharaohprov;
        private IPharaohService pharaohService;
        [SetUp]
        public void Init()
        {
            pharaohprov = new Mock<IPharaohDataProvider>(MockBehavior.Strict);
            pharaohService = new PharaohService(pharaohprov.Object);

            pharaohprov.Setup(x => x.AddPharaoh(It.IsAny<Pharaohs>())).Returns((Pharaohs x) => x).Verifiable();
        }
        [Test]
        public void AddPharaohTestGood()
        {
            Pharaohs p = TestData.p;
            pharaohService.AddPharaoh(p);
            pharaohprov.Verify(x => x.AddPharaoh(It.IsAny<Pharaohs>()), Times.Once);
        }
        [Test]
        public void AddPharaohTestBadDate()
        {
            Pharaohs p = TestData.wrongp;
            Assert.Throws<ArgumentException>(() => pharaohService.AddPharaoh(p));
        }
    }
}
