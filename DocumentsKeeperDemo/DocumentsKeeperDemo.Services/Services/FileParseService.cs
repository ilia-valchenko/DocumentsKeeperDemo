using System;
using System.Linq;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;
using DocumentsKeeperDemo.Core.Infrastructure;

namespace DocumentsKeeperDemo.Services.Services
{
    public class FileParseService : IFileParseService
    {
        public DocumentModel ParseFile(FileResultModel fileResult)
        {
            Guard.ArgumentNotNull(fileResult, nameof(fileResult));

            string text = System.IO.File.ReadAllText(fileResult.FileNames.FirstOrDefault());

            throw new NotImplementedException();

            //if (fileType == FileType.TXT.ToStringValue())
            //{
            //    // TODO: Parse as .txt file.
            //}

            //if (fileType == FileType.DOC.ToStringValue())
            //{
            //    // TODO: Parse as .doc file.
            //}

            //if (fileType == FileType.DOCX.ToStringValue())
            //{
            //    // TODO: Parse as .docx file.
            //}

            //if (fileType == FileType.PDF.ToStringValue())
            //{
            //    // TODO: Parse as .pdf file.
            //}

            //if (fileType == FileType.ODT.ToStringValue())
            //{
            //    // TODO: Parse as .odt file.
            //}

            //if (fileType == FileType.RTF.ToStringValue())
            //{
            //    // TODO: Parse as .rtf file.
            //}

            //if (fileType == FileType.TEX.ToStringValue())
            //{
            //    // TODO: Parse as .tex file.
            //}
        }
    }
}
