using DocumentsKeeperDemo.Core.Attributes;

namespace DocumentsKeeperDemo.Core.Enums
{
    /// <summary>
    /// The file type enumeration.
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// The none value. 
        /// </summary>
        NONE = 0,

        /// <summary>
        /// The plain text.
        /// </summary>
        [Text("text/plain")]
        TXT = 1,

        /// <summary>
        /// The application msword.
        /// </summary>
        [Text("application/msword")]
        DOC = 2,

		/// <summary>
		/// The Microsoft Office Open XML format.
		/// </summary>
		[Text("application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        DOCX = 3,

		/// <summary>
		/// The Portable Document Format.
		/// </summary>
		[Text("application/pdf")]
        PDF = 4,

        ODT = 5,
        RTF = 6,
        TEX = 7
    }
}
