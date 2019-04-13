using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers
{
    /// <summary>
    /// The fields controller.
    /// </summary>
    public class FieldsController : ApiController
    {
        private readonly IFieldService fieldService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldsController"/> class.
        /// </summary>
        /// <param name="fieldService">The field service.</param>
        public FieldsController(IFieldService fieldService)
        {
            this.fieldService = fieldService;
        }

        /// <summary>
        /// Gets lite fields by using folder id.
        /// </summary>
        /// <param name="folderId">The id of the folder.</param>
        [HttpGet]
        public IEnumerable<FieldModel> GetLiteFieldsByFolderId(Guid folderId)
        {
            var liteFields = this.fieldService.GetLiteFields(folderId);

            return liteFields;
        }

        [HttpPost]
        public HttpResponseMessage CreateField(FieldModel field)
        {
            var createdField = this.fieldService.CreateField(field);

            return Request.CreateResponse(HttpStatusCode.Created, createdField);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteField(Guid id)
        {
            this.fieldService.DeleteField(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}