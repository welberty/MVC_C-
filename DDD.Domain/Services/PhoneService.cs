
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Models;
using DDD.Domain.Services.Base;

namespace DDD.Domain.Services
{
	public class PhoneService: ServiceBase<Phone>, IPhoneService
	{
		private readonly IPhoneRepository _phoneRepository;
		public PhoneService(IPhoneRepository phoneRepository) : base(phoneRepository)
		{
			_phoneRepository = phoneRepository;
		}
	}
}
