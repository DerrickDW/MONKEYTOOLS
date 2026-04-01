using System.Linq;
using System.Text;
namespace MONKEYTOOLS.Sort;

public class Sort
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
        
        string root = args[0];
        if (!Directory.Exists(root))
        {
            Console.WriteLine(" Folder does not exist");
        }

        foreach (var file in Directory.GetFiles(root))
        {
            HandleFile(file, root);
        }
    }
}
