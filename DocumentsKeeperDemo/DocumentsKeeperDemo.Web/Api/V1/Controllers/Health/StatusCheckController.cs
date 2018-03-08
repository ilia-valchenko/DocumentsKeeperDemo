using System.Web.Http;

namespace DocumentsKeeperDemo.Web.Api.V1.Controllers.Health
{
	/// <summary>
	/// The status check controller.
	/// </summary>
	public sealed class StatusCheckController : ApiController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="StatusCheckController"/> class.
		/// </summary>
		public StatusCheckController() { }

		/// <summary>
		/// Gets status.
		/// </summary>
		/// <returns></returns>
		public IHttpActionResult Get()
		{
			return Ok();
		}
	}
}