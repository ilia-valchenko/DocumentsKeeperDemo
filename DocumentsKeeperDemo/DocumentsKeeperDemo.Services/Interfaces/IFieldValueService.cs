using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Services.Models;

namespace DocumentsKeeperDemo.Services.Interfaces
{
    /// <summary>
    /// The field value service interface.
    /// </summary>
    public interface IFieldValueService
    {
        FieldValueModel GetFieldValue(Guid fieldValueId);

        IEnumerable<FieldValueModel> GetFieldValues(Guid fieldId);

        FieldValueModel GetLiteFieldValue(Guid fieldValueId);

        IEnumerable<FieldValueModel> GetLiteFieldValues(Guid fieldId);
    }
}
