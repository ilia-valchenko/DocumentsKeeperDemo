using System;

namespace DocumentsKeeperDemo.Services.Models
{
	/// <summary>
	/// The file result model class.
	/// </summary>
	public sealed class FileResultModel
	{
		/// <summary>
		/// The name of a file.
		/// </summary>
		public string FileName { get; set; }

		/// <summary>
		/// The name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The content type.
		/// </summary>
		public string ContentType { get; set; }

		/// <summary>
		/// The description of a file.
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
	}
}
