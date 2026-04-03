using System.Text.RegularExpressions;
using System.IO;
using System.Linq;
using System;
using System.Net;


namespace MONKEYTOOLS.Sort;

    public static class SortLogic
    {
        public static void RunLogic(string originPath)
        {
            var files = Directory.EnumerateFiles(originPath);

            foreach (var file  in files)
            
            {
                Console.WriteLine(file);
            }
        }
        private static IEnumerable<string> GetVideoFiles;
        {
            string[] ext = [".mp4", ".mkv", ".avi", ".mov"];
            return Directory.EnumerateFiles(originPath, "*.*", SearchOption.TopDirectoryOnly)
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
    }
    