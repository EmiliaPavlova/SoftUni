namespace _6.EFCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new ChatDbContext();
            var channels = context.Channels
                .Include(c => c.ChannelMessages)
                .Include("ChannelMessages.User")
                .Select(c => new
                {
                    c.Name,
                    ChannelMessages = c.ChannelMessages.Select(cm => new
                    {
                        cm.Content,
                        cm.DateTime,
                        cm.User.Username
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
