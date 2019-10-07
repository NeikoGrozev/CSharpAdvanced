namespace DateModifier
{
    using System;
    using System.Globalization;

    public class DateModifier
    {
        public static int GetDifferenceBetwenTwoDays(string firstStr, string secondStr)
        {
            DateTime firstDate = DateTime.ParseExact(firstStr, "yyyy MM dd", CultureInfo.InvariantCulture);
            DateTime secondDate = DateTime.ParseExact(secondStr, "yyyy MM dd", CultureInfo.InvariantCulture);
            int result = Math.Abs((firstDate - secondDate).Days);

            return result;
        }
    }
}
