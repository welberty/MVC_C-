
using DDD.Domain.Models;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace DDD.Infra.Data.Config
{
	public class PhoneConfig: EntityTypeConfiguration<Phone>
	{
		public PhoneConfig()
		{
			//modelBuilder.Entity<Phone>()
			HasOptional(p => p.Client)
			.WithMany(c => c.Phones)
			.HasForeignKey(p => p.ClientId);
		}
	}
}
