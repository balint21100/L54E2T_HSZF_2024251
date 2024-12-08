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
    internal class DeleteWorker
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

            workerDataProvider.Setup(x => x.DeleteWorker(It.IsAny<int>())).Verifiable();
        }
        [Test]
        public void DeleteGoodWorker()
        {
            Workers w = TestData.WorkerWithGoodData;
            workerService.DeleteWorker(w);
            workerDataProvider.Verify(x => x.DeleteWorker(w.Id), Times.Once());
        }
        [Test]
        public void DeleteBadWorker()
        {
            Workers w = null;
            Assert.Throws<ArgumentException>(() => workerService.DeleteWorker(w));
        }
    }
}
