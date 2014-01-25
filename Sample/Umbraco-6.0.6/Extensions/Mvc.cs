using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using UmbracoTest.Web.Controllers;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace UmbracoTest.Web.Extensions
{
    public static class Mvc
    {
		private const string ControllerPattern = "Controller$";

		public static void RenderAction<T>(this HtmlHelper htmlHelper, string actionName) where T : Controller
		{
			htmlHelper.RenderAction<T>(actionName, (RouteValueDictionary)null);
		}

		public static void RenderAction<T>(this HtmlHelper htmlHelper, string actionName, object parameters) where T : Controller
		{
			var controllerName = Regex.Replace(typeof(T).Name, ControllerPattern, String.Empty);
			htmlHelper.RenderAction(actionName, controllerName, parameters);
		}

		public static IHtmlString RenderLinkTag(this HtmlHelper htmlHelper, string title, string url, bool newWindow = false, object htmlAttributes = null)
		{
			var linkTag = new TagBuilder("a");

			linkTag.SetInnerText(htmlHelper.Encode(title));
			linkTag.MergeAttribute("href", htmlHelper.Encode(url));

			if (newWindow)
				linkTag.MergeAttribute("target", "_blank");

			if (htmlAttributes != null)
				linkTag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

			return new HtmlString(linkTag.ToString(TagRenderMode.Normal));
		}

		public static IHtmlString RenderLinkTag(this HtmlHelper htmlHelper, IHtmlString title, string url, bool newWindow = false, object htmlAttributes = null)
		{
			var linkTag = new TagBuilder("a") {InnerHtml = title.ToHtmlString()};

			linkTag.MergeAttribute("href", htmlHelper.Encode(url));

			if (newWindow)
				linkTag.MergeAttribute("target", "_blank");

			if (htmlAttributes != null)
				linkTag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

			return new HtmlString(linkTag.ToString(TagRenderMode.Normal));
		}

		public static void RenderPartialView(this HtmlHelper htmlHelper, string partialView, IPublishedContent content)
		{
			htmlHelper.RenderPartial(partialView, new PartialViewMacroModel(content, 0, String.Empty, String.Empty, null));
		}
    }
}