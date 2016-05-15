namespace ChatLogger
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security;
    using System.Text.RegularExpressions;

    class ChatLogger
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.ParseExact(
            Console.ReadLine(),
            "dd-MM-yyyy HH:mm:ss",
            CultureInfo.InvariantCulture);
            var messages = new SortedDictionary<DateTime, string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = Regex.Split(input, @"\s+\/\s+");
                string message = tokens[0];
                DateTime date = DateTime.ParseExact(
                tokens[1],
                "dd-MM-yyyy HH:mm:ss",
                CultureInfo.InvariantCulture);
                messages.Add(date, message);
            }
            foreach (var message in messages)
            {
                Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(message.Value));
            }

            var mostRecentPostDate = messages.Last().Key;
            string time = string.Empty;
            var difference = (today - mostRecentPostDate);
            if (mostRecentPostDate.AddDays(1).Date == today.Date)
            {
                time = "yesterday";
            }
            else if (difference.TotalDays > 1)
            {
                time = string.Format("{0:dd-MM-yyyy}", mostRecentPostDate);
            }
            else
            {
                var seconds = (int)difference.TotalSeconds;
                if (seconds < 60)
                {
                    time = "a few moments ago";
                }
                else if (seconds < 60 * 60)
                {
                    time = string.Format(
                        "{0} minute(s) ago",
                        (int)difference.TotalMinutes);
                }
                else
                {
                    time = string.Format(
                        "{0} hour(s) ago",
                        (int)difference.TotalHours);
                }
            }
            Console.WriteLine("<p>Last active: <time>{0}</time></p>", time);
        }
    }
}
