
using System.Collections.Generic;

namespace DDD.Domain.Interfaces.Services.Base
{
	public interface IServiceBase<TEntity> where TEntity : class
	{
		void SetContext(string conn);
		void Add(TEntity obj);
		TEntity GetById(int id);
		IEnumerable<TEntity> GetAll();
		void Update(TEntity obj);
		void Remove(TEntity obj);
		void Dispose();
	}
}
