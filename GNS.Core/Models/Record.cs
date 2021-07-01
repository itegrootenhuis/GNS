using System;

namespace GNS.Core.Models
{
    public class Record
    {
        public Guid RecordId { get; set; }

        public Game Game { get; set; }

        public Player Winner { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
