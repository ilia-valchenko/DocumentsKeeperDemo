using DocumentsKeeperDemo.Core.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DocumentsKeeperDemo.Repositories.Interfaces.Repositories
{
	/// <summary>
	/// The document repository.
	/// </summary>
	public interface IDocumentRepository
	{
		/// <summary>
		/// Gets all document entities.
		/// </summary>
		/// <returns></returns>
		List<DocumentEntity> GetAllDocumentEntities();

			/// <summary>
		/// Gets the instance of the <see cref="DocumentEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// Returns the instance of the <see cref="DocumentEntity"/> class.
		/// </returns>
		DocumentEntity GetDocumentEntity(Expression<Func<DocumentEntity, bool>> predicate);

		/// <summary>
		/// Gets the collection of instances of the <see cref="DocumentEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// The collection of instances of the <see cref="DocumentEntity"/> class.
		/// </returns>
		List<DocumentEntity> GetDocumentEntities(Expression<Func<DocumentEntity, bool>> predicate);
	}
}
