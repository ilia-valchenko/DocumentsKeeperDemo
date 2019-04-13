using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers
{
    /// <summary>
    /// The folders controller.
    /// </summary>
    public sealed class FoldersController : ApiController
    {
        /// <summary>
        /// The folder service.
        /// </summary>
        private readonly IFolderService folderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoldersController"/> class.
        /// </summary>
        /// <param name="folderService">The folder service.</param>
        public FoldersController(IFolderService folderService)
        {
            this.folderService = folderService;
        }

        /// <summary>
        /// Gets folder lite view model.
        /// </summary>
        /// <param name="id">The folder id.</param>
        /// <returns>
        /// Returns folder lite view model.
        /// </returns>
        public FolderViewModel GetLiteFolder(Guid id)
        {
            var folderLiteModel = this.folderService.GetLiteFolder(id);
            var folderLiteViewModel = Mapper.Map<FolderViewModel>(folderLiteModel);

            return folderLiteViewModel;
        }

        /// <summary>
        /// Gets the collection of the folder view models. 
        /// </summary>
        /// <returns>
        /// Returns the collection of the folder view models.
        /// </returns>
        public IEnumerable<FolderViewModel> GetAllFolders()
        {
            var folderModels = this.folderService.GetAllFolders();
            var folderViewModels = Mapper.Map<List<FolderViewModel>>(folderModels);

            return folderViewModels;
        }

        /// <summary>
        /// Gets folder by folder id.
        /// </summary>
        /// <param name="id">The id of the folder.</param>
        public FolderViewModel GetFolderById(Guid id)
        {
            var folderModel = this.folderService.GetFolder(id);
            var folderViewModel = Mapper.Map<FolderViewModel>(folderModel);

            return folderViewModel;
        }

        /// <summary>
        /// Gets all folder lite view models.
        /// </summary>
        /// <returns>
        /// Returns the collection of folder lite view models.
        /// </returns>
        public IEnumerable<FolderModel> GetAllLiteFolders()
        {
            var folderLiteModels = this.folderService.GetAllLiteFolders();

            return folderLiteModels;
        }

        /// <summary>
        /// Creates new folder. 
        /// </summary>
        /// <param name="createFolderModel">The crete folder model.</param>
        /// <returns>
        /// Returns the <see cref="HttpResponseMessage"/> class.
        /// </returns>
        [HttpPost]
        public HttpResponseMessage CreateFolder(CreateFolderModel createFolderModel)
        {
            var createdFolder = this.folderService.CreateFolder(createFolderModel);
            return Request.CreateResponse(HttpStatusCode.Created, createdFolder);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteFolder(Guid id)
        {
            this.folderService.DeleteFolder(id);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
