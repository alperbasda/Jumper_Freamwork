using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.CodeGenerator.Helpers.Constants;
using Jumper.CodeGenerator.Helpers.FileHelpers;
using Jumper.Domain.MongoEntities;
using Newtonsoft.Json;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Jumper.CodeGenerator.BuilderBase.Starters;

public class ProjectFileCreatorStarter
{
    private const string M_TRANSFORM = "TransformText";

    FileHelper _fileHelper;

    public ProjectFileCreatorStarter(FileHelper fileHelper)
    {
        _fileHelper = fileHelper;
    }


    public async Task StartProcess(GetWithAllDetailByIdProjectDeclarationResponse project, ArchitectureDefinition architectureDefinition)
    {
        _fileHelper.Create(FileSettings.ReadProjectPath, JsonConvert.SerializeObject(project));

        var templates = Assembly.LoadFile($"{FileSettings.ExternalDllDirectory}\\{architectureDefinition.DllName}").GetTypes().Where(w => w.GetCustomAttribute(typeof(GeneratedCodeAttribute)) != null && !w.Name.EndsWith("Base")).ToList();

        foreach (var template in templates)
        {
            var obj = Activator.CreateInstance(template);
            var mi = template.GetMethod(M_TRANSFORM);
            var res = mi.Invoke(obj, null);
        }

        _fileHelper.DeleteIfExists(FileSettings.ReadProjectPath);


    }

}
