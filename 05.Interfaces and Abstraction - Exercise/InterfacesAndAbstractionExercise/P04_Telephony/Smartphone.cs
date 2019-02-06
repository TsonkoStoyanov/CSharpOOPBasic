using System.Linq;

namespace P04_Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                return $"Invalid URL!";
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (number.Any(char.IsLetter))
            {
                return $"Invalid number!";
            }

            return $"Calling... {number}";
        }
    }
}