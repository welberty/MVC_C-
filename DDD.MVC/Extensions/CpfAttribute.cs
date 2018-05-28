using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DDD.MVC.Extensions
{
	public class CpfAttribute : ValidationAttribute, IClientValidatable
	{
		public CpfAttribute()
		{
			this.ErrorMessage = "The value {0} is invalid for CPF";
		}

		protected override ValidationResult IsValid(
			object value,
			ValidationContext validationContext)
		{
			if (value != null)
			{
				var valueValidLength = 11;
				var maskChars = new[] { ".", "-" };
				var multipliersForFirstDigit = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
				var multipliersForSecondDigit = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

				var mod11 = new Mod11();
				var isValid = Valida(value.ToString());//mod11.IsValid(value.ToString(), valueValidLength, maskChars, multipliersForFirstDigit, multipliersForSecondDigit);

				if (!isValid)
				{
					return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
				}
			}

			return null;
		}

		IEnumerable<ModelClientValidationRule> IClientValidatable.GetClientValidationRules(
			ModelMetadata metadata,
			ControllerContext context)
		{
			var modelClientValidationRule = new ModelClientValidationRule
			{
				ValidationType = "cpf",
				ErrorMessage = this.FormatErrorMessage(metadata.DisplayName)
			};

			return new List<ModelClientValidationRule> { modelClientValidationRule };
		}
		
		public bool Valida(string cpf)

		{

			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

			string tempCpf;

			string digito;

			int soma;

			int resto;

			cpf = cpf.Trim();

			cpf = cpf.Replace(".", "").Replace("-", "");

			if (cpf.Length != 11)

				return false;

			tempCpf = cpf.Substring(0, 9);

			soma = 0;

			for (int i = 0; i < 9; i++)

				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

			resto = soma % 11;

			if (resto < 2)

				resto = 0;

			else

				resto = 11 - resto;

			digito = resto.ToString();

			tempCpf = tempCpf + digito;

			soma = 0;

			for (int i = 0; i < 10; i++)

				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

			resto = soma % 11;

			if (resto < 2)

				resto = 0;

			else

				resto = 11 - resto;

			digito = digito + resto.ToString();

			return cpf.EndsWith(digito);

		}


	}
}