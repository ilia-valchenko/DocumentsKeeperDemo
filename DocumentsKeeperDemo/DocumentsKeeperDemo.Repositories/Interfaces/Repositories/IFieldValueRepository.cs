using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DocumentsKeeperDemo.Core.Repositories.Entities;

namespace DocumentsKeeperDemo.Repositories.Interfaces.Repositories
{
	/// <summary>
	/// The field value repository interface.
	/// </summary>
	public interface IFieldValueRepository
	{
		/// <summary>
		/// Gets the instance of the <see cref="FieldValueEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// The instance of the <see cref="FieldValueEntity"/> class.
		/// </returns>
		FieldValueEntity GetFieldValueEntity(Expression<Func<FieldValueEntity, bool>> predicate);

		/// <summary>
		/// Gets the collection of instances of the <see cref="FieldValueEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// The collection of instances of the <see cref="FieldValueEntity"/> class.
		/// </returns>
		List<FieldValueEntity> GetFieldValueEntities(Expression<Func<FieldValueEntity, bool>> predicate);
	}
}
