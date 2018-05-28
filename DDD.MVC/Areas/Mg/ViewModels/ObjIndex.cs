

using System;
using System.Collections.Generic;

namespace DDD.MVC.Areas.Mg.ViewModels
{
	public class ObjIndex
	{
		public string Cpf { get; set; }
		public DateTime? BirthDay { get; set; }
		public IEnumerable<ClientViewModel> Clients { get; set; }
	}
}