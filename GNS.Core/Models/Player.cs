using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GNS.Core.Models
{
    public class Player
    {
        public Guid PlayerId { get; set; }

        [ForeignKey( "GroupId" )]
        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
