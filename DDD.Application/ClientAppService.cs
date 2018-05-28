
using DDD.Application.Base;
using DDD.Application.Interfaces;
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Models;

namespace DDD.Application
{
	public class ClientAppService: AppServiceBase<Client>, IClientAppService
	{
		private readonly IClientService _clientService;
		public ClientAppService(IClientService clientService):base(clientService)
		{
			_clientService = clientService;
		}
	}
}
