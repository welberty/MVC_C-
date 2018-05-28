

using DDD.Domain.Interfaces.Repositories;
using DDD.Domain.Models;
using DDD.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DDD.Infra.Data.Repositories
{
	public class ClientRepository : RepositoryBase<Client>, IClientRepository
	{
		public IEnumerable<Client> Filter(string name, string cpf, DateTime? birthDay){
			return ctx.Clients.Where(c => 
						(!string.IsNullOrEmpty(name)? c.Name.Contains(name):true) 
						&& (!string.IsNullOrEmpty(cpf) ? c.Cpf == cpf : true) 
						&& (birthDay != null ? c.BirthDay == birthDay : true)
					);
		}
		public void Update(Client obj)
		{		
			var clientToUpdate = ctx.Clients.SingleOrDefault(c => c.ClientId == obj.ClientId);
			clientToUpdate.Phones.Clear();
			foreach (var item in obj.Phones)
			{
				var existingPhone =
				
				ctx.Phones.Add(new Phone
				{
					Number = item.Number,
					Client = item.Client,
					ClientId = item.ClientId
				});
				clientToUpdate.Phones.Add(existingPhone);
			}
			ctx.SaveChanges();
		}
		public void Remove(Client obj)
		{
			var phones = ctx.Phones.Where(p => p.ClientId == obj.ClientId);
			ctx.Phones.RemoveRange(phones);
			ctx.Clients.Remove(obj);
			ctx.SaveChanges();
		}
	}
}
