using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ViewMessagesApplication.Models
{
    [MetadataType(typeof(ConsoleMessage_Metadata))]
    public partial class ConsoleMessage
    {
    }
    public class ConsoleMessage_Metadata
    {
        public int ID { get; set; }
        [DisplayName("Meddelanden")]
        public string Text { get; set; }
        public DateTime Tid { get; set; }
    }
}