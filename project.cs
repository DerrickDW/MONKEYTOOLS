using MONKEYTOOLS.Calc;
using MONKEYTOOLS.Scan;
using MONKEYTOOLS.Sort;
using MONKEYTOOLS;
using MONKEYTOOLS.Hash;

class Program
{

    static void Main(string[] args)
    {

    public interface ICommand
    {
        string Name { get; }
        string Description { get; }
        void Run(string[] args);
    }

    private var commands = new Dictionary<string, ICommand>(
        StringComparer.OrdinalIgnoreCase)
    {
        //define commands
        ["scan"] = new ScanCommand(),
        ["sort"] = new SortCommand(),
        ["hash"] = new SortCommand(),
        ["nethack"] = new SortCommand(),
    };
        Console.WriteLine("MONKEYTOOLS");
        Console.WriteLine("🐒 systems stable");
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: monkey <tool>");
            return;
        }
        //get off the switch case
        /*
        string tool = args[0].ToLower();

        switch (tool)
        {
            case "calc":
                Calc.Run();
                break;

            case "scan":
                Scan.Run(args.Skip(1).ToArray());
                break;

            case "nethack":
                NethackWrapper.Run(args.Skip(1).ToArray());
                break;
            
            case "sort":
                Sort.Run(args.Skip(1).ToArray());
                break;
            
            case "hash":
                Hash.Run(args.Skip(1).ToArray());
                break;
            //case "ugly":
            //Ugly.Run(args.Skip(1).ToArray());
            //break;

            //case "wireshark":
            //LaunchExternal("external/wireshark/Wireshark.exe");
            //break;

            default:
                Console.WriteLine($"🚬🐒 unknown tool: {tool}");
                break;
        }  
        */
    }
}