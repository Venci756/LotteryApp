using DtoModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DtoModels
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Combination { get; set; }
        public int Round { get; set; }
        public Status Status { get; set; }
        public int Prize { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
