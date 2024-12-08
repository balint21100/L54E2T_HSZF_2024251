using Moq;
using L54E2T_HSZF_2024251.Model;
using L54E2T_HSZF_2024251.Persistence.MsSql;
using L54E2T_HSZF_2024251.Application;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace L54E2T_HSZF_2024251.Test.ProjectTest
{
    [TestFixture]
    internal class ProjectAdd
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

            projectDataProvider.Setup(x => x.AddProjects(It.IsAny<Projects>())).Returns((Projects x) => x).Verifiable();
            pharaohprov.Setup(x => x.GetPharaohs()).Returns(TestData.PharaohList).Verifiable();
        }
        [Test]
        public void AddProjectTestGood()
        {
            Projects p = TestData.ProjectWithGoodDate;
            projectService.AddProjects(p);
            projectDataProvider.Verify(x => x.AddProjects(It.IsAny<Projects>()), Times.Once);
        }
        [Test]
        public void AddProjectTestBadDate()
        {
            Projects p = TestData.ProjectWithBadDate;
            Assert.Throws<ArgumentException>(() => projectService.AddProjects(p));
        }
        [Test]
        public void AddProjectTestBadId()
        {
            Projects p = TestData.ProjectWithBadId;
            Assert.Throws<ArgumentException>(() => projectService.AddProjects(p));
        }
    }
}
