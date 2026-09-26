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
        
        string originPath = Path.GetFullPath(args[0]);

        if (!Directory.Exists(originPath))
        {
            Console.WriteLine("No Folder Found"); 
        }
        SortLogic.RunLogic(originPath: originPath);
        
    }
}
