using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;

namespace MONKEYTOOLS.Scan;

public static class Scan
{
    private static readonly Dictionary<int, string> Services = new()
    {
        {22, "ssh"},
        {80, "http"},
        {443, "https"},
        {445, "smb"},
        {548, "afp"},
        {631, "ipp"},
        {9100, "printer-raw"},
        {3389, "rdp"},
        {3306, "mysql"},
        {5432, "postgres"},
        {6379, "redis"},
        {8080, "http-alt"},
    };

    private static readonly int[] CuriousPorts =
    {
        22, 80, 443, 445, 548, 631, 9100, 3389, 3306, 5432, 6379, 8080
    };

    public static void Run(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Usage monkey scan <host> [--curious]");
            return;
        }

        string host = args[0];
        bool curious = Array.Exists(args, a => a == "--curious");

        if (host.EndsWith("/24"))
        {
            SweepSubnet(host, curious);
            return;
        }

        ScanHost(host, curious);

        Console.WriteLine($"🐒 scanning {host}");

        
        if (curious)
            Console.WriteLine("🐒 monkey is feeling curious...");



        Console.WriteLine("\n🐒 scan finished");
    }

    private static void ScanHost(string host, bool curious)
    {

        Console.WriteLine($"\nHost: {host}");

        int[] ports = curious ? CuriousPorts : BuildRange(1, 1024);

        List<int> openPorts = new();

        int total = ports.Length;
        int checkedCount = 0;

        foreach (int port in ports)
        {
            CheckPort(host, port, openPorts);

            checkedCount++;
            PrintProgress(checkedCount, total);
        }

        PrintDeviceGuess(openPorts);
    }

    private static void SweepSubnet(string subnet, bool curious)
    {
        string baseIp = subnet.Replace(".0/24", "");
        Console.WriteLine($"🐒 sweeping {subnet}...");

        for (int i = 1; i <= 254; i++)
        {
            string ip = $"{baseIp}.{i}";
            ScanHost(ip, curious);
        }
    }
    

    private static int[] BuildRange(int start, int end)
{
    List<int> list = new();

    for (int i = start; i <= end; i++)
        list.Add(i);

    return list.ToArray();
}

    private static void CheckPort(string host, int port, List<int> openPorts)
    {
        try
        {
            using TcpClient client = new();

            var result = client.BeginConnect(host, port, null, null);
            bool success = result.AsyncWaitHandle.WaitOne(200);

            if (!success)
                return;

            client.EndConnect(result);

            openPorts.Add(port);

            string service = Services.ContainsKey(port) ? Services[port] : "unknown";

            Console.Write($"{port,-5} open {service}");

            string banner = GrabBanner(client, port);

            Console.WriteLine($"DEBUG open port: {port}");

            if (!string.IsNullOrWhiteSpace(banner))
                Console.Write($"  [{banner}");

            Console.WriteLine();

            if (port == 3306 || port == 5432 || port == 6379)
                Console.WriteLine("🚬🐒 sombody left their database open....");
        }
        catch
        {
        }
    }

    private static string GrabBanner(TcpClient client, int port)
    {
        try
        {
            NetworkStream stream = client.GetStream();
            if (port == 80 || port == 8080)
            {
                string request = "HEAD / HTTP/1.1\r\nHost: test\r\nConnection: close\r\n\r\n";
                byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                stream.Write(requestBytes, 0, requestBytes.Length);
            }

            byte[] buffer = new byte[256];
            int bytes = stream.Read(buffer, 0, buffer.Length);

            if (bytes <= 0)
                return "";

            string banner = Encoding.ASCII.GetString(buffer, 0, bytes);

            banner = banner.Replace("\r", "").Replace("\n", " ").Trim();

            if (banner.Length > 60)
                banner = banner.Substring(0, 60);
            return banner;
        }
        catch
        {
            return "";
        }
    }

    private static void PrintProgress(int current, int total)
    {
        int width = 20;

        double percent = (double)current / total;

        int filled = (int)(percent * width);

        string bar =
            new string('#', filled) +
            new string('-', width - filled);

        Console.Write($"\r[{bar}] {current}/{total}");
    }
  
        private static void PrintDeviceGuess(List<int> openPorts)
    {
        Console.WriteLine();

        bool hasHttp = openPorts.Contains(80) || openPorts.Contains(443) || openPorts.Contains(8080);
        bool hasSmb = openPorts.Contains(445);
        bool hasSsh = openPorts.Contains(22);
        bool hasPrinter = openPorts.Contains(9100) || openPorts.Contains(631);
        bool hasAfp = openPorts.Contains(548);
        bool hasRdp = openPorts.Contains(3389);
        bool hasDb = openPorts.Contains(3306) || openPorts.Contains(5432) || openPorts.Contains(6379);

        if (hasPrinter)
        {
            Console.WriteLine("🐒 monkey guess: printer or print server");
                return;
        }

        if (hasHttp && hasSmb)
        {
            Console.WriteLine("🐒 monkey guess: nas or shared storage box");
            return;
        }

        if (hasHttp && !hasSsh && !hasSmb && !hasDb)
        {
            Console.WriteLine("🐒 monkey guess: router, camera, or web-managed device");
            return;
        }

        if (hasSsh && hasHttp)
        {
            Console.WriteLine("🐒 monkey guess: linux box with web panel");
            return;
        }

        if (hasSsh)
        {
            Console.WriteLine("🐒 monkey guess: windows machine");
            return;
        }

        if (hasDb)
        {
            Console.WriteLine("🚬🐒 monkey guess: database box doing irresponsible things...");
            return;
        }

        if (openPorts.Count == 0)
        {
            Console.WriteLine("🚬🐒 ain't nothing there chief");
            return;
        }

        Console.WriteLine("🐒 monkey guess: weird box, needs more poking");
    }
}

