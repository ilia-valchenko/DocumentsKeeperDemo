using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Services.Interfaces
{
	/// <summary>
	/// The document service interface.
	/// </summary>
	public interface IDocumentService
	{
		/// <summary>
		/// Gets all document models.
		/// </summary>
		/// <returns></returns>
		List<DocumentModel> GetAllDocumentModels();

			/// <summary>
		/// Gets the document by id.
		/// </summary>
		/// <param name="documentId">The document's id.</param>
		/// <returns>
		/// The document model.
		/// </returns>
		DocumentModel GetDocumentModelById(Guid documentId);
	}
}
