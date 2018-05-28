
using System.ComponentModel.DataAnnotations;

namespace DDD.MVC.ViewModels
{
	public class PhoneViewModel
	{
		[Key]
		public int PhoneId { get; set; }		
		public string Number { get; set; }
		public virtual ClientViewModel Client { get; set; }
	}
}