using DocumentsKeeperDemo.Core.Attributes;

namespace DocumentsKeeperDemo.Core.Enums
{
    /// <summary>
    /// The system fields. Each file have to contain all of these fields.
    /// </summary>
    public enum SystemField
    {
        [Text("File Name")]
        FileName = 0,

        [Text("File Text")]
        FileText = 1
    }
}