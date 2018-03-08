using System;
using System.Collections.Generic;
using AutoMapper;
using DocumentsKeeperDemo.Core.Infrastructure;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;

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
		public List<DocumentModel> GetAllDocumentModels()
		{
			var documentEntities = this.documentRepository.GetAllDocumentEntities();
			var documentModels = AutoMapper.Mapper.Map<List<DocumentModel>>(documentEntities);
			return documentModels;
		}

		/// <summary>
		/// Gets the document by id.
		/// </summary>
		/// <param name="documentId">The document's id.</param>
		/// <returns>
		/// The document model.
		/// </returns>
		public DocumentModel GetDocumentModelById(Guid documentId)
		{
			if (documentId == Guid.Empty)
			{
				throw new ArgumentException("The document id is empty guid.");
			}

			var documentEntity = this.documentRepository.GetDocumentEntity(d => d.Id == documentId.ToNonDashedString());
			var documentModel = Mapper.Map<DocumentModel>(documentEntity);

			return documentModel;
		}
	}
}
