using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Services.Services;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Core.Infrastructure;

namespace DocumentsKeeperDemo.Services.UnitTests
{
    /// <summary>
    /// The document service test class.
    /// </summary>
    [TestClass]
    public class DocumentServiceTests
    {
        private Mock<IDocumentRepository> documentRepositoryMock;
        private DocumentService documentService;

        /// <summary>
        /// Initializes each test.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.documentRepositoryMock = new Mock<IDocumentRepository>();
            this.documentService = new DocumentService(this.documentRepositoryMock.Object);
        }

        [TestMethod]
        public void TestGetDocumentModelByIdSuccessfullyReturnsDocumentModel()
        {
            ApplicationLogger.LogInfo("The test method TestGetDocumentModelByIdSuccessfullyReturnsDocumentModel successfully started.");

            // Arrange
            Guid documentId = Guid.NewGuid();
            int documentNumber = 178;

            var documentEntity = new DocumentEntity
            {
                Id = documentId.ToNonDashedString(),
                DocumentNumber = documentNumber
            };

            // Act
            var documentModel = this.documentService.GetDocumentModelById(documentId);

            // Assert
            Assert.AreEqual(documentModel.Id, documentId);
            Assert.AreEqual(documentModel.DocumentNumber, documentNumber);
        }
    }
}
