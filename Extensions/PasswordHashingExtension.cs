using System.Security.Cryptography;
using System.Text;

namespace ShoxShop.Extension;
public static class PasswordHashingExtension
{
    public static string ToSha256(this string input)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(input);
        using var sha256 = SHA256.Create();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = sha256.ComputeHash(inputBytes);
        return Encoding.UTF8.GetString(hashBytes);
    }
}