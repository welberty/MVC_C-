
using System.Collections.Generic;

namespace DDD.Domain.Interfaces.Repositories.Base
{
	public interface IRepositoryBase<TEntity> where TEntity : class
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
