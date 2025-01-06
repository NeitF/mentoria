using System.Text;

namespace BusinessLogic.Extensions;

public static class StringHelpers
{
    private static readonly Random random = new Random();
    
    public static string GenerateRandomString(int length)
    {
        const string chars = "abcdefgh9";
        StringBuilder result = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            result.Append(chars[random.Next(chars.Length)]);
        }

        return result.ToString();
    }
}