
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.Domain.Models
{
	public class Phone
	{
		[Key]
		public int PhoneId { get; set; }
		public string Number { get; set; }
		[ForeignKey("Client")]
		public int? ClientId { get; set; }
		public virtual Client Client { get; set; }
	}
}
