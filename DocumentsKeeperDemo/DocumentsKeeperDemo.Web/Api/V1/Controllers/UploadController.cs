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
        private const string ServerUploadFolder = "C:\\Temp";

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

        [HttpPost]
        public async Task<FileResultModel> UploadFile(Guid folderId)
        {
            var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
            await Request.Content.ReadAsMultipartAsync(streamProvider);

            var fileResult = new FileResultModel
            {
                FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
                Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
                ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
                Description = streamProvider.FormData["description"],
                CreatedTimestamp = DateTime.UtcNow,
                UpdatedTimestamp = DateTime.UtcNow,
                DownloadLink = "TODO, will implement when file is persisited",
                FileSizes = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.Size)
            };

            this.documentService.InsertDocuments(folderId, fileResult);

            return fileResult;

            // ----------------------------------------------

            //int iUploadedCnt = 0;

            //// DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            //string sPath = "";
            //sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/locker/");

            //System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;

            //// CHECK THE FILE COUNT.
            //for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            //{
            //    System.Web.HttpPostedFile hpf = hfc[iCnt];

            //    if (hpf.ContentLength > 0)
            //    {
            //        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
            //        if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
            //        {
            //            // SAVE THE FILES IN THE FOLDER.
            //            hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
            //            iUploadedCnt = iUploadedCnt + 1;
            //        }
            //    }
            //}

            //// RETURN A MESSAGE.
            //if (iUploadedCnt > 0)
            //{
            //    return iUploadedCnt + " Files Uploaded Successfully";
            //}
            //else
            //{
            //    return "Upload Failed";
            //}




        }
    }
}