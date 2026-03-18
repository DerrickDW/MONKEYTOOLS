using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MONKEYTOOLS;
{

    public class LaunchNethack()
    {

    public string baseDir = AppContext.BaseDirectory;
    public string nethackDir = Path.Combine(baseDir, "Nethack");
    public string cmdexe = Path.Combine(nethackDir, "NetHack.exe");
    public string guiexe = Path.Combine(nethackDir, "NetHackW.exe");
    public string sysconf = Path.Combine(nethackDir, "sysconf.txt");



    if (File.Exists(cmdexe))
        if (!File.Exists(cmdexe))
            Console.WriteLine("🚬🐒 No Nethack CMD Exists RIP");

    if (File.Exists(guiexe))
        if (!File.Exists(guiexe))
            Console.WriteLine("🚬🐒 No Nethack GUi Exists RIP");

    if (!File.Exists(cmdexe) && !File.Exists(guiexe))
        Console.WriteLine("🚬🐒 No Nethack exe's at all WTF Closing Now");
    

    if (File.Exists(sysconf))
        File.ReadAllText(sysconf).Contains("portable_device_paths = 1");
    string content = File.ReadAllText(sysconf);
    if (!content.Contains("portable_device_paths = 1"))
        File.AppendAllText(sysconf, "portable_device_paths = 1");

    if (!File.Exists(sysconf))
        File.WriteAllText(sysconf, "portable_device_paths = 1");


    Console.WriteLine("🚬🐒Nethack Loaded, sorry about your productivity dude");
    Console.WriteLine("type 'exit' to quit");
    Console.Write("> 1 Nethack CMD line" +
        "> 2 Netack GUI");
    string input = Console.ReadLine() ?? "";
    if (string.IsNullOrWhiteSpace(input))

        if (input.ToLower() == "exit")


            if (input.ToLower() == "1")
                Process.Start(new ProcessStartInfo
                {
                    FileName = cmdexe,
                    WorkingDirectory = nethackDir,
                    UseShellExecute = true
                });
    if (input.ToLower() == "2")
        Process.Start(new ProcessStartInfo
        {
            FileName = guiexe,
            WorkingDirectory = nethackDir,
            UseShellExecute = true
        });

    }

}
