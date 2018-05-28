
using System.ComponentModel.DataAnnotations;

namespace DDD.MVC.Areas.Sp.ViewModels
{
	public class PhoneViewModel
	{
		[Key]
		public int PhoneId { get; set; }		
		public string Number { get; set; }
		public int ClientId { get; set; }
		public virtual ClientViewModel Client { get; set; }
	}
}