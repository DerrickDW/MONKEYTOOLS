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
    }
}