using System;
using AutoMapper;
using DocumentsKeeperDemo.Core.Enums;
using DocumentsKeeperDemo.Core.Repositories.Entities;
using DocumentsKeeperDemo.Services.Models;

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
			this.CreateMap<DocumentEntity, DocumentModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
				.ForMember(dest => dest.MimeType, opt => opt.MapFrom(x => Enum.Parse(typeof(MimeType), x.MimeType)));

			this.CreateMap<FieldEntity, FieldModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)))
				.ForMember(dest => dest.DataType, opt => opt.MapFrom(x => Enum.Parse(typeof(FieldDataType), x.DataType)));

			this.CreateMap<FieldValueEntity, FieldValueModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)));

			this.CreateMap<FolderEntity, FolderModel>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.Parse(x.Id)));
		}
	}
}
