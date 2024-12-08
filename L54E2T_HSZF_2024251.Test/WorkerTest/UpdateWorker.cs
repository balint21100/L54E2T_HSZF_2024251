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
    internal class UpdateWorker
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

            workerDataProvider.Setup(x => x.UpdateWorker(It.IsAny<int>(), It.IsAny<Workers>())).Verifiable();

            projectDataProvider.Setup(x => x.GetProjects()).Returns(TestData.ProjectsList).Verifiable();
        }
        [Test]
        public void TestUpdateWorkerGoodData()
        {
            Workers w = TestData.WorkerWithGoodData;
            workerService.UpdateWorker(w.Id, w);
            workerDataProvider.Verify(x => x.UpdateWorker(It.IsAny<int>(), It.IsAny<Workers>()), Times.Once);
        }
        [Test]
        public void TestUpdateWorkerBadId()
        {
            Workers w = TestData.WorkerWithBadId;
            Assert.Throws<ArgumentException>(() => workerService.UpdateWorker(w.Id, w));
        }
    }
}
