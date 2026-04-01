using MONKEYTOOLS.Calc;
using MONKEYTOOLS.Scan;
using System;
using System.Linq;
using System.ComponentModel.Design;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using MONKEYTOOLS;
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

            case "scan":
                Scan.Run(args.Skip(1).ToArray());
                break;

            case "nethack":
                NethackWrapper.Run(args.Skip(1).ToArray());
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