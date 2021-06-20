using System;
using System.Collections.Generic;

namespace GNS.Core.Models
{
    public class GameGroup
    {
        //public AspNetUser Ledger { get; set; }

        public IEnumerable<Game> Games { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Player> Players { get; set; }
    }
}
