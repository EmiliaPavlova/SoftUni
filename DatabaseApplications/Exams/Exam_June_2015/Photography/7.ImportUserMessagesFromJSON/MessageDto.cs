﻿namespace _7.ImportUserMessagesFromJSON
{
    using System;

    class MessageDto
    {
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public string Recipient { get; set; }

        public string Sender { get; set; }
    }
}
