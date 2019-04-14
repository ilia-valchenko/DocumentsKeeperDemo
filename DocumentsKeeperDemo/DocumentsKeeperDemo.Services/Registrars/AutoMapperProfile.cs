using System;
using AutoMapper;
using DocumentsKeeperDemo.Core.Enums;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Services.Models;
using DocumentsKeeperDemo.Core.Extensions;

namespace DocumentsKeeperDemo.Services.Registrars
{
	/// <summary>
	/// The service layer AutoMapper profile.
	/// </summary>
	public sealed class AutoMapperProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
		/// </summary>
		public AutoMapperProfile()
		{
            // Document
            this.CreateMap<DocumentEntity, DocumentModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(x => x.FileType.FromTextAttributeStringToEnumValue<FileType>()));

		    this.CreateMap<DocumentModel, DocumentEntity>()
		        .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToNonDashedString()))
		        .ForMember(dest => dest.FileType, opt => opt.MapFrom(x => x.FileType.ToStringValue()));

            this.CreateMap<DocumentLiteEntity, DocumentModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(x => x.FileType.FromTextAttributeStringToEnumValue<FileType>()))
                .ForMember(dest => dest.FolderId, opt => opt.MapFrom(x => Guid.Parse(x.FolderId)));

            // Field
            this.CreateMap<FieldEntity, FieldModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
				.ForMember(dest => dest.DataType, opt => opt.MapFrom(x => Enum.Parse(typeof(FieldDataType), x.DataType)));

            this.CreateMap<FieldLiteEntity, FieldModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
                .ForMember(dest => dest.FolderId, opt => opt.MapFrom(x => Guid.Parse(x.FolderId)));

            this.CreateMap<FieldModel, FieldEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToNonDashedString()))
                .ForMember(dest => dest.FolderId, opt => opt.MapFrom(x => x.FolderId.ToNonDashedString()));

            this.CreateMap<FieldModel, FieldLiteEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToNonDashedString()))
                .ForMember(dest => dest.FolderId, opt => opt.MapFrom(x => x.FolderId.ToNonDashedString()));

            // Field value
            this.CreateMap<FieldValueEntity, FieldValueModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)));

            this.CreateMap<FieldValueLiteEntity, FieldValueModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
                .ForMember(dest => dest.FieldId, opt => opt.MapFrom(x => Guid.Parse(x.FieldId)))
                .ForMember(dest => dest.DocumentId, opt => opt.MapFrom(x => Guid.Parse(x.DocumentId)));

            // Folder
            this.CreateMap<FolderEntity, FolderModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(x => x.ModifiedDate));

            this.CreateMap<FolderModel, FolderEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToNonDashedString()))
                .ForMember(dest => dest.ModifiedDate, opt => opt.MapFrom(x => x.LastModified));

            this.CreateMap<FolderLiteEntity, FolderModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(x => x.ModifiedDate));
        }
	}
}