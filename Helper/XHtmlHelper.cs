using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Helper
{
    public static class XHtmlHelper
    {
        public static MvcHtmlString Submit (this HtmlHelper helper,string lable = "Submit",string action= null)
        {
            var submit = new TagBuilder("input");
            submit.Attributes["type"] = "submit";
            submit.Attributes["value"] = lable;
            if (action != null)
            {
                submit.Attributes["onclick"] = "{form.action='" + action + "'}";


            }
            submit.Attributes["class"] = "btn btn-default";
            return MvcHtmlString.Create(submit.ToString(TagRenderMode.SelfClosing));
        }

    }
}