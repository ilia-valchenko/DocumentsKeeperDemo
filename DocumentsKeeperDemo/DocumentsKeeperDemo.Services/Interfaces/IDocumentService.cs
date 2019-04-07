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
		IEnumerable<DocumentModel> GetAllDocuments();

        /// <summary>
        /// Gets all lite document models.
        /// </summary>
        /// <returns>
        /// Returns the collection of document lite models.
        /// </returns>
	    IEnumerable<DocumentModel> GetAllLiteDocuments();

        /// <summary>
		/// Gets the document by id.
		/// </summary>
		/// <param name="documentId">The document's id.</param>
		/// <returns>
		/// The document model.
		/// </returns>
		DocumentModel GetDocument(Guid documentId);

        /// <summary>
        /// Gets document lite model by id.
        /// </summary>
        /// <param name="documentId">The document id.</param>
        /// <returns>
        /// Returns document lite model.
        /// </returns>
	    DocumentModel GetLiteDocument(Guid documentId);

		/// <summary>
		/// Inserts new document.
		/// </summary>
		/// <param name="documentModel">The document model.</param>
		/// <returns>
		/// The guid of the created document.
		/// </returns>
		Guid InsertDocument(DocumentModel documentModel);

        /// <summary>
        /// Gets all lite documents for the specified folder.
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        IEnumerable<DocumentModel> GetLiteDocumentsByFolderId(Guid folderId);
	}
}