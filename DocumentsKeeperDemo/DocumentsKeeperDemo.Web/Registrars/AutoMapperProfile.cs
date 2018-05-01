using AutoMapper;
using DocumentsKeeperDemo.Core.Extensions;
using DocumentsKeeperDemo.Services.Models;
using DocumentsKeeperDemo.Web.Api.V1.ViewModels;

namespace DocumentsKeeperDemo.Web.Registrars
{
	/// <summary>
	/// The AutoMapper profile for presentation layer.
	/// </summary>
	public sealed class AutoMapperProfile : Profile
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
		/// </summary>
		public AutoMapperProfile()
		{
            // Document 
            this.CreateMap<DocumentModel, DocumentViewModel>()
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(x => x.FileType.ToStringValue()));

            // Field 
            this.CreateMap<FieldModel, FieldViewModel>();
			this.CreateMap<FieldViewModel, FieldValueViewModel>();

            // Folder
			this.CreateMap<FolderModel, FolderViewModel>();
		}
	}
}