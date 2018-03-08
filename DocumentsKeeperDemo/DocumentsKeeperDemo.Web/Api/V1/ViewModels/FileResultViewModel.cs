using System;
using System.Collections.Generic;

namespace DocumentsKeeperDemo.Web.Api.V1.ViewModels
{
	/// <summary>
	/// The file result view model.
	/// </summary>
	public sealed class FileResultViewModel
	{
		/// <summary>
		/// The file names.
		/// </summary>
		public IEnumerable<string> FileNames { get; set; }

		/// <summary>
		/// The description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The created timestamp.
		/// </summary>
		public DateTime CreatedTimestamp { get; set; }

		/// <summary>
		/// The updated timestamp.
		/// </summary>
		public DateTime UpdatedTimestamp { get; set; }

		/// <summary>
		/// The download link.
		/// </summary>
		public string DownloadLink { get; set; }

		/// <summary>
		/// The content types.
		/// </summary>
		public IEnumerable<string> ContentTypes { get; set; }

		/// <summary>
		/// The names.
		/// </summary>
		public IEnumerable<string> Names { get; set; }
	}
}