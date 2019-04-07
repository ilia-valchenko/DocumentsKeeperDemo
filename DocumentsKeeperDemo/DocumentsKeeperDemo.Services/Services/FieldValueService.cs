using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Core.Extensions;
using AutoMapper;

namespace DocumentsKeeperDemo.Services.Services
{
    /// <summary>
    /// The field value service.
    /// </summary>
    public class FieldValueService : IFieldValueService
    {
        private readonly IFieldValueRepository fieldValueRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldValueService"/> class.
        /// </summary>
        /// <param name="fieldValueRepository">The field value repository.</param>
        public FieldValueService(IFieldValueRepository fieldValueRepository)
        {
            this.fieldValueRepository = fieldValueRepository;
        }

        public FieldValueModel GetFieldValue(Guid fieldValueId)
        {
            var fieldValueEntity = this.fieldValueRepository
                .GetFieldValue(f => f.Id == fieldValueId.ToNonDashedString());

            var fieldValueModel = Mapper.Map<FieldValueModel>(fieldValueEntity);

            return fieldValueModel;
        }

        public IEnumerable<FieldValueModel> GetFieldValues(Guid fieldId)
        {
            var fieldValueEntities = this.fieldValueRepository
                .GetFieldValues(f => f.Field.Id == fieldId.ToNonDashedString());

            var fieldValueModels = Mapper.Map<IEnumerable<FieldValueModel>>(fieldValueEntities);

            return fieldValueModels;
        }

        public FieldValueModel GetLiteFieldValue(Guid fieldValueId)
        {
            var liteFieldValueEntity = this.fieldValueRepository
                .GetLiteFieldValue(f => f.Id == fieldValueId.ToNonDashedString());

            var liteFieldValueModel = Mapper.Map<FieldValueModel>(liteFieldValueEntity);

            return liteFieldValueModel;
        }

        public IEnumerable<FieldValueModel> GetLiteFieldValues(Guid fieldId)
        {
            var liteFieldValueEntities = this.fieldValueRepository
                .GetLiteFieldValues(f => f.FieldId == fieldId.ToNonDashedString());

            var liteFieldValueModels = Mapper.Map<IEnumerable<FieldValueModel>>(liteFieldValueEntities);

            return liteFieldValueModels;
        }
    }
}