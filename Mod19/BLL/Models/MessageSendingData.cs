using System;
using System.Collections.Generic;
using System.Text;

namespace Mod19.BLL.Models
{
    internal class MessageSendingData
    {
        public int SenderId { get; set; }
        public string Content { get; set; }
        public string RecipientEmail { get; set; }
    }
}
