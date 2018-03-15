using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DocumentsKeeperDemo.Core.Enums;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;

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
		/// Initializes a new instance of the <see cref="UploadController"/> class.
		/// </summary>
		/// <param name="documentService"></param>
		public UploadController(IDocumentService documentService)
		{
			this.documentService = documentService;
		}

		/// <summary>
		/// Upload single file on the server.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public async Task<FileResultViewModel> UploadSingleFile()
		{
			// TODO: Add exception handling.

			var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);
			await this.Request.Content.ReadAsMultipartAsync(streamProvider);

			var fileResult = new FileResultViewModel
			{
				FileNames = streamProvider.FileData.Select(entry => entry.LocalFileName),
				Names = streamProvider.FileData.Select(entry => entry.Headers.ContentDisposition.FileName),
				ContentTypes = streamProvider.FileData.Select(entry => entry.Headers.ContentType.MediaType),
				Description = streamProvider.FormData["description"],
				CreatedTimestamp = DateTime.UtcNow,
				UpdatedTimestamp = DateTime.UtcNow,
				DownloadLink = "TODO, will implement when file is persisited"
			};

			var fileType = fileResult.ContentTypes.First();

			if (fileType == FileType.TXT.ToStringValue())
			{
				// TODO: Parse as .txt file.

				var fileModel = AutoMapper.Mapper.Map<FileResultModel>(fileResult);
				//this.documentService.
			}

			if (fileType == FileType.DOC.ToStringValue())
			{
				// TODO: Parse as .doc file.
			}

			if (fileType == FileType.DOCX.ToStringValue())
			{
				// TODO: Parse as .docx file.
			}

			if (fileType == FileType.PDF.ToStringValue())
			{
				// TODO: Parse as .pdf file.
			}

			if (fileType == FileType.ODT.ToStringValue())
			{
				// TODO: Parse as .odt file.
			}

			if (fileType == FileType.RTF.ToStringValue())
			{
				// TODO: Parse as .rtf file.
			}

			if (fileType == FileType.TEX.ToStringValue())
			{
				// TODO: Parse as .tex file.
			}

			return fileResult;
		}
	}
}