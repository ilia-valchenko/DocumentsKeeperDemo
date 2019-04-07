using DocumentsKeeperDemo.Services.Interfaces;
using System.Web.Http;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers
{
    /// <summary>
    /// The field values controller.
    /// </summary>
    public class FieldValuesController : ApiController
    {
        private readonly IFieldValueService fieldValueService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValuesController"/> class.
        /// </summary>
        /// <param name="fieldValueService">The field value service.</param>
        public FieldValuesController(IFieldValueService fieldValueService)
        {
            this.fieldValueService = fieldValueService;
        }
    }
}
