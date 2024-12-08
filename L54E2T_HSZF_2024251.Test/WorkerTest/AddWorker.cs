using Moq;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using L54E2T_HSZF_2024251.Application;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace L54E2T_HSZF_2024251.Test.WorkerTest
{
    [TestFixture]
    internal class AddWorker
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

            workerDataProvider.Setup(x => x.AddWorker(It.IsAny<Workers>())).Returns((Workers x) => x).Verifiable();
            projectDataProvider.Setup(x => x.GetProjects()).Returns(TestData.ProjectsList).Verifiable();
        }
        [Test]
        public void AddWorkerTestGood()
        {
            Workers w = TestData.WorkerWithGoodData;
            workerService.AddWorker(w);
            workerDataProvider.Verify(x => x.AddWorker(It.IsAny<Workers>()), Times.Once);
        }
        [Test]
        public void AddWorkerTestBadId()
        {
            Workers w = TestData.WorkerWithBadId;
            Assert.Throws<ArgumentException>(() => workerService.AddWorker(w));
        }
    }
}
