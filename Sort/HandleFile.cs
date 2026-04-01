using System.Text.RegularExpressions;

namespace MONKEYTOOLS.Sort;

public class HandleFile
{
    static readonly Regex Tv = new Regex(@"\S(d\{1,2})E(\d{1,2})", RegexOptions.IgnoreCase);
}

{

public static void GetMediaFiles(string filePath, string root)
{
    string ext = Path.GetExtension(filePath).ToLower();

internal string targetFolder = ext switch;
}
