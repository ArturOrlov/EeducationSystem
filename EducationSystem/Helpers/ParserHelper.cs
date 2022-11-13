using System.Text.RegularExpressions;

namespace EducationSystem.Helpers;

public class ParserHelper
{
    private static Regex PhoneRegex =
        new Regex(@"(^\s*(?<phone>(^8|7|\+7)((\d{10})|(\s\(\d{3}\)\s\d{3}\s\d{2}\s\d{2}))))");

    private static Regex EmailRegex =
        new Regex(
            @"^\s*(?<email>(?:^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)))");

    public static bool TryParsePhoneNumber(string str, out string phoneNumber)
    {
        if (string.IsNullOrEmpty(str))
        {
            phoneNumber = null;
        }

        string phone = str;
        phone = phone.Replace("(", "")
            .Replace(")", "")
            .Replace(" ", "")
            .Replace("-", "")
            .Replace("+", "")
            .Trim(' ');

        if (phone.StartsWith("8"))
        {
            phone = "7" + phone.Substring(1);
        }

        if (phone.StartsWith("+") == false)
        {
            phone = "+" + phone;
        }

        Match result = PhoneRegex.Match(phone);

        if (result.Success)
        {
            phoneNumber = result.Groups["phone"].Value;
            return true;
        }

        phoneNumber = null;
        return false;
    }

    public static bool TryParseEmail(string str, out string email)
    {
        email = null;

        if (string.IsNullOrEmpty(str))
        {
            return false;
        }

        string e = str.Trim(' ').ToLower();

        Match result = EmailRegex.Match(e);

        if (result.Success)
        {
            email = result.Groups["email"].Value;
            return true;
        }

        return false;
    }
}