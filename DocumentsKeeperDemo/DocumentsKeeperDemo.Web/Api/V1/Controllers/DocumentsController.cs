using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers
{
    // TODO: Do not return FileResult. DocumentViewModel should
    // be returned instead.
    public class FileResult
    {
        public IEnumerable<string> FileNames { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public DateTime UpdatedTimestamp { get; set; }
        public string DownloadLink { get; set; }
        public IEnumerable<string> ContentTypes { get; set; }
        public IEnumerable<string> Names { get; set; }
    }

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

        [HttpPost]
        public async Task<FileResult> Post()
        {
            var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
            await Request.Content.ReadAsMultipartAsync(streamProvider);

            return new FileResult
            {
                FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
                Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
                ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
                Description = streamProvider.FormData["description"],
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
                DownloadLink = "TODO, will implement when file is persisited"
            };
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
        /// <param name="documentId">The document's id.</param>
        /// <returns>
        /// The document view model.
        /// </returns>
        [HttpGet]
        public DocumentViewModel GetDocument(Guid documentId)
        {
            var documentModel = this.documentService.GetDocument(documentId);
            var documentViewModel = Mapper.Map<DocumentViewModel>(documentModel);
            return documentViewModel;
        }

        /// <summary>
        /// Gets lite document by id.
        /// </summary>
        /// <param name="documentId">The document id.</param>
        /// <returns>
        /// Returns the document lite model.
        /// </returns>
        [HttpGet]
        public DocumentViewModel GetLiteDocument(Guid documentId)
        {
            var documentLiteModel = this.documentService.GetLiteDocument(documentId);
            var documentLiteViewModel = Mapper.Map<DocumentViewModel>(documentLiteModel);

            return documentLiteViewModel;
        }
    }
}