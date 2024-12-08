using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Test.FileTest
{
    [TestFixture]
    internal class ImportTest
    {
        private Mock<IPharaohDataProvider> pharaohprov;
        private Mock<IProjectDataProvider> projectDataProvider;
        private Mock<IWorkerDataProvider> workerDataProvider;
        private Mock<IWorkerRelationshipsDataProvider> workerRelationshipsDataProvider;
        private IFileService fileService;
        [SetUp]
        public void Init()
        {
            pharaohprov = new Mock<IPharaohDataProvider>(MockBehavior.Strict);
            projectDataProvider = new Mock<IProjectDataProvider>(MockBehavior.Strict);
            workerDataProvider = new Mock<IWorkerDataProvider>(MockBehavior.Strict);
            workerRelationshipsDataProvider = new Mock<IWorkerRelationshipsDataProvider>(MockBehavior.Strict);
            fileService = new FileService(pharaohprov.Object, projectDataProvider.Object, workerDataProvider.Object, workerRelationshipsDataProvider.Object);

            pharaohprov.Setup(x => x.AddPharaoh(It.IsAny<Pharaohs>())).Returns((Pharaohs x) => x).Verifiable();
            projectDataProvider.Setup(x => x.AddProjects(It.IsAny<Projects>())).Returns((Projects x) => x).Verifiable();
            workerDataProvider.Setup(x => x.AddWorker(It.IsAny<Workers>())).Returns((Workers x) => x).Verifiable();
            workerRelationshipsDataProvider.Setup(x => x.AddWorkerRelationships(It.IsAny<WorkerRelationShip>())).Returns((WorkerRelationShip x) => x).Verifiable();
        }
        [Test]
        public void CorrectFileLoad()
        {
            fileService.Import("SeedGoodConditions.json");
            pharaohprov.Verify(x => x.AddPharaoh(It.IsAny<Pharaohs>()), Times.Exactly(2));
            projectDataProvider.Verify(x => x.AddProjects(It.IsAny<Projects>()), Times.Exactly(3));
            workerDataProvider.Verify(x => x.AddWorker(It.IsAny<Workers>()), Times.Exactly(9));
            workerRelationshipsDataProvider.Verify(x => x.AddWorkerRelationships(It.IsAny<WorkerRelationShip>()), Times.Exactly(3));
        }
        [Test]
        public void SeedWithNoPharaohs()
        {
            Assert.Throws<ArgumentException>(() => fileService.Import("SeedWithNoPharaohs_cleanfile.json"));
        }
        [Test]
        public void SeedWithNoProject()
        {
            Assert.Throws<ArgumentException>(() => fileService.Import("SeedWithNoProjects.json"));
        }
        [Test]
        public void SeedWithNoWorkers()
        {
            Assert.Throws<ArgumentException>(() => fileService.Import("SeedWithNoWorkers.json"));
        }
    }
}
