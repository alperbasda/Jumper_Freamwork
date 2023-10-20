﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Jumper.CodeGenerator.CqrsBuilder.ApplicationTemplates
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Jumper.CodeGenerator.Helpers.Constants;
    using Jumper.CodeGenerator.Helpers.DirectoryHelpers;
    using Jumper.CodeGenerator.Helpers.StringHelpers;
    using Jumper.CodeGenerator.Helpers.FileHelpers;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ApplicationServiceRegistirationTemplate : ApplicationServiceRegistirationTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            this.Write("\r\n");
            
            #line 21 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"

    
    string settingsJson = File.ReadAllText(FileSettings.ReadProjectPath);
    var datasource = JObject.Parse(settingsJson);
    var filePath = $"{FileSettings.ProjectCreateDirectory}{datasource["SolutionName"]}/Cqrs/{datasource["SolutionName"]}.Application";
    DirectoryHelper.CreateDirectoryIfNotExists(filePath);

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 29 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FileSettings.AUTO_GENERATED_MESSAGE));
            
            #line default
            #line hidden
            this.Write("\r\n\r\n\r\nusing Core.Application.Pipelines.Caching;\r\nusing Core.Application.Pipelines" +
                    ".Logging;\r\nusing Core.Application.Pipelines.Transaction;\r\nusing Core.Application" +
                    ".Pipelines.Validation;\r\nusing FluentValidation;\r\nusing ");
            
            #line 37 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Base;\r\nusing ");
            
            #line 38 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.Auth.HttpClients;\r\nusing ");
            
            #line 39 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Common.IdentityConfigurations;\r\nusing MediatR.NotificationPublishers;\r\nusing Mic" +
                    "rosoft.Extensions.Configuration;\r\nusing Microsoft.Extensions.DependencyInjection" +
                    ";\r\nusing System.Reflection;\r\n\r\nnamespace ");
            
            #line 45 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(@".Application;

public static class ApplicationServiceRegistiration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddIdentityOptions(configuration);

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());

            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            ");
            
            #line 65 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"

            WriteLine("");
            if(bool.Parse(datasource["UseCache"].ToString()) == true)
            {
            WriteLine($"\t\t\tconfiguration.AddOpenBehavior(typeof(CachingBehavior<,>));");
            WriteLine($"\t\t\tconfiguration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));");
            }
            if(bool.Parse(datasource["UseSerilog"].ToString()) == true)
            {
            WriteLine($"\t\t\tconfiguration.AddOpenBehavior(typeof(LoggingBehavior<,>));");
            }
            
            
            
            #line default
            #line hidden
            this.Write("            \r\n            ///Dikkat : Aşagıdaki kod bloğu notificationların asenk" +
                    "ron çalışmasını sağlar.\r\n            //Ef core aynı anda 2 istekle database e ba" +
                    "ğlanırsa hata alacağından dolayı dikkatli olunması gerekir.\r\n            //Datab" +
                    "ase erişiminin ayni anda birden fazla yerde çağırılacagını düşünüyorsanız aşagıd" +
                    "aki kod 3 satırını siliniz.\r\n            configuration.NotificationPublisher = n" +
                    "ew TaskWhenAllPublisher();\r\n            configuration.NotificationPublisherType " +
                    "= typeof(TaskWhenAllPublisher);\r\n            configuration.Lifetime = ServiceLif" +
                    "etime.Scoped;\r\n        });\r\n\r\n        \r\n\r\n        return services;\r\n\r\n    }\r\n\r\n " +
                    "   public static IServiceCollection AddIdentityOptions(this IServiceCollection s" +
                    "ervices,IConfiguration configuration)\r\n    {\r\n        IdentityApiConfiguration i" +
                    "dentityOpts = new IdentityApiConfiguration();\r\n\r\n        configuration.GetSectio" +
                    "n(\"HttpClients:IdentityServer\").Bind(identityOpts);\r\n        services.Configure<" +
                    "IdentityApiConfiguration>(options =>\r\n        {\r\n            options = identityO" +
                    "pts;\r\n        });\r\n        services.AddSingleton<IdentityApiConfiguration>(sp =>" +
                    "\r\n        {\r\n            return identityOpts;\r\n        });\r\n\r\n\r\n\r\n        JwtTok" +
                    "enOptions tokenOpts = new JwtTokenOptions();\r\n\r\n        configuration.GetSection" +
                    "(\"JwtTokenOptions\").Bind(tokenOpts);\r\n        services.Configure<JwtTokenOptions" +
                    ">(options =>\r\n        {\r\n            options = tokenOpts;\r\n        });\r\n        " +
                    "services.AddSingleton<JwtTokenOptions>(sp =>\r\n        {\r\n            return toke" +
                    "nOpts;\r\n        });\r\n\r\n\r\n        services.AddHttpClient<IIdentityServerClientSer" +
                    "vice, IdentityServerClientService>((client) =>\r\n        {\r\n            client.Ba" +
                    "seAddress = new Uri(identityOpts.BaseAddress);\r\n        });\r\n\r\n        return se" +
                    "rvices;\r\n    }\r\n\r\n\r\n\r\n    public static IServiceCollection AddSubClassesOfType(\r" +
                    "\n      this IServiceCollection services,\r\n      Assembly assembly,\r\n      Type t" +
                    "ype,\r\n      Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle" +
                    " = null)\r\n    {\r\n        var types = assembly.GetTypes().Where(t => t.IsSubclass" +
                    "Of(type) && type != t).ToList();\r\n        foreach (var item in types)\r\n         " +
                    "   if (addWithLifeCycle == null)\r\n                services.AddScoped(item);\r\n   " +
                    "         else\r\n                addWithLifeCycle(services, type);\r\n        return" +
                    " services;\r\n    }\r\n\r\n}\r\n\r\n");
            
            #line 149 "C:\Projects\Jumper_Freamwork\CodeGenerator\Jumper.CodeGenerator.CqrsBuilder\ApplicationTemplates\ApplicationServiceRegistirationTemplate.tt"
    
FileHelper.CreateAndClearBuilder($"{filePath}/ApplicationServiceRegistiration.cs",this.GenerationEnvironment);

            
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
    public class ApplicationServiceRegistirationTemplateBase
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
