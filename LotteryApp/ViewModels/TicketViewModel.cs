using DtoModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
    public class TicketViewModel
    {
        public string Combination { get; set; }
        public int Round { get; set; }
        public Status Status { get; set; }
        public int Prize { get; set; }
    }
}
