namespace Jumper.CodeGenerator.Helpers.FileHelpers;

public class FileHelper
{
    public void Create(string fullPath, string content)
    {
        DeleteIfExists(fullPath);

        using (StreamWriter writer = new StreamWriter($"{fullPath}", false))
        {
            writer.Write(content);
            writer.Close();
            writer.Dispose();
        }
    }

    public async Task<string> GetFileContent(string fullPath)
    {
        return await File.ReadAllTextAsync(fullPath);
    }

    public void DeleteIfExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

}
