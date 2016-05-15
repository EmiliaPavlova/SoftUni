namespace EF_Code_First.Models
{
    using System.Collections.Generic;

    public class User
    {
        private ICollection<Channel> channels;
        private ICollection<UserMessage> sentUserMessages;
        private ICollection<UserMessage> recievedUserMessages;

        public User()
        {
            this.channels = new HashSet<Channel>();
            this.sentUserMessages = new HashSet<UserMessage>();
            this.recievedUserMessages = new HashSet<UserMessage>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<UserMessage> SentUserMessages
        {
            get { return this.sentUserMessages; }
            set { this.sentUserMessages = value; }
        }

        public virtual ICollection<UserMessage> RecievedUserMessages
        {
            get { return this.recievedUserMessages; }
            set { this.recievedUserMessages = value; }
        }

        public virtual ICollection<Channel> Channels
        {
            get { return this.channels; }
            set { this.channels = value; }
        }
    }
}
