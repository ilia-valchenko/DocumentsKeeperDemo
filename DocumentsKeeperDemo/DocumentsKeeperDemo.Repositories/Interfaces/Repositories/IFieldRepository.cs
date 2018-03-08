using DocumentsKeeperDemo.Core.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DocumentsKeeperDemo.Repositories.Interfaces.Repositories
{
	/// <summary>
	/// The field repository.
	/// </summary>
	public interface IFieldRepository
	{
		/// <summary>
		/// Gets the instance of the <see cref="FieldEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// The instance of the <see cref="FieldEntity"/> class.
		/// </returns>
		FieldEntity GetFieldEntiy(Expression<Func<FieldEntity, bool>> predicate);

		/// <summary>
		/// Gets the collection of instances of the <see cref="FieldEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// The collection of instances of the <see cref="FieldEntity"/> class.
		/// </returns>
		List<FieldEntity> GetFieldEntities(Expression<Func<FieldEntity, bool>> predicate);
	}
}
