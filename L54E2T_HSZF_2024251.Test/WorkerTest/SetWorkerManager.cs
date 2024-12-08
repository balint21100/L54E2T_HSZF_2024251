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
    internal class SetWorkerManager
    {
        private Mock<IWorkerDataProvider> workerDataProvider;
        private IWorkerRelationShipService workerRelatioshipService;
        private Mock<IWorkerRelationshipsDataProvider> workerRelatioshipDataProvider;
        [SetUp]
        public void Init()
        {
            workerDataProvider = new Mock<IWorkerDataProvider>(MockBehavior.Strict);
            workerRelatioshipDataProvider = new Mock<IWorkerRelationshipsDataProvider>(MockBehavior.Strict);
            workerRelatioshipService = new WorkerRelationShipService(workerRelatioshipDataProvider.Object, workerDataProvider.Object);

            workerRelatioshipDataProvider.Setup(x => x.AddWorkerRelationships(It.IsAny<WorkerRelationShip>())).Returns((WorkerRelationShip x) => x).Verifiable();
            workerRelatioshipDataProvider.Setup(x => x.GetWorkerRelationShip()).Returns(TestData.workerRelationShipsList).Verifiable();
            workerRelatioshipDataProvider.Setup(x => x.DeleteWorkerRelationShip(It.IsAny<int>(), It.IsAny<int>())).Verifiable();
            workerDataProvider.Setup(x => x.GetWorker()).Returns(TestData.WorkersList).Verifiable();
        }
        [Test]
        public void AddWorkerRelationShipTestWithoutCurrentManagerGood()
        {
            WorkerRelationShip workerRelationShip = TestData.relationShipGoodWithoutManager;
            workerRelatioshipService.AddWorkerRelationShip(workerRelationShip);
            workerRelatioshipDataProvider.Verify(x => x.AddWorkerRelationships(It.IsAny<WorkerRelationShip>()), Times.Once);
        }
        [Test]
        public void AddWorkerRelationShipTestWithCurrentManagerGood()
        {
            WorkerRelationShip workerRelationShip = TestData.relationShipGoodWithoutManager;
            workerRelatioshipService.AddWorkerRelationShip(workerRelationShip);
            workerRelatioshipDataProvider.Verify(x => x.AddWorkerRelationships(It.IsAny<WorkerRelationShip>()), Times.Once);
        }
        [Test]
        public void WorkerRelationShipTestSameId()
        {
            WorkerRelationShip workerRelationShip = TestData.relationShipSameId;
            Assert.Throws<ArgumentException>(() => workerRelatioshipService.AddWorkerRelationShip(workerRelationShip));
        }
        [Test]
        public void WorkerRelationShipTestManagerFoundInWorkers()
        {
            WorkerRelationShip workerRelationShip = new WorkerRelationShip()
            {
                Id = 1,
                WorkerId = 1,
                ManagerId = 4
            };
            Assert.Throws<ArgumentException>(() => workerRelatioshipService.AddWorkerRelationShip(workerRelationShip));
        }
    }
}
