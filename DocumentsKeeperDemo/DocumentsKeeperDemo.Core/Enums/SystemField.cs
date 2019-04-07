using DocumentsKeeperDemo.Core.Attributes;

namespace DocumentsKeeperDemo.Core.Enums
{
    public enum SystemField
    {
        [Text("FileName")]
        FileName = 0,

        [Text("DocumentText")]
        DocumentText = 1
    }
}
