using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Services.Interfaces
{
    public interface IFieldService
    {
        IEnumerable<FieldModel> GetLiteFields(Guid folderId);

        FieldModel CreateField(FieldModel field);

        void DeleteField(Guid fieldId);
    }
}
