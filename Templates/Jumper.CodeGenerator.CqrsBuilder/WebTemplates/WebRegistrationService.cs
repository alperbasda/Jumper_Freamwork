﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Jumper.CodeGenerator.CqrsBuilder.WebTemplates
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
    
    #line 1 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class WebRegistrationService : WebRegistrationServiceBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            
            #line 20 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"

    string settingsJson = File.ReadAllText(FileSettings.ReadProjectPath);
    var datasource = JObject.Parse(settingsJson);
    var filePath = $"{FileSettings.ProjectCreateDirectory}{datasource["SolutionName"]}/Presentation/{datasource["SolutionName"]}.UI.Web/Middlewares";
    DirectoryHelper.CreateDirectoryIfNotExists(filePath);

            
            #line default
            #line hidden
            
            #line 26 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(FileSettings.AUTO_GENERATED_MESSAGE));
            
            #line default
            #line hidden
            this.Write(@"
using Core.Application.Pipelines.Caching;
using Core.CrossCuttingConcerns.Serilog.Logger;
using Core.CrossCuttingConcerns.Serilog;
using StackExchange.Redis;
using MassTransit;
using Core.ApiHelpers.JwtHelper.Models;
using Core.Persistence.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using ");
            
            #line 37 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".UI.Web.Helpers;\r\nusing Microsoft.AspNetCore.Authentication.Cookies;\r\nusing ");
            
            #line 39 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Application.Features.Auth.HttpClients;\r\nusing ");
            
            #line 40 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(".Common.IdentityConfigurations;\r\n\r\nnamespace ");
            
            #line 42 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write(@".UI.Web.Middlewares;

public static class AddWebRegistrationService
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        _ = services.AddSettingsSingleton<DatabaseOptions>(configuration);
        _ = services.AddSettingsSingleton<IdentityApiConfiguration>(configuration);
        _ = services.AddSettingsSingleton<JwtTokenOptions>(configuration);
        var identityApiSettings = services.AddSettingsSingleton<IdentityApiConfiguration>(configuration);

        services.AddHttpClient<IIdentityServerClientService, IdentityServerClientService>((client) =>
        {
            client.BaseAddress = new Uri(identityApiSettings.BaseAddress);
        });
        ");
            
            #line 57 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"

        WriteLine("");
        if(datasource["UseCache"].Value<bool>() == true)
        {
        WriteLine("\t\tservices.AddDistributedMemoryCache();");
        WriteLine("\t\tvar cacheSettings = services.AddSettingsSingleton<CacheSettings>(configuration);");
        WriteLine("\t\tservices.AddRedis(cacheSettings);");
        }
        
            
            #line default
            #line hidden
            this.Write("        ");
            
            #line 66 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"

        WriteLine("");
        if(datasource["UseRabbitMq"].Value<bool>() == true)
        {
        WriteLine("\t\tservices.AddAmqpServices(configuration);");
        }
        
            
            #line default
            #line hidden
            this.Write("        services.AddHttpClient();\r\n        services.AddHttpContextAccessor();\r\n  " +
                    "      services.AddWebMessageServices();\r\n        services.AddAuth();\r\n        ");
            
            #line 77 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"

        WriteLine("");
        if(datasource["SeriLogConfigurations"]["ElasticLogConfiguration"] != null && !string.IsNullOrEmpty(datasource["SeriLogConfigurations"]["ElasticLogConfiguration"]["Uri"].Value<string?>()))
        {
        WriteLine("\t\tservices.AddTransient<LoggerServiceBase, ElasticLogger>();");
        }
        else if(datasource["SeriLogConfigurations"]["FileLogConfiguration"] != null && !string.IsNullOrEmpty(datasource["SeriLogConfigurations"]["FileLogConfiguration"]["FolderPath"].Value<string?>()))
        {
        WriteLine("\t\tservices.AddTransient<LoggerServiceBase, FileLogger>();");
        }
        else if(datasource["SeriLogConfigurations"]["MsSqlLogConfiguration"] != null)
        {
        WriteLine("\t\t//Şimdilik Databaseloggeri destekleyemiyoruz.");
        }
        
            
            #line default
            #line hidden
            this.Write(@"        
        
        ScopeSafeServiceProvider.Create(services);
        return services;
    }

    public static void AddWebMessageServices(this IServiceCollection collection)
    {
        collection.AddSingleton<IDataProtectionProvider>(s => DataProtectionProvider.Create(""");
            
            #line 100 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(datasource["SolutionName"]));
            
            #line default
            #line hidden
            this.Write("\"));\r\n\r\n        collection.Configure<CookieTempDataProviderOptions>(options =>\r\n " +
                    "       {\r\n\r\n        });\r\n        collection.AddSingleton<ITempDataProvider, Cook" +
                    "ieTempDataProvider>();\r\n    }\r\n\r\n    public static IServiceCollection AddAuth(th" +
                    "is IServiceCollection services)\r\n    {\r\n        services.AddAuthentication(Cooki" +
                    "eAuthenticationDefaults.AuthenticationScheme)\r\n                .AddCookie(option" +
                    "s =>\r\n                {\r\n\r\n                    options.ExpireTimeSpan = TimeSpan" +
                    ".FromMinutes(20);\r\n                    options.SlidingExpiration = true;\r\n      " +
                    "              options.AccessDeniedPath = \"/auth/login/\";\r\n                });\r\n\r" +
                    "\n        services.AddScoped<AuthHelper>();\r\n        services.AddScoped<TokenPara" +
                    "meters>();\r\n\r\n        return services;\r\n    }\r\n\r\n    //Redis cache i aktif etmek" +
                    " için çağırabilirsiniz. \r\n    public static void AddRedis(this IServiceCollectio" +
                    "n services, CacheSettings cacheSettings)\r\n    {\r\n        services.AddStackExchan" +
                    "geRedisCache(opt =>\r\n        {\r\n\r\n            opt.ConfigurationOptions = new Con" +
                    "figurationOptions\r\n            {\r\n                Password = cacheSettings.Passw" +
                    "ord,\r\n                EndPoints =\r\n                    {\r\n                      " +
                    "  { cacheSettings.Host, int.Parse(cacheSettings.Port) }\r\n                    },\r" +
                    "\n            };\r\n        });\r\n    }\r\n\r\n    public static T AddSettingsSingleton<" +
                    "T>(this IServiceCollection services, IConfiguration configuration)\r\n        wher" +
                    "e T : class, new()\r\n    {\r\n        T settings = new T();\r\n        configuration." +
                    "GetSection(settings.GetType().Name).Bind(settings);\r\n\r\n        services.Configur" +
                    "e<T>(options =>\r\n        {\r\n            options = settings;\r\n        });\r\n      " +
                    "  services.AddSingleton<T>(sp =>\r\n        {\r\n            return settings;\r\n     " +
                    "   });\r\n\r\n        return settings;\r\n    }\r\n\r\n\r\n    //Masstransit rabbitMq ayarla" +
                    "rını aktif etmek için çağırabilirsiniz. \r\n    public static void AddAmqpServices" +
                    "(this IServiceCollection services, IConfiguration configuration)\r\n    {\r\n       " +
                    " //consumerName alanlarına kuyruk isimleri girerek çoklayabilirsiniz.\r\n        /" +
                    "/services.AddScoped<consumerName>();\r\n        services.AddMassTransit(x =>\r\n    " +
                    "    {\r\n          //  x.AddConsumer<consumerName>();\r\n            x.UsingRabbitMq" +
                    "((ctx, cfg) =>\r\n            {\r\n                cfg.Host(configuration[\"RabbitMq:" +
                    "Host\"], ushort.Parse(configuration[\"RabbitMq:Port\"]), \"/\", host =>\r\n            " +
                    "    {\r\n                    host.Username(configuration[\"RabbitMq:UserName\"]);\r\n " +
                    "                   host.Password(configuration[\"RabbitMq:Password\"]);\r\n         " +
                    "       });\r\n\r\n                //kuyruk isimlerini Common altında QueueNames enum" +
                    " u ile tutmanız önerilir.\r\n                //cfg.ReceiveEndpoint(queueName.GetDe" +
                    "scription(), e =>\r\n                //{\r\n                //    e.PrefetchCount = " +
                    "100;\r\n                //    e.ConfigureConsumer(ctx, typeof(consumerName));\r\n\r\n " +
                    "               //});\r\n\r\n            });\r\n        });\r\n\r\n        services.Configu" +
                    "re<MassTransitHostOptions>(options =>\r\n        {\r\n            options.WaitUntilS" +
                    "tarted = false;\r\n            options.StartTimeout = TimeSpan.FromSeconds(5);\r\n  " +
                    "          options.StopTimeout = TimeSpan.FromMinutes(1);\r\n        });\r\n\r\n    }\r\n" +
                    "\r\n}\r\n\r\n");
            
            #line 200 "C:\Users\Admin\source\repos\Jumper_Freamwork\Templates\Jumper.CodeGenerator.CqrsBuilder\WebTemplates\WebRegistrationService.tt"
    
FileHelper.CreateAndClearBuilder($"{filePath}/WebRegistrationService.cs",this.GenerationEnvironment);


            
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
    public class WebRegistrationServiceBase
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