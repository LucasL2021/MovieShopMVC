#pragma checksum "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "723d4dd7ceacac1d284964a9540aee9ac9e5c094"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Movies_Details), @"mvc.1.0.view", @"/Views/Movies/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\_ViewImports.cshtml"
using MovieShopMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"723d4dd7ceacac1d284964a9540aee9ac9e5c094", @"/Views/Movies/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6112aabca9b932007558671ce74e32c023ef6c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Movies_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.Models.MovieDetailsResponseModel>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "723d4dd7ceacac1d284964a9540aee9ac9e5c0943276", async() => {
                WriteLiteral("\r\n    <style>\r\n        #row1\r\n        {\r\n            background-image: url(\"");
#nullable restore
#line 9 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                              Write(Model.BackdropUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral(@""");
        height: 28.1rem;
    width: 100%;
    background-size: cover;
    background-color: #07131b;
    background-blend-mode: overlay;

        }
        h1
        {
            color: white;
        }
        p
        {
            color: white;
        }
        #lengthAndDate 
        {
            color: gray;
            font-weight: bold;
        }
        #reviewBtn
        {
            background-color: black;
            color: white;
            height: 30px;
            width: 130px;
            margin-bottom: 10px;
        }
        #buyBtn
        {
            background-color: white;
            color: black;
            height: 30px;
            width: 130px;
        }
        #trailerRow
        {
        margin-top: 10px;
        }
        .character1
        {
        position:absolute;
            left: 490px;
        }
        .actor
        {
        position:absolute;
            left: 190px;
        }


    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "723d4dd7ceacac1d284964a9540aee9ac9e5c0945590", async() => {
                WriteLiteral("\r\n<div class=\"container\">\r\n  <div class=\"row\" id=\"row1\">\r\n    <div class=\"col-4\" align=\"right\">\r\n      <img");
                BeginWriteAttribute("src", " src=\"", 1324, "\"", 1346, 1);
#nullable restore
#line 68 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 1330, Model.PosterUrl, 1330, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("  width=\"70%\"/>\r\n    </div>\r\n    <div class=\"col-6\">\r\n      <h1>");
#nullable restore
#line 71 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
     Write(Model.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\r\n        <font size=\"2\" color=\"white\">");
#nullable restore
#line 72 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                Write(Model.Tagline);

#line default
#line hidden
#nullable disable
                WriteLiteral("</font>\r\n        <div>\r\n        <span id=\"lengthAndDate\">");
#nullable restore
#line 74 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                            Write(Model.RunTime);

#line default
#line hidden
#nullable disable
                WriteLiteral(" m | ");
#nullable restore
#line 74 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                               Write(Model.ReleaseDate.Value.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n        <span>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</span>\r\n");
#nullable restore
#line 76 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
         foreach(var GenreModel in @Model.Genres)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <span class=\"badge badge-pill badge-secondary\">");
#nullable restore
#line 78 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                          Write(GenreModel.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n");
#nullable restore
#line 79 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        <br/>\r\n        <font size=\"6\"> <span class=\"badge badge-success\" height=\"100\">");
#nullable restore
#line 81 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                  Write(String.Format("{0:0.0}", @Model.Rating));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></font>\r\n        <p>");
#nullable restore
#line 82 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
      Write(Model.Overview);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n      <div class=\"col-2\" align=\"right\">\r\n        <br/><br/>\r\n        <input type=\"submit\" value=\"REVIEW\" id=\"reviewBtn\">\r\n        <br/>\r\n        <input type=\"submit\"");
                BeginWriteAttribute("value", " value=\"", 2219, "\"", 2244, 3);
                WriteAttributeValue("", 2227, "BUY", 2227, 3, true);
                WriteAttributeValue(" ", 2230, "$", 2231, 2, true);
#nullable restore
#line 89 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 2232, Model.Price, 2232, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" id=""buyBtn"" >
      </div>
  </div>
    <div class=""row"" >
        <div class=""col-4"">
            <h3>MOVIE FACTS</h3>
            <ul class=""list-group list-group-flush"">
            <li class=""list-group-item"">Release Date&nbsp<span class=""badge badge-pill badge-secondary"">");
#nullable restore
#line 96 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                                   Write(Model.ReleaseDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></li>\r\n            <li class=\"list-group-item\">Run Time&nbsp<span class=\"badge badge-pill badge-secondary\">");
#nullable restore
#line 97 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                               Write(Model.RunTime);

#line default
#line hidden
#nullable disable
                WriteLiteral(" m</span></li>\r\n            <li class=\"list-group-item\">Box Office&nbsp<span class=\"badge badge-pill badge-secondary\"> ");
#nullable restore
#line 98 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                                  Write(String.Format("{0:C2}", @Model.Revenue));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></li>\r\n            <li class=\"list-group-item\">Budget&nbsp<span class=\"badge badge-pill badge-secondary\">");
#nullable restore
#line 99 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                                             Write(String.Format("{0:C2}", @Model.Budget));

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></li>\r\n            </ul>\r\n            <br/>\r\n            <h3>TRAILERS</h3>\r\n            <ul class=\"list-group list-group-flush\">\r\n");
#nullable restore
#line 104 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
             foreach(var trailer in @Model.Trailers)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                      <li class=\"list-group-item\"><a");
                BeginWriteAttribute("href", " href=", 3274, "", 3299, 1);
#nullable restore
#line 106 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3280, trailer.TrailerUrl, 3280, 19, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 106 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                                                         Write(trailer.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></li>\r\n");
#nullable restore
#line 107 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </ul>\r\n        </div>\r\n    <div class=\"col-8\">\r\n        <h3>CAST</h3>\r\n");
#nullable restore
#line 112 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
             foreach(var cast in @Model.Casts)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("  <a");
                BeginWriteAttribute("href", " href=", 3495, "", 3518, 1);
#nullable restore
#line 113 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3501, cast.ProfilePath, 3501, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"list-group-item list-group-item-action\">\r\n                      <img");
                BeginWriteAttribute("src", " src=", 3594, "", 3616, 1);
#nullable restore
#line 114 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3599, cast.ProfilePath, 3599, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"rounded-circle\"");
                BeginWriteAttribute("alt", " alt=", 3639, "", 3654, 1);
#nullable restore
#line 114 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
WriteAttributeValue("", 3644, cast.Name, 3644, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" height=\"40\">\r\n                      &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp\r\n                      <span class=\"actor\">");
#nullable restore
#line 116 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                     Write(cast.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                        \r\n                      <span class=\"character1\">");
#nullable restore
#line 118 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                                          Write(cast.Character);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                    </a>\r\n");
#nullable restore
#line 120 "D:\Antra\MovieShopMVC\MovieShop\MovieShopMVC\Views\Movies\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            \r\n        </div>\r\n    </div>\r\n  </div>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.Models.MovieDetailsResponseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
