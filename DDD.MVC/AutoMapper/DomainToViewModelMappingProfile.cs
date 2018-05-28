
using AutoMapper;
using DDD.Domain.Models;


namespace DDD.MVC.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			this.CreateMap<DDD.MVC.Areas.Mg.ViewModels.ClientViewModel, Client>();
			this.CreateMap<DDD.MVC.Areas.Mg.ViewModels.PhoneViewModel, Phone>();

			this.CreateMap<DDD.MVC.Areas.Sp.ViewModels.ClientViewModel, Client>();
			this.CreateMap<DDD.MVC.Areas.Sp.ViewModels.PhoneViewModel, Phone>();
		}
	}
}