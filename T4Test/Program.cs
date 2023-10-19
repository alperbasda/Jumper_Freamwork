using Jumper.Application;
using Jumper.Persistance;
using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using T4Test;
using System.Reflection;

var builder = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json");
var configuration = builder.Build();


var serviceCollection = new ServiceCollection()
    .AddCodeGeneratorServices(configuration)
    .AddApplicationServices(configuration)
    .AddPersistenceServices(configuration)
    .BuildServiceProvider();

new EntityTemplate().TransformText();

var mediator = serviceCollection.GetRequiredService<IMediator>();

var project = await mediator.Send(new GetWithAllDetailByIdProjectDeclarationQuery { Id = Guid.Parse("808D2FFF-57E4-4D3F-960E-2233A7F71882"), ArchitectureId = Guid.Parse("2DB2A671-25DC-447D-9EF3-A2E617A7745E") });

File.WriteAllText($"{project.SolutionName}.json", JsonConvert.SerializeObject(project));

Console.WriteLine("Dosya Yazıldı");

Console.ReadKey();

