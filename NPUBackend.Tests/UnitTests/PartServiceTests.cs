using Moq;
using NPUBackend.Domain.Entities;
using NPUBackend.Domain.Interfaces.Repositories;
using NPUBackend.Infra.DTO;
using NPUBackend.Infra.Interfaces.Services;
using NPUBackend.Infra.Services;
using NUnit.Framework;

namespace NPUBackend.Tests
{
    [TestFixture]
    public class PartServiceTests
    {
        private Mock<IPartRepository> m_PartRepositoryMock;
        private IPartService m_PartService;

        [SetUp]
        public void Setup()
        {
            m_PartRepositoryMock = new Mock<IPartRepository>();
            m_PartService = new PartService(m_PartRepositoryMock.Object);
        }

        [Test]
        public async Task GetPartAsync_ValidPartId_ReturnsPartDTO()
        {
            int partId = 1;
            var part = new Part
            {
                Id = partId,
                Name = "Test Part"
            };

            m_PartRepositoryMock.Setup(x => x.GetPartAsync(partId)).ReturnsAsync(part);

            var result = await m_PartService.GetPartAsync(partId);

            Assert.IsInstanceOf<PartDTO>(result);
            Assert.AreEqual(part.Id, result.Id);
            Assert.AreEqual(part.Name, result.Name);
        }

        [Test]
        public async Task GetPartAsync_PartNotFound_ReturnsNull()
        {
            int partId = 1;
            var notFoundPart = new Part
            {
                Id = -1
            };

            m_PartRepositoryMock.Setup(x  => x .GetPartAsync(partId)).ReturnsAsync(notFoundPart);

            var result = await m_PartService.GetPartAsync(partId);

            Assert.IsNull(result);
        }

        [Test]
        public async Task AddPartToAssemblyAsync_PartNotInAssembly_AddsPartToAssembly()
        {
            var part = new Part
            {
                Id = 1,
                Name = "Test Part"
            };
            int assemblyId = 1;
            m_PartRepositoryMock.Setup(x => x.GetPartAsync(part.Id)).ReturnsAsync(part);
            m_PartRepositoryMock.Setup(x => x.GetAssemblyPartRelationAsync(assemblyId, part.Id)).ReturnsAsync(new AssemblyPartRelation(-1, -1));
            m_PartRepositoryMock.Setup(x => x.CreatePartAsync(part)).ReturnsAsync(part.Id);
            m_PartRepositoryMock.Setup(x => x.AddAssemblyPartRelationAsync(It.IsAny<AssemblyPartRelation>())).ReturnsAsync("Success");

            var result = await m_PartService.AddPartToAssemblyAsync(part, assemblyId);

            Assert.AreEqual("Success", result);
            m_PartRepositoryMock.Verify(x => x.GetPartAsync(part.Id), Times.Once);
            m_PartRepositoryMock.Verify(x => x.GetAssemblyPartRelationAsync(assemblyId, part.Id), Times.Once);
            m_PartRepositoryMock.Verify(x => x.CreatePartAsync(part), Times.Once);
            m_PartRepositoryMock.Verify(x => x.AddAssemblyPartRelationAsync(It.IsAny<AssemblyPartRelation>()), Times.Once);
        }

        [Test]
        public async Task RemovePartFromAssemblyAsync_PartInAssembly_RemovesPartFromAssembly()
        {
            int partId = 1;
            int assemblyId = 1;
            m_PartRepositoryMock.Setup(x => x.GetAssemblyPartRelationAsync(assemblyId, partId)).ReturnsAsync(new AssemblyPartRelation(assemblyId, partId));
            m_PartRepositoryMock.Setup(x => x.DeleteAssemblyPartRelationAsync(It.IsAny<AssemblyPartRelation>())).ReturnsAsync("Success");

            var result = await m_PartService.RemovePartFromAssemblyAsync(partId, assemblyId);

            Assert.AreEqual("Success", result);
            m_PartRepositoryMock.Verify(x => x.GetAssemblyPartRelationAsync(assemblyId, partId), Times.Once);
            m_PartRepositoryMock.Verify(x => x.DeleteAssemblyPartRelationAsync(It.IsAny<AssemblyPartRelation>()), Times.Once);
        }

        [Test]
        public async Task FindAssemblyIDsWherePartIsUsedAsync_PartUsedByName_ReturnsAssemblyIDs()
        {
            string partName = "Test Part";
            int partId = 1;
            var part = new PartDTO
            {
                Id = partId,
                Name = partName,
                DirectoryId = 1,
            };
            var assemblyIds = new List<int> { 1, 2, 3 };

            m_PartRepositoryMock.Setup(x => x.GetPartAsync(partName)).ReturnsAsync(part);
            m_PartRepositoryMock.Setup(x => x.GetAssemblyIdsWherePartIdIsUsedAsync(part.Id)).ReturnsAsync(assemblyIds);

            var result = await m_PartService.FindAssemblyIDsWherePartIsUsedAsync(partName);

            Assert.AreEqual(assemblyIds, result);
        }
    }
}
