
using DDD.Application.Base;
using DDD.Application.Interfaces;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Models;

namespace DDD.Application
{
	public class PhoneAppService: AppServiceBase<Phone>, IPhoneAppService
	{
		private readonly IPhoneService _phoneService;
		public PhoneAppService(IPhoneService phoneService) : base(phoneService)
		{
			_phoneService = phoneService;
		}
	}
}
