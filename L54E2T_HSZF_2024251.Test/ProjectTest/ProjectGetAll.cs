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
    internal class ProjectGetAll
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

            projectDataProvider.Setup(x => x.GetProjects()).Returns(TestData.ProjectsList).Verifiable();
        }
        [Test]
        public void GetAllProjects()
        {
            var ProjectList = projectService.GetProjects();
            projectDataProvider.Verify(x => x.GetProjects(), Times.Once());
            Assert.That(() => ProjectList.Count, Is.EqualTo(2));
        }
    }
}
