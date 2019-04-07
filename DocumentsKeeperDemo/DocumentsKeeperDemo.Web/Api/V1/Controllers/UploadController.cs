using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers
{
	/// <summary>
	/// The upload controller.
	/// </summary>
	public class UploadController : ApiController
	{
		// TODO: Move it to the Web.config file.

		/// <summary>
		/// The server upload folder.
		/// </summary>
		private const string ServerUploadFolder = "~/App_Data/UploadedFiles";

		/// <summary>
		/// The document service.
		/// </summary>
		private readonly IDocumentService documentService;

        /// <summary>
        /// The file parser.
        /// </summary>
        private readonly IFileParseService fileParser;

		/// <summary>
		/// Initializes a new instance of the <see cref="UploadController"/> class.
		/// </summary>
		/// <param name="documentService">The document service.</param>
        /// <param name="fileParser">The file parser.</param>
		public UploadController(
            IDocumentService documentService,
            IFileParseService fileParser)
		{
			this.documentService = documentService;
            this.fileParser = fileParser;
		}

		/// <summary>
		/// Upload single file on the server.
		/// </summary>
		[HttpPost]
		public async Task UploadSingleFile(Guid folderId)
		{
            // TODO: Move folder path to config file.
            //var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
            var streamProvider = new MultipartFormDataStreamProvider(
                "C:/Users/iValc/Downloads/git/DocumentsKeeperDemo/DocumentsKeeperDemo/DocumentsKeeperDemo.Web/App_Data/UploadedFiles");
            await this.Request.Content.ReadAsMultipartAsync(streamProvider);

            var document = this.fileParser.ParseFile(new FileResultModel
            {
                FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
                Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
                ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
                Description = streamProvider.FormData["description"],
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
                DownloadLink = "TODO, will implement when file is persisited"
            });

            document.Folder = new FolderModel { Id = folderId };

            this.documentService.InsertDocument(document);
		}
	}
}