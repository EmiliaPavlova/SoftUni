using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Import_User_Messages_from_Json
{
    class MessageDto
    {
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public string Recipient { get; set; }

        public string Sender { get; set; }
    }
}
