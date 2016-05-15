namespace EF_Code_First.Models
{
    using System;

    public class ChannelMessage
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
