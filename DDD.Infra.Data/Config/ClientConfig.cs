using DDD.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace DDD.Infra.Data.Config
{
	public class ClientConfig:EntityTypeConfiguration<Client>
	{
		public ClientConfig(string databaseName)
		{
			Property(c => c.Name)
				.IsRequired()
				.HasMaxLength(150);
			
			if(databaseName == "ExemploClientesMG"){
				Property(c => c.RG)
					.IsRequired();
			}

			HasMany(c => c.Phones)
			.WithOptional()
			.WillCascadeOnDelete(true);
			
		}

	}
}
