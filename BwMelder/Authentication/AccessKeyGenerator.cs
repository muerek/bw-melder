using BwMelder.Model;
using System.Security.Cryptography;

namespace BwMelder.Authentication;

public static class AccessKeyGenerator
{
    public static AccessKey GetAccessKey()
    {
        var alphabet = "abcdefghijklmnopqrstuvwxyz123456789";
        var key = RandomNumberGenerator.GetString(alphabet, 14);
        return new AccessKey { Key = key };
    }
}