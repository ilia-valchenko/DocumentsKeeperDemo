using System;
using System.Collections.Generic;
using AutoMapper;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Core.Infrastructure;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;
using DocumentsKeeperDemo.Core.Repositories.Entities;

namespace DocumentsKeeperDemo.Services.Services
{
	/// <summary>
	/// The document service.
	/// </summary>
	public sealed class DocumentService : IDocumentService
	{
		/// <summary>
		/// The document repository.
		/// </summary>
		private readonly IDocumentRepository documentRepository;

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentService"/> class.
		/// </summary>
		/// <param name="documentRepository">The document repository.</param>
		public DocumentService(IDocumentRepository documentRepository)
		{
			this.documentRepository = documentRepository;
		}

		/// <summary>
		/// Gets all document models.
		/// </summary>
		/// <returns></returns>
		public List<DocumentModel> GetAllDocuments()
		{
			var documentEntities = this.documentRepository.GetAllDocumentEntities();
			var documentModels = AutoMapper.Mapper.Map<List<DocumentModel>>(documentEntities);

			return documentModels;
		}

	    /// <summary>
	    /// Gets all lite document models.
	    /// </summary>
	    /// <returns>
	    /// Returns the collection of document lite models.
	    /// </returns>
	    public List<DocumentModel> GetAllLiteDocuments()
	    {
	        var documentLiteEntities = this.documentRepository.GetAllDocumentLiteEntities();
	        var documentLiteModels = Mapper.Map<List<DocumentModel>>(documentLiteEntities);

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
        /// Inserts new document model.
        /// </summary>
        /// <param name="documentModel">The document model.</param>
        /// <returns>
        /// The guid of the inserted document model.
        /// </returns>
        public Guid InsertDocument(DocumentModel documentModel)
		{
            Guard.ArgumentNotNull(documentModel, nameof(documentModel));

            documentModel.Id = Guid.NewGuid();
            var documentEntity = Mapper.Map<DocumentEntity>(documentModel);
            this.documentRepository.InsertDocument(documentEntity);

            return documentModel.Id;
		}
	}
}
