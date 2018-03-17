using DocumentsKeeperDemo.Core.Infrastructure;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace DocumentsKeeperDemo.Web.Filters
{
    /// <summary>
    /// The application exception filter attribute.
    /// </summary>
    public sealed class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// The overrided on exception method.
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            ApplicationLogger.LogError(actionExecutedContext.Exception);

            if(actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                return;
            }
            else if(actionExecutedContext.Exception is ArgumentNullException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else if(actionExecutedContext.Exception is ArgumentException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else if(actionExecutedContext.Exception is NullReferenceException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            else if(actionExecutedContext.Exception is IndexOutOfRangeException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }

            // Another types of an exception.
            else
            {
                base.OnException(actionExecutedContext);
            }
        }
    }
}