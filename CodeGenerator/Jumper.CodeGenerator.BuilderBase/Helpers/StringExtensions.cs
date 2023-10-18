using System.Text;

namespace Jumper.CodeGenerator.BuilderBase.Helpers;

public static class StringExtensions
{

    static Dictionary<char, char> turkishToEnglishMap = new Dictionary<char, char>
        {
            { 'ç', 'c' },
            { 'ğ', 'g' },
            { 'ı', 'i' },
            { 'ö', 'o' },
            { 'ş', 's' },
            { 'ü', 'u' },
            { 'Ç', 'C' },
            { 'Ğ', 'G' },
            { 'İ', 'I' },
            { 'Ö', 'O' },
            { 'Ş', 'S' },
            { 'Ü', 'U' }
            // Diğer Türkçe karakterleri ekleyebilirsiniz
        };

    /// <summary>
    /// TÜrkçe karakterleri ingilizce karaktere dönüştürür
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToEng(this string text)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in text)
        {
            if (turkishToEnglishMap.ContainsKey(c))
            {
                result.Append(turkishToEnglishMap[c]);
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }


    /// <summary>
    /// Verilen kelimeyi çoğul yapar
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToPlural(this string text)
    {
        // Bazı temel kurallara göre çoğul halini dönüştürmek için koşullar ekleyebilirsiniz.
        if (text.EndsWith("s") || text.EndsWith("x") || text.EndsWith("z") || text.EndsWith("ch") || text.EndsWith("sh"))
        {
            return text + "es";
        }
        else if (text.EndsWith("y"))
        {
            // "y" ünlü harfle bitiyorsa, "y" harfini "ies" ile değiştirin.
            return text.Substring(0, text.Length - 1) + "ies";
        }
        else
        {
            // Yukarıdaki kurallara uymuyorsa, textnin sonuna sadece "s" ekleyin.
            return text + "s";
        }
    }

    /// <summary>
    /// Verilen string ifadenin ilk harfini küçültür.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToCamelCase(this string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return "";
        }
        char firstChar = char.ToLower(text[0]);
        string restOfString = text.Substring(1);
        return firstChar + restOfString;
    }
}
