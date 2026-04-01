using System.Linq;
namespace MONKEYTOOLS.Sort;

public class Sort
{
    public static void Run(string[] args)
    {
        Console.WriteLine("MONKEY SORT");
        Console.WriteLine("🚬🐒 Monkey Will Sort Your Media Files");
        Console.WriteLine("Type 'help' for more information");
        Console.WriteLine("Type 'exit' to quit");
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: money sort --all, --tv --movie");
        }
    }
}