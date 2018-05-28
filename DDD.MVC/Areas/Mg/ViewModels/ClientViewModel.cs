
using DDD.MVC.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DDD.MVC.Areas.Mg.ViewModels
{
	public class ClientViewModel
	{
		[Key]
		public int ClientId { get; set; }
		[Required(ErrorMessage ="Nome requerido.")]
		[MaxLength(150, ErrorMessage ="Máximo de caracteres: {0}")]
		public string Name { get; set; }
		[Required(ErrorMessage ="Cpf requerido.")]
		[CpfAttribute(ErrorMessage ="Cpf inválido.")]
		public string Cpf { get; set; }
		[Required(ErrorMessage ="RG requerido!")]
		public string RG { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime BirthDay { get; set; }
		[ScaffoldColumn(false)]
		public DateTime InsertedAt { get; set; }
		public virtual IEnumerable<PhoneViewModel> Phones { get; set; }
	}
}