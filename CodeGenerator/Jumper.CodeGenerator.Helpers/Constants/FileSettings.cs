namespace Jumper.CodeGenerator.Helpers.Constants;

/// <summary>
/// Todo Alper Canlıya Alırken unutma kafana göre path vermekle olmuyor bu işler.
/// </summary>
public class FileSettings
{
    public static string ExternalDllDirectory = $"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.FullName}/_Dependencies/Architectures";

    public static string ProjectCreateDirectory = $"{Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName}/";

    public static string ReadProjectPath = $"{Environment.CurrentDirectory}/wwwroot/executingProject.json";
}

