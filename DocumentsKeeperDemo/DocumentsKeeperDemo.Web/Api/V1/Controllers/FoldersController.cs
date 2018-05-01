using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;

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
        /// <param name="folderId">The folder id.</param>
        /// <returns>
        /// Returns folder lite view model.
        /// </returns>
        public FolderViewModel GetLiteFolder(Guid folderId)
        {
            var folderLiteModel = this.folderService.GetLiteFolder(folderId);
            var folderLiteViewModel = Mapper.Map<FolderViewModel>(folderLiteModel);

            return folderLiteViewModel;
        }

        /// <summary>
        /// Gets the collection of the folder view models. 
        /// </summary>
        /// <returns>
        /// Returns the collection of the folder view models.
        /// </returns>
        public List<FolderViewModel> GetAllFolders()
        {
            var folderModels = this.folderService.GetAllFolders();
            var folderViewModels = Mapper.Map<List<FolderViewModel>>(folderModels);

            return folderViewModels;
        }

        /// <summary>
        /// Gets all folder lite view models.
        /// </summary>
        /// <returns>
        /// Returns the collection of folder lite view models.
        /// </returns>
        public List<FolderViewModel> GetAllLiteFolders()
        {
            var folderLiteModels = this.folderService.GetAllLiteFolders();
            var folderLiteViewModels = Mapper.Map<List<FolderViewModel>>(folderLiteModels);

            return folderLiteViewModels;
        }

        /// <summary>
        /// Creates new folder. 
        /// </summary>
        /// <param name="folderName">The name of the folder.</param>
        /// <returns>
        /// Returns the <see cref="HttpResponseMessage"/> class.
        /// </returns>
        [HttpPost]
        public HttpResponseMessage PostCreateFolder([FromBody] string folderName)
        {
            this.folderService.CreateFolder(folderName);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
