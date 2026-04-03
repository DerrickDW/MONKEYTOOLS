using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using static System.IO.Directory;

namespace MONKEYTOOLS.Sort;

public static class Sort
{
    public static void Run(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("MONKEY SORT");
            Console.WriteLine("🚬🐒 Monkey Will Sort Your Media Files");
            Console.WriteLine("Type 'help' for more information");
            Console.WriteLine("Type 'exit' to quit");
            Console.WriteLine("Usage: money sort <folder> --all, --tv --movie");
            return;
        }
        
        string path = Path.GetFullPath(args[0]);

        if (Path.Exists(path)) 
            SortLogic.RunLogic(path);
        
        else
        {
            Console.WriteLine("No Folder Found");
        }
    }
}
