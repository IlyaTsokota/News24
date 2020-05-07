﻿using News24.Web.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace News24.Web.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
        Pager pager, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            var div = new TagBuilder("div");
            div.AddCssClass("pagination col-12 d-flex flex-wrap justify-content-center");
            for (int i = 1; i <= pager.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                // если текущая страница, то выделяем ее,
                // например, добавляя класс
                if (i == pager.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                div.InnerHtml += tag.ToString();
                
            }
            result.Append(div.ToString());
            return MvcHtmlString.Create(result.ToString());
        }
        public static MvcHtmlString PaginationAjax(this HtmlHelper html, Pager pager)
        {
            if (pager == null || pager.TotalPages == 1)
            {
                return null;
            }

            var result = new StringBuilder();
            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("pagination col-12 d-flex flex-wrap justify-content-center my-1");
            for (var i = 1; i <= pager.TotalPages; i++)
            {
                var liTag = new TagBuilder("li");
                liTag.AddCssClass("page-item");
                if (i == pager.PageNumber)
                {
                    liTag.AddCssClass("active");
                }

                var buttonTag = new TagBuilder("button");
                buttonTag.AddCssClass("btn page-link");
                buttonTag.MergeAttribute("type", "submit");
                buttonTag.MergeAttribute("name", "page");
                buttonTag.MergeAttribute("value", i.ToString());
                buttonTag.InnerHtml = i.ToString();
                liTag.InnerHtml = buttonTag.ToString();
                ulTag.InnerHtml += liTag.ToString();
            }

            result.Append(ulTag);
            return MvcHtmlString.Create(result.ToString());
        }
        public static MvcHtmlString PaginationArticlesAjax(this HtmlHelper html, Pager pager)
        {
            if (pager == null || pager.TotalPages == 1)
            {
                return null;
            }

            var result = new StringBuilder();
            var divTag = new TagBuilder("div");
            divTag.AddCssClass("col-12 text-center pb-4 pt-4");
           
            for (var i = 1; i <= pager.TotalPages; i++)
            {
                var buttonTag = new TagBuilder("button");
                if (i == pager.PageNumber)
                {
                    buttonTag.AddCssClass("active");
                }
                buttonTag.AddCssClass("btn_pagging");
                buttonTag.MergeAttribute("type", "submit");
                buttonTag.MergeAttribute("name", "page");
                buttonTag.MergeAttribute("value", i.ToString());
                buttonTag.InnerHtml = i.ToString();
              
                divTag.InnerHtml += buttonTag.ToString();
            }
           
            result.Append(divTag);
            return MvcHtmlString.Create(result.ToString());
        }
    }
}