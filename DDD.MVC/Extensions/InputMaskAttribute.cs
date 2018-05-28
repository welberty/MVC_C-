using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace DDD.MVC.Extensions
{
	public class InputMaskAttribute : Attribute, System.Web.ModelBinding.IMetadataAware
	{

		private string _mask = string.Empty;

		public InputMaskAttribute(string mask)
		{
			_mask = mask;
		}

		public string Mask
		{
			get { return _mask; }
		}

		private const string ScriptText = "<script type='text/javascript'>" +
										  "$(document).ready(function () {{" +
										  "$('#{0}').mask('{1}');}});</script>";

		public const string templateHint = "_mask";

		private int _count;

		public string Id
		{
			get { return "maskedInput_" + _count; }
		}

		internal HttpContextBase Context
		{
			get { return new HttpContextWrapper(HttpContext.Current); }
		}

		public void OnMetadataCreated(System.Web.ModelBinding.ModelMetadata metadata)
		{
			var list = Context.Items["Scripts"]
			as IList<string> ?? new List<string>();
			_count = list.Count;
			metadata.TemplateHint = templateHint;
			metadata.AdditionalValues[templateHint] = Id;
			list.Add(string.Format(ScriptText, Id, Mask));
			Context.Items["Scripts"] = list;
		}
	}

	public static class ViewData{
		public static TAttribute GetModelAttribute<TAttribute>
		(this ViewDataDictionary viewData, bool inherit = false) where TAttribute : Attribute
		{
			if (viewData == null) throw new ArgumentException("ViewData");
			var containerType = viewData.ModelMetadata.ContainerType;
			return
				((TAttribute[])
				 containerType.GetProperty(viewData.ModelMetadata.PropertyName).
				 GetCustomAttributes(typeof(TAttribute),
				 inherit)).
					FirstOrDefault();

		}
		public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
		{
			var scripts = htmlHelper.ViewContext.HttpContext.Items["Scripts"] as IList<string>;
			if (scripts != null)
			{
				var builder = new StringBuilder();
				foreach (var script in scripts)
				{
					builder.AppendLine(script);
				}
				return new MvcHtmlString(builder.ToString());
			}
			return null;
		}
	}

}