using System;
using System.Collections.Generic;

namespace GNS.Core.Models
{
    public class Record
    {
        public Guid RecordId { get; set; }

        public Game Game { get; set; }

        public ICollection<Player> Winners { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
