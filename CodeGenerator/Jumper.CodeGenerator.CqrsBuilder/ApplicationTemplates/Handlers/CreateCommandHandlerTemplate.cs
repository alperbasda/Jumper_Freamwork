﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Jumper.CodeGenerator.CqrsBuilder.ApplicationTemplates.Handlers
{
    using System.IO;
    using System.Runtime;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Jumper.CodeGenerator.Helpers.Constants;
    using Jumper.CodeGenerator.Helpers.DirectoryHelpers;
    using Jumper.CodeGenerator.Helpers.StringHelpers;
    using Jumper.CodeGenerator.Helpers.FileHelpers;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CreateCommandHandlerTemplate : CreateCommandHandlerTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            
            #line 15 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"

    
    string settingsJson = File.ReadAllText(FileSettings.ReadProjectPath);
    var datasource = JObject.Parse(settingsJson);

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 21 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"

foreach (var entity in datasource["Entities"])
{
foreach(var action in entity["Actions"].Where(w => w["EntityAction"].ToString() == "0"))
{
var filePath = $"{FileSettings.ProjectCreateDirectory}{datasource["SolutionName"]}/Cqrs/{datasource["SolutionName"]}.Application/Features/{entity["Name"].ToString().ToPlural()}/Handlers/Commands/{action["Name"]}";
DirectoryHelper.CreateDirectoryIfNotExists(filePath);

            
            #line default
            #line hidden
            
            #line 29 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FileSettings.AUTO_GENERATED_MESSAGE));
            
            #line default
            #line hidden
            this.Write("\r\nusing AutoMapper;\r\nusing ");
            
            #line 31 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 31 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Commands.");
            
            #line 31 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            this.Write(";\r\nusing ");
            
            #line 32 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 32 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Rules;\r\nusing ");
            
            #line 33 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Services.Repositories;\r\nusing ");
            
            #line 34 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Domain.Entities;\r\nusing ");
            
            #line 35 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Domain.MongoEntities;\r\nusing MediatR;\r\nnamespace ");
            
            #line 37 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.");
            
            #line 37 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToPlural()));
            
            #line default
            #line hidden
            this.Write(".Handlers.Commands.");
            
            #line 37 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            this.Write(";\r\n\r\npublic class ");
            
            #line 39 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            
            #line 39 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write("CommandHandler : IRequestHandler<");
            
            #line 39 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            
            #line 39 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write("Command, ");
            
            #line 39 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            
            #line 39 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write("Response>\r\n{\r\n    private readonly I");
            
            #line 41 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Dal _");
            
            #line 41 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Dal;\r\n    private readonly ");
            
            #line 42 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("BusinessRules _");
            
            #line 42 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("BusinessRules;\r\n    private readonly IMapper _mapper;\r\n\r\n    public ");
            
            #line 45 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            
            #line 45 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write("CommandHandler(IMapper mapper, I");
            
            #line 45 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("Dal ");
            
            #line 45 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Dal, ");
            
            #line 45 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString()));
            
            #line default
            #line hidden
            this.Write("BusinessRules ");
            
            #line 45 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("BusinessRules)\r\n    {\r\n        _mapper = mapper;\r\n        _");
            
            #line 48 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Dal = ");
            
            #line 48 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Dal;\r\n        _");
            
            #line 49 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("BusinessRules = ");
            
            #line 49 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("BusinessRules;\r\n    }\r\n\r\n    public async Task<");
            
            #line 52 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            
            #line 52 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write("Response> Handle(");
            
            #line 52 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            
            #line 52 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write("Command request, CancellationToken cancellationToken)\r\n    {\r\n        var data = " +
                    "_mapper.Map<");
            
            #line 54 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write(">(request);\r\n\r\n        _");
            
            #line 56 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("BusinessRules.SetId(data);\r\n        //İş Kurallarınızı Burada Çağırabilirsiniz.\r\n" +
                    "\r\n        await _");
            
            #line 59 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"].ToString().ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Dal.AddAsync(data);\r\n\r\n        return _mapper.Map<");
            
            #line 61 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(action["Name"]));
            
            #line default
            #line hidden
            
            #line 61 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entity["Name"]));
            
            #line default
            #line hidden
            this.Write("Response>(data);\r\n    }\r\n}\r\n\r\n\r\n\r\n");
            
            #line 67 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\Handlers\CreateCommandHandlerTemplate.tt"
    
FileHelper.CreateAndClearBuilder($"{filePath}/{action["Name"]}{entity["Name"]}CommandHandler.cs",this.GenerationEnvironment);
}
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
    public class CreateCommandHandlerTemplateBase
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