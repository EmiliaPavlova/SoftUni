namespace _7.ImportUserMessagesFromJSON
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web.Script.Serialization;
    using _6.EFCodeFirst;
    using _6.EFCodeFirst.Models;

    class ImportUserMessagesFromJSON
    {
        static void Main(string[] args)
        {
            var json = File.ReadAllText(@"..\..\messages.json");
            var jsSerializer = new JavaScriptSerializer();
            var parsedMessages = jsSerializer.Deserialize<IEnumerable<MessageDto>>(json);

            foreach (var message in parsedMessages)
            {
                try
                {
                    ImportMessageToDatabase(message);
                    Console.WriteLine("Message \"{0}\" imported", message.Content);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        private static void ImportMessageToDatabase(MessageDto message)
        {
            if (string.IsNullOrWhiteSpace(message.Content))
            {
                throw new ArgumentException("Content is required");
            }

            if (string.IsNullOrWhiteSpace(message.Recipient))
            {
                throw new ArgumentException("Recipient is required");
            }

            if (string.IsNullOrWhiteSpace(message.Sender))
            {
                throw new ArgumentException("Sender is required");
            }

            var context = new ChatDbContext();
            var recipientId = context.Users
                .Where(u => u.Username == message.Recipient)
                .Select(u => u.Id)
                .FirstOrDefault();

            var senderId = context.Users
                .Where(u => u.Username == message.Sender)
                .Select(u => u.Id)
                .FirstOrDefault();

            var newMessage = new UserMessage
            {
                Content = message.Content,
                DateTime = message.DateTime,
                RecipientId = recipientId,
                SenderId = senderId
            };

            context.UserMessages.Add(newMessage);
            context.SaveChanges();
        }
    }
}
