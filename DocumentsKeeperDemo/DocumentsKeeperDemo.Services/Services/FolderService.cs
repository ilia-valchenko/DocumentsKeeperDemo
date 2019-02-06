﻿using System;
using System.Collections.Generic;
using AutoMapper;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Core.Infrastructure;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Services.Services
{
    /// <summary>
    /// The folder service class.
    /// </summary>
    public sealed class FolderService : IFolderService
    {
        /// <summary>
        /// The folder repository.
        /// </summary>
        private readonly IFolderRepository folderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderService"/> class.
        /// </summary>
        /// <param name="folderRepository">The folder repository.</param>
        public FolderService(IFolderRepository folderRepository)
        {
            this.folderRepository = folderRepository;
        }

        /// <summary>
        /// Gets folder model by id. 
        /// </summary>
        /// <param name="folderGuid">The folder id.</param>
        /// <returns>
        /// Returns the folder model.
        /// </returns>
        public FolderModel GetFolder(Guid folderGuid)
        {
            Guard.NotEmptyGuid(folderGuid, nameof(folderGuid));

            var folderEntity = this.folderRepository.GetFolder(f => f.Id == folderGuid.ToNonDashedString());
            var folderModel = Mapper.Map<FolderModel>(folderEntity);

            return folderModel;
        }

        /// <summary>
        /// Gets folder lite model.
        /// </summary>
        /// <param name="folderId">The folder id.</param>
        /// <returns>
        /// Returns folder lite model.
        /// </returns>
        public FolderModel GetLiteFolder(Guid folderId)
        {
            Guard.NotEmptyGuid(folderId, nameof(folderId));

            var folderLiteEntity = this.folderRepository.GetLiteFolder(f => f.Id == folderId.ToNonDashedString());
            var folderLiteModel = Mapper.Map<FolderModel>(folderLiteEntity);

            return folderLiteModel;
        }

        /// <summary>
        /// Gets all folder models.
        /// </summary>
        /// <returns>
        /// Returns the collection of the folder models.
        /// </returns>
        public List<FolderModel> GetAllFolders()
        {
            var folderEntities = this.folderRepository.GetAllFolders();
            var folderModels = Mapper.Map<List<FolderModel>>(folderEntities);

            return folderModels;
        }

        /// <summary>
        /// Gets all folder lite models.
        /// </summary>
        /// <returns>
        /// Returns the collection of folder lite models.
        /// </returns>
        public List<FolderModel> GetAllLiteFolders()
        {
            var folderLiteEntities = this.folderRepository.GetAllLiteFolders();
            var folderLiteModels = Mapper.Map<List<FolderModel>>(folderLiteEntities);

            return folderLiteModels;
        }

        /// <summary>
        /// Creates folder.
        /// </summary>
        /// <param name="folderName">The name of the folder.</param>
        public void CreateFolder(string folderName)
        {
            if (string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentException("The name of the folder is null or empty.");
            }

            var folderModel = new FolderModel
            {
                Id = Guid.NewGuid(),
                Name = folderName,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now
            };

            var folderEntity = Mapper.Map<FolderEntity>(folderModel);

            this.folderRepository.InsertFolder(folderEntity);
        }
    }
}