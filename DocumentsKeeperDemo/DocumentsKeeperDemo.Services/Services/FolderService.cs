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
        /// The field service.
        /// </summary>
        private readonly IFieldService fieldService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FolderService"/> class.
        /// </summary>
        /// <param name="fieldService">The field service.</param>
        /// <param name="folderRepository">The folder repository.</param>
        public FolderService(
            IFieldService fieldService,
            IFolderRepository folderRepository)
        {
            this.folderRepository = folderRepository;
            this.fieldService = fieldService;
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
        public IEnumerable<FolderModel> GetAllFolders()
        {
            var folderEntities = this.folderRepository.GetAllFolders();
            var folderModels = Mapper.Map<IEnumerable<FolderModel>>(folderEntities);

            return folderModels;
        }

        /// <summary>
        /// Gets all folder lite models.
        /// </summary>
        /// <returns>
        /// Returns the collection of folder lite models.
        /// </returns>
        public IEnumerable<FolderModel> GetAllLiteFolders()
        {
            var folderLiteEntities = this.folderRepository.GetAllLiteFolders();
            var folderLiteModels = Mapper.Map<IEnumerable<FolderModel>>(folderLiteEntities);

            return folderLiteModels;
        }

        /// <summary>
        /// Creates folder.
        /// </summary>
        /// <param name="createFolderModel">The create folder model.</param>
        public FolderModel CreateFolder(CreateFolderModel createFolderModel)
        {
            Guard.ArgumentNotNull(createFolderModel, nameof(createFolderModel));

            if (string.IsNullOrWhiteSpace(createFolderModel.FolderName))
            {
                throw new FolderNameIsNotSpecifiedException("Cannot create folder. The name was not specified.");
            }

            var folderModel = new FolderModel
            {
                Id = Guid.NewGuid(),
                Name = createFolderModel.FolderName,
                CreatedDate = DateTime.Now,
                LastModified = DateTime.Now
            };

            folderModel.Fields = this.fieldService.CreateSystemFieldsForFolder(folderModel.Id);

            // Associate the fields with the folder.
            foreach (var field in folderModel.Fields)
            {
                field.Folder = folderModel;
            }

            var folderEntity = Mapper.Map<FolderEntity>(folderModel);
            var createdFolderEntity = this.folderRepository.CreateFolder(folderEntity);
            var createdFolderModel = Mapper.Map<FolderModel>(createdFolderEntity);

            return createdFolderModel;
        }

        /// <summary>
        /// Removes folder by folder id.
        /// </summary>
        public void DeleteFolder(Guid folderId)
        {
            if (folderId == Guid.Empty)
            {
                return;
            }

            this.folderRepository.DeleteFolder(folderId.ToNonDashedString());
        }
    }
}