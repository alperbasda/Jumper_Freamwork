﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Jumper.CodeGenerator.CqrsBuilder.WebTemplates.ViewTemplates
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Jumper.Common.Constants;
    using Jumper.Common.DirectoryHelpers;
    using Jumper.Common.StringHelpers;
    using Jumper.Common.FileHelpers;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class IndexTemplate : IndexTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            
            #line 20 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

    
    string settingsJson = File.ReadAllText(FileSettings.ReadProjectPath);
    var datasource = JObject.Parse(settingsJson);
    var filePath = $"{FileSettings.ProjectCreateDirectory}{datasource["SolutionName"]}/Presentation/{datasource["SolutionName"]}.UI.Web/Views";

            
            #line default
            #line hidden
            
            #line 26 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

foreach (var entity in datasource["Entities"])
{

            
            #line default
            #line hidden
            this.Write("<!--\r\n   ");
            
            #line 31 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FileSettings.AUTO_GENERATED_MESSAGE));
            
            #line default
            #line hidden
            this.Write(" \r\n-->\r\n@using Core.Persistence.Dynamic;\r\n@using Core.Persistence.Models.Response" +
                    "s;\r\n@using Core.WebHelper.NameValueCollectionHelpers;\r\n@using ");
            
            #line 36 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"].ToString()));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 36 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Queries.ListDynamic;\r\n@using Core.CrossCuttingConcerns.Helpers.EnumHelpers;\r\n");
            
            #line 38 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
 
if(ProjectSettings.NoSqlDatabaseTypes.Contains(entity["DatabaseType"].ToString()))
{
WriteLine($"@using {datasource["SolutionName"]}.Domain.MongoEntities;");
}
else
{
WriteLine($"@using {datasource["SolutionName"]}.Domain.Entities;");
}

            
            #line default
            #line hidden
            this.Write("\r\n@{\r\n    ViewData[\"Title\"] = \"");
            
            #line 50 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(@" Listesi"";
    var filters = new List<Filter>();
    if (Model != null && Model.DynamicQuery != null && Model.DynamicQuery.Filter != null)
    {
        filters.AddRange(CollectionToDynamicQueryExtension.GetAllFilters(Model.DynamicQuery.Filter));
    }
}
@model ListModel<ListDynamic");
            
            #line 57 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(@"Response>



<div class=""card"">
    <!--begin:Card Header-->
    <div class=""card-header"">
        <!--begin:Card Title-->
        <div class=""card-title"">
            
        </div>
        <!--end:Card Title-->
        <!--begin::Toolbar container-->
        <div class=""card-toolbar"">
            <div class=""card-toolbar"">
                <ul class=""nav nav-tabs nav-line-tabs nav-stretch fs-6 border-0"">
                    <li class=""nav-item"">
                        <a href=""@Url.Action(""Create"",""");
            
            #line 74 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("\")\" class=\"btn btn-sm fw-bold btn-secondary\">");
            
            #line 74 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(@" Ekle</a>
                    </li>
                </ul>
            </div>
        </div>
        <!--end::Toolbar container-->

    </div>
    <!--end:Card Header-->
    <!--begin::Card Body container-->
    <div class=""card-body p-0"">
        <form method=""get"" action=""@Url.Action(""Index"",""");
            
            #line 85 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(@""")"">
            <div class=""d-flex flex-column flex-column-fluid"">
                <div id=""kt_app_content"" class=""app-content flex-column-fluid"">
                    <div id=""kt_app_content_container"" class=""app-container container-xxxl"">
                        <div class=""table-responsive"">
                            <table class=""dynamic-table table table-hover table-row-bordered gy-5 gs-7"">
                                <tr>
                                ");
            
            #line 92 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

                                foreach(var prop in entity["Properties"].Where(w=> datasource["PropertyTypeNames"].Select(w=>w.ToString()).Contains(w["PropertyTypeCode"].ToString())))
                                {
                                if(prop["Name"].ToString() == "Id")
                                {
                                continue;
                                }
                                
            
            #line default
            #line hidden
            this.Write("                                <th>\r\n                                    <b>\r\n  " +
                    "                                      <a data-sort=\"@nameof(");
            
            #line 102 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 102 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(")\" href=\"#/\">\r\n                                            ");
            
            #line 103 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(" &nbsp;\r\n                                        </a>\r\n                          " +
                    "          </b>\r\n                                </th>\r\n                         " +
                    "       ");
            
            #line 107 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

                                }
                                
            
            #line default
            #line hidden
            this.Write("                                <th></th>\r\n                                <th></" +
                    "th>\r\n                                </tr>\r\n\r\n\r\n                                " +
                    "<tr>\r\n                                ");
            
            #line 116 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

                                foreach(var prop in entity["Properties"].Where(w=> datasource["PropertyTypeNames"].Select(w=>w.ToString()).Contains(w["PropertyTypeCode"].ToString())))
                                {
                                if(prop["Name"].ToString() == "Id")
                                {
                                continue;
                                }
                                if(prop["Name"].ToString().EndsWith("Id"))
                                {
                                WriteLine("");
                                WriteLine($"\t\t\t\t\t\t\t\t<th><select class=\"form-control form-control-sm search_box\" data-dynamic-for=\"{prop["Name"].ToString().Substring(0, prop["Name"].ToString().Length - 2)}/Dropdown\" placeholder=\"@filters.FirstOrDefault(w=>w.Field == nameof({entity["Name"].ToString()}.{prop["Name"].ToString()}))?.Value\" name=\"{prop["Name"].ToString()}\"></select></th>");
                                continue;
                                }
                                
            
            #line default
            #line hidden
            this.Write("                                <th>\r\n                                    <input " +
                    "type=\"text\" class=\"form-control form-control-sm\" name=\"");
            
            #line 131 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("\" placeholder=\"Aranacak kelime yazın\" value=\"@filters.FirstOrDefault(w=>w.Field =" +
                    "= nameof(");
            
            #line 131 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 131 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("))?.Value\" />\r\n                                </th>\r\n                           " +
                    "     ");
            
            #line 133 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

                                }
                                
            
            #line default
            #line hidden
            this.Write(@"                                <th> <input type=""submit"" class=""btn btn-primary btn-sm"" value=""Filtrele"" /> </th>
                                <th></th>
                                </tr>

                                @foreach (var item in Model.Items)
                                {
                                    <tr>
                                         ");
            
            #line 143 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

                                         foreach(var prop in entity["Properties"].Where(w=> datasource["PropertyTypeNames"].Select(w=>w.ToString()).Contains(w["PropertyTypeCode"].ToString())))
                                         {
                                         if(prop["Name"].ToString() == "Id")
                                         {
                                         continue;
                                         }
                                         if(prop["Name"].ToString().EndsWith("Id"))
                                         {
                                         WriteLine("");
                                         WriteLine($"\t\t\t\t\t\t\t\t\t\t<td data-fill-controller=\"{prop["Name"].ToString().Substring(0, prop["Name"].ToString().Length - 2)}Controller\" data-fill-ref=\"{prop["Id"].ToString()}\"></td>");
                                         continue;
                                         }
                                         
            
            #line default
            #line hidden
            this.Write("                                         <td>@item.");
            
            #line 157 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("</td>\r\n                                         ");
            
            #line 158 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"

                                         }
                                         
            
            #line default
            #line hidden
            this.Write("\r\n                                        <td>\r\n                                 " +
                    "           <div class=\"d-flex justify-content-around\">\r\n                        " +
                    "                        <a href=\"@Url.Action(\"Update\",\"");
            
            #line 164 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(@""")/@item.Id"" data-bs-toggle=""tooltip"" data-bs-placement=""top"" title=""Düzenle"">
                                                    <i class=""fa fa-edit""></i>
                                                </a>
                                                <a class=""delete-link"" href=""@Url.Action(""DeleteAsync"",""");
            
            #line 167 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("\")/@item.Id\" data-bs-toggle=\"tooltip\" data-bs-placement=\"top\" title=\"Sil\">\r\n     " +
                    "                                               <i class=\"fa fa-trash\"></i>\r\n    " +
                    "                                            </a>\r\n                              " +
                    "              </div>\r\n                                        </td>\r\n\r\n         " +
                    "                           </tr>\r\n                                }\r\n           " +
                    "                 </table>\r\n\r\n                        </div>\r\n                   " +
                    " </div>\r\n                </div>\r\n\r\n\r\n            </div>\r\n        </form>\r\n\r\n    " +
                    "</div>\r\n    <!--end::Card Body container-->\r\n    <div class=\"card-footer\">\r\n    " +
                    "    <ul class=\"pagination pagination-circle\">\r\n            @if (Model.Pages > 1)" +
                    "\r\n            {\r\n                // \"Başa git Git\" butonu\r\n                if (M" +
                    "odel.HasPrevious)\r\n                {\r\n                    <li class=\"page-item f" +
                    "irst\">\r\n                        <a data-page=\"1\" class=\"page-link\" href=\"#/\">\r\n " +
                    "                           <i class=\"fa-solid fa-angles-left fs-2\"></i>\r\n       " +
                    "                 </a>\r\n                    </li>\r\n                }\r\n           " +
                    "     for (int i = Math.Max(1, Model.Index - 3); i < Model.Index; i++)\r\n         " +
                    "       {\r\n                    <li class=\"page-item\">\r\n                        <a" +
                    " data-page=\"@i\" class=\"page-link\" href=\"#/\"> @i </a>\r\n                    </li>\r" +
                    "\n                }\r\n                // Mevcut sayfa\r\n                <li class=\"" +
                    "page-item active\">\r\n                    <span class=\" page-link\">@Model.Index</s" +
                    "pan>\r\n                </li>\r\n                for (int i = Model.Index + 1; i <= " +
                    "Math.Min(Model.Pages, Model.Index + 3); i++)\r\n                {\r\n               " +
                    "     <li class=\"page-item\">\r\n                        <a data-page=\"@i\" class=\"pa" +
                    "ge-link\" href=\"#/\">@i</a>\r\n                    </li>\r\n                }\r\n       " +
                    "         // \"Sona Git\" butonu\r\n                if (Model.HasNext)\r\n             " +
                    "   {\r\n                    <li class=\"page-item last  \">\r\n                       " +
                    " <a data-page=\"@Model.Pages\" class=\"page-link\" href=\"#/\">\r\n                     " +
                    "       <i class=\"fa-solid fa-angles-right fs-2\"></i>\r\n                        </" +
                    "a>\r\n                    </li>\r\n                }\r\n            }\r\n        </ul>\r\n" +
                    "    \r\n        @if (Model.Count == 0)\r\n        {\r\n            <div class=\"text-ce" +
                    "nter\">\r\n                <h5>\r\n                    Kriterlere uygun veri bulunama" +
                    "dı.\r\n                </h5>\r\n\r\n            </div>\r\n        }\r\n    \r\n    </div>\r\n " +
                    "   \r\n    \r\n    </div>\r\n    \r\n    <div class=\"pt-2\">\r\n        <p>\r\n            Si" +
                    "steme Kayıtlı @Model.Items.Count servis bulunmaktadır.\r\n        </p>\r\n    </div>" +
                    "\r\n</div>\r\n\r\n\r\n");
            
            #line 251 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\ViewTemplates\IndexTemplate.tt"
    
DirectoryHelper.CreateDirectoryIfNotExists($"{filePath}/{entity["Name"].ToString()}");
FileHelper.CreateAndClearBuilder($"{filePath}/{entity["Name"].ToString()}/Index.cshtml",this.GenerationEnvironment);
}

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class IndexTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        public System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
