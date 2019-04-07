using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Services.Interfaces
{
    /// <summary>
    /// The file parse service.
    /// </summary>
    public interface IFileParseService
    {
        DocumentModel ParseFile(FileResultModel fileResult);
    }
}
