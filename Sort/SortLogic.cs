using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System;

namespace MONKEYTOOLS.Sort;
static readonly Regex Tv = new Regex(@"\S(d\{1,2})E(\d{1,2})", RegexOptions.IgnoreCase);

public static class SortLogic
{
    public static void RunLogic(path);
    {
        var files = Directory.EnumerateFiles(path);

        foreach (var file in files) ;
        {
            ProcessFile(files, path);
        }
    }
    private static IEnumerable<string> GetVideoViles;
    {
        string[] ext = [".mp4", ".mkv", ".avi", ".mov"];
        return Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly)
            .Where(f => exts.Contains(Path.GetFileNameWithoutExtension(f), StringComparer.OrdinalIgnoreCase));
    }

    static void ProcessFile(string filePath, string path)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        bool isTv = LooksLikeTv(fileName);
        string normalizedName = NormalizeName(fileName);
        
        string destinationDir = isTv
            ? Path.Combine(path, "tv")
            : Path.Combine(path, "movies");
        if (!Directory.Exists(destinationDir))
            Directory.CreateDirectory(destinationDir);
        
        string destPath = Path.Combine(destinationDir, Path.GetFileName(filePath));
        
        Console.WriteLine($"MOVE: {filePath} -> {destPath}");
    }
    


