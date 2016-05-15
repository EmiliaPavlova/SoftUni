namespace EF_Code_First.Models
{
    using System.Collections.Generic;

    public class Channel
    {
        private ICollection<User> users;
        private ICollection<ChannelMessage> channelMessages;

        public Channel()
        {
            this.users = new HashSet<User>();
            this.channelMessages = new HashSet<ChannelMessage>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<ChannelMessage> ChannelMessages
        {
            get { return this.channelMessages; }
            set { this.channelMessages = value; }
        }
    }
}
