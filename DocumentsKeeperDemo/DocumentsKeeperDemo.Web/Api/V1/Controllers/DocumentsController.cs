using System;
using System.Collections.Generic;
using System.Web.Http;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers
{
	/// <summary>
	/// The document controller.
	/// </summary>
	public sealed class DocumentsController : ApiController
	{
		/// <summary>
		/// The document service.
		/// </summary>
		private readonly IDocumentService documentService;

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentsController"/> class.
		/// </summary>
		/// <param name="documentService">The </param>
		public DocumentsController(IDocumentService documentService)
		{
			this.documentService = documentService;
		}

		/// <summary>
		/// Gets all documents.
		/// </summary>
		/// <returns>
		/// The collection of all documents.
		/// </returns>
		public List<DocumentViewModel> GetAllDocuments()
		{
            var documentModels = this.documentService.GetAllDocumentModels();
			var documentViewModels = AutoMapper.Mapper.Map<List<DocumentViewModel>>(documentModels);
			return documentViewModels;
		}

		/// <summary>
		/// Gets the document by id.
		/// </summary>
		/// <param name="documentId">The document's id.</param>
		/// <returns>
		/// The document view model.
		/// </returns>
		public DocumentViewModel Get(Guid documentId)
		{
            var documentModel = this.documentService.GetDocumentModelById(documentId);
			var documentViewModel = AutoMapper.Mapper.Map<DocumentViewModel>(documentModel);
			return documentViewModel;
		}
	}
}