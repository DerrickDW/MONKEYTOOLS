using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MONKEYTOOLS;


public class NethackWrapper
{

    public static void Run(string[] args)
    {
        LaunchNethack();
    }

    static void LaunchNethack()
    {
        //Little hacky but grab root or exe location when built
        static string GetNetHackDir()
        {
#if DEBUG
            return Path.GetFullPath(
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Nethack")
                );
#else
            return Path.Combine(AppContext.BaseDirectory, "Nethack")
#endif
        }

        string cmdexe = Path.Combine(GetNetHackDir(), "Nethack.exe");
        string guiexe = Path.Combine(GetNetHackDir(), "NetHackW.exe");
        string sysconf = Path.Combine(GetNetHackDir(), "sysconf.txt");

        if (!File.Exists(cmdexe))
        {
            Console.WriteLine("🚬🐒 No Nethack CMD Exists RIP");
            return;
        }

        if (!File.Exists(guiexe))
        {
            Console.WriteLine("🚬🐒 No Nethack GUi Exists RIP");
            return;
        }

        if (!File.Exists(sysconf))
        {
            File.WriteAllText(sysconf, "portable_device_paths = 1");
            Console.WriteLine("🐒 Wrote sysconf for ya");
        }

        if (File.Exists(sysconf))
        {
            File.ReadAllText(sysconf).Contains("portable_device_paths = 1");
            Console.WriteLine("🐒 sysconf smells correct");
        }
        string content = File.ReadAllText(sysconf);
        if (!content.Contains("portable_device_paths = 1"))
        {
            File.AppendAllText(sysconf, "portable_device_paths");
            Console.WriteLine("🐒 Fixed sysconf");
        }
        
        Console.WriteLine("🚬🐒Nethack Loaded, sorry about your productivity dude");
        Console.WriteLine("1) Nethack CMD line");
        Console.WriteLine("2) Netack GUI");
        Console.WriteLine("type 'exit' to quit");
        Console.Write(">");
        string input = Console.ReadLine() ?? "";
        if (string.IsNullOrWhiteSpace(input))
        {
            if (input.ToLower() == "exit")


                if (input.ToLower() == "1") ;

        }
        //FIGURE OUT THE ARGS
        Process.Start(new ProcessStartInfo
        {
            FileName = cmdexe,
            WorkingDirectory = GetNetHackDir(),
            //Arguments = "--cmd",
            UseShellExecute = true

        });
        if (input.ToLower() == "2")
            Process.Start(new ProcessStartInfo
            {
                FileName = guiexe,
                WorkingDirectory = GetNetHackDir(),
                //Arguments = "--gui",
                UseShellExecute = true
            });
        }
    }


    




