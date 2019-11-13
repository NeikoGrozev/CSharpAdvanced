namespace Telephony
{
    using System;
    using System.Linq;

    public class SmartPhone : ICalling, IBrowsing
    {
        public string Calling(string phoneNumber)
        {
            if (phoneNumber.Any(x => !char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browsing(string webSite)
        {
            if (webSite.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {webSite}!";
        }
    }
}