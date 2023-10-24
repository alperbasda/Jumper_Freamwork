using System.Text;

namespace Jumper.Common.FileHelpers;

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

    public static void CreateAndClearBuilder(string fullPath, StringBuilder builder)
    {
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }

        File.WriteAllText(fullPath, builder.ToString());

        builder.Remove(0, builder.Length);
    }


    public void DeleteIfExists(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

}
