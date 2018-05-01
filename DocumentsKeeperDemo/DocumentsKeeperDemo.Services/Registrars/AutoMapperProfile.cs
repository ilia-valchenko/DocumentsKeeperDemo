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

            // Field
            this.CreateMap<FieldEntity, FieldModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
				.ForMember(dest => dest.DataType, opt => opt.MapFrom(x => Enum.Parse(typeof(FieldDataType), x.DataType)));

			this.CreateMap<FieldValueEntity, FieldValueModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)));

            // Folder
			this.CreateMap<FolderEntity, FolderModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)));

		    this.CreateMap<FolderModel, FolderEntity>()
		        .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToNonDashedString()));
        }
	}
}
