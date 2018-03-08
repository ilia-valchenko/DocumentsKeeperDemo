﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace DocumentsKeeperDemo.Repositories.Repositories
{
	/// <summary>
	/// The document repository.
	/// </summary>
	class DocumentRepository : IDocumentRepository
	{
		/// <summary>
		/// The session factory.
		/// </summary>
		private readonly ISessionFactory sessionFactory;

		/// <summary>
		/// Initializes a new instance of the <see cref="DocumentRepository"/> class.
		/// </summary>
		/// <param name="sessionFactory">The session factory.</param>
		public DocumentRepository(ISessionFactory sessionFactory)
		{
			this.sessionFactory = sessionFactory;
		}

		/// <summary>
		/// Get all document entities.
		/// </summary>
		/// <returns></returns>
		public List<DocumentEntity> GetAllDocumentEntities()
		{
			using (var session = this.sessionFactory.OpenSession())
			{
				var documentEntities = session.Query<DocumentEntity>().ToList();

				foreach (var entity in documentEntities)
				{
					NHibernateUtil.Initialize(entity.Folder);
					NHibernateUtil.Initialize(entity.FieldValues);
				}

				return documentEntities;
			}
		}

		/// <summary>
		/// Gets the instance of the <see cref="DocumentEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// Returns the instance of the <see cref="DocumentEntity"/> class.
		/// </returns>
		public DocumentEntity GetDocumentEntity(Expression<Func<DocumentEntity, bool>> predicate)
		{
			using (var session = this.sessionFactory.OpenSession())
			{
				var documentEntity = session.Query<DocumentEntity>().FirstOrDefault(predicate);

				if (documentEntity != null)
				{
					NHibernateUtil.Initialize(documentEntity.Folder);
					NHibernateUtil.Initialize(documentEntity.FieldValues);
				}

				return documentEntity;
			}
		}

		/// <summary>
		/// Gets the collection of instances of the <see cref="DocumentEntity"/> class.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>
		/// The collection of instances of the <see cref="DocumentEntity"/> class.
		/// </returns>
		public List<DocumentEntity> GetDocumentEntities(Expression<Func<DocumentEntity, bool>> predicate)
		{
			throw new NotImplementedException();
		}
	}
}