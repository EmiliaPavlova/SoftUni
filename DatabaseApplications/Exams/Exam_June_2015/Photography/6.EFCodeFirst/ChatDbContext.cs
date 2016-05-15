namespace _6.EFCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Migrations;
    using Models;

    public class ChatDbContext : DbContext
    {
        public ChatDbContext()
            : base("name=ChatDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatDbContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Channel> Channels { get; set; }

        public virtual DbSet<UserMessage> UserMessages { get; set; }

        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }

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