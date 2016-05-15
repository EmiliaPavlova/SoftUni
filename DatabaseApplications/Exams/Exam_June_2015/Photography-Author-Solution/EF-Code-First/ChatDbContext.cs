namespace EF_Code_First
{
    using System.Data.Entity;

    using EF_Code_First.Models;
    using EF_Code_First.Migrations;

    public class ChatDbContext : DbContext
    {
        public ChatDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatDbContext, Configuration>());
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Channel> Channels { get; set; }

        public IDbSet<UserMessage> UserMessages { get; set; }

        public IDbSet<ChannelMessage> ChannelMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserMessage>()
                .HasRequired(x => x.Sender)
                .WithMany(x => x.SentUserMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserMessage>()
                .HasRequired(x => x.Recipient)
                .WithMany(x => x.RecievedUserMessages)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
