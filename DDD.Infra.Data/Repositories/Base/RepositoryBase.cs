using DDD.Domain.Interfaces.Repositories.Base;
using DDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DDD.Infra.Data.Repositories.Base
{
	public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
	{
		protected DDDContext ctx;
		public RepositoryBase()
		{
			ctx = new DDDContext();
		}
		public void Add(TEntity obj)
		{
			ctx.Set<TEntity>().Add(obj);
			ctx.SaveChanges();
		}		

		public IEnumerable<TEntity> GetAll()
		{
			return ctx.Set<TEntity>().ToList();
		}

		public TEntity GetById(int id)
		{
			return ctx.Set<TEntity>().Find(id);
		}

		public void Remove(TEntity obj)
		{
			ctx.Set<TEntity>().Remove(obj);
			ctx.SaveChanges();
		}

		public void Update(TEntity obj)
		{			
			ctx.Entry(obj).State = EntityState.Modified;
			ctx.SaveChanges();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public void SetContext(string conn)
		{
			ctx = new DDDContext(conn);
		}
	}
}
