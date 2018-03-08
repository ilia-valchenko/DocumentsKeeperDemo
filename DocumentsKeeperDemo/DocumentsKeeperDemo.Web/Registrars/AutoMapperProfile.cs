using AutoMapper;
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
			this.CreateMap<DocumentModel, DocumentViewModel>();
			this.CreateMap<FieldModel, FieldViewModel>();
			this.CreateMap<FieldViewModel, FieldValueViewModel>();
			this.CreateMap<FolderModel, FolderViewModel>();
		}
	}
}