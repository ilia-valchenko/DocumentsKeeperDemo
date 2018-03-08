using DocumentsKeeperDemo.Core.Attributes;

namespace DocumentsKeeperDemo.Core.Enums
{
    /// <summary>
    /// The file type enumeration.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// The plain text.
        /// </summary>
        [Text("text/plain")]
        TXT,

        /// <summary>
        /// The application msword.
        /// </summary>
        [Text("application/msword")]
        DOC,

		/// <summary>
		/// The Microsoft Office Open XML format.
		/// </summary>
		[Text("application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        DOCX,

		/// <summary>
		/// The Portable Document Format.
		/// </summary>
		[Text("application/pdf")]
        PDF,

        ODT,
        RTF,
        TEX
    }
}
