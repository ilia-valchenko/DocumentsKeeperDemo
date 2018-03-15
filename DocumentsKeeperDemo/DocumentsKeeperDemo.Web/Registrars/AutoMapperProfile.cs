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
            this.CreateMap<DocumentModel, DocumentViewModel>()
                .ForMember(dest => dest.FileType, opt => opt.MapFrom(x => x.FileType.ToStringValue()));

			this.CreateMap<FieldModel, FieldViewModel>();
			this.CreateMap<FieldViewModel, FieldValueViewModel>();
			this.CreateMap<FolderModel, FolderViewModel>();
			this.CreateMap<FileResultViewModel, FileResultModel>();
		}
	}
}