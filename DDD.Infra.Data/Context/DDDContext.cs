
using DDD.Domain.Models;
using DDD.Infra.Data.Config;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DDD.Infra.Data.Context
{
	public class DDDContext:DbContext
	{
		public DDDContext():base("ExemploClientes")
		{

		}
		public DDDContext(string conn) : base(conn)
		{
			
		}
		public DbSet<Client> Clients { get; set; }
		public DbSet<Phone> Phones { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			//modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Properties<string>()
				.Configure(p => p.HasColumnType("varchar"));
			modelBuilder.Properties<string>()
							.Configure(p => p.HasMaxLength(100));
			var conn = this.Database.Connection;
			
			modelBuilder.Configurations.Add(new ClientConfig(conn.Database));
			modelBuilder.Configurations.Add(new PhoneConfig());			
		}

		public override int SaveChanges()
		{
			foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("InsertedAt") != null))
			{
				if(entry.State == EntityState.Added)
				{
					entry.Property("InsertedAt").CurrentValue = DateTime.Now;
				}
				if (entry.State == EntityState.Modified)
				{
					entry.Property("InsertedAt").IsModified = false;
				}
			}
			return base.SaveChanges();
		}
	}
}
