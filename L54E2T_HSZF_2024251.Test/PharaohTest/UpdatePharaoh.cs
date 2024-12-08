using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Test.PharaohTest
{
    [TestFixture]
    internal class UpdatePharaoh
    {
        private Mock<IPharaohDataProvider> pharaohprov;
        private IPharaohService pharaohService;
        [SetUp]
        public void Init()
        {
            pharaohprov = new Mock<IPharaohDataProvider>(MockBehavior.Strict);
            pharaohService = new PharaohService(pharaohprov.Object);

            pharaohprov.Setup(x => x.UpdatePharaoh(It.IsAny<int>(), It.IsAny<Pharaohs>())).Verifiable();
        }
        [Test]
        public void TestUpdatePharaohG()
        {
            Pharaohs p = TestData.p;
            pharaohService.UpdatePharaoh(p.Id, p);
            pharaohprov.Verify(x => x.UpdatePharaoh(It.IsAny<int>(), It.IsAny<Pharaohs>()), Times.Once);
        }
        [Test]
        public void TestUpdatePharaohB()
        {
            Pharaohs p = TestData.wrongp;
            Assert.Throws<ArgumentException>(() => pharaohService.UpdatePharaoh(p.Id, p));
        }
    }
}
