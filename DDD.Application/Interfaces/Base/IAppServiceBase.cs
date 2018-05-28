
using System.Collections.Generic;

namespace DDD.Application.Interfaces.Base
{
	public interface IAppServiceBase<TEntity> where TEntity : class
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
