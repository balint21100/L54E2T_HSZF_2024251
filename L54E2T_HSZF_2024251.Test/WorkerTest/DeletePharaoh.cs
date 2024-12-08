using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Test.WorkerTest
{
    [TestFixture]
    internal class WorkerAdd
    {
        private Mock<IPharaohDataProvider> pharaohprov;
        private IPharaohService pharaohService;
        [SetUp]
        public void Init()
        {
            pharaohprov = new Mock<IPharaohDataProvider>(MockBehavior.Strict);
            pharaohService = new PharaohService(pharaohprov.Object);

            pharaohprov.Setup(x => x.DeletePharaoh(It.IsAny<int>())).Verifiable();
        }
        [Test]
        public void DeleteGoodPharaoh()
        {
            Pharaohs p = TestData.p;
            pharaohService.DeletePharaoh(p);
            pharaohprov.Verify(x => x.DeletePharaoh(p.Id), Times.Once());
        }
        [Test]
        public void DeleteBadPharaoh()
        {
            Pharaohs p = null;
            Assert.Throws<ArgumentException>(() => pharaohService.DeletePharaoh(p));
        }
    }
}
