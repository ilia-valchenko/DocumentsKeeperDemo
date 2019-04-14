using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;
using AutoMapper;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Core.Infrastructure;
using DocumentsKeeperDemo.Core.Exceptions;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Core.Enums;

namespace DocumentsKeeperDemo.Services.Services
{
    /// <summary>
    /// The field service.
    /// </summary>
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository fieldRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldService"/> class.
        /// </summary>
        /// <param name="fieldRepository">The field repository.</param>
        public FieldService(IFieldRepository fieldRepository)
        {
            this.fieldRepository = fieldRepository;
        }

        public IEnumerable<FieldModel> GetLiteFields(Guid folderId)
        {
            if (folderId == Guid.Empty)
            {
                return null;
            }

            var liteFolderEntities = this.fieldRepository
                .GetLiteFields(f => f.FolderId == folderId.ToNonDashedString());

            return Mapper.Map<IEnumerable<FieldModel>>(liteFolderEntities);
        }

        public FieldModel CreateField(FieldModel field)
        {
            this.ValidateField(field);

            field.Id = Guid.NewGuid();
            field.Name = field.DisplayName.RemoveSpaces();

            var fieldEntity = Mapper.Map<FieldEntity>(field);
            var createdFieldEntity = this.fieldRepository.CreateField(fieldEntity);
            var createdFieldModel = Mapper.Map<FieldModel>(createdFieldEntity);

            return createdFieldModel;
        }

        public void DeleteField(Guid fieldId)
        {
            this.fieldRepository.DeleteField(fieldId);
        }

        public IEnumerable<FieldModel> CreateSystemFieldsForFolder(Guid folderId)
        {
            return new List<FieldModel>
            {
                new FieldModel
                {
                    Id = Guid.NewGuid(),
                    Name = SystemField.FileName.ToStringValue().RemoveSpaces(),
                    DisplayName = SystemField.FileName.ToStringValue(),
                    DataType = FieldDataType.STRING,
                    FolderId = folderId,
                    IsMultipleValue = false,
                },
                new FieldModel
                {
                    Id = Guid.NewGuid(),
                    Name = SystemField.FileText.ToStringValue().RemoveSpaces(),
                    DisplayName = SystemField.FileText.ToStringValue(),
                    DataType = FieldDataType.STRING,
                    FolderId = folderId,
                    IsMultipleValue = false
                }
            };
        }

        private void ValidateField(FieldModel field)
        {
            Guard.ArgumentNotNull(field, nameof(field));

            if (field.FolderId == Guid.Empty)
            {
                throw new InvalidFieldException("FolderId is not specified.");
            }

            if (string.IsNullOrWhiteSpace(field.DisplayName))
            {
                throw new InvalidFieldException("The name of the field is empty.");
            }
        }
    }
}
