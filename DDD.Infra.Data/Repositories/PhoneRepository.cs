

using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Models;
using DDD.Infra.Data.Repositories.Base;

namespace DDD.Infra.Data.Repositories
{
	public class PhoneRepository: RepositoryBase<Phone>, IPhoneRepository
	{
	}
}
