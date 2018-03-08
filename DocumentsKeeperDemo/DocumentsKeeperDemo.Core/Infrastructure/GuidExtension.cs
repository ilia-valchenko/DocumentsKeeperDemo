using System;

namespace DocumentsKeeperDemo.Core.Infrastructure
{
	/// <summary>
	/// The guid extension class.
	/// </summary>
	public static class GuidExtension
	{
		/// <summary>
		/// Converts guid to non dashed string
		/// </summary>
		/// <param name="guid">The guid.</param>
		/// <returns>
		/// The non dahsed string representation of the guid.
		/// </returns>
		public static string ToNonDashedString(this Guid guid) => guid.ToString().Replace("-", "");
	}
}
