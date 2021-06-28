using System;
using System.Collections.Generic;

namespace GNS.Core.Models
{
    public class Group
    {
        public Guid GroupId { get; set; }

        public Guid LedgerId { get; set; }

        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
