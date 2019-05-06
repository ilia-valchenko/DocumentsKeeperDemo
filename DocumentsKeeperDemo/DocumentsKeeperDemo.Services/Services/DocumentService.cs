using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DocumentsKeeperDemo.Core.Enums;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Core.Infrastructure;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using NHibernate.Util;

namespace DocumentsKeeperDemo.Services.Services
{
    /// <summary>
    /// The document service.
    /// </summary>
    public sealed class DocumentService : IDocumentService
    {
        // TODO: Move it to web.config file.
        private const string DefaultFileName = "Unknown";
        private const string indexName = "documentskeeperindex";

        /// <summary>
        /// The document repository.
        /// </summary>
        private readonly IDocumentRepository documentRepository;

        /// <summary>
        /// The ElasticSearch repository that manages ES index.
        /// </summary>
        private readonly IElasticRepository elasticRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentService"/> class.
        /// </summary>
        /// <param name="documentRepository">The document repository.</param>
        /// <param name="elasticRepository">The ElasticSearch repository.</param>
        public DocumentService(
            IDocumentRepository documentRepository,
            IElasticRepository elasticRepository)
        {
            this.documentRepository = documentRepository;
            this.elasticRepository = elasticRepository;
        }

        /// <summary>
        /// Gets all document models.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DocumentModel> GetAllDocuments()
        {
            var documentEntities = this.documentRepository.GetAllDocumentEntities();
            var documentModels = Mapper.Map<IEnumerable<DocumentModel>>(documentEntities);

            return documentModels;
        }

        /// <summary>
        /// Gets all lite document models.
        /// </summary>
        /// <returns>
        /// Returns the collection of document lite models.
        /// </returns>
        public IEnumerable<DocumentModel> GetAllLiteDocuments()
        {
            var documentLiteEntities = this.documentRepository.GetAllDocumentLiteEntities();
            var documentLiteModels = Mapper.Map<IEnumerable<DocumentModel>>(documentLiteEntities);

            return documentLiteModels;
        }

        /// <summary>
        /// Gets the document by id.
        /// </summary>
        /// <param name="documentId">The document's id.</param>
        /// <returns>
        /// The document model.
        /// </returns>
        public DocumentModel GetDocument(Guid documentId)
        {
            Guard.NotEmptyGuid(documentId, nameof(documentId));

            var documentEntity = this.documentRepository.GetDocumentEntity(d => d.Id == documentId.ToNonDashedString());
            var documentModel = Mapper.Map<DocumentModel>(documentEntity);

            return documentModel;
        }

        /// <summary>
        /// Gets document lite model by id.
        /// </summary>
        /// <param name="documentId">The document id.</param>
        /// <returns>
        /// Returns document lite model.
        /// </returns>
        public DocumentModel GetLiteDocument(Guid documentId)
        {
            Guard.NotEmptyGuid(documentId, nameof(documentId));

            var documentLiteEntity = this.documentRepository.GetDocumentLiteEntity(d => d.Id == documentId.ToNonDashedString());
            var documentLiteModel = Mapper.Map<DocumentModel>(documentLiteEntity);

            return documentLiteModel;
        }

        /// <summary>
        /// Gets all lite documents that are contained in the specified folder.
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        public IEnumerable<DocumentModel> GetLiteDocumentsByFolderId(Guid folderId)
        {
            if (folderId == Guid.Empty)
            {
                return null;
            }

            var liteDocumentEntities = this.documentRepository
                .GetDocumentLiteEntities(d => d.FolderId == folderId.ToNonDashedString());

            var liteDocumentModels = Mapper.Map<IEnumerable<DocumentModel>>(liteDocumentEntities);

            return liteDocumentModels;
        }

        /// <summary>
        /// Removes document by document id.
        /// </summary>
        /// <param name="documentId">The id of the document that have to be deleted.</param>
        public void DeleteDocument(Guid documentId)
        {
            if (documentId == Guid.Empty)
            {
                return;
            }

            this.documentRepository.DeleteDocument(documentId.ToNonDashedString());
        }

        public IEnumerable<DocumentModel> InsertDocuments(Guid folderId, FileResultModel fileResult)
        {
            Guard.ArgumentNotNull(fileResult, nameof(fileResult));

            var documents = new List<DocumentModel>();

            // TODO: Use Parallel library.
            if (EnumerableExtensions.Any(fileResult.Names))
            {
                var names = fileResult.Names.Select(this.RemoveSpecialCharactersFromFileName).ToArray();
                var fileNames = fileResult.FileNames.ToArray();
                var contentTypes = fileResult.ContentTypes.ToArray();

                for (var i = 0; i < names.Length; i++)
                {
                    string documentText = System.IO.File.ReadAllText(fileNames[i]);

                    documents.Add(new DocumentModel
                    {
                        Id = Guid.NewGuid(),
                        Folder = new FolderModel { Id = folderId },
                        FolderId = folderId,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        FileName = names[i],
                        TextNasPath = fileNames[i],
                        FileType = contentTypes[i].FromTextAttributeStringToEnumValue<FileType>(),
                        DocumentText = documentText
                    });
                }
            }

            var documentEntities = Mapper.Map<IEnumerable<DocumentEntity>>(documents);
            this.documentRepository.InsertDocuments(documentEntities);

            // test
            if (documentEntities.Any())
            {
                foreach(var document in documentEntities)
                {
                    this.elasticRepository.Create(document, indexName);
                }
            }
            // end of test

            return documents;
        }

        private string RemoveSpecialCharactersFromFileName(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return DefaultFileName;
            }

            return fileName.Replace("\"", "");
        }
    }
}