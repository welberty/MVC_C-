
using DDD.MVC.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD.MVC.ViewModels
{
	public class ClientViewModel
	{
		[Key]
		public int ClientId { get; set; }
		[Required(ErrorMessage ="Nome requerido.")]
		[MaxLength(150, ErrorMessage ="Máximo de caracteres: {0}")]
		public string Name { get; set; }
		[InputMask("999.999.999-99")]
		public string Cpf { get; set; }
		public string RG { get; set; }
		public DateTime BirthDay { get; set; }
		[ScaffoldColumn(false)]
		public DateTime InsertedAt { get; set; }
		public virtual IEnumerable<PhoneViewModel> Phones { get; set; }
	}
}