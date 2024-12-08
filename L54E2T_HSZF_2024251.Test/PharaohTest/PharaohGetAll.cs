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
    internal class PharaohGet
    {
        private Mock<IPharaohDataProvider> pharaohprov;
        private IPharaohService pharaohService;
        [SetUp]
        public void Init()
        {
            pharaohprov = new Mock<IPharaohDataProvider>(MockBehavior.Strict);
            pharaohService = new PharaohService(pharaohprov.Object);

            pharaohprov.Setup(x => x.GetPharaohs()).Returns(TestData.PharaohList).Verifiable();
        }
        [Test]
        public void GetAllP()
        {
            var PharaohsList = pharaohService.GetPharaohs();
            pharaohprov.Verify(x => x.GetPharaohs(), Times.Once());
            Assert.That(() => PharaohsList.Count, Is.EqualTo(2));
        }
    }
}
