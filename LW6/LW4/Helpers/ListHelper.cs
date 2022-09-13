using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LW4.Helpers
{
    public static class ListHelper
    {
        public static MvcHtmlString UpdateTelephoneNumber(this HtmlHelper html, TelephoneDictionary.TelephoneNumber telephoneNumber, MvcHtmlString antiForgeryToken)
        {
            TagBuilder form = new TagBuilder("form");
            form.MergeAttribute("action", "/LW6_4/TelephoneNumbers/Edit/1");
            form.MergeAttribute("method", "post");
            form.MergeAttribute("novalidate", "novalidate");

            TagBuilder mainDiv = new TagBuilder("div");
            mainDiv.MergeAttribute("class", "form-horizontal");

            TagBuilder preview = new TagBuilder("h4");
            preview.SetInnerText("TelephoneNumber");

            TagBuilder separator = new TagBuilder("hr");

            TagBuilder inputId = new TagBuilder("input");
            inputId.MergeAttribute("data-val","true");
            inputId.MergeAttribute("data-val-number","The field Id must be a number.");
            inputId.MergeAttribute("data-val-required", "Требуется поле Id.");
            inputId.MergeAttribute("id", "Id");
            inputId.MergeAttribute("name", "Id");
            inputId.MergeAttribute("type", "hidden");
            inputId.MergeAttribute("value", telephoneNumber.Id.ToString());

            mainDiv.InnerHtml += preview.ToString();
            mainDiv.InnerHtml += separator.ToString(TagRenderMode.SelfClosing);
            mainDiv.InnerHtml += inputId.ToString(TagRenderMode.SelfClosing);

            //first div
            TagBuilder firstInnerDiv = new TagBuilder("div");
            firstInnerDiv.AddCssClass("form-group");

            TagBuilder firstInnerDivLabel = new TagBuilder("label");
            firstInnerDivLabel.AddCssClass("control-label");
            firstInnerDivLabel.AddCssClass("col-md-2");
            firstInnerDivLabel.MergeAttribute("for", "Name");
            firstInnerDivLabel.SetInnerText("Name");

            TagBuilder firstInnerDivDiv = new TagBuilder("div");
            firstInnerDivDiv.AddCssClass("col-md-10");

            TagBuilder firstInnerDivDivInput = new TagBuilder("input");
            firstInnerDivDivInput.AddCssClass("form-control");
            firstInnerDivDivInput.AddCssClass("text-box");
            firstInnerDivDivInput.AddCssClass("single-line");
            firstInnerDivDivInput.MergeAttribute("id", "Name");
            firstInnerDivDivInput.MergeAttribute("name", "Name");
            firstInnerDivDivInput.MergeAttribute("type", "text");
            firstInnerDivDivInput.MergeAttribute("value", telephoneNumber.Name);

            firstInnerDivDiv.InnerHtml+= firstInnerDivDivInput.ToString(TagRenderMode.SelfClosing);

            firstInnerDiv.InnerHtml += firstInnerDivLabel.ToString();
            firstInnerDiv.InnerHtml += firstInnerDivDiv.ToString();
            mainDiv.InnerHtml += firstInnerDiv.ToString();
            //
            TagBuilder secondInnerDiv = new TagBuilder("div");
            secondInnerDiv.AddCssClass("form-group");

            TagBuilder secondInnerDivLabel = new TagBuilder("label");
            secondInnerDivLabel.AddCssClass("control-label");
            secondInnerDivLabel.AddCssClass("col-md-2");
            secondInnerDivLabel.MergeAttribute("for", "PhoneNumber");
            secondInnerDivLabel.SetInnerText("PhoneNumber");

            TagBuilder secondInnerDivDiv = new TagBuilder("div");
            secondInnerDivDiv.AddCssClass("col-md-10");

            TagBuilder secondInnerDivDivInput = new TagBuilder("input");
            secondInnerDivDivInput.AddCssClass("form-control");
            secondInnerDivDivInput.AddCssClass("text-box");
            secondInnerDivDivInput.AddCssClass("single-line");
            secondInnerDivDivInput.MergeAttribute("id", "PhoneNumber");
            secondInnerDivDivInput.MergeAttribute("name", "PhoneNumber");
            secondInnerDivDivInput.MergeAttribute("type", "text");
            secondInnerDivDivInput.MergeAttribute("value", telephoneNumber.PhoneNumber);

            secondInnerDivDiv.InnerHtml += secondInnerDivDivInput.ToString(TagRenderMode.SelfClosing);

            secondInnerDiv.InnerHtml += secondInnerDivLabel.ToString();
            secondInnerDiv.InnerHtml += secondInnerDivDiv.ToString();
            mainDiv.InnerHtml += secondInnerDiv.ToString();

            //3
            TagBuilder thirdInnerDiv = new TagBuilder("div");
            thirdInnerDiv.AddCssClass("form-group");

            TagBuilder thirdInnerDivDiv = new TagBuilder("div");
            thirdInnerDivDiv.AddCssClass("col-md-offset-2");
            thirdInnerDivDiv.AddCssClass("col-md-10");

            TagBuilder thirdInnerDivDivInput = new TagBuilder("input");
            thirdInnerDivDivInput.AddCssClass("btn");
            thirdInnerDivDivInput.AddCssClass("btn-default");
            thirdInnerDivDivInput.MergeAttribute("type", "submit");
            thirdInnerDivDivInput.MergeAttribute("value", "Save");

            thirdInnerDivDiv.InnerHtml += thirdInnerDivDivInput.ToString(TagRenderMode.SelfClosing);

            thirdInnerDiv.InnerHtml += thirdInnerDivDiv.ToString();
            mainDiv.InnerHtml += thirdInnerDiv.ToString();


            form.InnerHtml += antiForgeryToken;
            form.InnerHtml += mainDiv.ToString();

            return new MvcHtmlString(form.ToString());
        }
    }
}