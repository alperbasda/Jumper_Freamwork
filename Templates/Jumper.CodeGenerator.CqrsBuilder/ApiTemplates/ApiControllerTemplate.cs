﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Jumper.CodeGenerator.CqrsBuilder.ApiTemplates
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
    
    #line 1 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ApiControllerTemplate : ApiControllerTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            
            #line 20 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"

    
    string settingsJson = File.ReadAllText(FileSettings.ReadProjectPath);
    var datasource = JObject.Parse(settingsJson);
    var filePath = $"{FileSettings.ProjectCreateDirectory}{datasource["SolutionName"]}/Presentation/{datasource["SolutionName"]}.UI.Api/Controllers";
    DirectoryHelper.CreateDirectoryIfNotExists(filePath);

            
            #line default
            #line hidden
            
            #line 27 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"

foreach (var entity in datasource["Entities"])
{

            
            #line default
            #line hidden
            
            #line 31 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FileSettings.AUTO_GENERATED_MESSAGE));
            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 32 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"

foreach(var action in entity["Actions"].Where(w=>w["IsConstant"].Value<bool>() == false))
{

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 36 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 36 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 36 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProjectSettings.ReadActionTypes.Contains(action["EntityAction"].ToString()) ? "Queries" : "Commands"));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 36 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            this.Write(";\r\n");
            
            #line 37 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"

}

            
            #line default
            #line hidden
            this.Write("using ");
            
            #line 40 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 40 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Commands.Create;\r\nusing ");
            
            #line 41 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 41 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Commands.DeleteById;\r\nusing ");
            
            #line 42 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 42 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Commands.Update;\r\nusing ");
            
            #line 43 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 43 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Queries.GetById;\r\nusing ");
            
            #line 44 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 44 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Queries.ListDynamic;\r\nusing ");
            
            #line 45 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".UI.Api.ActionFilters;\r\nusing ");
            
            #line 46 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".UI.Api.Controllers.Base;\r\nusing Core.Persistence.Models.Responses;\r\nusing Micros" +
                    "oft.AspNetCore.Mvc;\r\nusing System.Collections.Specialized;\r\nusing System.Web;\r\nu" +
                    "sing Core.WebHelper.NameValueCollectionHelpers;\r\n");
            
            #line 52 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
 
if(ProjectSettings.NoSqlDatabaseTypes.Contains(entity["DatabaseType"].ToString()))
{
WriteLine($"using {datasource["SolutionName"]}.Domain.MongoEntities;");
}
else
{
WriteLine($"using {datasource["SolutionName"]}.Domain.Entities;");
}

            
            #line default
            #line hidden
            this.Write("\r\nnamespace ");
            
            #line 63 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".UI.Api.Controllers\r\n{\r\n    [Route(\"");
            
            #line 65 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n    public class ");
            
            #line 66 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write("Controller : MediatrController\r\n    {\r\n        [HttpGet(\"{id}\")]\r\n        public " +
                    "async Task<IActionResult> GetByIdAsync(Guid id)\r\n        {\r\n            var resp" +
                    "onse = await base.Mediator.Send(new GetById");
            
            #line 71 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Query { Id = id });\r\n            return Ok(Response<GetById");
            
            #line 72 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Response>.Success(response,200));\r\n        }\r\n\r\n        [HttpGet(\"getlist\")]\r\n   " +
                    "     public async Task<IActionResult> ListAsync(NameValueCollection collection)\r" +
                    "\n        {\r\n            var query = new ListDynamic");
            
            #line 78 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Query\r\n            {\r\n                DynamicQuery = collection.ToDynamicFilter<");
            
            #line 80 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write(">(),\r\n                PageRequest = collection.ToPageRequest()\r\n            };\r\n " +
                    "           var response = await base.Mediator.Send(query);\r\n\r\n            return" +
                    " Ok(Response<ListModel<ListDynamic");
            
            #line 85 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Response>>.Success(response,200));\r\n        }\r\n\r\n        [HttpPost(\"list\")]\r\n    " +
                    "    public async Task<IActionResult> ListAsync(ListDynamic");
            
            #line 89 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Query query)\r\n        {\r\n            var response = await base.Mediator.Send(quer" +
                    "y);\r\n            return Ok(Response<ListModel<ListDynamic");
            
            #line 92 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Response>>.Success(response,200));\r\n        }\r\n\r\n        [HttpPost]\r\n        publ" +
                    "ic async Task<IActionResult> CreateAsync(Create");
            
            #line 96 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Command request)\r\n        {\r\n            return Ok(Response<Create");
            
            #line 98 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Response>.Success(await base.Mediator.Send(request), 200));\r\n        }\r\n\r\n       " +
                    " [HttpPut]\r\n        public async Task<IActionResult> UpdateAsync(Update");
            
            #line 102 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Command request)\r\n        {\r\n            return Ok(Response<Update");
            
            #line 104 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Response>.Success(await base.Mediator.Send(request), 200));\r\n        }\r\n\r\n       " +
                    " [HttpDelete]\r\n        public async Task<IActionResult> DeleteByIdAsync(Guid id)" +
                    "\r\n        {\r\n            return Ok(Response<DeleteById");
            
            #line 110 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Response>.Success(await base.Mediator.Send(new DeleteById");
            
            #line 110 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Command { Id = id }), 200));\r\n        }\r\n\r\n        ");
            
            #line 113 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"

        foreach(var action in entity["Actions"].Where(w=>w["IsConstant"].Value<bool>() == false))
        {
        
            
            #line default
            #line hidden
            this.Write("\r\n        [HttpPost(\"");
            
            #line 118 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("\")]\r\n        public async Task<IActionResult> ");
            
            #line 119 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            this.Write("Async(");
            
            #line 119 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"].ToString()));
            
            #line default
            #line hidden
            
            #line 119 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            
            #line 119 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(ProjectSettings.ReadActionTypes.Contains(action["EntityAction"].ToString()) ? "Query" : "Command"));
            
            #line default
            #line hidden
            this.Write(" request)\r\n        {\r\n            return Ok(Response<");
            
            #line 121 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"].ToString()));
            
            #line default
            #line hidden
            
            #line 121 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Response>.Success(await base.Mediator.Send(request), 200));\r\n        }\r\n\r\n       " +
                    " ");
            
            #line 124 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"

        }
        
            
            #line default
            #line hidden
            this.Write("\r\n    }\r\n}\r\n\r\n\r\n");
            
            #line 132 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\ApiTemplates\ApiControllerTemplate.tt"
    
FileHelper.CreateAndClearBuilder($"{filePath}/{entity["Name"].ToString().ToPlural()}Controller.cs",this.GenerationEnvironment);
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
    public class ApiControllerTemplateBase
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
