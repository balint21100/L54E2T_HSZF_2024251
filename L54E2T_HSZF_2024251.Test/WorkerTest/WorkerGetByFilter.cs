using L54E2T_HSZF_2024251.Application;
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
    internal class WorkerGetByFilter
    {
        private Mock<IWorkerDataProvider> workerDataProvider;
        private IWorkerService workerService;
        private Mock<IProjectDataProvider> projectDataProvider;
        [SetUp]
        public void Init()
        {
            workerDataProvider = new Mock<IWorkerDataProvider>(MockBehavior.Strict);
            projectDataProvider = new Mock<IProjectDataProvider>(MockBehavior.Strict);
            workerService = new WorkerService(workerDataProvider.Object, projectDataProvider.Object);

            workerDataProvider.Setup(x => x.GetWorker()).Returns(TestData.WorkersList).Verifiable();
        }
        [Test]
        public void GetPharaohByFilter()
        {
            var WorkerList = workerService.GetWorkersByFilter(x => x.Id == 1);
            workerDataProvider.Verify(x => x.GetWorker(), Times.Once());
            Assert.That(() => WorkerList.Count, Is.EqualTo(1));
        }
    }
}
