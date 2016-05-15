namespace EF_Code_First.Migrations
{
    using System;

    using EF_Code_First.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ChatDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(ChatDbContext context)
        {
            AddUsers(context);

            AddChannels(context);

            AddChannelMessages(context);
        }

        private static void AddUsers(ChatDbContext context)
        {
            var users = new List<User>()
            {
                new User {Username = "VGeorgiev", FullName = "Vladimir Georgiev", PhoneNumber = "0894545454"},
                new User {Username = "Nakov", FullName = "Svetlin Nakov", PhoneNumber = "0897878787"},
                new User {Username = "Ache", FullName = "Angel Georgiev", PhoneNumber = "0897121212"},
                new User {Username = "Alex", FullName = "Alexandra Svilarova", PhoneNumber = "0894151417"},
                new User {Username = "Petya", FullName = "Petya Grozdarska", PhoneNumber = "0895464646"}
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }

        private static void AddChannels(ChatDbContext context)
        {
            var channels = new List<Channel>
            {
                new Channel {Name = "Malinki"},
                new Channel {Name = "SoftUni"},
                new Channel {Name = "Admins"},
                new Channel {Name = "Programmers"},
                new Channel {Name = "Geeks"},
            };

            foreach (var channel in channels)
            {
                context.Channels.Add(channel);
            }

            context.SaveChanges();
        }

        private void AddChannelMessages(ChatDbContext context)
        {
            var channelMalinki = context.Channels.FirstOrDefault(x => x.Name == "Malinki");
            var nakov = context.Users.FirstOrDefault(x => x.Username == "Nakov");
            var vlado = context.Users.FirstOrDefault(x => x.Username == "VGeorgiev");
            var petya = context.Users.FirstOrDefault(x => x.Username == "Petya");

            var channelMessages = new List<ChannelMessage>
            {
                new ChannelMessage { ChannelId = channelMalinki.Id, Content = "Hey dudes, are you ready for tonight?", DateTime = DateTime.Now, UserId = petya.Id },
                new ChannelMessage { ChannelId = channelMalinki.Id, Content = "Hey Petya, this is the SoftUni chat.", DateTime = DateTime.Now, UserId = vlado.Id },
                new ChannelMessage { ChannelId = channelMalinki.Id, Content = "Hahaha, we are ready!", DateTime = DateTime.Now, UserId = nakov.Id },
                new ChannelMessage { ChannelId = channelMalinki.Id, Content = "Oh my god. I mean for drinking some beer!", DateTime = DateTime.Now, UserId = petya.Id },
                new ChannelMessage { ChannelId = channelMalinki.Id, Content = "We are sure!", DateTime = DateTime.Now, UserId = vlado.Id },
            };

            foreach (var channelMessage in channelMessages)
            {
                context.ChannelMessages.Add(channelMessage);
            }

            context.SaveChanges();
        }
    }
}
