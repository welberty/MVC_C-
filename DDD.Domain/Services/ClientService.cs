
using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Interfaces.Services;
using DDD.Domain.Models;
using DDD.Domain.Services.Base;

namespace DDD.Domain.Services
{
	public class ClientService: ServiceBase<Client>, IClientService
	{
		private readonly IClientRepository _clientRepository;
		public ClientService(IClientRepository clientRepository):base(clientRepository)
		{
			_clientRepository = clientRepository;
		}
	}
}
