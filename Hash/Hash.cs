using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace MONKEYTOOLS.Hash;
using System.Security.Cryptography;
using System.Text;
using System;

public class Hash
{
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