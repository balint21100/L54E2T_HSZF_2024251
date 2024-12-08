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
    internal class DeleteProject
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

            projectDataProvider.Setup(x => x.DeleteProjects(It.IsAny<int>())).Verifiable();
        }
        [Test]
        public void DeleteGoodProject()
        {
            Projects p = TestData.ProjectWithGoodDate;
            projectService.DeleteProjects(p);
            projectDataProvider.Verify(x => x.DeleteProjects(p.Id), Times.Once());
        }
        [Test]
        public void DeleteBadProject()
        {
            Projects p = null;
            Assert.Throws<ArgumentException>(() => projectService.DeleteProjects(p));
        }
    }
}
