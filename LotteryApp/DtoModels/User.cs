using DtoModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DtoModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  Username { get; set; }
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public int  Balance { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public Role Role { get; set; }

    }
}
