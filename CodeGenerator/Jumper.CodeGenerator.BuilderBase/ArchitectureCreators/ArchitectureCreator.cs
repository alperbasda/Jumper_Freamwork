using Jumper.Application.Features.ProjectDeclarations.Queries.GetWithAllDetailById;
using Jumper.CodeGenerator.BuilderBase.Builders.Processes;
using Jumper.Common.Constants;
using Jumper.Common.DirectoryHelpers;
using Jumper.Domain.MongoEntities;

namespace Jumper.CodeGenerator.BuilderBase.ArchitectureCreators;

public class ArchitectureCreator : IArchitectureCreator
{
    private readonly ProcessBuilder _processBuilder;
    private GetWithAllDetailByIdProjectDeclarationResponse _project;
    private ArchitectureDefinition _architectureDefinition;

    public ArchitectureCreator()
    { 
        _processBuilder = new ProcessBuilder();
        _processBuilder.SetFileName("dotnet")
            .SetUseShellExecute(false)
            .SetRedirectStandardOutput(true)
            .SetRedirectStandardError(true)
            .SetCreateNoWindow(true);
    }

    public void Create(GetWithAllDetailByIdProjectDeclarationResponse project, ArchitectureDefinition architectureDefinition)
    {
        _project = project;
        _architectureDefinition = architectureDefinition;

        CreateSolution();
        CreateTypedProjects();

        _processBuilder.Exit();
    }

    private void CreateSolution()
    {
        var solutionFolder = $"{FileSettings.ProjectCreateDirectory}/{_project.SolutionName}";
        DirectoryHelper.CreateDirectoryIfNotExists(solutionFolder);

        _processBuilder
            .SetArguments($"new sln -o {solutionFolder} --name {_project.SolutionName} --force")
            .SetWorkingDirectory(solutionFolder)
            .Execute();

    }
    private void CreateTypedProjects()
    {
        foreach (var projectItem in _architectureDefinition.Projects)
        {
            var projectCreatePath = $"{FileSettings.ProjectCreateDirectory}/{_project.SolutionName}/{projectItem.Folder}/{_project.SolutionName}.{projectItem.Name}";
            
            DirectoryHelper.CreateDirectoryIfNotExists(projectCreatePath);
            
            _processBuilder
            .SetArguments($"new {projectItem.DotnetType} -o {projectCreatePath} --name {_project.SolutionName} --solutionname  {_project.SolutionName} --force")
            .SetWorkingDirectory(projectCreatePath)
            .Execute();
            
            _processBuilder
            .SetArguments($"sln add  {projectCreatePath}/{_project.SolutionName}.{projectItem.Name}.csproj")
            .SetWorkingDirectory($"{FileSettings.ProjectCreateDirectory}/{_project.SolutionName}")
            .Execute();
        }

        RestoreSolution();

    }

    private void RestoreSolution()
    {
        _processBuilder.SetWorkingDirectory($"{FileSettings.ProjectCreateDirectory}/{_project.SolutionName}").SetArguments("restore").Execute();
    }

}
