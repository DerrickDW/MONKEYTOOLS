using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace MONKEYTOOLS.Hash;
using System.Security.Cryptography;
using System.Text;
using System;
// TODO:
// Finish Runner Logic, Args, User Input, Help
// Add Comparision Function
// Wire Into Launcher
// Desired Uses <file> [--algo-'algorithm'] (default SHA256) <file> <hash> (compare) <hash1> <hash2> (compare user supplied hashes)
// <value> --detect-algo (detects algorithm of supplied hash)
public class Hash
{
    public static void Run(string[] args)

    {
        if (args.Length == 0)
        {
            Console.WriteLine("Hash Checker");
            Console.WriteLine("🚬🐒Monkey Generate Hash and/or Make Sure Hashes Match");
            Console.WriteLine("Usage: <file path>, <hash to compare> [--compute-hash] [--detect-algo]");
            Console.WriteLine("Type 'exit' to Quit or 'help' for Help");
        }

        static string ComputeHash(string path, string algorithm = "sha256")
    {
        using var stream = File.OpenRead(path);

        byte[] hashBytes = algorithm.ToLowerInvariant() switch
        {
            "md5" => MD5.HashData(stream),
            "sha1" => SHA1.HashData(stream),
            "sha256" => SHA256.HashData(stream),
            "sha384" => SHA384.HashData(stream),
            "sha512" => SHA512.HashData(stream),
            _ => throw new ArgumentException($"Unsupported algorithm: {algorithm}")
        };
        
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
        
        static string? DetectHashAlgorithm(string hash)
        {
            hash = hash.Trim();

            return hash.Length switch
            {
                32 => "md5",
                40 => "sha1",
                64 => "sha256",
                96 => "sha384",
                128 => "sha512",
                _ => "null"
            };
        }

        var actual = ComputeHash(path, algorithm);
        var expected = expectedHash.Trim().ToLowerInvariant();
        //if hashBytes && expectedHash != DetectHashAlgorithm;
            //Console.WriteLine("Hash Algorithms Do Not Match");
            
        Console.WriteLine(actual == expected ? "Match" : "No Match");
    }
}