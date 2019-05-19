using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;
using DocumentsKeeperDemo.Services.Models;

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
        /// <param name="documentService">The document service.</param>
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
        [HttpGet]
        public List<DocumentViewModel> GetAllDocuments()
        {
            var documentModels = this.documentService.GetAllDocuments();
            var documentViewModels = Mapper.Map<List<DocumentViewModel>>(documentModels);
            return documentViewModels;
        }

        /// <summary>
        /// Gets the document by id.
        /// </summary>
        /// <param name="id">The document's id.</param>
        /// <returns>
        /// The document view model.
        /// </returns>
        [HttpGet]
        public DocumentViewModel GetDocument(Guid id)
       {
            var documentModel = this.documentService.GetDocument(id);
            var documentViewModel = Mapper.Map<DocumentViewModel>(documentModel);
            return documentViewModel;
        }

        /// <summary>
        /// Gets lite document by id.
        /// </summary>
        /// <param name="id">The document id.</param>
        /// <returns>
        /// Returns the document lite model.
        /// </returns>
        [HttpGet]
        public DocumentViewModel GetLiteDocument(Guid id)
        {
            var documentLiteModel = this.documentService.GetLiteDocument(id);
            var documentLiteViewModel = Mapper.Map<DocumentViewModel>(documentLiteModel);

            return documentLiteViewModel;
        }

        /// <summary>
        /// Gets the number of the documents that are contained
        /// in the provided folder.
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        /// <returns>Returns the number of the document.</returns>
        [HttpGet]
        public int GetDocumentsCount(Guid folderId)
        {
            int count = this.documentService.GetDocumentsCount(folderId);
            return count;
        }

        /// <summary>
        /// Gets the collection of lite documents that are contained
        /// in the folder.
        /// </summary>
        /// <param name="folderId">The identifier of the folder.</param>
        /// <param name="pageNumber">The number of the page.</param>
        [HttpGet]
        public IEnumerable<DocumentViewModel> GetLiteDocumentsByFolderId(
            Guid folderId,
            int pageNumber)
        {
            var liteDocumentModels = this.documentService
                .GetLiteDocumentsByFolderId(folderId, pageNumber);

            var liteDocumentsViewModels = Mapper
                .Map<IEnumerable<DocumentViewModel>>(liteDocumentModels);

            return liteDocumentsViewModels;
        }

        /// <summary>
        /// Deletes document by document id.
        /// </summary>
        /// <param name="id">The id of the document that have to be removed.</param>
        [HttpDelete]
        public HttpResponseMessage DeleteDocument(Guid id)
        {
            this.documentService.DeleteDocument(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Gets a collection of documents that meet query requirements.
        /// </summary>
        /// <param name="query">The query</param>
        [HttpGet]
        public IEnumerable<DocumentModel> GetDocumentsBySearchQuery(string query)
        {
            var documents = this.documentService.GetDocumentsBySearchQuery(query);
            return documents;
        }
    }
}