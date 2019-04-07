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
		FieldValueEntity GetFieldValue(Expression<Func<FieldValueEntity, bool>> predicate);

		/// <summary>
		/// Gets the collection of instances of the <see cref="FieldValueEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// The collection of instances of the <see cref="FieldValueEntity"/> class.
		/// </returns>
		IEnumerable<FieldValueEntity> GetFieldValues(
            Expression<Func<FieldValueEntity, bool>> predicate);

        /// <summary>
        /// Gets lite field value entitie by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>
        /// Returns the lite field value entity that satisfy
        /// predicate conditions.
        /// </returns>
        FieldValueLiteEntity GetLiteFieldValue(
            Expression<Func<FieldValueLiteEntity, bool>> predicate);

        /// <summary>
        /// Gets a collection of field value lite entities that satisfy
        /// predicate conditions.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        IEnumerable<FieldValueLiteEntity> GetLiteFieldValues(
            Expression<Func<FieldValueLiteEntity, bool>> predicate);
	}
}
