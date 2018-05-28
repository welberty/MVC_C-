
using AutoMapper;
using DDD.Domain.Models;


namespace DDD.MVC.AutoMapper
{
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			this.CreateMap<Client, DDD.MVC.Areas.Mg.ViewModels.ClientViewModel>();
			this.CreateMap<Phone, DDD.MVC.Areas.Mg.ViewModels.PhoneViewModel>();

			this.CreateMap<Client, DDD.MVC.Areas.Sp.ViewModels.ClientViewModel>();
			this.CreateMap<Phone, DDD.MVC.Areas.Sp.ViewModels.PhoneViewModel>();
		}
	}
}