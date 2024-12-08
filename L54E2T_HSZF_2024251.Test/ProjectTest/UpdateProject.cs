using L54E2T_HSZF_2024251.Application;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L54E2T_HSZF_2024251.Test.ProjectTest
{
    [TestFixture]
    internal class UpdateProject
    {
        private Mock<IProjectDataProvider> projectDataProvider;
        private IProjectService projectService;
        private Mock<IPharaohDataProvider> pharaohprov;
        [SetUp]
        public void Init()
        {
            projectDataProvider = new Mock<IProjectDataProvider>(MockBehavior.Strict);
            pharaohprov = new Mock<IPharaohDataProvider>(MockBehavior.Strict);
            projectService = new ProjectService(projectDataProvider.Object, pharaohprov.Object);

            projectDataProvider.Setup(x => x.UpdateProjects(It.IsAny<int>(), It.IsAny<Projects>())).Verifiable();
            pharaohprov.Setup(x => x.GetPharaohs()).Returns(TestData.PharaohList).Verifiable();
        }
        [Test]
        public void TestUpdateProjectGodd()
        {
            Projects p = TestData.ProjectWithGoodDate;
            projectService.UpdateProjects(p.Id, p);
            projectDataProvider.Verify(x => x.UpdateProjects(It.IsAny<int>(), It.IsAny<Projects>()), Times.Once);
        }
        [Test]
        public void TestUpdateProjectBadId()
        {
            Projects p = TestData.ProjectWithBadId;
            Assert.Throws<ArgumentException>(() => projectService.UpdateProjects(p.Id, p));
        }
        [Test]
        public void TestUpdateProjectBadDate()
        {
            Projects p = TestData.ProjectWithBadDate;
            Assert.Throws<ArgumentException>(() => projectService.UpdateProjects(p.Id, p));
        }
        
    }
}
