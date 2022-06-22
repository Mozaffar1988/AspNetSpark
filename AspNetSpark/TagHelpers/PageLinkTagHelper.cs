using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSpark.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetSpark.TagHelpers
{
    [HtmlTargetElement("div",Attributes="page-model")]
    public class PageLinkTagHelper:TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo pageModel { get; set; }
        public string PageAction { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            //for (int i = 1; i <= pageModel.TotalItems ;i++)
            for (int i = 1; i <= pageModel.TotalPage; i++)
                {
                TagBuilder tag = new TagBuilder("a");
                string url = pageModel.UrlParam.Replace(":", i.ToString());
                tag.Attributes["href"] = url;
                tag.AddCssClass(i==pageModel.CurrentPage?PageClassSelected:PageClassNormal); ;
                tag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }

    }
}
