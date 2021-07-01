using System;
using System.Collections.Generic;

namespace GNS.Core.Models
{
    public class Group
    {
        public Guid GroupId { get; set; }

        public Guid LedgerId { get; set; }

        public string Name { get; set; }

        public IEnumerable<Game> Games { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
