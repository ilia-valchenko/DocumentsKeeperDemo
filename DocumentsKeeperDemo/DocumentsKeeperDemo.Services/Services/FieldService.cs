using System;
using System.Collections.Generic;
using DocumentsKeeperDemo.Repositories.Interfaces.Repositories;
using DocumentsKeeperDemo.Services.Interfaces;
using DocumentsKeeperDemo.Services.Models;
using AutoMapper;
using DocumentsKeeperDemo.Core.Extensions;
using System.Linq;

namespace DocumentsKeeperDemo.Services.Services
{
    public class FieldService : IFieldService
    {
        private readonly IFieldRepository fieldRepository;

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
    }
}
