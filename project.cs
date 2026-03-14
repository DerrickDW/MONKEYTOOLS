using MONKEYTOOLS.Calc;
using System;
using System.ComponentModel.Design;
class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("MONKEYTOOLS");
        Console.WriteLine("🐒 systems stable");
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: monkey <tool>");
            return;
        }
        string tool = args[0].ToLower();
            
        switch (tool)
            {
            case "calc":
                Calc.Run();
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
    }
}