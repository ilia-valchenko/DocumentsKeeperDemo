using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers
{
    /// <summary>
    /// The document controller.
    /// </summary>
    public sealed class DocumentsController : ApiController
    {
        // TODO: Move to config file.
        private const string ServerUploadFolder = "C:\\Temp";

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

        [HttpGet]
        public IEnumerable<DocumentViewModel> GetLiteDocumentsByFolderId(Guid folderId)
        {
            var liteDocumentModels = this.documentService
                .GetLiteDocumentsByFolderId(folderId);

            var liteDocumentsViewModels = Mapper
                .Map<IEnumerable<DocumentViewModel>>(liteDocumentModels);

            return liteDocumentsViewModels;
        }
    }
}