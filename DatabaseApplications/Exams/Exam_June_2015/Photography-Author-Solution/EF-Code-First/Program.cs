namespace EF_Code_First
{
    using System;
    using System.Collections.Specialized;
    using System.Data.Entity;
    using System.Linq;

    using EF_Code_First.Models;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new ChatDbContext();
            var channels = context.Channels
                .Include(x => x.ChannelMessages)
                .Include("ChannelMessages.User")
                .Select(x => new
                {
                    x.Name,
                    ChannelMessages = x.ChannelMessages.Select(c => new
                    {
                        c.Content,
                        c.DateTime,
                        c.User.Username
                    })
                });
            foreach (var channel in channels)
            {
                Console.WriteLine(channel.Name);
                Console.WriteLine("-- Messages: --");
                foreach (var channelMessage in channel.ChannelMessages)
                {
                    Console.WriteLine("Content: {0}, DateTime: {1}, User: {2}", channelMessage.Content, channelMessage.DateTime, channelMessage.Username);
                }
                Console.WriteLine();
            }
        }
    }
}
